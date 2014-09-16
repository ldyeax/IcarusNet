using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using IcarusNetProject;

namespace IcarusNetFrontend_Winforms
{
    [IcarusNetComponent(typeof(IcarusNetProject.Components.IPSPatcher))]
    public partial class IPSFileForm : Form, IProjectComponentForm
    {
        public IPSFileForm()
        {
            InitializeComponent();
        }

        void setText(string fn)
        {
            try
            {
                FileInfo fi = new FileInfo(fn);
                if (cbRelative.Checked)
                {
                    txtFilePath.Text = fi.Name;
                }
                else
                {
                    txtFilePath.Text = fi.FullName;
                }

                this.icarusNetComponent.FilePath = txtFilePath.Text;

                lblOutput.Text = "OK";
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error with file." + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace;
                txtFilePath.Text = "";
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFilePath.Text = this.openFileDialog.FileName;
            }
        }

        private void IPSFileForm_Load(object sender, EventArgs e)
        {

        }

        #region overrides

        private IcarusNetProject.Components.IPSPatcher icarusNetComponent;

        public IcarusNetProject.Components.Component GetComponent()
        {
            return icarusNetComponent;
        }

        public void Initialize(IcarusNetProject.Components.Component component)
        {
            this.icarusNetComponent = (IcarusNetProject.Components.IPSPatcher)component;
            setText(this.icarusNetComponent.FilePath);
        }

        #endregion

        private void cbRelative_CheckedChanged(object sender, EventArgs e)
        {
            if (txtFilePath.Text.Length > 0)
            {
                setText(txtFilePath.Text);
            }
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            this.icarusNetComponent.FilePath = txtFilePath.Text;

            this.icarusNetComponent.FileNameToName();
        }
    }
}
