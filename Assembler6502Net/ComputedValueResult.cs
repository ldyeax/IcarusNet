using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assembler6502Net
{
    public class ComputedValueResult
    {
        /// <summary>
        /// Only the part that can be given to Convert.ToInt32
        /// </summary>
        public string ValueString = null;
        public ushort Result;
        public int Base = -1;
        public bool Literal;
        public bool Finished = false;
        public bool MakeNegative = false;

        public int GetNumeral()
        {
            var ComputedValue = this;
            try
            {
                int ret = Convert.ToInt32(
                    ComputedValue.ValueString,
                    ComputedValue.Base
                );
                if (ComputedValue.MakeNegative)
                    ret *= -1;
                //throw new Exception("Got the number: " + ComputedValue.ValueString);
                return ret;
            }
            catch (FormatException ex)
            {
                throw new FormatException("Error parsing '" + ComputedValue.ValueString + "' in base " + ComputedValue.Base + ": " + ex.Message, ex);
            }

        }
    }

}
