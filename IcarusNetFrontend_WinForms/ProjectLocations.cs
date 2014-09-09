using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IcarusNetFrontend_Winforms
{
    public static class ProjectLocations
    {
        public static string ProjectsDir;
        public static string IcarusNetDir;
        public static string RomsDir;
        public static string ExampleRomFile;
        public static string SettingsFile;

        /// <summary>
        /// Use like:
        /// initialize(staticPropertyOfThisClass = "MyCoolNewDirectoryName");
        /// assigns the value and also creates the directory if it does not exists
        /// </summary>
        /// <param name="directoryThatShouldExist"></param>
        static void initializeDir(string directoryThatShouldExist)
        {
            if (!Directory.Exists(directoryThatShouldExist))
                Directory.CreateDirectory(directoryThatShouldExist);
        }

        static ProjectLocations()
        {
            initializeDir(IcarusNetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IcarusNet"));
            initializeDir(ProjectsDir = Path.Combine(IcarusNetDir, "Projects"));
            initializeDir(RomsDir = Path.Combine(IcarusNetDir, "ROMs"));

            if (!File.Exists(ExampleRomFile = Path.Combine(RomsDir, "example.nes")))
            {
                byte[] exampleRomBytes = new byte[131088];
                //header
                byte[] writeOver = { 0x4E, 0x45, 0x53, 0x1A, 0x08, 0x00, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                Array.Copy(writeOver, exampleRomBytes, writeOver.Length);

                File.WriteAllBytes(ExampleRomFile, exampleRomBytes);
            }

            if (!File.Exists(SettingsFile = Path.Combine(IcarusNetDir, "settings.json")))
            {
                File.WriteAllText(SettingsFile, "{}");
            }
        }
    }
}
