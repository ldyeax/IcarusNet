using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assembler6502Net;

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
        public int Width = 300;
        public int Height = 200;
        public int ExecutionOrder = 0;
        public WindowState WindowState = WindowState.Normal;

        public abstract void Initialize(Project project);
        public abstract void PreBuild(Project project);
        public abstract void Build(Project project);

        public Component()
        {

        }

        public int CompareTo(Component other)
        {
            return other.ExecutionOrder - this.ExecutionOrder;
        }
    }
}
