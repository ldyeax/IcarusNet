using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IcarusNetFrontend_Winforms
{
    public partial class OpenProjectForm : Form
    {
        public OpenProjectForm()
        {
            InitializeComponent();
        }

        const char Sep = '|';

        public string OpenProjectPath = null;
        
        private void OpenProjectForm_Load(object sender, EventArgs e)
        {
            lblLookingIn.Text = "Looking in: " + ProjectLocations.ProjectsDir;

            var dirs = new DirectoryInfo(ProjectLocations.ProjectsDir).GetDirectories();

            foreach (var dir in dirs)
            {
                comboBox1.Items.Add(dir.Name + Sep + dir.FullName);
            }

            if (dirs.Length != 0)
                comboBox1.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("No directory selected!");
                return;
            }

            var spl = comboBox1.SelectedItem.ToString().Split(Sep);
            if (spl.Length == 1)
                OpenProjectPath = spl[0];
            else if (spl.Length == 2)
                OpenProjectPath = spl[1];
            else
                throw new InvalidOperationException("Something is wrong with the path");

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog() { SelectedPath = ProjectLocations.ProjectsDir };
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var pth = dialog.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(pth);
                var str = di.Name + Sep + di.FullName;
                comboBox1.Items.Add(str);
                comboBox1.SelectedItem = str;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();
        }
    }
}
