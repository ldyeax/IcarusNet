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
    public partial class HexEditorForm : Form
    {
        public HexEditorForm()
        {
            InitializeComponent();
        }

        public Be.Windows.Forms.HexBox HexEditor;

        private void HexEditorForm_Load(object sender, EventArgs e)
        {
            HexEditor = this.HexBox;

        }

    }
}
