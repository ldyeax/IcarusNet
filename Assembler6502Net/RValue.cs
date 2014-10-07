using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assembler6502Net
{
    public class RValue
    {

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

        public static Dictionary<string, Assembly.AddressingMethod[]> LineEndingToOptions = new Dictionary<string, Assembly.AddressingMethod[]>()
            {
                {LineEnding.CommaXParen, new Assembly.AddressingMethod[]{ Assembly.AddressingMethod.indirectX }},
                {LineEnding.ParenCommaY, new Assembly.AddressingMethod[]{ Assembly.AddressingMethod.indirectY }},
                {LineEnding.Paren, new Assembly.AddressingMethod[]{ Assembly.AddressingMethod.indirect }},
                {LineEnding.CommaX, new Assembly.AddressingMethod[]{ Assembly.AddressingMethod.absoluteX, Assembly.AddressingMethod.zeropageX }},
                {LineEnding.CommaY, new Assembly.AddressingMethod[]{ Assembly.AddressingMethod.absoluteY, Assembly.AddressingMethod.zeropageY }},
                {"", new Assembly.AddressingMethod[]
                    { 
                        Assembly.AddressingMethod.absolute, 
                        Assembly.AddressingMethod.immediate, 
                        Assembly.AddressingMethod.relative, 
                        Assembly.AddressingMethod.zeropage
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

        static Assembly.OpCode[] labelUsers = { 
                Assembly.OpCode.JMP, 
                Assembly.OpCode.JSR, 
                Assembly.OpCode.BCC, 
                Assembly.OpCode.BCS, 
                Assembly.OpCode.BEQ,
                Assembly.OpCode.BMI,
                Assembly.OpCode.BNE,
                Assembly.OpCode.BPL,
                Assembly.OpCode.BVC,
                Assembly.OpCode.BVS
            };



        /// <summary>
        /// only for instructions that don't use labels or from within other setValue()
        /// </summary>
        void setValue(int nval)
        {
            if (nval < 0)
            {
                nval = Assembly.TwosComplement8bit(nval);
            }

            if (nval > ushort.MaxValue)
            {
                throw new SyntaxErrorException("Value out of range");
            }

            ComputedValue.Result = (ushort)nval;
            return;
        }

        /// <summary>
        /// only for instructions that use labels
        /// </summary>
        /// <param name="Assembly.AddressingMethod"></param>
        /// <param name="pc"></param>
        void setValue(Assembly.AddressingMethod AddressingMethod, ushort pc)
        {
            int nval = 0;
            try
            {
                nval = ComputedValue.GetNumeral();
            }
            catch (FormatException ex)
            {
                throw new SyntaxErrorException("Invalid label or literal", ex);
            }

            if (AddressingMethod == Assembly.AddressingMethod.relative)
                nval -= (short)pc;

            if (nval < 0)
            {
                nval = Assembly.TwosComplement8bit(nval);
            }

            if (nval > ushort.MaxValue)
            {
                throw new SyntaxErrorException("Value out of range");
            }

            setValue(nval);
            return;
        }

        void parseValue()
        {
            ComputedValue = new ComputedValueResult();

            ComputedValue.Literal = ValueMiddle.StartsWith("#");

            bool found = false;

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

                        found = true;
                        break;
                    }

                    ComputedValue.Base = BaseIdentifiers[identifier];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                ComputedValue.ValueString = ValueMiddle;
                if (ComputedValue.Literal)
                {
                    ComputedValue.ValueString = ComputedValue.ValueString.Substring(1, ComputedValue.ValueString.Length - 1);
                }
                ComputedValue.Base = 10;
            }

            //if (ComputedValue.Literal)
            //    ComputedValue.ValueString = ComputedValue.ValueString.Substring(1, ComputedValue.ValueString.Length - 1);

            if (ComputedValue.ValueString.StartsWith("-"))
            {
                ComputedValue.ValueString = ComputedValue.ValueString.Substring(1, ComputedValue.ValueString.Length - 1);
                ComputedValue.MakeNegative = true;
            }

            return;
        }

        /// <summary>
        /// Populate the ComputedValue object with the results determined from the earlier-set ValueLeft, ValueMiddle, ValueRight, and OpCode
        /// For use on the first pass for opcodes that do not accept a label
        /// </summary>
        /// <param name="opcode"></param>
        public void ParseValue(Assembly.OpCode opcode)
        {
            if (labelUsers.Contains(opcode))
                return;

            parseValue();
            setValue(ComputedValue.GetNumeral());
        }

        /// <summary>
        /// Populate the ComputedValue object with the results determined from the earlier-set ValueLeft, ValueMiddle, ValueRight, and OpCode
        /// For use on the second pass for opcodes that use a label
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="Assembly.AddressingMethod"></param>
        /// <param name="pc"></param>
        public void ParseValue(Assembly.OpCode opcode, Assembly.AddressingMethod AddressingMethod, ushort pc)
        {
            if (!(labelUsers.Contains(opcode)))
                return;

            parseValue();

            setValue(AddressingMethod, pc);

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
                        // ValueMiddle = RawString.Substring(1, ValueMiddle.Length - 1 - ValueRight.Length);
                        ValueMiddle = RawString.Substring(1, RawString.Length - 1 - ValueRight.Length);
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

}
