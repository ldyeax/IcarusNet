using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Assembler6502Net;
using Newtonsoft.Json;

namespace IcarusNetProject.Components
{
    public class AssemblyEditor : FileComponent
    {
        public AssemblerConfig Config = new AssemblerConfig() { OperandLength = AssemblerConfig.OperandLengthOption.AsWritten, ReallocateIfOutOfBounds = false };

        [JsonIgnore]
        public Assembler Assembler;

        public AssemblyEditor()
        {
            
        }

        #region overrides

        public override void SaveFile()
        {
            File.WriteAllText(FilePath, Assembler.Text);
        }


        public override void Initialize(Project project)
        {
            base.Initialize(project);

            if (!File.Exists(FilePath))
                File.Create(FilePath).Close();
            this.Name = new FileInfo(FilePath).Name;
            this.Assembler = new Assembler(this.Config) { Text = File.ReadAllText(FilePath) };

            project.AssemblerGroup.Add(Assembler);
            project.Events.Saved += SaveFile;
            this.PreBuild += () => { preBuild(this.Project); };
        }

        void preBuild(Project project)
        {
            this.Assembler.Bytes = project.Bytes;
            this.Assembler.FirstPass();
        }

        public override void Build(Project project)
        {
            this.Assembler.Bytes = project.Bytes;
            SaveFile();
            this.Assembler.Assemble();
        }

        #endregion
    }
}
