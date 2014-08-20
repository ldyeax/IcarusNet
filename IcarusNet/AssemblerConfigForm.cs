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
    public partial class AssemblerConfigForm : Form
    {
        public AssemblerConfigForm()
        {
            InitializeComponent();
        }

        public AssemblerConfig Config
        {
            get
            {
                if (lbAddressingOptions.SelectedItem == null)
                    return new AssemblerConfig()
                    {
                         ReallocateIfOutOfBounds = rbFilesize.Checked
                    };

                return new AssemblerConfig()
                {
                     OperandLength = (AssemblerConfig.OperandLengthOption)
                        Enum.Parse(typeof(AssemblerConfig.OperandLengthOption),
                            lbAddressingOptions.SelectedItem.ToString()
                        ),
                    ReallocateIfOutOfBounds = rbFilesize.Checked
                };
            }
        }

        private void AssemblerConfigForm_Load(object sender, EventArgs e)
        {
            foreach (string s in Enum.GetNames(typeof(AssemblerConfig.OperandLengthOption)))
                lbAddressingOptions.Items.Add(s);
            
        }
    }
}
