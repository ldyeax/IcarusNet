namespace IcarusNetFrontend_Winforms
{
    partial class AssemblerConfigForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.rbFilesize = new System.Windows.Forms.RadioButton();
            this.lbAddressingOptions = new System.Windows.Forms.ListBox();
            this.txtStartAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Addressing Preference:";
            // 
            // rbFilesize
            // 
            this.rbFilesize.AutoSize = true;
            this.rbFilesize.Location = new System.Drawing.Point(154, 17);
            this.rbFilesize.Name = "rbFilesize";
            this.rbFilesize.Size = new System.Drawing.Size(126, 17);
            this.rbFilesize.TabIndex = 11;
            this.rbFilesize.TabStop = true;
            this.rbFilesize.Text = "Allow Expand Filesize";
            this.rbFilesize.UseVisualStyleBackColor = true;
            // 
            // lbAddressingOptions
            // 
            this.lbAddressingOptions.FormattingEnabled = true;
            this.lbAddressingOptions.Location = new System.Drawing.Point(12, 33);
            this.lbAddressingOptions.Name = "lbAddressingOptions";
            this.lbAddressingOptions.Size = new System.Drawing.Size(122, 56);
            this.lbAddressingOptions.TabIndex = 9;
            // 
            // txtStartAddr
            // 
            this.txtStartAddr.Location = new System.Drawing.Point(130, 103);
            this.txtStartAddr.Name = "txtStartAddr";
            this.txtStartAddr.Size = new System.Drawing.Size(136, 20);
            this.txtStartAddr.TabIndex = 18;
            this.txtStartAddr.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "File starting address:";
            // 
            // AssemblerConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 135);
            this.Controls.Add(this.txtStartAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbFilesize);
            this.Controls.Add(this.lbAddressingOptions);
            this.Name = "AssemblerConfigForm";
            this.Text = "AssemblerConfigForm";
            this.Load += new System.EventHandler(this.AssemblerConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbFilesize;
        private System.Windows.Forms.ListBox lbAddressingOptions;
        private System.Windows.Forms.TextBox txtStartAddr;
        private System.Windows.Forms.Label label2;
    }
}