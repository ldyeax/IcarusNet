using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assembler6502Net
{
    public enum DirectiveType
    {
        @byte,
        word,
        @string
    }

    public class Directive
    {
        public DirectiveType Type;
        public ComputedValueResult ComputedValue = null;

        public string RawArgumentWithoutQuotes = "";

        public byte[] Bytes = null;

        public int LengthInBytes;

        public Directive(string nameWithoutDot, string unquotedArgument)
        {
            this.Type = (DirectiveType)Enum.Parse(typeof(DirectiveType), nameWithoutDot, true);
            RawArgumentWithoutQuotes = unquotedArgument;

            switch (this.Type)
            {
                case DirectiveType.@byte:
                    this.LengthInBytes = 1;
                    break;
                case DirectiveType.word:
                    this.LengthInBytes = 2;
                    break;
                case DirectiveType.@string:
                    this.LengthInBytes = unquotedArgument.Length;
                    this.Bytes = Encoding.ASCII.GetBytes(unquotedArgument);
                    break;
            }
        }

        public void ParseValue()
        {
            
            //get the value out of the string

            if (this.Type == DirectiveType.@string)
                return;

            this.ComputedValue = Assembly.NumeralFromFormattedLiteralString(RawArgumentWithoutQuotes);
        }
    }
}
