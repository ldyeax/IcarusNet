using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;

namespace IcarusNetProject.Components
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class HexEditor : Component
    {
        public string FilePath = "";

        [JsonIgnore]
        public FileSystemWatcher FileWatcher;

        #region overrides

        public override void Initialize(Project project)
        {
            FileWatcher = new FileSystemWatcher(FilePath);
        }

        //public override void PreBuild(Project project)
        //{
        //    throw new NotImplementedException();
        //}

        public override void Build(Project project)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
