using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IcarusNetProject
{
    public static class NES
    {
        public class Header
        {
            static int eightkb = 8192;
            static int sixteenkb = 16384;

            //public bool ContainsNES1A = false;
            public int PRGRomSize;
            public int CHRRomSize;
            public byte Flags6;
            public byte Flags7;
            public int PRGRamSize;
            public byte Flags9;
            public byte Flags10;
            public Header(byte[] bytes)
            {
                //ContainsNES1A = bytes[0] == 0x4e && bytes[1] == 0x45 && bytes[2] == 0x53 && bytes[3] == 0x1a;
                PRGRomSize = sixteenkb * bytes[4];
                CHRRomSize = eightkb * bytes[5];
                Flags6 = bytes[6];
                Flags7 = bytes[7];
                PRGRamSize = eightkb * bytes[8];
                Flags9 = bytes[9];
                Flags10 = bytes[10];
            }
            public byte[] GetBytes()
            {
                return new byte[0x10]
                {
                    0x4E, 0x45, 0x53, 0x1A,
                    (byte)(PRGRomSize/sixteenkb),
                    (byte)(CHRRomSize/eightkb),
                    Flags6,
                    Flags7,
                    (byte)(PRGRamSize/eightkb),
                    Flags9,
                    Flags10,
                    0,0,0,0,0
                };
            }

            public string GetAssemblySource()
            {
                byte[] bytes = GetBytes();
                string nl = Environment.NewLine;

                string ret = "";
                ret += ";iNES Header" + nl;
                ret += nl;

                ret += ".string \"NES\"" + nl;
                ret += ".byte $1A" + nl;
                ret += nl;

                ret += ";Size of PRG ROM in 16 KB units" + nl;
                ret += ".byte $" + bytes[4].ToString("X2") + nl;
                ret += nl;

                ret += ";Size of CHR ROM in 8KB units (Value 0 means the board uses CHR RAM)" + nl;
                ret += ".byte $" + bytes[5].ToString("X2") + nl;
                ret += nl;

                ret += ";Flags 6" + nl;
                ret += ".byte %" + string.Format("{0,8}", Convert.ToString(bytes[6], 2)).Replace(' ','0') + nl;
                ret += nl;

                ret += ";Flags 7" + nl;
                ret += ".byte %" + string.Format("{0,8}", Convert.ToString(bytes[7], 2)).Replace(' ', '0') + nl;
                ret += nl;

                ret += ";Size of PRG RAM in 8 KB units (Value 0 infers 8 KB for compatibility)" + nl;
                ret += ".byte $" + bytes[8].ToString("X2") + nl;
                ret += nl;

                ret += ";Flags 9" + nl;
                ret += ".byte %" + string.Format("{0,8}", Convert.ToString(bytes[9], 2)).Replace(' ', '0') + nl;
                ret += nl;

                ret += ";Flags 10" + nl;
                ret += ".byte %" + string.Format("{0,8}", Convert.ToString(bytes[10], 2)).Replace(' ', '0') + nl;
                ret += nl;

                ret += ";Zero fill" + nl;
                for (int i = 11; i <= 15; ++i)
                {
                    ret += ".byte 0" + nl;
                }

                return ret;
            }
        }
    }
}
