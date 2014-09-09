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
        #region variables

        //Thread workerThread;

        public AssemblerConfig Config
        {
            get
            {
                uint startaddr = 0;
                try
                {
                    startaddr = Convert.ToUInt32(txtStartAddr.Text, 16);
                }
                catch (FormatException)
                {
                    startaddr = 0;
                    txtStartAddr.BackColor = Color.Red;
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
                txtStartAddr.Text = Convert.ToString(value.FileStartAddress, 16);
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
                    this.Config = _projectEditorComponent.Config;
                }
            }
        }

        #endregion

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

            component.PreBuild += () => { textboxToAssembler(true, false); };
            component.PreSave += () => { textboxToAssembler(true); };
        }

        public IcarusNetProject.Components.Component GetComponent()
        {
            return this.ProjectEditorComponent;
        }

        #endregion

        #region assorted methods

        void refreshLineNumberDocks()
        {
            ;
            this.txtLineNumbers.Refresh();
            this.txtHexValues.Refresh();
        }

        void _invoke(Action a)
        {
            this.Invoke((MethodInvoker)delegate
            {
                a();
            });
        }

        void textboxToAssembler(bool doBuild = true, bool firstPassOnly = false)
        {
            _invoke(() =>
            {
                ProjectEditorComponent.Assembler.Config = this.Config;
                ProjectEditorComponent.Assembler.Text = txtInputAssembly.Text;
            });

            if (!doBuild)
                return;

            try
            {
                ProjectEditorComponent.Assembler.FirstPass();
                if (!firstPassOnly)
                    ProjectEditorComponent.Assembler.Assemble(true);

                _invoke(() =>
                {
                    lblErrorOutput.Text = "";
                });

                
            }
            catch (Assembler6502Net.SyntaxErrorException ex)
            {
                
                _invoke(() =>
                {
                    lblErrorOutput.Text = ex.ToString() + Environment.NewLine + ex.StackTrace;
                });

                //throw ex
            }
            finally
            {
                _invoke(refreshLineNumberDocks);
            };
            
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

                if (line == null || line.ComputedBytes == null)
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

        void assembleLoop()
        {
            //return;
            int t = 0;

            while (true)
            {
                //Console.WriteLine((t++).ToString());

                try
                {

                    System.Threading.Thread.Sleep(100);


                    if (ProjectEditorComponent == null || ProjectEditorComponent.Project == null || ProjectEditorComponent.Project.Building)
                    {
                        //Monitor.Exit(this.ProjectEditorComponent);
                        continue;
                    }

                    //if (Monitor.TryEnter(this.ProjectEditorComponent))
                    lock(this.ProjectEditorComponent)
                    {
                        //_invoke(() => { this.Text = "1"; });

                        textboxToAssembler();
                        //_invoke(() => { this.Text = "2"; });
                        //Monitor.Exit(this.ProjectEditorComponent);
                        continue;
                    }



                    //pointless, just do it regardless every 100ms, cheap enough
                    /*
                    t++;
                    _invoke(() => { this.Text = t.ToString(); });
                    
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
                    */

                }
                catch (Exception ex)
                {

                    //return;
                    _invoke(() => { this.Text = ex.Message; });
                    //MessageBox.Show(ex.Message);
                };
            }
        }

        #endregion

        #region generated

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void AssemblyFileForm_Load(object sender, EventArgs e)
        {
            this.txtLineNumbers.LineTextSetter = setTextFromLineNo;
            this.txtHexValues.LineTextSetter = setHexStringFromLineNo;

            backgroundWorker.RunWorkerAsync();

            foreach (var ctrl in this.Controls)
            {
                ((Control)ctrl).Enter += bringToFrontEvent;
                ((Control)ctrl).Click += bringToFrontEvent;
            }
            //workerThread = new Thread(new ThreadStart(assembleLoop));
            //workerThread.Start();
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
                    //queueTextboxToAssembler();
                    break;
            }
        }

        private void txtInputAssembly_Leave(object sender, EventArgs e)
        {
            //queueTextboxToAssembler();
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
            //queueTextboxToAssembler();
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
                MessageBox.Show(this.ParentForm, "Null ref");
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            assembleLoop();
        }

        #endregion

        private void bringToFrontEvent(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
