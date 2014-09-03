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

using IcarusNetProject;
using IcarusNetProject.Components;

using Microsoft.VisualBasic;

namespace IcarusNetFrontend_Winforms
{
    public partial class MainWindow : Form
    {
        #region variables
        
        Project OpenProject
        {
            get
            {
                return _openProject;
            }
            set
            {
                _openProject = value;

                
                setGrayedOut();

                if (value == null)
                {
                    this.Text = "IcarusNet: No open project";
                }
                else
                {
                    repopulateComponentSelectors();
                    pnlComponentZoo.Controls.Clear();
                    var fi = new FileInfo(_openProject.PathToProjectFile);
                    this.Text = "IcarusNet " + fi.Name + ": " + fi.Directory.FullName;
                }
            }
        }
        Project _openProject;

        Dictionary<string, Form> nameToComponentForm = new Dictionary<string, Form>();

        //Dictionary<Form, TabPage> formToTabPage = new Dictionary<Form, TabPage>();
        //Dictionary<TabPage, Form> tabPageToForm = new Dictionary<TabPage, Form>();

        #endregion

        #region mainwindow events, constructors

        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.OpenProject = null;
            //setGrayedOut();
            //tabsTop.Enabled = true;
            //tabsTop.Visible = tabsTop.TabPages.Count != 0;
            //Application.AddMessageFilter()
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //return;

            //if (e.KeyCode == Keys.F5)
            //{
            //    toolstrip_buildAndRun.PerformClick();
            //    e.Handled = true;
            //    return;
            //}

            //if (e.Control)
            //{
            //    switch (e.KeyCode)
            //    {
            //        case Keys.O:
            //            {
            //                toolstrip_open.PerformClick();
            //                break;
            //            }
            //        case Keys.S:
            //            {
            //                toolstrip_saveProject.PerformClick();
            //                break;
            //            }
            //    }
            //}
        }


        #endregion

        #region helping methods


        void setMessage(string msg)
        {
            txtOutput.Text = msg;
        }

        void setGrayedOut(Control ctrlToSearch = null)
        {
            if (ctrlToSearch == null)
            {
                ctrlToSearch = this;
            }
            if (ctrlToSearch.Controls == null || ctrlToSearch.Controls.Count == 0)
                return;

            bool projectIsOpen = OpenProject != null;

            if (ctrlToSearch.Tag != null && (string)(ctrlToSearch.Tag) == "NeedOpenProject")
                ctrlToSearch.Enabled = projectIsOpen;

            foreach (var ctrl in ctrlToSearch.Controls.OfType<Control>())
                setGrayedOut(ctrl);
        }

        void repopulateComponentSelectors()
        {
            this.lbProjectControls.Items.Clear();
            //this.tabsTop.Controls.Clear();

            if (this.OpenProject != null)
            {
                foreach (var c in OpenProject.ComponentsSortedByExecutionOrder)
                {
                    this.lbProjectControls.Items.Add(c.Name);
                    if (c.WindowState != IcarusNetProject.Components.WindowState.Closed)
                    {
                        //tabControl1.Controls.Add(new TabControl() { Name = c.Name });
                    }
                }
            }
        }

        IcarusNetProject.Components.WindowState FormToIcarusWindowState(Form form)
        {

            if (!form.Visible)
                return IcarusNetProject.Components.WindowState.Closed;
            switch (form.WindowState)
            {
                case FormWindowState.Maximized:
                    return IcarusNetProject.Components.WindowState.Max;
                case FormWindowState.Minimized:
                    return IcarusNetProject.Components.WindowState.Min;
                case FormWindowState.Normal:
                    return IcarusNetProject.Components.WindowState.Normal;
            }
            throw new InvalidOperationException();
        }

        #endregion

        #region components in the components panel

        #region tabs
        
        //void processTab(Form form)
        //{
        //    TabPage tab = new TabPage(form.Text);
        //    formToTabPage[form] = tab;
        //    tabPageToForm[tab] = form;
        //    tab.Click += tab_Click;
        //}

        //void tab_Click(object sender, EventArgs e)
        //{
        //    tabPageToForm[(TabPage)sender].BringToFront();
        //}

