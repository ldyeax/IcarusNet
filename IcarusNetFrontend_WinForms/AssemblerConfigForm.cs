using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assembler6502Net;

namespace IcarusNetFrontend_Winforms
{
    public partial class AssemblerConfigForm : Form
    {
        public AssemblerConfigForm(AssemblerConfig conf)
        {
            _config = conf;
            InitializeComponent();
        }

        private AssemblerConfig _config;

        public AssemblerConfig Config
        {
            get
            {
                int startaddr = 0;
                try
                {
                    startaddr = Convert.ToInt32(txtStartAddr.Text);
                }
                catch (FormatException)
                {
                    try
                    {
                        startaddr = Convert.ToInt32(txtStartAddr.Text, 16);
                    }
                    catch (FormatException)
                    {
                        startaddr = 0;
                        MessageBox.Show(this.ParentForm, "Invalid starting address");
                    }
                }

                return new AssemblerConfig()
                {
                     OperandLength = 
                        lbAddressingOptions.SelectedItem != null ?
                            (AssemblerConfig.OperandLengthOption)
                                Enum.Parse(typeof(AssemblerConfig.OperandLengthOption),
                                    lbAddressingOptions.SelectedItem.ToString()
                                )
                            :
                            AssemblerConfig.OperandLengthOption.AsWritten,

                    ReallocateIfOutOfBounds = rbFilesize.Checked,

                    FileStartAddress = startaddr
                };
            }
        }

        private void AssemblerConfigForm_Load(object sender, EventArgs e)
        {
            foreach (string s in Enum.GetNames(typeof(AssemblerConfig.OperandLengthOption)))
                lbAddressingOptions.Items.Add(s);

            lbAddressingOptions.SelectedItem = lbAddressingOptions.Items.OfType<object>().Where(o => o.ToString() == _config.OperandLength.ToString()).First();
            rbFilesize.Checked =  _config.ReallocateIfOutOfBounds;
            txtStartAddr.Text = "0x" + Convert.ToString(_config.FileStartAddress, 16);
        }
    }
}
