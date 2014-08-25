using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Assembler6502Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using IcarusNetProject.Components;

namespace IcarusNetProject
{
    public class Project
    {
        const string projectFileName = "project.json";
        static JsonSerializerSettings jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented };

        string _oldcwd;
        void setCWD()
        {
            _oldcwd = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(PathToDirectory);
        }
        void revertCWD()
        {
            Directory.SetCurrentDirectory(_oldcwd);
        }

        static Project()
        {
            jsonSettings.Converters.Add(new StringEnumConverter() { CamelCaseText = true });
            jsonSettings.TypeNameHandling = TypeNameHandling.All;
            var resolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            resolver.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
            jsonSettings.ContractResolver = resolver;

        }

        public static void Create(string pathToDirectory, Settings settings)
        {
            if (!Directory.Exists(pathToDirectory))
                Directory.CreateDirectory(pathToDirectory);
            new Project() { 
                Settings = settings,
                PathToProjectFile = System.IO.Path.Combine(pathToDirectory, projectFileName)
            }.Save();

            return;
        }

        public static Project Load(ProjectEvents events, string pathToDirectory)
        {
            string pathToProjectFile = Path.Combine(pathToDirectory, projectFileName);
            Project ret = JsonConvert.DeserializeObject<Project>(System.IO.File.ReadAllText(pathToProjectFile), jsonSettings);
            ret.PathToDirectory = pathToDirectory;
            ret.PathToProjectFile = pathToProjectFile;
            ret.events = events;
            ret.init();
            return ret;
        }

        public void Save()
        {
            File.WriteAllText(PathToProjectFile, JsonConvert.SerializeObject(this, jsonSettings));
        }

        private List<Component> components = new List<Component>();
        public Settings Settings = new Settings();

        [JsonIgnore]
        public string PathToDirectory = "";
        [JsonIgnore]
        public string PathToProjectFile = "";
        [JsonIgnore]
        public AssemblerGroup AssemblerGroup = new AssemblerGroup();
        //To be written to by Components during Build
        [JsonIgnore]
        public Byte[] Bytes;
        [JsonIgnore]
        ProjectEvents events;

        public void AddComponent(Component component)
        {
            component.Initialize(this);
            this.components.Add(component);
            events.ComponentAdded(component);
        }

        public void RemoveComponent(Component component)
        {
            this.components.Remove(component);
            events.ComponentRemoved(component);
        }

        public void Build()
        {
            setCWD();

            Bytes = File.ReadAllBytes(Settings.InputFile);

            var components = this.components.ToList();
            components.Sort();

            foreach (Component c in components)
                c.PreBuild(this);
            foreach (Component c in components)
                c.Build(this);

            File.WriteAllBytes(Settings.OutputFile, Bytes);

            events.BuildFinished();

            Save();

            revertCWD();
        }


        private Project()
        {
            
        }

        private void init()
        {
            setCWD();

            foreach (Component c in components)
            {
                c.Initialize(this);
                events.ComponentAdded(c);
            }

            revertCWD();
        }
    }
}
