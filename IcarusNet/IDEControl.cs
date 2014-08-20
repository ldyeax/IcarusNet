using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assembler6502Net;

namespace IcarusNet
{
    interface IDEControl
    {
        void Process(AssemblerGroup group);
        int GetOrder();
    }
}
