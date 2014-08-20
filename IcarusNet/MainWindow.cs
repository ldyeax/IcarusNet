using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Assembler6502Net;

namespace IcarusNet
{
    public partial class MainWindow : Form
    {
        AssemblerGroup group;
        List<AssemblyFileForm> assemblyFiles = new List<AssemblyFileForm>();
        List<IDEControl> IDEControls = new List<IDEControl>();

        ushort FileSize
        {
            get
            {
                try
                {
                    return Convert.ToUInt16(txtFileSize.Text);
                }
                catch (Exception)
                {
                    txtFileSize.Text = "1024";
                    return 1024;
                }
            }
            set
            {
                txtFileSize.Text = value.ToString();
            }
        }

        byte[] bytes;

        void catchError(Action action)
        {
            //try
            //{
            //    action();
            //}
            //catch (Assembler6502Net.SyntaxErrorException ex)
            //{
            //    lblErrorOutput.Text = "Error on line " + (ex.Line + 1) + ":\n" + ex.Message + "\n";
            //    if (ex.InnerException != null)
            //        lblErrorOutput.Text += ex.InnerException.Message;
            //    //string line = textBox.Text.Split('\n')[ex.Line];
            //    ////int start = txtInput.Text.IndexOf(line);
            //    //textBox.SelectionStart = txtInput1.GetFirstCharIndexFromLine(ex.Line);
            //    //textBox.SelectionLength = line.Length;
            //    //textBox.HideSelection = false;
            //}
        }

        void addIDEControl(IDEControl ctrl)
        {
            this.IDEControls.Add(ctrl);
            Form form = (Form)ctrl;
            form.FormClosed += form_FormClosed;
            form.TopLevel = false;
            this.Controls.Add(form);
            form.Show();
        }

        //Generated code below

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string s in Enum.GetNames(typeof(Assembler6502Net.AssemblerConfig.OperandLengthOption)))
            {
                //lbAddr1.Items.Add(s);
            }
            //lbAddr1.SelectedIndex = 0;

            bytes = new byte[FileSize];
        }

        class IDEComparer : IComparer<IDEControl>
        {
            public static IDEComparer Instance = new IDEComparer();
            public int Compare(IDEControl a, IDEControl b)
            {
                return a.GetOrder() - b.GetOrder();
            }
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            group = new AssemblerGroup(bytes);

            IDEControls.Sort(IDEComparer.Instance);

            foreach (IDEControl ctrl in IDEControls)
                ctrl.Process(group);

            group.Assemble();
        }

        private void btnClearBytes_Click(object sender, EventArgs e)
        {
            bytes = new byte[FileSize];
        }

        private void btnAddAssembler_Click(object sender, EventArgs e)
        {
            addIDEControl(new AssemblyFileForm());
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //assemblyFiles.Remove((AssemblyFileForm)sender);
            this.IDEControls.Remove((IDEControl)sender);
        }
        private void btnAddHexView_Click(object sender, EventArgs e)
        {
            addIDEControl(new HexEditorForm());
        }



    }
}
