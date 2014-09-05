namespace IcarusNetFrontend_Winforms
{
    partial class NewProjectForm
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtCreateUnder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.txtOutputFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMakeCopy = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(533, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtCreateUnder
            // 
            this.txtCreateUnder.Location = new System.Drawing.Point(16, 21);
            this.txtCreateUnder.Name = "txtCreateUnder";
            this.txtCreateUnder.Size = new System.Drawing.Size(342, 20);
            this.txtCreateUnder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create under:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(16, 77);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(342, 20);
            this.txtProjectName.TabIndex = 4;
            this.txtProjectName.Text = "MyNewProject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Input file:";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(16, 135);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(342, 20);
            this.txtInputFile.TabIndex = 6;
            // 
            // txtOutputFileName
            // 
            this.txtOutputFileName.Location = new System.Drawing.Point(16, 197);
            this.txtOutputFileName.Name = "txtOutputFileName";
            this.txtOutputFileName.Size = new System.Drawing.Size(342, 20);
            this.txtOutputFileName.TabIndex = 8;
            this.txtOutputFileName.Text = "MyNewProjectRom.nes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output filename:";
            // 
            // cbMakeCopy
            // 
            this.cbMakeCopy.AutoSize = true;
            this.cbMakeCopy.Checked = true;
            this.cbMakeCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMakeCopy.Location = new System.Drawing.Point(364, 138);
            this.cbMakeCopy.Name = "cbMakeCopy";
            this.cbMakeCopy.Size = new System.Drawing.Size(79, 17);
            this.cbMakeCopy.TabIndex = 9;
            this.cbMakeCopy.Text = "Make copy";
            this.cbMakeCopy.UseVisualStyleBackColor = true;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 264);
            this.Controls.Add(this.cbMakeCopy);
            this.Controls.Add(this.txtOutputFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCreateUnder);
            this.Controls.Add(this.btnCreate);
            this.Name = "NewProjectForm";
            this.Text = "NewProjectForm";
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtCreateUnder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.TextBox txtOutputFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbMakeCopy;
    }
}