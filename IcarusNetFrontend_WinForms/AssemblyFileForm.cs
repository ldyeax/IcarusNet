using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Assembler6502Net;

using IcarusNetProject.Components;

namespace IcarusNetFrontend_Winforms
{
    [IcarusNetComponent(typeof(IcarusNetProject.Components.AssemblyEditor))]
    public partial class AssemblyFileForm : Form, IProjectComponentForm
    {

        public AssemblerConfig Config
        {
            get
            {
                uint startaddr = 0;
                try
                {
                    startaddr = Convert.ToUInt32(txtStartAddr.Text);
                }
                catch (FormatException)
                {
                    try
                    {
                        startaddr = Convert.ToUInt32(txtStartAddr.Text, 16);
                    }
                    catch (FormatException)
                    {
                        startaddr = 0;
                        MessageBox.Show("Invalid starting address");
                    }
                }

                return new AssemblerConfig()
                {
                    OperandLength =
                       cbAddressingPreference.SelectedItem != null ?
                           (AssemblerConfig.OperandLengthOption)
                               Enum.Parse(typeof(AssemblerConfig.OperandLengthOption),
                                   cbAddressingPreference.SelectedItem.ToString()
                               )
                           :
                           AssemblerConfig.OperandLengthOption.AsWritten,

                    ReallocateIfOutOfBounds = rbFilesize.Checked,

                    FileStartAddress = startaddr
                };
            }
            set
            {
                cbAddressingPreference.Items.Clear();

                foreach (string s in Enum.GetNames(typeof(AssemblerConfig.OperandLengthOption)))
                    cbAddressingPreference.Items.Add(s);

                cbAddressingPreference.SelectedItem = cbAddressingPreference.Items.OfType<object>().Where(o => o.ToString() == value.OperandLength.ToString()).First();
                rbFilesize.Checked = value.ReallocateIfOutOfBounds;
                txtStartAddr.Text = "0x" + Convert.ToString(value.FileStartAddress, 16);
                try
                {
                    this.ProjectEditorComponent.Assembler.Config = value;
                }
                catch (NullReferenceException) { }
            }
        }

        IcarusNetProject.Components.AssemblyEditor _projectEditorComponent;
        public IcarusNetProject.Components.AssemblyEditor ProjectEditorComponent
        {
            get
            {
                return _projectEditorComponent;
            }
            set
            {
                _projectEditorComponent = value;
                if (_projectEditorComponent != null)
                {
                    this.Text = _projectEditorComponent.Name;
                    //textboxToAssembler();
                    assemblerToTextbox();
                }
            }
        }

        #region overrides

        /// <summary>
        /// Call after adding to form and showing
        /// </summary>
        public void Initialize(IcarusNetProject.Components.Component component)
        {
            this.ProjectEditorComponent = (AssemblyEditor)component;

            assemblerToTextbox();
            this.Left = ProjectEditorComponent.X;
            this.Top = ProjectEditorComponent.Y;
            this.Width = ProjectEditorComponent.Width;
            this.Height = ProjectEditorComponent.Height;

            component.PreBuild += textboxToAssembler;
            component.PreSave += textboxToAssembler;
        }

        public IcarusNetProject.Components.Component GetComponent()
        {
            return this.ProjectEditorComponent;
        }

        #endregion

        void refreshLineNumberDocks()
        {
            this.txtLineNumbers.Refresh();
            this.txtHexValues.Refresh();
        }

        void textboxToAssembler()
        {
            ProjectEditorComponent.Assembler.Config = this.Config;
            ProjectEditorComponent.Assembler.Text = txtInputAssembly.Text;
            try
            {
                progressBar1.Value = 0;
                ProjectEditorComponent.Assembler.FirstPass();
                progressBar1.Value = 50;
                ProjectEditorComponent.Assembler.Assemble(true);
                progressBar1.Value = 100;
                lblErrorOutput.Text = "";
            }
            catch (Assembler6502Net.SyntaxErrorException ex)
            {
                lblErrorOutput.Text = ex.ToString();
                throw ex;
            }
            finally
            {
                refreshLineNumberDocks();
            }
            
        }

