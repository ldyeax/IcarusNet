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
    public partial class HexEditorForm : Form, IDEControl
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

        #region IDEControl
        public void Process(AssemblerGroup group)
        {
            group.OnAssembleFinished += () =>
            {
                HexEditor.ByteProvider = new Be.Windows.Forms.DynamicByteProvider(group.Bytes);
            };
        }
        public int GetOrder()
        {
            return int.MaxValue;
        }
        #endregion
    }
}
