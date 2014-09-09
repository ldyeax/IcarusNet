namespace IcarusNetFrontend_Winforms
{
    partial class IPSFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.cbRelative = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(466, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(83, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(372, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // cbRelative
            // 
            this.cbRelative.AutoSize = true;
            this.cbRelative.Location = new System.Drawing.Point(12, 14);
            this.cbRelative.Name = "cbRelative";
            this.cbRelative.Size = new System.Drawing.Size(65, 17);
            this.cbRelative.TabIndex = 2;
            this.cbRelative.Text = "Relative";
            this.cbRelative.UseVisualStyleBackColor = true;
            this.cbRelative.CheckedChanged += new System.EventHandler(this.cbRelative_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "IPS files|*.ips|All files|*.*";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(13, 49);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(40, 13);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "Get file";
            // 
            // IPSFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 74);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.cbRelative);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Name = "IPSFileForm";
            this.Text = "IPSFileForm";
            this.Load += new System.EventHandler(this.IPSFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.CheckBox cbRelative;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblOutput;
    }
}