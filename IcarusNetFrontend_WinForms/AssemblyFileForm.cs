using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Assembler6502Net;

using IcarusNetProject.Components;

namespace IcarusNetFrontend_Winforms
{
    [IcarusNetComponent(typeof(IcarusNetProject.Components.AssemblyEditor))]
    public partial class AssemblyFileForm : Form, IProjectComponentForm
    {

        #region overrides

        /// <summary>
        /// Call after adding to form
        /// </summary>
        public void Initialize(IcarusNetProject.Components.Component component)
        {
            this.ProjectEditorComponent = (AssemblyEditor)component;

            assemblerToTextbox();
            this.Left = ProjectEditorComponent.X;
            this.Top = ProjectEditorComponent.Y;
            this.Width = ProjectEditorComponent.Width;
            this.Height = ProjectEditorComponent.Height;
        }

        #endregion

        void textboxToAssembler()
        {
            ProjectEditorComponent.Assembler.Text = txtInputAssembly.Text;
        }

        void assemblerToTextbox()
        {
            txtInputAssembly.Text = ProjectEditorComponent.Assembler.Text;
        }

        AssemblerConfigForm configForm = new AssemblerConfigForm();

        public IcarusNetProject.Components.AssemblyEditor ProjectEditorComponent;

        //Generated code

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void AssemblyFileForm_Load(object sender, EventArgs e)
        {
            
        }
        public AssemblyFileForm()
        {
            InitializeComponent();
        }

        private void txtInputAssembly_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInputAssembly_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtInputAssembly_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textboxToAssembler();
            }
        }

        private void txtInputAssembly_Leave(object sender, EventArgs e)
        {
            textboxToAssembler();
        }

        private void AssemblyFileForm_Move(object sender, EventArgs e)
        {
            if (ProjectEditorComponent != null)
            {
                ProjectEditorComponent.X = this.Left;
                ProjectEditorComponent.Y = this.Top;
            }
        }

        private void AssemblyFileForm_ResizeEnd(object sender, EventArgs e)
        {
            if (ProjectEditorComponent != null)
            {
                ProjectEditorComponent.Width = this.Width;
                ProjectEditorComponent.Height = this.Height;
            }
        }
    }
}
