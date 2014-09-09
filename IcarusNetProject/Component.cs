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
        public string Name = null;

        [JsonIgnore]
        public Action PreSave = () => { };
        [JsonIgnore]
        public Action PreBuild = () => { };
        [JsonIgnore]
        public Project Project;

        public virtual void Initialize(Project project)
        {
            this.Project = project;
        }
        public abstract void Build(Project project);

        public Component()
        {
            
        }

        public int CompareTo(Component other)
        {
            return other.BuildOrder - this.BuildOrder;
        }
    }
}