        //void componentForm_VisibleChanged(object sender, EventArgs e)
        //{
        //    Form frm = (Form)sender;
        //    if (frm.Visible)
        //    {
        //        tabsTop.TabPages.Add(formToTabPage[frm]);
        //    }
        //    else
        //    {
        //        tabsTop.TabPages.Remove(formToTabPage[frm]);
        //    }
        //}
        
        #endregion

        void addComponentForm(IcarusNetProject.Components.Component component, Form componentForm)
        {
            componentForm.TopLevel = false;
            //this.Controls.Add(frm);
            this.pnlComponentZoo.Controls.Add(componentForm);

            //processTab(componentForm);


            if (component.WindowState != IcarusNetProject.Components.WindowState.Closed)
                componentForm.Show();
            else
                componentForm.Hide();

            ((IProjectComponentForm)componentForm).Initialize(component);

            if (component.X < 0 || component.X >= pnlComponentZoo.Width)
                componentForm.Left = 0;
            if (component.Y < 0 || component.Y >= pnlComponentZoo.Height)
                componentForm.Top = 0;

            repopulateComponentSelectors();

            componentForm.FormClosed += componentForm_FormClosed;
            componentForm.FormClosing += componentForm_FormClosing;
            componentForm.SizeChanged += componentForm_SizeChanged;
            componentForm.MouseDown += componentForm_MouseDown;
            componentForm.GotFocus += componentForm_GotFocus;
            componentForm.VisibleChanged += componentForm_VisibleChanged;

            nameToComponentForm.Add(component.Name, componentForm);

            component.PreSave += () =>
            {
                component.WindowState = FormToIcarusWindowState(componentForm);
            };

            return;
        }

        void componentForm_VisibleChanged(object sender, EventArgs e)
        {

        }

        void componentForm_GotFocus(object sender, EventArgs e)
        {
            ((Form)sender).BringToFront();
        }

        void componentForm_MouseDown(object sender, MouseEventArgs e)
        {
            ((Form)sender).BringToFront();
        }

        #endregion

        #region project events

