namespace IcarusNet
{
    partial class Form1
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
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.lbAddr1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.rbFilesize1 = new System.Windows.Forms.RadioButton();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.rbFilesize2 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAddr2 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput1
            // 
            this.txtInput1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput1.Location = new System.Drawing.Point(13, 13);
            this.txtInput1.Multiline = true;
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(397, 166);
            this.txtInput1.TabIndex = 0;
            this.txtInput1.Text = "place = $100\r\n* = $20\r\nyes:\r\nLDA #$04\r\nBNE no\r\nTAY\r\nTAX\r\nINX\r\nSTA place\r\njmp yes\r" +
    "\nno:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(580, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Assemble";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hexBox1
            // 
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.Location = new System.Drawing.Point(580, 49);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(517, 317);
            this.hexBox1.TabIndex = 3;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // lbAddr1
            // 
            this.lbAddr1.FormattingEnabled = true;
            this.lbAddr1.Location = new System.Drawing.Point(5, 20);
            this.lbAddr1.Name = "lbAddr1";
            this.lbAddr1.Size = new System.Drawing.Size(122, 56);
            this.lbAddr1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alpha version of 6502  IDE. Assembles correctly as far as I know. ldyeax@gmail.co" +
    "m\r\nOutput dumped to output.bin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFileSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(869, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 30);
            this.panel1.TabIndex = 6;
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(54, 4);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(64, 20);
            this.txtFileSize.TabIndex = 1;
            this.txtFileSize.Text = "1024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filesize:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbAddr1);
            this.panel2.Location = new System.Drawing.Point(416, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 80);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Addressing Preference:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(711, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Clear Bytes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbFilesize1
            // 
            this.rbFilesize1.AutoSize = true;
            this.rbFilesize1.Location = new System.Drawing.Point(416, 98);
            this.rbFilesize1.Name = "rbFilesize1";
            this.rbFilesize1.Size = new System.Drawing.Size(126, 17);
            this.rbFilesize1.TabIndex = 0;
            this.rbFilesize1.TabStop = true;
            this.rbFilesize1.Text = "Allow Expand Filesize";
            this.rbFilesize1.UseVisualStyleBackColor = true;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblErrorOutput.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOutput.Location = new System.Drawing.Point(12, 434);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(986, 136);
            this.lblErrorOutput.TabIndex = 10;
            // 
            // txtInput2
            // 
            this.txtInput2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput2.Location = new System.Drawing.Point(12, 200);
            this.txtInput2.Multiline = true;
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(397, 166);
            this.txtInput2.TabIndex = 11;
            this.txtInput2.Text = "place = $100\r\n* = $100\r\nTAY\r\nTAY\r\nINX\r\njmp yes\r\n";
            // 
            // rbFilesize2
            // 
            this.rbFilesize2.AutoSize = true;
            this.rbFilesize2.Location = new System.Drawing.Point(417, 288);
            this.rbFilesize2.Name = "rbFilesize2";
            this.rbFilesize2.Size = new System.Drawing.Size(126, 17);
            this.rbFilesize2.TabIndex = 12;
            this.rbFilesize2.TabStop = true;
            this.rbFilesize2.Text = "Allow Expand Filesize";
            this.rbFilesize2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lbAddr2);
            this.panel3.Location = new System.Drawing.Point(415, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 82);
            this.panel3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Addressing Preference:";
            // 
            // lbAddr2
            // 
            this.lbAddr2.FormattingEnabled = true;
            this.lbAddr2.Location = new System.Drawing.Point(4, 20);
            this.lbAddr2.Name = "lbAddr2";
            this.lbAddr2.Size = new System.Drawing.Size(122, 56);
            this.lbAddr2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 579);
            this.Controls.Add(this.rbFilesize2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.rbFilesize1);
            this.Controls.Add(this.txtInput2);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hexBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtInput1);
            this.Name = "Form1";
            this.Text = "IcarusNet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.Button button1;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.ListBox lbAddr1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbFilesize1;
        private System.Windows.Forms.Label lblErrorOutput;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.RadioButton rbFilesize2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbAddr2;
    }
}

