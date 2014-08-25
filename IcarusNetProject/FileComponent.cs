using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IcarusNetProject.Components
{
    public abstract class FileComponent : Component
    {
        public string FilePath;
        public abstract void SaveFile();
    }
}