        void OnComponentAddedToProject(IcarusNetProject.Components.Component component)
        {
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attribs = t.GetCustomAttributes(typeof(IcarusNetComponentAttribute), false);
                if (attribs.Length != 1)
                    continue;
                var attrib = (IcarusNetComponentAttribute) attribs.First();
                if (attrib.ComponentType == component.GetType())
                {
                    var componentForm = (Form)Activator.CreateInstance(t);
                    addComponentForm(component, componentForm);
                    return;
                }
            }
            throw new NotImplementedException("No form found for control");
        }

        void componentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((IProjectComponentForm)sender).GetComponent().WindowState = IcarusNetProject.Components.WindowState.Closed;
            ((Form)sender).Hide();
            e.Cancel = true;
        }

        void componentForm_SizeChanged(object sender, EventArgs e)
        {
            var component = ((IProjectComponentForm)sender).GetComponent();
            switch(((Form)sender).WindowState)
            {
                case FormWindowState.Maximized:
                    component.WindowState = IcarusNetProject.Components.WindowState.Max;
                    break;
                case FormWindowState.Minimized:
                    component.WindowState = IcarusNetProject.Components.WindowState.Min;
                    break;
                case FormWindowState.Normal:
                    component.WindowState = IcarusNetProject.Components.WindowState.Normal;
                    break;
            }
        }

        void componentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        void OnComponentRemovedFromProject(IcarusNetProject.Components.Component component)
        {
            if (nameToComponentForm.ContainsKey(component.Name))
                nameToComponentForm.Remove(component.Name);
            var toRemove = pnlComponentZoo.Controls.OfType<Control>().Where(c => ((IProjectComponentForm)c).GetComponent() == component);
            if (toRemove.Count() != 0)
                pnlComponentZoo.Controls.Remove(toRemove.First());
        }
        void OnProjectBuildFinished()
        {
            setMessage("Build finished successfully");
        }

        ProjectEvents getEvents()
        {
            return new ProjectEvents()
            {
                ComponentAdded = OnComponentAddedToProject,
                ComponentRemoved = OnComponentRemovedFromProject,
                BuildFinished = OnProjectBuildFinished
            };
        }


        #endregion

        #region new project creator popup

        void newprojectform_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (NewProjectForm)sender;
            if (form.NewProjectPath != null)
            {
                OpenProject = Project.Load(getEvents(), form.NewProjectPath);
            }

        }

        #endregion

        #region project explorer

        /// <summary>
        /// returns null if none selected
        /// </summary>
        /// <returns></returns>
        Form getSelectedComponentFormInListBox()
        {
            if (lbProjectControls.SelectedItem == null)
                return null;

            return nameToComponentForm[lbProjectControls.SelectedItem.ToString()];
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void lbProjectControls_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void lbProjectControls_DoubleClick(object sender, EventArgs e)
        {
            if (OpenProject == null)
                return;

            var ctrl = getSelectedComponentFormInListBox();

            if (ctrl != null)
            {
                if (!pnlComponentZoo.Controls.Contains(ctrl))
                    pnlComponentZoo.Controls.Add(ctrl);

                ctrl.Show();
                ctrl.BringToFront();
            }
        }

        private void btnAddAssembler_Click(object sender, EventArgs e)
        {
            if (OpenProject == null)
                return;

            string newname = Microsoft.VisualBasic.Interaction.InputBox("Name:");
            if (!newname.EndsWith(".s"))
                newname += ".s";

            OpenProject.AddComponent(new AssemblyEditor() { FilePath = newname });
        }


        private void lbProjectControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpenProject == null)
                return;

            var form = getSelectedComponentFormInListBox();
            if (form != null)
            {
                if (pnlComponentZoo.Contains(form))
                    form.BringToFront();
            }

        }

        #endregion

        #region file associations

        private void btnFileAssociations_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region toolstrip

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newprojectform = new NewProjectForm();
            newprojectform.FormClosing += newprojectform_FormClosing;
            newprojectform.Show();
        }

        private void toolstrip_open_Click(object sender, EventArgs e)
        {
            OpenProject = Project.Load(getEvents(), @"C:\users\user\icarproj\hope");
            return;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OpenProject = Project.Load(getEvents(), dialog.SelectedPath);
            }
        }

        private void _toolstrip_save_Click(object sender, EventArgs e)
        {
            var wh = pnlComponentZoo.Controls.OfType<Control>().Where(c => c.Focused);
            if (wh.Count() != 0)
            {
                if (wh.First() is IProjectComponentForm)
                {
                    var pcf = (IProjectComponentForm)wh.First();
                    if (pcf.GetComponent() is FileComponent)
                    {
                        ((FileComponent)pcf.GetComponent()).SaveFile();
                    }
                }
            }
        }

        private void toolstrip_saveProject_Click(object sender, EventArgs e)
        {
            if (OpenProject == null)
                return;

            OpenProject.Save();
            setMessage("Project saved");
        }

        private void toolstrip_buildOptions_Click(object sender, EventArgs e)
        {

        }

        private void toolstrip_build_Click(object sender, EventArgs e)
        {
            if (OpenProject == null)
                return;
            try
            {
                OpenProject.Build();
                //setMessage("Build successful");
            }//put this into a build error event
            catch (BuildErrorException ex)
            {
                setMessage("Build error:\n" + ex.Message);
            }
        }

        private void toolstrip_buildAndRun_Click(object sender, EventArgs e)
        {
            if (OpenProject == null)
                return;
            try
            {
                OpenProject.Build();
                //System.Diagnostics.Process.Start(..
                setMessage("Build successful. Running post-run command.");
            }
            catch (BuildErrorException ex)
            {
                setMessage("Build error:\n" + ex.Message);
            }
        }

        private void toolstrip_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alpha version of 6502 IDE. Assembles correctly as far as I know.\nLDYEAX@gmail.com");
        }

        private void toolstrip_options_Click(object sender, EventArgs e)
        {

        }

        private void toolstrip_new_Click(object sender, EventArgs e)
        {

        }

        private void toolstrip_help_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

    }
}
