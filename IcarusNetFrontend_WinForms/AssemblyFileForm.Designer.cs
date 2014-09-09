namespace IcarusNetFrontend_Winforms
{
    partial class AssemblyFileForm
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
            this.txtInputAssembly = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtLineNumbers = new RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers ();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.txtHexValues = new RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers ();
            this.txtStartAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFilesize = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAddressingPreference = new System.Windows.Forms.ComboBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInputAssembly
            // 
            this.txtInputAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputAssembly.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputAssembly.HideSelection = false;
            this.txtInputAssembly.Location = new System.Drawing.Point(110, 41);
            this.txtInputAssembly.Name = "txtInputAssembly";
            this.txtInputAssembly.Size = new System.Drawing.Size(441, 377);
            this.txtInputAssembly.TabIndex = 9;
            this.txtInputAssembly.Text = "";
            this.txtInputAssembly.SizeChanged += new System.EventHandler(this.txtInputAssembly_SizeChanged);
            this.txtInputAssembly.TextChanged += new System.EventHandler(this.txtInputAssembly_TextChanged);
            this.txtInputAssembly.Enter += new System.EventHandler(this.bringToFrontEvent);
            this.txtInputAssembly.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInputAssembly_KeyUp);
            this.txtInputAssembly.Leave += new System.EventHandler(this.txtInputAssembly_Leave);
            this.txtInputAssembly.Resize += new System.EventHandler(this.txtInputAssembly_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Order:";
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(42, -1);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(26, 20);
            this.txtOrder.TabIndex = 12;
            this.txtOrder.Text = "0";
            this.txtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrder_KeyPress);
            // 
            // txtLineNumbers
            // 
            this.txtLineNumbers._SeeThroughMode_ = false;
            this.txtLineNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLineNumbers.AutoSizing = false;
            this.txtLineNumbers.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtLineNumbers.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.txtLineNumbers.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.txtLineNumbers.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.txtLineNumbers.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.txtLineNumbers.BorderLines_Thickness = 1F;
            this.txtLineNumbers.DockSide = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Left;
            this.txtLineNumbers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineNumbers.GridLines_Color = System.Drawing.Color.SlateGray;
            this.txtLineNumbers.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.txtLineNumbers.GridLines_Thickness = 1F;
            this.txtLineNumbers.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.txtLineNumbers.LineNrs_AntiAlias = true;
            this.txtLineNumbers.LineNrs_AsHexadecimal = false;
            this.txtLineNumbers.LineNrs_ClippedByItemRectangle = true;
            this.txtLineNumbers.LineNrs_LeadingZeroes = true;
            this.txtLineNumbers.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.txtLineNumbers.Location = new System.Drawing.Point(-2, 41);
            this.txtLineNumbers.Margin = new System.Windows.Forms.Padding(0);
            this.txtLineNumbers.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.txtLineNumbers.MarginLines_Side = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Right;
            this.txtLineNumbers.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.txtLineNumbers.MarginLines_Thickness = 1F;
            this.txtLineNumbers.Name = "txtLineNumbers";
            this.txtLineNumbers.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.txtLineNumbers.ParentRichTextBox = this.txtInputAssembly;
            this.txtLineNumbers.Show_BackgroundGradient = false;
            this.txtLineNumbers.Show_BorderLines = false;
            this.txtLineNumbers.Show_GridLines = true;
            this.txtLineNumbers.Show_LineNrs = true;
            this.txtLineNumbers.Show_MarginLines = true;
            this.txtLineNumbers.Size = new System.Drawing.Size(111, 377);
            this.txtLineNumbers.TabIndex = 13;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorOutput.BackColor = System.Drawing.Color.LightGray;
            this.lblErrorOutput.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOutput.Location = new System.Drawing.Point(12, 425);
            this.lblErrorOutput.Margin = new System.Windows.Forms.Padding(0);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(602, 62);
            this.lblErrorOutput.TabIndex = 14;
            this.lblErrorOutput.Text = "(Output)";
            // 
            // txtHexValues
            // 
            this.txtHexValues._SeeThroughMode_ = false;
            this.txtHexValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHexValues.AutoSizing = false;
            this.txtHexValues.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtHexValues.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.txtHexValues.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.txtHexValues.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.txtHexValues.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.txtHexValues.BorderLines_Thickness = 1F;
            this.txtHexValues.DockSide = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Right;
            this.txtHexValues.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHexValues.GridLines_Color = System.Drawing.Color.SlateGray;
            this.txtHexValues.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.txtHexValues.GridLines_Thickness = 1F;
            this.txtHexValues.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.txtHexValues.LineNrs_AntiAlias = true;
            this.txtHexValues.LineNrs_AsHexadecimal = false;
            this.txtHexValues.LineNrs_ClippedByItemRectangle = true;
            this.txtHexValues.LineNrs_LeadingZeroes = true;
            this.txtHexValues.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.txtHexValues.Location = new System.Drawing.Point(552, 41);
            this.txtHexValues.Margin = new System.Windows.Forms.Padding(0);
            this.txtHexValues.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.txtHexValues.MarginLines_Side = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Right;
            this.txtHexValues.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.txtHexValues.MarginLines_Thickness = 1F;
            this.txtHexValues.Name = "txtHexValues";
            this.txtHexValues.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.txtHexValues.ParentRichTextBox = this.txtInputAssembly;
            this.txtHexValues.Show_BackgroundGradient = false;
            this.txtHexValues.Show_BorderLines = false;
            this.txtHexValues.Show_GridLines = true;
            this.txtHexValues.Show_LineNrs = true;
            this.txtHexValues.Show_MarginLines = true;
            this.txtHexValues.Size = new System.Drawing.Size(70, 377);
            this.txtHexValues.TabIndex = 13;
            // 
            // txtStartAddr
            // 
            this.txtStartAddr.Location = new System.Drawing.Point(110, 15);
            this.txtStartAddr.Name = "txtStartAddr";
            this.txtStartAddr.Size = new System.Drawing.Size(136, 20);
            this.txtStartAddr.TabIndex = 20;
            this.txtStartAddr.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "File offset (eg. for header):";
            // 
            // rbFilesize
            // 
            this.rbFilesize.AutoSize = true;
            this.rbFilesize.Location = new System.Drawing.Point(379, 19);
            this.rbFilesize.Name = "rbFilesize";
            this.rbFilesize.Size = new System.Drawing.Size(126, 17);
            this.rbFilesize.TabIndex = 21;
            this.rbFilesize.TabStop = true;
            this.rbFilesize.Text = "Allow Expand Filesize";
            this.rbFilesize.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Addressing Preference:";
            // 
            // cbAddressingPreference
            // 
            this.cbAddressingPreference.FormattingEnabled = true;
            this.cbAddressingPreference.Location = new System.Drawing.Point(252, 15);
            this.cbAddressingPreference.Name = "cbAddressingPreference";
            this.cbAddressingPreference.Size = new System.Drawing.Size(121, 21);
            this.cbAddressingPreference.TabIndex = 24;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "0x";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(539, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 26;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "File : NES";
            // 
            // AssemblyFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 496);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbAddressingPreference);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbFilesize);
            this.Controls.Add(this.txtStartAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHexValues);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.txtLineNumbers);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputAssembly);
            this.Name = "AssemblyFileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.AssemblyFileForm_Load);
            this.ResizeEnd += new System.EventHandler(this.AssemblyFileForm_ResizeEnd);
            this.Move += new System.EventHandler(this.AssemblyFileForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.RichTextBox txtInputAssembly;
        private RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers txtLineNumbers;
        private System.Windows.Forms.Label lblErrorOutput;
        private RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers txtHexValues;
        private System.Windows.Forms.TextBox txtStartAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbFilesize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAddressingPreference;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label5;
    }
}