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
    public partial class AssemblyFileForm : Form, IDEControl
    {
        AssemblerConfigForm configForm = new AssemblerConfigForm();

        public Assembler Assembler
        {
            get
            {
                return new Assembler(configForm.Config)
                {
                    Text = this.txtInputAssembly.Text
                };
            }
        }

        #region IDEControl
        public void Process(AssemblerGroup group)
        {
            group.Add(this.Assembler);
        }
        public int GetOrder()
        {
            try
            {
                return Convert.ToInt32(txtOrder.Text);
            }
            catch (FormatException)
            {
                return 0;
            }
        }
        #endregion

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

    }
}
