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
            bytes = new byte[FileSize];
        }

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

        Assembler myAssembler;

        private void button1_Click(object sender, EventArgs e)
        {
            if (FileSize > bytes.Length)
            {
                var newbytes = new byte[FileSize];
                Array.Copy(bytes, newbytes, bytes.Length);
                bytes = newbytes;
            }

            try
            {
                myAssembler = new Assembler(
                    ref bytes,
                    new AssemblerConfig()
                    {
                        OperandLength =
                            (AssemblerConfig.OperandLengthOption)Enum.Parse(
                                typeof(AssemblerConfig.OperandLengthOption),
                                listBox1.SelectedItem.ToString()
                            ),
                        ReallocateIfOutOfBounds = radioButton1.Checked
                    }
                );

                myAssembler.Assemble(txtInput.Text);

                System.IO.File.WriteAllBytes("output.bin", bytes);

                Be.Windows.Forms.DynamicByteProvider bp = new Be.Windows.Forms.DynamicByteProvider(bytes);
                hexBox1.ByteProvider = bp;
            }
            catch (Assembler6502Net.SyntaxErrorException ex)
            {
                lblErrorOutput.Text = "Error on line " + (ex.Line + 1) + ":\n" + ex.Message + "\n";
                if (ex.InnerException != null)
                    lblErrorOutput.Text += ex.InnerException.Message;
                string line = txtInput.Text.Split('\n')[ex.Line];
                //int start = txtInput.Text.IndexOf(line);
                txtInput.SelectionStart = txtInput.GetFirstCharIndexFromLine(ex.Line);
                txtInput.SelectionLength = line.Length;
                txtInput.HideSelection = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bytes = new byte[FileSize];
        }
    }
}
