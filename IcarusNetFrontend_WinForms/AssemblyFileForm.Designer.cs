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
            this.txtInputAssembly = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInputAssembly
            // 
            this.txtInputAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputAssembly.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputAssembly.Location = new System.Drawing.Point(12, 41);
            this.txtInputAssembly.Multiline = true;
            this.txtInputAssembly.Name = "txtInputAssembly";
            this.txtInputAssembly.Size = new System.Drawing.Size(744, 443);
            this.txtInputAssembly.TabIndex = 9;
            this.txtInputAssembly.TextChanged += new System.EventHandler(this.txtInputAssembly_TextChanged);
            this.txtInputAssembly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputAssembly_KeyPress);
            this.txtInputAssembly.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInputAssembly_KeyUp);
            this.txtInputAssembly.Leave += new System.EventHandler(this.txtInputAssembly_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Config";
            this.button1.UseVisualStyleBackColor = true;
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
            // AssemblyFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 496);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
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

        private System.Windows.Forms.TextBox txtInputAssembly;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrder;
    }
}