using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using Assembler6502Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using IcarusNetProject.Components;

namespace IcarusNetProject
{
    public class Project
    {
        public const string FileExtension = "icarusnet";
        const string projectFileName = "project." + FileExtension;
        static JsonSerializerSettings jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented,  };

        [JsonIgnore]
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

        //Ignore warning that DefaultMembersSearchFlags is obsolete - it's better than making a whole new derived class
#pragma warning disable 0618
        static Project()
        {
            
            jsonSettings.Converters.Add(new StringEnumConverter() { CamelCaseText = true });
            jsonSettings.TypeNameHandling = TypeNameHandling.All;
            var resolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            resolver.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
            jsonSettings.ContractResolver = resolver;

        }
#pragma warning restore 0618

        public static void Create(string pathToDirectory, Settings settings)
        {
            if (!Directory.Exists(pathToDirectory))
                Directory.CreateDirectory(pathToDirectory);
            new Project() { 
                Settings = settings,
                PathToProjectFile = System.IO.Path.Combine(pathToDirectory, projectFileName)
            }.SaveProject();

            return;
        }

        public static Project Load(ProjectEvents events, string pathToDirectory)
        {
            string pathToProjectFile = Path.Combine(pathToDirectory, projectFileName);
            Project ret = JsonConvert.DeserializeObject<Project>(System.IO.File.ReadAllText(pathToProjectFile), jsonSettings);
            ret.PathToProjectFile = pathToProjectFile;
            events.PreSave += () =>
            {
                foreach (Component c in ret.components)
                {
                    c.PreSave();
                }
            };
            ret.Events = events;
            ret.init();
            return ret;
        }

        public void SaveProject()
        {
            setCWD();

            Events.PreSave();
            File.WriteAllText(PathToProjectFile, JsonConvert.SerializeObject(this, jsonSettings));
            Events.Saved();

            revertCWD();
        }

        public void WriteToOutputFile()
        {
            File.WriteAllBytes(Settings.OutputFile, Bytes);
        }

        private List<Component> components = new List<Component>();
        public Settings Settings = new Settings();


        [JsonIgnore]
        public bool Building = false;

        [JsonIgnore]
        public string PathToDirectory
        {
            get
            {
                return (new FileInfo(PathToProjectFile)).Directory.FullName;
            }
        }
        [JsonIgnore]
        public string PathToProjectFile = "";
        [JsonIgnore]
        public string PathToOutputFile
        {
            get
            {
                setCWD();
                string ret = new FileInfo(Settings.OutputFile).FullName;
                revertCWD();
                return ret;
            }
        }
        [JsonIgnore]
        public AssemblerGroup AssemblerGroup = new AssemblerGroup();
        /// <summary>
        /// To be written to by Components during Build
        /// </summary>
        [JsonIgnore]
        public Byte[] Bytes;
        [JsonIgnore]
        public ProjectEvents Events = new ProjectEvents();
        [JsonIgnore]
        public IEnumerable<Component> ComponentsSortedByExecutionOrder
        {
            get
            {
                this.components.Sort();
                return components;
            }
        }
        [JsonIgnore]
        public IEnumerable<Component> Components
        {
            get
            {
                return this.components;
            }
        }

        public void AddComponent(Component component)
        {
            setCWD();

            this.components.Add(component);
            component.Initialize(this);
            
            Events.ComponentAdded(component);

            revertCWD();
        }

        public void RemoveComponent(Component component)
        {
            this.components.Remove(component);
            Events.ComponentRemoved(component);
        }

        void buildOutput(string msg)
        {
            if (msg != null)
                this.Events.OutputDuringBuild(msg + Environment.NewLine);
            System.Threading.Thread.Sleep(100);
        }

        public void Build()
        {
            Building = true;

            setCWD();
            try
            {
                Bytes = File.ReadAllBytes(Settings.InputFile);

                var components = this.components.ToList();
                components.Sort();

                foreach (Component c in components)
                {
                    lock (c)
                    {
                        buildOutput("Pre-build <" + c.GetType().Name + "> " + c.Name);

                        buildOutput(c.PreBuild());

                        //if (c.Message != null)
                            //this.Events.OutputDuringBuild(c.Message) + "\n";

                        WriteToOutputFile();

                        buildOutput("Success");

                    }

                }
                foreach (Component c in components)
                {
                    lock (c)
                    {
                        buildOutput("Build <" + c.GetType().Name + "> " + c.Name);

                        buildOutput(c.Build(this));

                        WriteToOutputFile();

                        buildOutput("Success");
                    }
                }

                Events.BuildFinished();

                buildOutput("Build finished.");

                SaveProject();

                buildOutput("Project saved.");

            }
            catch (Exception ex)
            {
                throw new BuildErrorException(ex);
            }
            finally
            {
                revertCWD();

                Building = false;
            }

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
                Events.ComponentAdded(c);
            }

            revertCWD();
        }



        public void GenerateHeaderAndFooterAssemblySources()
        {
            string headername = "icarusnet_generated_header.s";

            setCWD();

            NES.Header header = new NES.Header(File.ReadAllBytes(Settings.InputFile));
            File.WriteAllText(headername, header.GetAssemblySource());

            revertCWD();

            AddComponent(new AssemblyEditor() { FilePath = headername });
        }
    }
}
