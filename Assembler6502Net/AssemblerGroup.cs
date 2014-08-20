using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assembler6502Net
{
    public class AssemblerGroup
    {
        public AssemblerGroup() { }
        public AssemblerGroup(byte[] bytes)
        {
            this.Bytes = bytes;
        }

        List<Assembler> assemblers = new List<Assembler>();

        public void Add(Assembler assembler)
        {
            assemblers.Add(assembler);
            assembler.AssemblerGroup = this;
        }
        public void Remove(Assembler assembler)
        {
            assemblers.Remove(assembler);
            assembler.AssemblerGroup = new AssemblerGroup();
        }

        public byte[] Bytes;
        public Dictionary<string, ushort> Labels = new Dictionary<string, ushort>();
        public Dictionary<string, string> Variables = new Dictionary<string, string>();

        public void Assemble()
        {
            List<string> bannedLabels = new List<string>();
            //First pass
            foreach (Assembler assembler in assemblers)
            {
                assembler.Bytes = this.Bytes;
                assembler.FirstPass();
                foreach (var pair in assembler.Labels)
                {
                    if (bannedLabels.Contains(pair.Key))
                        continue;

                    if (Labels.Keys.Contains(pair.Key))
                    {
                        bannedLabels.Add(pair.Key);
                        Labels.Remove(pair.Key);
                        continue;
                    }

                    Labels.Add(pair.Key, pair.Value);
                }
            }

            //Second pass
            foreach (Assembler assembler in assemblers)
            {
                assembler.Assemble();
            }

            OnAssembleFinished();
        }

        public Action OnAssembleFinished = () => { };

    }
}
