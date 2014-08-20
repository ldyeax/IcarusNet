using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Assembler6502Net
{
    public class AssemblerConfig
    {
        public enum OperandLengthOption
        {
            Smallest,
            Longest,
            AsWritten
        }
        public OperandLengthOption OperandLength = OperandLengthOption.AsWritten;
        public bool ReallocateIfOutOfBounds = false;
    }

    public class Assembler
    {
        public AssemblerGroup AssemblerGroup = new AssemblerGroup();

        public AssemblerConfig Config = new AssemblerConfig() { OperandLength = AssemblerConfig.OperandLengthOption.AsWritten };
        public byte[] Bytes;
        public string Text = "";

        public Assembler(ref byte[] bytes, AssemblerConfig config)
        {
            this.Config = config;
            this.Bytes = bytes;
        }

        public Assembler(AssemblerConfig config)
        {
            this.Config = config;
        }

        public Assembler() { }

        public Dictionary<string, ushort> Labels = new Dictionary<string, ushort>();

        //public SortedDictionary<string, string> vars2 = new SortedDictionary<string,string>(new Comparer<string>
        /// <summary>
        /// Orders by length, longest to shortest
        /// </summary>
        class VariableComperer : IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return b.Length - a.Length;
            }
        }

        /// <summary>
        /// Variables are ordered by length so that the first variable replacement found on a string is not a variable whose name is a substring of another variable e.g. with variables HELLO = #$04 and LO = $1000 it is not desired for the replacement to result in HEL$1000.
        /// </summary>
        public SortedDictionary<string, string> Variables = new SortedDictionary<string, string>(new VariableComperer());

        static byte[] ushortToLE(ushort data)
        {
            byte[] b = new byte[2];
            b[0] = (byte)data;
            b[1] = (byte)(((uint)data >> 8) & 0xFF);
            return b;
        }

        Line[] lines;
        bool didFirstPass = false;
        int currentReadingLine = -1;

        public void FirstPass()
        {
            execWithWrappedException(() => firstPass(Text));
        }

        void firstPass(string text)
        {
            string[] strlines = text.ToUpper().Split('\n');

            lines = new Line[strlines.Length];

            ushort pc = 0;
            ushort highestPC = 0;

            //First pass resolves variables and sets labels 
            for (currentReadingLine = 0; currentReadingLine < lines.Length; ++currentReadingLine)
            {
                lines[currentReadingLine] = new Line(strlines[currentReadingLine], currentReadingLine);
                Line line = lines[currentReadingLine];

                line.PC = pc;

                if (line.Label != null)
                {
                    Labels[line.Label] = pc;
                }

                if (line.VariableAssignment != null)
                {
                    var variable = line.VariableAssignment.Value;
                    if (variable.Key == "*")
                    {
                        try
                        {
                            pc = Convert.ToUInt16(variable.Value.Substring(1, variable.Value.Length - 1), 16);
                        }
                        catch (FormatException)
                        {
                            throw new SyntaxErrorException(currentReadingLine, "Invalid address literal");
                        }
                    }
                    else
                    {
                        Variables[variable.Key] = variable.Value;
                    }
                }
                else if (line.OpCode != null)
                {
                    if (!line.ResolveVariables(this.Variables) && this.AssemblerGroup != null)
                    {
                        //globals
                        line.ResolveVariables(AssemblerGroup.Variables);
                    }

                    line.DetermineAddressingMethod(Config);

                    pc++;
                    pc += Assembly.AddressingMethodLength[line.AddressingMethod.Value];

                    if (pc > highestPC)
                        highestPC = pc;

                    if (pc > Bytes.Length)
                    {
                        if (!Config.ReallocateIfOutOfBounds)
                            throw new SyntaxErrorException(currentReadingLine, "Out of space on line");
                    }
                }

            }

            if (highestPC > Bytes.Length)
            {
                byte[] reallocated = new byte[highestPC];
                Array.Copy(Bytes, reallocated, Bytes.Length);
            }

            didFirstPass = true;
        }

        void secondPass()
        {
            //Second pass resolves labels and generates machine code
            for (currentReadingLine = 0; currentReadingLine < lines.Length; ++currentReadingLine)
            {
                Line line = lines[currentReadingLine];
                ushort pc = line.PC;

                if (line.OpCode != null)
                {
                    line.ResolveLabelsAndAssembleSecondPass(this, currentReadingLine);

                    this.Bytes[pc] = Assembly.OpcodeTable[line.OpCode.Value][line.AddressingMethod.Value];

                    switch (Assembly.AddressingMethodLength[line.AddressingMethod.Value])
                    {
                        case 0:
                            break;
                        case 1:
                            {
                                this.Bytes[pc + 1] = (byte)line.RValue.ComputedValue.Result;
                            }
                            break;
                        case 2:
                            {
                                var le = ushortToLE(line.RValue.ComputedValue.Result);
                                this.Bytes[pc + 1] = le[0];
                                this.Bytes[pc + 2] = le[1];
                            }
                            break;
                    }
                }
            }

            return;
        }

        void execWithWrappedException(Action act)
        {

            //If debugging, let the debugger catch it
            if (System.Diagnostics.Debugger.IsAttached)
            {
                act();
                return;
            }

            try
            {
                act();
            }
            catch (Exception ex)
            {
                if (ex is SyntaxErrorException)
                {
                    var s = (SyntaxErrorException)ex;
                    s.Line = currentReadingLine;
                    throw s;
                }
                else
                    throw new SyntaxErrorException(currentReadingLine, ex);
            }
        }

        public void Assemble()
        {
            if (!didFirstPass)
                throw new InvalidOperationException("Assemble cannot be called until FirstPass has been called");

            execWithWrappedException(secondPass);

        }

    }


    public class SyntaxErrorException : Exception
    {
        public int Line = 0;
        public SyntaxErrorException() : base() { }
        public SyntaxErrorException(string s, Exception ex = null) : base(s, ex) { }
        public SyntaxErrorException(int line, Exception ex = null) : base("Unspecified", ex)
        {
            Line = line;
        }
        public SyntaxErrorException(int line, string str, Exception ex = null)
            : base(str, ex)
        {
            Line = line;
        }

    }


}
