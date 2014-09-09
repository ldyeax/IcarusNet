using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public uint FileStartAddress = 0;
    }

}
