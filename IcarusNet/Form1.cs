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
                lbAddr1.Items.Add(s);
                lbAddr2.Items.Add(s);
            }
            lbAddr1.SelectedIndex = 0;
            lbAddr2.SelectedIndex = 0;

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

        Assembler assemblerFromControls(TextBox textBox, ListBox listBox, RadioButton radioButton)
        {
            return new Assembler(
                new AssemblerConfig()
                {
                    OperandLength =
                        (AssemblerConfig.OperandLengthOption)Enum.Parse(
                            typeof(AssemblerConfig.OperandLengthOption),
                            listBox.SelectedItem.ToString()
                        ),
                    ReallocateIfOutOfBounds = radioButton.Checked
                }
            ) { 
                Text = textBox.Text
            };
        }

        void doThing(ref Assembler myAssembler, TextBox textBox, ListBox listBox, RadioButton radioButton)
        {
            //if (FileSize > bytes.Length)
            //{
            //    var newbytes = new byte[FileSize];
            //    Array.Copy(bytes, newbytes, bytes.Length);
            //    bytes = newbytes;
            //}

            //try
            //{
            //    myAssembler = new Assembler(
            //        ref bytes,
            //        new AssemblerConfig()
            //        {
            //            OperandLength =
            //                (AssemblerConfig.OperandLengthOption)Enum.Parse(
            //                    typeof(AssemblerConfig.OperandLengthOption),
            //                    listBox.SelectedItem.ToString()
            //                ),
            //            ReallocateIfOutOfBounds = radioButton.Checked
            //        }
            //    );

            //    myAssembler.FirstPass(textBox.Text);
            //    myAssembler.Assemble();

            //    System.IO.File.WriteAllBytes("output.bin", bytes);

            //    Be.Windows.Forms.DynamicByteProvider bp = new Be.Windows.Forms.DynamicByteProvider(bytes);
            //    hexBox1.ByteProvider = bp;
            //}
            //catch (Assembler6502Net.SyntaxErrorException ex)
            //{
            //    lblErrorOutput.Text = "Error on line " + (ex.Line + 1) + ":\n" + ex.Message + "\n";
            //    if (ex.InnerException != null)
            //        lblErrorOutput.Text += ex.InnerException.Message;
            //    string line = textBox.Text.Split('\n')[ex.Line];
            //    //int start = txtInput.Text.IndexOf(line);
            //    textBox.SelectionStart = txtInput1.GetFirstCharIndexFromLine(ex.Line);
            //    textBox.SelectionLength = line.Length;
            //    textBox.HideSelection = false;
            //}
        }

        void catchError(Action action)
        {
            try
            {
                action();
            }
            catch (Assembler6502Net.SyntaxErrorException ex)
            {
                lblErrorOutput.Text = "Error on line " + (ex.Line + 1) + ":\n" + ex.Message + "\n";
                if (ex.InnerException != null)
                    lblErrorOutput.Text += ex.InnerException.Message;
                //string line = textBox.Text.Split('\n')[ex.Line];
                ////int start = txtInput.Text.IndexOf(line);
                //textBox.SelectionStart = txtInput1.GetFirstCharIndexFromLine(ex.Line);
                //textBox.SelectionLength = line.Length;
                //textBox.HideSelection = false;
            }
        }

        AssemblerGroup group;
        private void button1_Click(object sender, EventArgs e)
        {
            //doThing(ref Assembler1, txtInput1, lbAddr1, rbFilesize1);

            if (FileSize > bytes.Length)
            {
                var newbytes = new byte[FileSize];
                Array.Copy(bytes, newbytes, bytes.Length);
                bytes = newbytes;
            }

            group = new AssemblerGroup(bytes);
            group.Add(assemblerFromControls(txtInput1, lbAddr1, rbFilesize1));
            group.Add(assemblerFromControls(txtInput2, lbAddr2, rbFilesize2));

            group.Assemble();

            Be.Windows.Forms.DynamicByteProvider bp = new Be.Windows.Forms.DynamicByteProvider(bytes);
            hexBox1.ByteProvider = bp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bytes = new byte[FileSize];
        }

    }
}
