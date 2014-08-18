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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string s in Enum.GetNames(typeof(Assembler6502Net.AssemblerConfig.OperandLengthOption)))
            {
                listBox1.Items.Add(s);
            }
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                Assembler a = new Assembler(new AssemblerConfig()
                {
                    OperandLength =
                        (AssemblerConfig.OperandLengthOption)Enum.Parse(
                            typeof(AssemblerConfig.OperandLengthOption),
                            listBox1.SelectedItem.ToString()
                        )
                });

                var bytes = a.Assemble(textBox1.Text);

                System.IO.File.WriteAllBytes("output.bin", bytes);

                Be.Windows.Forms.DynamicByteProvider bp = new Be.Windows.Forms.DynamicByteProvider(bytes);
                hexBox1.ByteProvider = bp;
            }
            catch (Assembler6502Net.SyntaxErrorException ex)
            {
                MessageBox.Show("Error on line " + (ex.Line + 1));
            }

        }
    }
}
