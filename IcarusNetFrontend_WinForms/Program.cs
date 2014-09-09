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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow mainWindow = new MainWindow();
            //if (args.Length != 0)
            //{
            //    var dir = new FileInfo(args[0]).Directory.FullName;
            //    mainWindow.OpenProjectFromPath(dir);
            //}
                //mainWindow.OpenProjectFromPath(new FileInfo(args[0]).Directory.FullName);
                //MessageBox.Show(args[0]);
            Application.Run(mainWindow);
        }
    }
}
