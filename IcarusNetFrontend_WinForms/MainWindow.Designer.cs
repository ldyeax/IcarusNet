namespace IcarusNetFrontend_Winforms
{
    partial class MainWindow
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
            this.btnBuild = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearBytes = new System.Windows.Forms.Button();
            this.btnAddAssembler = new System.Windows.Forms.Button();
            this.btnAddHexView = new System.Windows.Forms.Button();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Location = new System.Drawing.Point(711, 122);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(113, 23);
            this.btnBuild.TabIndex = 1;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alpha version of 6502  IDE. Assembles correctly as far as I know. ldyeax@gmail.co" +
    "m\r\nOutput dumped to output.bin";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtFileSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(695, 34);
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
            // btnClearBytes
            // 
            this.btnClearBytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearBytes.Location = new System.Drawing.Point(711, 85);
            this.btnClearBytes.Name = "btnClearBytes";
            this.btnClearBytes.Size = new System.Drawing.Size(113, 23);
            this.btnClearBytes.TabIndex = 8;
            this.btnClearBytes.Text = "Clear Bytes";
            this.btnClearBytes.UseVisualStyleBackColor = true;
            this.btnClearBytes.Click += new System.EventHandler(this.btnClearBytes_Click);
            // 
            // btnAddAssembler
            // 
            this.btnAddAssembler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAssembler.Location = new System.Drawing.Point(711, 151);
            this.btnAddAssembler.Name = "btnAddAssembler";
            this.btnAddAssembler.Size = new System.Drawing.Size(113, 23);
            this.btnAddAssembler.TabIndex = 11;
            this.btnAddAssembler.Text = "Add Assembler";
            this.btnAddAssembler.UseVisualStyleBackColor = true;
            this.btnAddAssembler.Click += new System.EventHandler(this.btnAddAssembler_Click);
            // 
            // btnAddHexView
            // 
            this.btnAddHexView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHexView.Location = new System.Drawing.Point(711, 180);
            this.btnAddHexView.Name = "btnAddHexView";
            this.btnAddHexView.Size = new System.Drawing.Size(113, 23);
            this.btnAddHexView.TabIndex = 12;
            this.btnAddHexView.Text = "Add Hex View";
            this.btnAddHexView.UseVisualStyleBackColor = true;
            this.btnAddHexView.Click += new System.EventHandler(this.btnAddHexView_Click);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Location = new System.Drawing.Point(12, 12);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(113, 23);
            this.btnNewProject.TabIndex = 13;
            this.btnNewProject.Text = "New";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Location = new System.Drawing.Point(12, 41);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(113, 23);
            this.btnOpenProject.TabIndex = 14;
            this.btnOpenProject.Text = "Open";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(12, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 579);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenProject);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.btnAddHexView);
            this.Controls.Add(this.btnAddAssembler);
            this.Controls.Add(this.btnClearBytes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuild);
            this.Name = "MainWindow";
            this.Text = "IcarusNet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearBytes;
        private System.Windows.Forms.Button btnAddAssembler;
        private System.Windows.Forms.Button btnAddHexView;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Button btnOpenProject;
        private System.Windows.Forms.Button btnSave;
    }
}

