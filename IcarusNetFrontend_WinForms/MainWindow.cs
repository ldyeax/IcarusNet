using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Reflection;

using Assembler6502Net;

using IcarusNetProject;
using IcarusNetProject.Components;

using Microsoft.VisualBasic;

namespace IcarusNetFrontend_Winforms
{
    public partial class MainWindow : Form
    {
        Project OpenProject
        {
            get
            {
                return _openProject;
            }
            set
            {
                _openProject = value;
                var fi = new FileInfo(_openProject.PathToProjectFile);
                this.Text = fi.Name + ": " + fi.Directory.FullName;
            }
        }
        Project _openProject;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            OpenProject.Build();
        }

        private void btnClearBytes_Click(object sender, EventArgs e)
        {
     
        }

        private void btnAddAssembler_Click(object sender, EventArgs e)
        {
            string newname = Microsoft.VisualBasic.Interaction.InputBox("Name:");
            if (!newname.EndsWith(".s"))
                newname += ".s";

            OpenProject.AddComponent(new AssemblyEditor() { FilePath = newname });
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void btnAddHexView_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        void form_GotFocus(object sender, EventArgs e)
        {
            ((Form)sender).BringToFront();
        }

        Random r = new Random();

        #region project event handlers

        void OnProjectControlAdded(IcarusNetProject.Components.Component ctrl)
        {
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attribs = t.GetCustomAttributes(typeof(IcarusNetComponentAttribute), false);
                if (attribs.Length != 1)
                    continue;
                var attrib = (IcarusNetComponentAttribute) attribs.First();
                if (attrib.ComponentType == ctrl.GetType())
                {
                    var frm = (Form)Activator.CreateInstance(t);
                    frm.TopLevel = false;
                    this.Controls.Add(frm);
                    ((IProjectComponentForm)frm).Initialize(ctrl);
                    frm.Show();
                    return;
                }
            }
            throw new NotImplementedException("No form found for control");
        }
        void OnProjectControlRemoved(IcarusNetProject.Components.Component ctrl)
        {

        }
        void OnProjectBuildFinished()
        {
            MessageBox.Show("Build finished");
        }

        #endregion

        ProjectEvents getEvents()
        {
            return new ProjectEvents()
            {
                ComponentAdded = OnProjectControlAdded,
                ComponentRemoved = OnProjectControlRemoved,
                BuildFinished = OnProjectBuildFinished
            };
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            var newprojectform = new NewProjectForm();
            newprojectform.FormClosing += newprojectform_FormClosing;
            newprojectform.Show();
        }

        void newprojectform_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (NewProjectForm)sender;
            if (form.NewProjectPath != null)
            {
                OpenProject = Project.Load(getEvents(), form.NewProjectPath);
            }

        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OpenProject = Project.Load(getEvents(), dialog.SelectedPath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenProject.Save();
        }

    }
}
