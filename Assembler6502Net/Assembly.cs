using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assembler6502Net
{
    public static class Assembly
    {
        public static Dictionary<OpCode, Dictionary<AddressingMethod, byte>> OpcodeTable = new Dictionary<OpCode, Dictionary<AddressingMethod, byte>>();

        public static OpCode[] OpCodes = (OpCode[])Enum.GetValues(typeof(OpCode));

        public static OpCode GetOpCode(string str)
        {
            return (OpCode)Enum.Parse(typeof(OpCode), str.ToUpper());
        }

        public static byte[] UshortToLE(ushort data)
        {
            byte[] b = new byte[2];
            b[0] = (byte)data;
            b[1] = (byte)(((uint)data >> 8) & 0xFF);
            return b;
        }

        public static Dictionary<AddressingMethod, ushort> AddressingMethodLength = new Dictionary<AddressingMethod, ushort>();

        static Assembly()
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

        public enum OpCode
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
        public enum AddressingMethod
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
}
