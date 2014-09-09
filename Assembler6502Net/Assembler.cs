using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Assembler6502Net
{

    public class Assembler
    {
        public AssemblerGroup AssemblerGroup = new AssemblerGroup();

        public AssemblerConfig Config = new AssemblerConfig() { OperandLength = AssemblerConfig.OperandLengthOption.AsWritten };
        public byte[] Bytes;
        string text = "";
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                Labels = new Dictionary<string, ushort>();
                Variables = new SortedDictionary<string, string>();
                currentReadingLine = 0;
                didFirstPass = false;
                Lines = null;

                text = value;
            }
        }

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

        private Line[] _lines;
        public Line[] Lines 
        { 
            get 
            { 
                return _lines; 
            } 
            set 
            { 
                _lines = value; 
            } 
        }
        bool didFirstPass = false;
        int currentReadingLine = -1;

        public void FirstPass()
        {
            execWithWrappedException(() => firstPass(Text));
        }

        void firstPass(string text)
        {
            string[] strlines = text.ToUpper().Split('\n');

            Lines = new Line[strlines.Length];

            ushort pc = 0;
            ushort highestPC = 0;

            //First pass resolves variables and sets labels 
            for (currentReadingLine = 0; currentReadingLine < Lines.Length; ++currentReadingLine)
            {
                Lines[currentReadingLine] = new Line(strlines[currentReadingLine], currentReadingLine);
                Line line = Lines[currentReadingLine];

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
                    if (Bytes != null)
                        if (pc > Bytes.Length)
                        {
                            if (!Config.ReallocateIfOutOfBounds)
                                throw new SyntaxErrorException(currentReadingLine, "Out of space on line");
                        }
                }
                else if (line.Directive != null)
                {
                    pc += (ushort)line.Directive.LengthInBytes;
                }

            }

            if (Bytes != null)
                if (highestPC > Bytes.Length)
                {
                    byte[] reallocated = new byte[highestPC];
                    Array.Copy(Bytes, reallocated, Bytes.Length);
                }


            AssemblerGroup.AddLabels(Labels);
            didFirstPass = true;
        }
        /// <summary>
        /// if facade, results are not actually written - useful for preprocessing for errors in a text entry field
        /// </summary>
        /// <param name="facade"></param>
        void secondPass(bool facade = false)
        {
            //Second pass resolves labels and generates machine code
            for (currentReadingLine = 0; currentReadingLine < Lines.Length; ++currentReadingLine)
            {
                Line line = Lines[currentReadingLine];
                ushort pc = line.PC;

                line.ResolveLabelsAndAssembleSecondPass(this, currentReadingLine);

                if (line.ComputedBytes != null)
                {
                    if (!facade)
                    {
                        //this.Bytes[Config.FileStartAddress + pc] = Assembly.OpcodeTable[line.OpCode.Value][line.AddressingMethod.Value];

                        for (int j = 0; j < line.ComputedBytes.Count; ++j)
                        {
                            this.Bytes[pc + Config.FileStartAddress + j] = line.ComputedBytes[j];
                        }
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
             //   act();
             //   return;
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
        /// <summary>
        /// if facade, don't actually write to the output - useful for finding errors in text entry fields
        /// </summary>
        /// <param name="facade"></param>
        public void Assemble(bool facade = false)
        {
            if (!didFirstPass)
                throw new InvalidOperationException("Assemble cannot be called until FirstPass has been called");

            execWithWrappedException(() => secondPass(facade));

        }

    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class SyntaxErrorException : Exception
    {
        public int Line = 0;
        public SyntaxErrorException() : base() { }
        public SyntaxErrorException(string s, Exception ex = null) : base(s, ex) { }
        public SyntaxErrorException(int line, Exception ex = null) : base(ex.Message, ex)
        {
            Line = line;
        }
        public SyntaxErrorException(int line, string str, Exception ex = null)
            : base(str, ex)
        {
            Line = line;
        }

        public override string ToString()
        {
            return "Line " + (Line+1) + ": " + this.Message;
        }
    }


}
