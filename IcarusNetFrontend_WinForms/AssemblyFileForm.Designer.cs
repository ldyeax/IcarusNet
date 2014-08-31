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
            this.btnConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtLineNumbers = new RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.txtHexValues = new RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers();
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
            this.txtInputAssembly.Size = new System.Drawing.Size(586, 377);
            this.txtInputAssembly.TabIndex = 9;
            this.txtInputAssembly.Text = "";
            this.txtInputAssembly.SizeChanged += new System.EventHandler(this.txtInputAssembly_SizeChanged);
            this.txtInputAssembly.TextChanged += new System.EventHandler(this.txtInputAssembly_TextChanged);
            this.txtInputAssembly.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInputAssembly_KeyUp);
            this.txtInputAssembly.Leave += new System.EventHandler(this.txtInputAssembly_Leave);
            this.txtInputAssembly.Resize += new System.EventHandler(this.txtInputAssembly_Resize);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(681, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 10;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Order:";
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(56, 13);
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
            this.txtLineNumbers.DockSide = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Left;
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
            this.txtLineNumbers.MarginLines_Side = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Right;
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
            this.lblErrorOutput.Size = new System.Drawing.Size(747, 62);
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
            this.txtHexValues.DockSide = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Right;
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
            this.txtHexValues.Location = new System.Drawing.Point(697, 41);
            this.txtHexValues.Margin = new System.Windows.Forms.Padding(0);
            this.txtHexValues.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.txtHexValues.MarginLines_Side = RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers.LineNumberDockSide.Right;
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
            // AssemblyFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 496);
            this.Controls.Add(this.txtHexValues);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.txtLineNumbers);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.txtInputAssembly);
            this.Name = "AssemblyFileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AssemblyFileForm";
            this.Load += new System.EventHandler(this.AssemblyFileForm_Load);
            this.ResizeEnd += new System.EventHandler(this.AssemblyFileForm_ResizeEnd);
            this.Move += new System.EventHandler(this.AssemblyFileForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.RichTextBox txtInputAssembly;
        private RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers txtLineNumbers;
        private System.Windows.Forms.Label lblErrorOutput;
        private RichTextBoxWithLineNumbers.RichTextBoxWithLineNumbers txtHexValues;
    }
}