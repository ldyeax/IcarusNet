using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IcarusNetProject.Components;

namespace IcarusNetFrontend_Winforms
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IcarusNetComponentAttribute : System.Attribute
    {
        public Type ComponentType;
        public IcarusNetComponentAttribute(Type ComponentType)
        {
            this.ComponentType = ComponentType;
        }
    }
}
