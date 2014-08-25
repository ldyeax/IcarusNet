using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IcarusNetProject.Components
{
    public class IPSPatcher : FileComponent
    {

        public static void Patch(Byte[] bytes, string patchfp)
        {
            // Modified from http://www.smwiki.net/wiki/IPS_patching_code

            MemoryStream romstream = new MemoryStream(bytes, true);
            FileStream ipsstream = new FileStream(patchfp, FileMode.Open, FileAccess.Read, FileShare.Read);
            int lint = (int)ipsstream.Length;
            byte[] ipsbyte = new byte[ipsstream.Length];
            byte[] rombyte = new byte[romstream.Length];
            IAsyncResult romresult;
            IAsyncResult ipsresult = ipsstream.BeginRead(ipsbyte, 0, lint, null, null);
            ipsstream.EndRead(ipsresult);
            int ipson = 5;
            int totalrepeats = 0;
            int offset = 0;
            bool keepgoing = true;
            while (keepgoing == true)
            {
                offset = ipsbyte[ipson] * 0x10000 + ipsbyte[ipson + 1] * 0x100 + ipsbyte[ipson + 2];
                ipson++;
                ipson++;
                ipson++;
                if (ipsbyte[ipson] * 256 + ipsbyte[ipson + 1] == 0)
                {
                    ipson++;
                    ipson++;
                    totalrepeats = ipsbyte[ipson] * 256 + ipsbyte[ipson + 1];
                    ipson++;
                    ipson++;
                    byte[] repeatbyte = new byte[totalrepeats];
                    for (int ontime = 0; ontime < totalrepeats; ontime++)
                        repeatbyte[ontime] = ipsbyte[ipson];
                    romstream.Seek(offset, SeekOrigin.Begin);
                    romresult = romstream.BeginWrite(repeatbyte, 0, totalrepeats, null, null);
                    romstream.EndWrite(romresult);
                    ipson++;
                }
                else
                {
                    totalrepeats = ipsbyte[ipson] * 256 + ipsbyte[ipson + 1];
                    ipson++;
                    ipson++;
                    romstream.Seek(offset, SeekOrigin.Begin);
                    romresult = romstream.BeginWrite(ipsbyte, ipson, totalrepeats, null, null);
                    romstream.EndWrite(romresult);
                    ipson = ipson + totalrepeats;
                }
                if (ipsbyte[ipson] == 69 && ipsbyte[ipson + 1] == 79 && ipsbyte[ipson + 2] == 70)
                    keepgoing = false;
            }
            romstream.Close();
            ipsstream.Close();
        }

        #region overrides

        public override void Initialize(Project project)
        {
            
        }

        public override void PreBuild(Project project)
        {
            
        }

        public override void Build(Project project)
        {
            Patch(project.Bytes, this.FilePath);
        }


        public override void SaveFile()
        {
            throw new InvalidOperationException("Cannot save an IPSPatcher");
        }

        #endregion
    }
}
