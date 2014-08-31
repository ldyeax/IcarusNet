using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IcarusNetProject.Components;

namespace IcarusNetProject
{
    public class ProjectEvents
    {
        public Action<Component> ComponentAdded = (c) => { };
        public Action<Component> ComponentRemoved = (c) => { };
        public Action BuildFinished = () => { };
        public Action Saved = () => { };
        public Action PreSave = () => { };
    }
}
