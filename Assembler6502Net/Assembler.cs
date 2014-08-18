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
    }

    public class Assembler
    {


        static Dictionary<OpCode, Dictionary<AddressingMethod, byte>> OpcodeTable = new Dictionary<OpCode, Dictionary<AddressingMethod, byte>>();

        static OpCode[] OpCodes = (OpCode[])Enum.GetValues(typeof(OpCode));

        static OpCode getOpCode(string str)
        {
            return (OpCode)Enum.Parse(typeof(OpCode), str.ToUpper());
        }

        static Dictionary<AddressingMethod, ushort> AddressingMethodLength = new Dictionary<AddressingMethod, ushort>();

        static Assembler()
        {
            foreach (OpCode opcode in OpCodes)
                OpcodeTable[opcode] = new Dictionary<AddressingMethod, byte>();

            #region generated

            AddressingMethodLength[AddressingMethod.absolute] = 2;
            AddressingMethodLength[AddressingMethod.absoluteX] = 2;
            AddressingMethodLength[AddressingMethod.absoluteY] = 2;
            AddressingMethodLength[AddressingMethod.immediate] = 1;
            AddressingMethodLength[AddressingMethod.implied] = 0;
            AddressingMethodLength[AddressingMethod.indirect] = 2;
            AddressingMethodLength[AddressingMethod.indirectX] = 2;
            AddressingMethodLength[AddressingMethod.indirectY] = 2;
            AddressingMethodLength[AddressingMethod.relative] = 1;
            AddressingMethodLength[AddressingMethod.zeropage] = 1;
            AddressingMethodLength[AddressingMethod.zeropageX] = 1;
            AddressingMethodLength[AddressingMethod.zeropageY] = 1;

            OpcodeTable[OpCode.ADC][AddressingMethod.indirectX] = 97;
            OpcodeTable[OpCode.ADC][AddressingMethod.zeropage] = 101;
            OpcodeTable[OpCode.ADC][AddressingMethod.immediate] = 105;
            OpcodeTable[OpCode.ADC][AddressingMethod.absolute] = 109;
            OpcodeTable[OpCode.ADC][AddressingMethod.indirectY] = 113;
            OpcodeTable[OpCode.ADC][AddressingMethod.zeropageX] = 117;
            OpcodeTable[OpCode.ADC][AddressingMethod.absoluteY] = 121;
            OpcodeTable[OpCode.ADC][AddressingMethod.absoluteX] = 125;
            OpcodeTable[OpCode.AND][AddressingMethod.indirectX] = 33;
            OpcodeTable[OpCode.AND][AddressingMethod.zeropage] = 37;
            OpcodeTable[OpCode.AND][AddressingMethod.immediate] = 41;
            OpcodeTable[OpCode.AND][AddressingMethod.absolute] = 45;
            OpcodeTable[OpCode.AND][AddressingMethod.indirectY] = 49;
            OpcodeTable[OpCode.AND][AddressingMethod.zeropageX] = 53;
            OpcodeTable[OpCode.AND][AddressingMethod.absoluteY] = 57;
            OpcodeTable[OpCode.AND][AddressingMethod.absoluteX] = 61;
            OpcodeTable[OpCode.ASL][AddressingMethod.zeropage] = 6;
            OpcodeTable[OpCode.ASL][AddressingMethod.implied] = 10;
            OpcodeTable[OpCode.ASL][AddressingMethod.absolute] = 14;
            OpcodeTable[OpCode.ASL][AddressingMethod.zeropageX] = 22;
            OpcodeTable[OpCode.ASL][AddressingMethod.absoluteX] = 30;
            OpcodeTable[OpCode.BCC][AddressingMethod.relative] = 144;
            OpcodeTable[OpCode.BCS][AddressingMethod.relative] = 176;
            OpcodeTable[OpCode.BEQ][AddressingMethod.relative] = 240;
            OpcodeTable[OpCode.BIT][AddressingMethod.zeropage] = 36;
            OpcodeTable[OpCode.BIT][AddressingMethod.absolute] = 44;
            OpcodeTable[OpCode.BMI][AddressingMethod.relative] = 48;
            OpcodeTable[OpCode.BNE][AddressingMethod.relative] = 208;
            OpcodeTable[OpCode.BPL][AddressingMethod.relative] = 16;
            OpcodeTable[OpCode.BRK][AddressingMethod.implied] = 0;
            OpcodeTable[OpCode.BVC][AddressingMethod.relative] = 80;
            OpcodeTable[OpCode.BVS][AddressingMethod.relative] = 112;
            OpcodeTable[OpCode.CLC][AddressingMethod.implied] = 24;
            OpcodeTable[OpCode.CLD][AddressingMethod.implied] = 216;
            OpcodeTable[OpCode.CLI][AddressingMethod.implied] = 88;
            OpcodeTable[OpCode.CLV][AddressingMethod.implied] = 184;
            OpcodeTable[OpCode.CMP][AddressingMethod.indirectX] = 193;
            OpcodeTable[OpCode.CMP][AddressingMethod.zeropage] = 197;
            OpcodeTable[OpCode.CMP][AddressingMethod.immediate] = 201;
            OpcodeTable[OpCode.CMP][AddressingMethod.absolute] = 205;
            OpcodeTable[OpCode.CMP][AddressingMethod.indirectY] = 209;
            OpcodeTable[OpCode.CMP][AddressingMethod.zeropageX] = 213;
            OpcodeTable[OpCode.CMP][AddressingMethod.absoluteY] = 217;
            OpcodeTable[OpCode.CMP][AddressingMethod.absoluteX] = 221;
            OpcodeTable[OpCode.CPX][AddressingMethod.immediate] = 224;
            OpcodeTable[OpCode.CPX][AddressingMethod.zeropage] = 228;
            OpcodeTable[OpCode.CPX][AddressingMethod.absolute] = 236;
            OpcodeTable[OpCode.CPY][AddressingMethod.immediate] = 192;
            OpcodeTable[OpCode.CPY][AddressingMethod.zeropage] = 196;
            OpcodeTable[OpCode.CPY][AddressingMethod.absolute] = 204;
            OpcodeTable[OpCode.DEC][AddressingMethod.zeropage] = 198;
            OpcodeTable[OpCode.DEC][AddressingMethod.absolute] = 206;
            OpcodeTable[OpCode.DEC][AddressingMethod.zeropageX] = 214;
            OpcodeTable[OpCode.DEC][AddressingMethod.absoluteX] = 222;
            OpcodeTable[OpCode.DEX][AddressingMethod.implied] = 202;
            OpcodeTable[OpCode.DEY][AddressingMethod.implied] = 136;
            OpcodeTable[OpCode.EOR][AddressingMethod.indirectX] = 65;
            OpcodeTable[OpCode.EOR][AddressingMethod.zeropage] = 69;
            OpcodeTable[OpCode.EOR][AddressingMethod.immediate] = 73;
            OpcodeTable[OpCode.EOR][AddressingMethod.absolute] = 77;
            OpcodeTable[OpCode.EOR][AddressingMethod.indirectY] = 81;
            OpcodeTable[OpCode.EOR][AddressingMethod.zeropageX] = 85;
            OpcodeTable[OpCode.EOR][AddressingMethod.absoluteY] = 89;
            OpcodeTable[OpCode.EOR][AddressingMethod.absoluteX] = 93;
            OpcodeTable[OpCode.INC][AddressingMethod.zeropage] = 230;
            OpcodeTable[OpCode.INC][AddressingMethod.absolute] = 238;
            OpcodeTable[OpCode.INC][AddressingMethod.zeropageX] = 246;
            OpcodeTable[OpCode.INC][AddressingMethod.absoluteX] = 254;
            OpcodeTable[OpCode.INX][AddressingMethod.implied] = 232;
            OpcodeTable[OpCode.INY][AddressingMethod.implied] = 200;
            OpcodeTable[OpCode.JMP][AddressingMethod.absolute] = 76;
            OpcodeTable[OpCode.JMP][AddressingMethod.indirect] = 108;
            OpcodeTable[OpCode.JSR][AddressingMethod.absolute] = 32;
            OpcodeTable[OpCode.LDA][AddressingMethod.indirectX] = 161;
            OpcodeTable[OpCode.LDA][AddressingMethod.zeropage] = 165;
            OpcodeTable[OpCode.LDA][AddressingMethod.immediate] = 169;
            OpcodeTable[OpCode.LDA][AddressingMethod.absolute] = 173;
            OpcodeTable[OpCode.LDA][AddressingMethod.indirectY] = 177;
            OpcodeTable[OpCode.LDA][AddressingMethod.zeropageX] = 181;
            OpcodeTable[OpCode.LDA][AddressingMethod.absoluteY] = 185;
            OpcodeTable[OpCode.LDA][AddressingMethod.absoluteX] = 189;
            OpcodeTable[OpCode.LDX][AddressingMethod.immediate] = 162;
            OpcodeTable[OpCode.LDX][AddressingMethod.zeropage] = 166;
            OpcodeTable[OpCode.LDX][AddressingMethod.absolute] = 174;
            OpcodeTable[OpCode.LDX][AddressingMethod.zeropageY] = 182;
            OpcodeTable[OpCode.LDX][AddressingMethod.absoluteY] = 190;
            OpcodeTable[OpCode.LDY][AddressingMethod.immediate] = 160;
            OpcodeTable[OpCode.LDY][AddressingMethod.zeropage] = 164;
            OpcodeTable[OpCode.LDY][AddressingMethod.absolute] = 172;
            OpcodeTable[OpCode.LDY][AddressingMethod.zeropageX] = 180;
            OpcodeTable[OpCode.LDY][AddressingMethod.absoluteX] = 188;
            OpcodeTable[OpCode.LSR][AddressingMethod.zeropage] = 70;
            OpcodeTable[OpCode.LSR][AddressingMethod.implied] = 74;
            OpcodeTable[OpCode.LSR][AddressingMethod.absolute] = 78;
            OpcodeTable[OpCode.LSR][AddressingMethod.zeropageX] = 86;
            OpcodeTable[OpCode.LSR][AddressingMethod.absoluteX] = 94;
            OpcodeTable[OpCode.NOP][AddressingMethod.implied] = 234;
            OpcodeTable[OpCode.ORA][AddressingMethod.indirectX] = 1;
            OpcodeTable[OpCode.ORA][AddressingMethod.zeropage] = 5;
            OpcodeTable[OpCode.ORA][AddressingMethod.immediate] = 9;
            OpcodeTable[OpCode.ORA][AddressingMethod.absolute] = 13;
            OpcodeTable[OpCode.ORA][AddressingMethod.indirectY] = 17;
            OpcodeTable[OpCode.ORA][AddressingMethod.zeropageX] = 21;
            OpcodeTable[OpCode.ORA][AddressingMethod.absoluteY] = 25;
            OpcodeTable[OpCode.ORA][AddressingMethod.absoluteX] = 29;
            OpcodeTable[OpCode.PHA][AddressingMethod.implied] = 72;
            OpcodeTable[OpCode.PHP][AddressingMethod.implied] = 8;
            OpcodeTable[OpCode.PLA][AddressingMethod.implied] = 104;
            OpcodeTable[OpCode.PLP][AddressingMethod.implied] = 40;
            OpcodeTable[OpCode.ROL][AddressingMethod.zeropage] = 38;
            OpcodeTable[OpCode.ROL][AddressingMethod.implied] = 42;
            OpcodeTable[OpCode.ROL][AddressingMethod.absolute] = 46;
            OpcodeTable[OpCode.ROL][AddressingMethod.zeropageX] = 54;
            OpcodeTable[OpCode.ROL][AddressingMethod.absoluteX] = 62;
            OpcodeTable[OpCode.ROR][AddressingMethod.zeropage] = 102;
            OpcodeTable[OpCode.ROR][AddressingMethod.implied] = 106;
            OpcodeTable[OpCode.ROR][AddressingMethod.absolute] = 110;
            OpcodeTable[OpCode.ROR][AddressingMethod.zeropageX] = 118;
            OpcodeTable[OpCode.ROR][AddressingMethod.absoluteX] = 126;
            OpcodeTable[OpCode.RTI][AddressingMethod.implied] = 64;
            OpcodeTable[OpCode.RTS][AddressingMethod.implied] = 96;
            OpcodeTable[OpCode.SBC][AddressingMethod.indirectX] = 225;
            OpcodeTable[OpCode.SBC][AddressingMethod.zeropage] = 229;
            OpcodeTable[OpCode.SBC][AddressingMethod.immediate] = 233;
            OpcodeTable[OpCode.SBC][AddressingMethod.absolute] = 237;
            OpcodeTable[OpCode.SBC][AddressingMethod.indirectY] = 241;
            OpcodeTable[OpCode.SBC][AddressingMethod.zeropageX] = 245;
            OpcodeTable[OpCode.SBC][AddressingMethod.absoluteY] = 249;
            OpcodeTable[OpCode.SBC][AddressingMethod.absoluteX] = 253;
            OpcodeTable[OpCode.SEC][AddressingMethod.implied] = 56;
            OpcodeTable[OpCode.SED][AddressingMethod.implied] = 248;
            OpcodeTable[OpCode.SEI][AddressingMethod.implied] = 120;
            OpcodeTable[OpCode.STA][AddressingMethod.indirectX] = 129;
            OpcodeTable[OpCode.STA][AddressingMethod.zeropage] = 133;
            OpcodeTable[OpCode.STA][AddressingMethod.absolute] = 141;
            OpcodeTable[OpCode.STA][AddressingMethod.indirectY] = 145;
            OpcodeTable[OpCode.STA][AddressingMethod.zeropageX] = 149;
            OpcodeTable[OpCode.STA][AddressingMethod.absoluteY] = 153;
            OpcodeTable[OpCode.STA][AddressingMethod.absoluteX] = 157;
            OpcodeTable[OpCode.STX][AddressingMethod.zeropage] = 134;
            OpcodeTable[OpCode.STX][AddressingMethod.absolute] = 142;
            OpcodeTable[OpCode.STX][AddressingMethod.zeropageY] = 150;
            OpcodeTable[OpCode.STY][AddressingMethod.zeropage] = 132;
            OpcodeTable[OpCode.STY][AddressingMethod.absolute] = 140;
            OpcodeTable[OpCode.STY][AddressingMethod.zeropageX] = 148;
            OpcodeTable[OpCode.TAX][AddressingMethod.implied] = 170;
            OpcodeTable[OpCode.TAY][AddressingMethod.implied] = 168;
            OpcodeTable[OpCode.TSX][AddressingMethod.implied] = 186;
            OpcodeTable[OpCode.TXA][AddressingMethod.implied] = 138;
            OpcodeTable[OpCode.TXS][AddressingMethod.implied] = 154;
            OpcodeTable[OpCode.TYA][AddressingMethod.implied] = 152;
            #endregion
        }

        public AssemblerConfig Config = new AssemblerConfig() { OperandLength = AssemblerConfig.OperandLengthOption.AsWritten };

        public Assembler() { }
        public Assembler(AssemblerConfig config)
        {
            this.Config = config;
        }

        public SortedDictionary<string, ushort> Labels = new SortedDictionary<string, ushort>();

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


        public byte[] Assemble(string text)
        {
            string[] strlines = text.ToUpper().Split('\n');
            List<byte> ret = new List<byte>();

            Line[] lines = new Line[strlines.Length];
            
            ushort pc = 0;

            //First pass resolves variables and sets labels 
            for (int i = 0; i < lines.Length; ++i)
            {
                try
                {
                    lines[i] = new Line(strlines[i], i);
                    Line line = lines[i];

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
                                throw new SyntaxErrorException(i);
                            }
                        }
                        else
                        {
                            Variables[variable.Key] = variable.Value;
                        }
                    }
                    else
                    {
                        line.SetVariablesAndFindFirstPassAddressingMethods(this);

                        if (line.OpCode != null)
                        {
                            pc++;
                            pc += AddressingMethodLength[line.AddressingMethod.Value];
                        }
                    }

                }
                catch (Exception)
                {
                    throw new SyntaxErrorException(i);
                }

            }

            //Second pass resolves labels and generates machine code
            for (int i = 0; i < lines.Length; ++i)
            {
                try
                {
                    Line line = lines[i];
                    pc = line.PC;

                    if (line.OpCode != null)
                    {
                        line.DetermineLabelsAndSecondPassAddressingMethod(this, i);

                        ret.Add(OpcodeTable[line.OpCode.Value][line.AddressingMethod.Value]);

                        switch (AddressingMethodLength[line.AddressingMethod.Value])
                        {
                            case 0:
                                break;
                            case 1:
                                {
                                    ret.Add((byte)line.RValue.ComputedValue.Result);
                                }
                                break;
                            case 2:
                                {
                                    var le = ushortToLE(line.RValue.ComputedValue.Result);
                                    ret.Add(le[0]);
                                    ret.Add(le[1]);
                                }
                                break;
                        }


                    }
                }
                catch (Exception)
                {
                    throw new SyntaxErrorException(i);
                }

            }

            return ret.ToArray();
        }

        class RValue
        {
            public class ComputedValueResult
            {
                public string ValueString = null;
                public ushort Result;
                public int Base = -1;
                public bool Literal;
                public bool Finished = false;
            }

            /// <summary>
            /// whitespace already removed
            /// </summary>
            public string RawString = null;
            public ComputedValueResult ComputedValue = null;

            public string ValueLeft = "";
            public string ValueMiddle = "";
            public string ValueRight = "";

            public static class LineEnding
            {
                public const string CommaXParen = ",X)";
                public const string ParenCommaY = "),Y";
                public const string Paren = ")";
                public const string CommaX = ",X";
                public const string CommaY = ",Y";
            }

            public static Dictionary<string, AddressingMethod[]> LineEndingToOptions = new Dictionary<string, AddressingMethod[]>()
            {
                {LineEnding.CommaXParen, new AddressingMethod[]{ AddressingMethod.indirectX }},
                {LineEnding.ParenCommaY, new AddressingMethod[]{ AddressingMethod.indirectY }},
                {LineEnding.Paren, new AddressingMethod[]{ AddressingMethod.indirect }},
                {LineEnding.CommaX, new AddressingMethod[]{ AddressingMethod.absoluteX, AddressingMethod.zeropageX }},
                {LineEnding.CommaY, new AddressingMethod[]{ AddressingMethod.absoluteY, AddressingMethod.zeropageY }},
                {"", new AddressingMethod[]
                    { 
                        AddressingMethod.absolute, 
                        AddressingMethod.immediate, 
                        AddressingMethod.relative, 
                        AddressingMethod.zeropage
                    }
                }
            };

            static string[] partone = { LineEnding.CommaXParen, LineEnding.ParenCommaY, LineEnding.Paren };
            static string[] parttwo = { LineEnding.CommaX, LineEnding.CommaY };

            static Dictionary<char, int> BaseIdentifiers = new Dictionary<char, int>()
            {
                {'$', 16},
                {'%', 2},
                {'0', 8}
            };

            static OpCode[] labelUsers = { 
                OpCode.JMP, 
                OpCode.JSR, 

                OpCode.BCC, 
                OpCode.BCS, 
                OpCode.BEQ,
                OpCode.BMI,
                OpCode.BNE,
                OpCode.BPL,
                OpCode.BVC,
                OpCode.BVS
            };

            int getNumeral()
            {
                return Convert.ToInt32(
                    ComputedValue.ValueString,
                    ComputedValue.Base
                );
            }

            /// <summary>
            /// only for instructions that don't use labels or from within other setValue()
            /// </summary>
            void setValue(int nval)
            {
                if (nval < 0)
                {
                    if (nval < sbyte.MinValue)
                        throw new SyntaxErrorException();
                    nval *= -1;
                    nval = ((byte)nval) ^ byte.MaxValue;
                    nval++;
                }

                ComputedValue.Result = (ushort)nval;
                return;
            }

            /// <summary>
            /// only for instructions that use labels
            /// </summary>
            /// <param name="addressingMethod"></param>
            /// <param name="pc"></param>
            void setValue(AddressingMethod addressingMethod, ushort pc)
            {
                int nval = getNumeral();

                if (addressingMethod == AddressingMethod.relative)
                    nval -= (short)pc;

                if (nval < 0)
                {
                    if (nval < sbyte.MinValue)
                        throw new SyntaxErrorException();
                    nval *= -1;
                    nval = ((byte)nval) ^ byte.MaxValue;
                    
                    nval++;
                }

                setValue(nval);
                return;
            }

            void parseValue()
            {
                ComputedValue = new ComputedValueResult();

                ComputedValue.Literal = ValueMiddle.StartsWith("#");

                foreach (char identifier in BaseIdentifiers.Keys)
                {
                    //Console.WriteLine(identifier.ToString());
                    bool check = ValueMiddle[0] == identifier;
                    if (ValueMiddle.Length > 1)
                        check = check || ValueMiddle[1] == identifier;

                    if (check)
                    {
                        ComputedValue.ValueString = ValueMiddle.Split(identifier)[1];

                        if (identifier == '0' && ComputedValue.ValueString.Length == 0)
                        {
                            ComputedValue.ValueString = "0";
                            ComputedValue.Base = 10;

                            return;
                        }

                        ComputedValue.Base = BaseIdentifiers[identifier];

                        return;
                    }
                }

                ComputedValue.ValueString = ValueMiddle;
                ComputedValue.Base = 10;

                return;
            }

            /// <summary>
            /// Populate the ComputedValue object with the results determined from the earlier-set ValueLeft, ValueMiddle, ValueRight, and OpCode
            /// For use on the first pass for opcodes that do not accept a label
            /// </summary>
            /// <param name="opcode"></param>
            public void ParseValue(OpCode opcode)
            {
                if (labelUsers.Contains(opcode))
                    return;

                parseValue();
                //something has gone wrong 
                setValue(getNumeral());
            }

            /// <summary>
            /// Populate the ComputedValue object with the results determined from the earlier-set ValueLeft, ValueMiddle, ValueRight, and OpCode
            /// For use on the second pass for opcodes that use a label
            /// </summary>
            /// <param name="opcode"></param>
            /// <param name="addressingMethod"></param>
            /// <param name="pc"></param>
            public void ParseValue(OpCode opcode, AddressingMethod addressingMethod, ushort pc)
            {
                if (!(labelUsers.Contains(opcode)))
                    return;

                parseValue();

                setValue(addressingMethod, pc);

                return;
            }

            public RValue(string str)
            {
                RawString = str;

                if (RawString.StartsWith("("))
                {
                    ValueLeft = "(";
                    foreach (string part in partone)
                    {
                        if (RawString.EndsWith(part))
                        {
                            ValueRight = part;
                            ValueMiddle = RawString.Substring(1, ValueMiddle.Length - 1 - ValueRight.Length);
                            return;
                        }
                    }
                }

                foreach (var part in parttwo)
                {
                    if (RawString.EndsWith(part))
                    {
                        ValueRight = part;
                        ValueMiddle = RawString.Substring(0, RawString.Length - ValueRight.Length);
                        return;
                    }
                }

                ValueMiddle = RawString;
                return;
            }
        }

        class Line
        {
            static string formatLine(string line)
            {
                return line.Replace('\t', ' ').Trim().Split(';')[0];
            }

            //static ushort getNumb

            const string alphabet = "qwertuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            const string numerals = "1234567890";
            const string hexchars = "abcdefABCDEF1234567890";

            public string Label = null;
            public OpCode? OpCode = null;
            public AddressingMethod? AddressingMethod = null;
            public RValue RValue = null;
            public KeyValuePair<string, string>? VariableAssignment = null;
            public ushort PC;

            public Line() { }

            public Line(string s, int lineno)
            {
                string line = formatLine(s);
                if (line.Length == 0)
                    return;

                if (line.Contains(':'))
                {
                    string[] bycolon = line.Split(':');
                    Label = bycolon[0];
                    if (bycolon.Length > 1)
                        line = formatLine(bycolon[1]);
                    else
                        line = "";
                }

                if (line.Length == 0)
                    return;

                if (line.Contains('='))
                {
                    string[] byequals = (from str in line.Split('=') select formatLine(str)).ToArray();
                    if (byequals.Length != 2)
                        throw new SyntaxErrorException(lineno);
                    string lvalue = byequals.First();
                    string rvalue = byequals.Last();
                    if (lvalue.Length == 0)
                        throw new SyntaxErrorException(lineno);


                    if (lvalue != "*")
                    {
                        if (!alphabet.Contains(lvalue[0]))
                            throw new SyntaxErrorException(lineno);
                        foreach (char c in lvalue)
                        {
                            if (!alphabet.Contains(c) && !numerals.Contains(c))
                                throw new SyntaxErrorException(lineno);
                        }
                    }


                    VariableAssignment = new KeyValuePair<string, string>(lvalue, rvalue);
                    return;
                }
                if (line.Length < 3)
                    throw new SyntaxErrorException(lineno);

                string opcode = line.Substring(0, 3);
                try
                {
                    this.OpCode = (OpCode)Enum.Parse(typeof(OpCode), opcode, true);
                }
                catch (ArgumentException)
                {
                    throw new SyntaxErrorException(lineno);
                }

                List<string> byspace = line.Split(' ').ToList();

                byspace.RemoveAt(0);

                if (byspace.Count == 0)
                    return;

                this.RValue = new RValue(formatLine(string.Join("", byspace.ToArray())));

                return;
            }

            /// <summary>
            /// only call if it's a statement
            /// </summary>
            /// <param name="assembler"></param>
            public void SetVariablesAndFindFirstPassAddressingMethods(Assembler assembler)
            {
                if (this.RValue == null)
                {
                    this.AddressingMethod = Assembler6502Net.AddressingMethod.implied;
                    return;
                }

                //branches and jumps can use variables, not just labels
                //so those have to be checked for here because it will later be assumed that the variables were already filled in
                foreach (var varname in assembler.Variables.Keys)
                {
                    if (RValue.ValueMiddle == varname)
                    {
                        RValue.ValueMiddle = assembler.Variables[varname];
                        break;
                    }
                }

                //will include branches, jmp, implied, accumulator (shown as implied 
                if (OpcodeTable[OpCode.Value].Keys.Count == 1)
                {
                    AddressingMethod = OpcodeTable[OpCode.Value].Keys.First();
                    return;
                }

                //branches and jumps were already detected before this point
                this.RValue.ParseValue(this.OpCode.Value);

                var result = this.RValue.ComputedValue;

                var choices =
                    RValue.LineEndingToOptions[this.RValue.ValueRight].Where(
                        choice => OpcodeTable[this.OpCode.Value].Keys.Contains(choice)
                    ).ToList();

                if (choices.Count == 0)
                    throw new SyntaxErrorException();

                if (choices.Count == 1)
                {
                    this.AddressingMethod = choices.First();
                    return;
                }

                if (result.Literal)
                {
                    this.AddressingMethod = Assembler6502Net.AddressingMethod.immediate;
                    return;
                }

                choices.Remove(Assembler6502Net.AddressingMethod.immediate);

                if (choices.Count == 0)
                    throw new SyntaxErrorException();

                if (choices.Count == 1)
                {
                    this.AddressingMethod = choices.First();
                    return;
                }

                AddressingMethod lo = choices.Where(choice => AddressingMethodLength[choice] == 1).First();
                AddressingMethod hi = choices.Where(choice => AddressingMethodLength[choice] == 2).First();

                switch (assembler.Config.OperandLength)
                {
                    case AssemblerConfig.OperandLengthOption.Longest:
                        this.AddressingMethod = hi;
                        return;
                    case AssemblerConfig.OperandLengthOption.Smallest:
                        if (result.Result > byte.MaxValue)
                        {
                            this.AddressingMethod = hi;
                            return;
                        }

                        this.AddressingMethod = lo;
                        return;
                    case AssemblerConfig.OperandLengthOption.AsWritten:
                        //Only works in binary and hex because they're the ones where one extra digit is the point where it goes from one byte to two
                        if (result.Base == 2 || result.Base == 16)
                        {
                            //maximum characters before there are more characters than necessary to represent 256
                            int bumpLimit = result.Base == 2 ? 8 : 2;

                            if (result.ValueString.Length > bumpLimit)
                            {
                                this.AddressingMethod = hi;
                                return;
                            }

                            this.AddressingMethod = lo;
                            return;
                        }

                        if (result.Result > byte.MaxValue)
                        {
                            this.AddressingMethod = hi;
                            return;
                        }
                        this.AddressingMethod = lo;
                        return;
                }

                throw new SyntaxErrorException();
            }

            /// <summary>
            /// called on second pass once labels have already been initialized
            /// </summary>
            /// <param name="assembler"></param>
            public void DetermineLabelsAndSecondPassAddressingMethod(Assembler assembler, int lineno)
            {
                //no work to do
                if (this.AddressingMethod.Value == Assembler6502Net.AddressingMethod.implied)
                    return;

                foreach (var label in assembler.Labels.Keys)
                {
                    if (RValue.ValueMiddle == label)
                    {
                        RValue.ValueMiddle = "$" + Convert.ToString(assembler.Labels[label], 16);
                        break;
                    }
                }

                this.RValue.ParseValue(this.OpCode.Value, this.AddressingMethod.Value, PC);

                //Label searching and value setting done - now only concerned with determining the addressing method

                if (this.AddressingMethod != null)
                    //The label replacement has been finished by now, and jmps and branches are finished
                    return;


            }
        }
    }


    public class SyntaxErrorException : Exception
    {
        public int Line = 0;
        public SyntaxErrorException() : base() { }
        public SyntaxErrorException(string s) : base(s) { }
        public SyntaxErrorException(int line)
            : base("Syntax error at line " + line)
        {
            Line = line;
        }
    }

    enum OpCode
    {
        ADC,
        AND,
        ASL,
        BCC,
        BCS,
        BEQ,
        BIT,
        BMI,
        BNE,
        BPL,
        BRK,
        BVC,
        BVS,
        CLC,
        CLD,
        CLI,
        CLV,
        CMP,
        CPX,
        CPY,
        DEC,
        DEX,
        DEY,
        EOR,
        INC,
        INX,
        INY,
        JMP,
        JSR,
        LDA,
        LDX,
        LDY,
        LSR,
        NOP,
        ORA,
        PHA,
        PHP,
        PLA,
        PLP,
        ROL,
        ROR,
        RTI,
        RTS,
        SBC,
        SEC,
        SED,
        SEI,
        STA,
        STX,
        STY,
        TAX,
        TAY,
        TSX,
        TXA,
        TXS,
        TYA
    }
    enum AddressingMethod
    {
        absolute,
        absoluteX,
        absoluteY,
        immediate,
        implied,
        indirect,
        indirectX,
        indirectY,
        relative,
        zeropage,
        zeropageX,
        zeropageY
    }
}
