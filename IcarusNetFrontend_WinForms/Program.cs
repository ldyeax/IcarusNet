using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace IcarusNetFrontend_Winforms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var indir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IcarusNet");
            if (!Directory.Exists(indir))
            {
                Directory.CreateDirectory(indir);
            }
            var projectsdir = Path.Combine(indir, "Projects");
            if (!Directory.Exists(projectsdir))
            {
                Directory.CreateDirectory(projectsdir);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
