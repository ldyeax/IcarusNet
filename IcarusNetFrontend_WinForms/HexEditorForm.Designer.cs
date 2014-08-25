namespace IcarusNetFrontend_Winforms
{
    partial class HexEditorForm
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
            this.HexBox = new Be.Windows.Forms.HexBox();
            this.SuspendLayout();
            // 
            // HexBox
            // 
            this.HexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HexBox.ColumnInfoVisible = true;
            this.HexBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HexBox.LineInfoVisible = true;
            this.HexBox.Location = new System.Drawing.Point(12, 12);
            this.HexBox.Name = "HexBox";
            this.HexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.HexBox.Size = new System.Drawing.Size(616, 466);
            this.HexBox.TabIndex = 4;
            this.HexBox.UseFixedBytesPerLine = true;
            this.HexBox.VScrollBarVisible = true;
            // 
            // HexEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 490);
            this.Controls.Add(this.HexBox);
            this.Name = "HexEditorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "HexEditorForm";
            this.Load += new System.EventHandler(this.HexEditorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Be.Windows.Forms.HexBox HexBox;
    }
}