        void assemblerToTextbox()
        {
            txtInputAssembly.Text = ProjectEditorComponent.Assembler.Text;

            Config = ProjectEditorComponent.Assembler.Config;
        }

        string setHexStringFromLineNo(int lineno)
        {
            string linenostr = "-";

            if (this.ProjectEditorComponent == null)
                return linenostr;
            if (this.ProjectEditorComponent.Assembler == null)
                return linenostr;
            if (this.ProjectEditorComponent.Assembler.Lines == null)
                return linenostr;

            lineno--;

            if (lineno < this.ProjectEditorComponent.Assembler.Lines.Length)
            {
                Line line = this.ProjectEditorComponent.Assembler.Lines[lineno];

                if (line == null)
                {
                    return linenostr;
                }

                return string.Join(" ", (from b in line.ComputedBytes select b.ToString("X2")).ToArray());
            }

            return linenostr;
        }

        string setTextFromLineNo(int lineno)
        {
            string linenostr = lineno.ToString();

            if (this.ProjectEditorComponent == null)
                return linenostr;
            if (this.ProjectEditorComponent.Assembler == null)
                return linenostr;
            if (this.ProjectEditorComponent.Assembler.Lines == null)
                return linenostr;

            lineno--;

            if (lineno < this.ProjectEditorComponent.Assembler.Lines.Length)
            {
                Line line = this.ProjectEditorComponent.Assembler.Lines[lineno];

                if (line == null)
                {
                    return linenostr;
                }

                return 
                    linenostr + " " + 
                    (line.PC + this.ProjectEditorComponent.Assembler.Config.FileStartAddress).ToString("X5") +
                    ":" +
                    line.PC.ToString("X4");
            }

            return linenostr;
        }

        //Generated code

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void AssemblyFileForm_Load(object sender, EventArgs e)
        {
            this.txtLineNumbers.LineTextSetter = setTextFromLineNo;
            this.txtHexValues.LineTextSetter = setHexStringFromLineNo;

        }
        public AssemblyFileForm()
        {
            InitializeComponent();
        }

        private void txtInputAssembly_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Up:
                case Keys.Down:
                    queueTextboxToAssembler();
                    break;
            }
        }

        private void txtInputAssembly_Leave(object sender, EventArgs e)
        {
            queueTextboxToAssembler();
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

        private void txtInputAssembly_Resize(object sender, EventArgs e)
        {
            this.txtLineNumbers.Invalidate();
            this.refreshLineNumberDocks();
        }

        private void txtInputAssembly_SizeChanged(object sender, EventArgs e)
        {
            this.txtLineNumbers.Invalidate();
            this.refreshLineNumberDocks();
        }

        private void txtInputAssembly_TextChanged(object sender, EventArgs e)
        {
            //ProjectEditorComponent.Assembler.Text = txtInputAssembly.Text;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            AssemblerConfigForm configForm = new AssemblerConfigForm(this.ProjectEditorComponent.Assembler.Config);
            configForm.Show();
            configForm.FormClosing += configForm_FormClosing;
        }

        void configForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.ProjectEditorComponent.Assembler.Config = ((AssemblerConfigForm)sender).Config;
            }
            catch (NullReferenceException) 
            {
                MessageBox.Show("Null ref");
            }
        }

        //can't use lock on a bool
        class AssemblePending
        {
            public bool Value = false;
        }

        AssemblePending assembleIsPending = new AssemblePending();

        void queueTextboxToAssembler()
        {
            lock (assembleIsPending)
            {
                assembleIsPending.Value = true;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bool doAssemble;
                lock (assembleIsPending)
                {
                    doAssemble = assembleIsPending.Value;
                    if (assembleIsPending.Value)
                    {
                        assembleIsPending.Value = false;
                    }
                }
                if (doAssemble)
                {
                    textboxToAssembler();
                }

            }
        }
    }
}
