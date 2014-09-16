using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assembler6502Net;
using Newtonsoft.Json;

namespace IcarusNetProject.Components
{
    public enum WindowState
    {
        Normal,
        Max,
        Min,
        Closed
    }

    public abstract class Component : IComparable<Component>
    {
        public int X = 0;
        public int Y = 0;
        public int Width = 600;
        public int Height = 400;
        public int BuildOrder = 0;
        public WindowState WindowState = WindowState.Normal;
        [JsonIgnore]
        private string _name = null;
        public string Name
        {
            get
            {
                if (_name == null)
                    _name = this.GetType().Name + "_" + System.Guid.NewGuid().ToString("B").ToUpper();
                return _name;
            }
            set
            {
                _name = value;
                while (Project.Components.Where(c => c.Name == _name).Count() != 1)
                    _name += "_";
                NameChanged(_name);
            }
        }

        [JsonIgnore]
        public Action PropertyChangedOutsideNormalView = () => { };
        [JsonIgnore]
        public Func<string> PreSave = () => { return null; };
        [JsonIgnore]
        public Func<string> PreBuild = () => { return null; };
        [JsonIgnore]
        public Project Project;
        [JsonIgnore]
        public Action<string> NameChanged = (s) => { };
        
        [JsonIgnore]
        public string Message = null;

        public virtual void Initialize(Project project)
        {
            this.Project = project;
        }
        public abstract string Build(Project project);

        public Component()
        {
            
        }

        public int CompareTo(Component other)
        {
            return this.BuildOrder - other.BuildOrder;
        }
    }
}
