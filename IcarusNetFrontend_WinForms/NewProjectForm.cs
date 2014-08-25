using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using IcarusNetProject;

namespace IcarusNetFrontend_Winforms
{
    public partial class NewProjectForm : Form
    {
        public string NewProjectPath = null;

        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string inputFile = txtInputFile.Text;
            string createUnder = txtCreateUnder.Text;

            string pathtoproject = Path.Combine(createUnder, txtProjectName.Text);

            if (!Directory.Exists(createUnder))
                Directory.CreateDirectory(createUnder);
            
            Project.Create(
                pathtoproject,
                new Settings() {
                    InputFile = cbMakeCopy.Checked ? new FileInfo(inputFile).Name : inputFile, 
                    OutputFile = txtOutputFileName.Text 
                }
            );

            if (cbMakeCopy.Checked)
            {
                File.Copy(inputFile, Path.Combine(pathtoproject, new FileInfo(inputFile).Name));
            }

            NewProjectPath = pathtoproject;
            this.Close();
        }
    }
}
