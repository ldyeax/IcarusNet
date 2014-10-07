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
            this.components = new System.ComponentModel.Container();
            this.lbProjectControls = new System.Windows.Forms.ListBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlComponentZoo = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.toolstrip_new = new System.Windows.Forms.MenuItem();
            this.toolstrip_open = new System.Windows.Forms.MenuItem();
            this.toolstrip_saveProject = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.toolstrip_newAssemblySource = new System.Windows.Forms.MenuItem();
            this.toolstrip_generateHeaderFooterAssemblySource = new System.Windows.Forms.MenuItem();
            this.toolstrip_addIPS = new System.Windows.Forms.MenuItem();
            this.toolstrip_addExistingAssemblySource = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.toolstrip_build = new System.Windows.Forms.MenuItem();
            this.toolstrip_buildAndRun = new System.Windows.Forms.MenuItem();
            this.toolstrip_buildOptions = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.toolstrip_help = new System.Windows.Forms.MenuItem();
            this.toolstrip_about = new System.Windows.Forms.MenuItem();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnHexEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProjectControls
            // 
            this.lbProjectControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProjectControls.FormattingEnabled = true;
            this.lbProjectControls.Location = new System.Drawing.Point(971, 33);
            this.lbProjectControls.Name = "lbProjectControls";
            this.lbProjectControls.Size = new System.Drawing.Size(126, 550);
            this.lbProjectControls.TabIndex = 16;
            this.lbProjectControls.Tag = "NeedOpenProject";
            this.lbProjectControls.SelectedIndexChanged += new System.EventHandler(this.lbProjectControls_SelectedIndexChanged);
            this.lbProjectControls.DoubleClick += new System.EventHandler(this.lbProjectControls_DoubleClick);
            this.lbProjectControls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbProjectControls_KeyDown);
            this.lbProjectControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbProjectControls_MouseDown);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(971, 584);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(63, 23);
            this.btnUp.TabIndex = 18;
            this.btnUp.Tag = "NeedOpenProject";
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(1034, 584);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(63, 23);
            this.btnDown.TabIndex = 19;
            this.btnDown.Tag = "NeedOpenProject";
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // pnlComponentZoo
            // 
            this.pnlComponentZoo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComponentZoo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComponentZoo.Location = new System.Drawing.Point(0, 7);
            this.pnlComponentZoo.Name = "pnlComponentZoo";
            this.pnlComponentZoo.Size = new System.Drawing.Size(959, 505);
            this.pnlComponentZoo.TabIndex = 20;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.toolstrip_new,
            this.toolstrip_open,
            this.toolstrip_saveProject});
            this.menuItem1.Text = "File";
            // 
            // toolstrip_new
            // 
            this.toolstrip_new.Index = 0;
            this.toolstrip_new.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.toolstrip_new.Text = "New";
            this.toolstrip_new.Click += new System.EventHandler(this.toolstrip_new_Click);
            // 
            // toolstrip_open
            // 
            this.toolstrip_open.Index = 1;
            this.toolstrip_open.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.toolstrip_open.Text = "Open";
            this.toolstrip_open.Click += new System.EventHandler(this.toolstrip_open_Click);
            // 
            // toolstrip_saveProject
            // 
            this.toolstrip_saveProject.Index = 2;
            this.toolstrip_saveProject.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.toolstrip_saveProject.Text = "Save";
            this.toolstrip_saveProject.Click += new System.EventHandler(this.toolstrip_saveProject_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.toolstrip_newAssemblySource,
            this.toolstrip_generateHeaderFooterAssemblySource,
            this.toolstrip_addIPS,
            this.toolstrip_addExistingAssemblySource});
            this.menuItem4.Text = "Project";
            // 
            // toolstrip_newAssemblySource
            // 
            this.toolstrip_newAssemblySource.Index = 0;
            this.toolstrip_newAssemblySource.Text = "New Assembly Source";
            this.toolstrip_newAssemblySource.Click += new System.EventHandler(this.toolstrip_newAssemblySource_Click);
            // 
            // toolstrip_generateHeaderFooterAssemblySource
            // 
            this.toolstrip_generateHeaderFooterAssemblySource.Index = 1;
            this.toolstrip_generateHeaderFooterAssemblySource.Text = "Generate Header/Footer Assembly Source";
            this.toolstrip_generateHeaderFooterAssemblySource.Click += new System.EventHandler(this.toolstrip_generateHeaderFooterAssemblySource_Click);
            // 
            // toolstrip_addIPS
            // 
            this.toolstrip_addIPS.Index = 2;
            this.toolstrip_addIPS.Text = "Add IPS File";
            this.toolstrip_addIPS.Click += new System.EventHandler(this.toolstrip_addIPS_Click);
            // 
            // toolstrip_addExistingAssemblySource
            // 
            this.toolstrip_addExistingAssemblySource.Index = 3;
            this.toolstrip_addExistingAssemblySource.Text = "Add Existing Assembly Source";
            this.toolstrip_addExistingAssemblySource.Click += new System.EventHandler(this.toolstrip_addExistingAssemblySource_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.toolstrip_build,
            this.toolstrip_buildAndRun,
            this.toolstrip_buildOptions});
            this.menuItem2.Text = "Build";
            // 
            // toolstrip_build
            // 
            this.toolstrip_build.Index = 0;
            this.toolstrip_build.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftB;
            this.toolstrip_build.Text = "Build";
            this.toolstrip_build.Click += new System.EventHandler(this.toolstrip_build_Click);
            // 
            // toolstrip_buildAndRun
            // 
            this.toolstrip_buildAndRun.Index = 1;
            this.toolstrip_buildAndRun.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.toolstrip_buildAndRun.Text = "Build and Run";
            this.toolstrip_buildAndRun.Click += new System.EventHandler(this.toolstrip_buildAndRun_Click);
            // 
            // toolstrip_buildOptions
            // 
            this.toolstrip_buildOptions.Index = 2;
            this.toolstrip_buildOptions.Text = "Options";
            this.toolstrip_buildOptions.Click += new System.EventHandler(this.toolstrip_buildOptions_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.toolstrip_help,
            this.toolstrip_about});
            this.menuItem3.Text = "Help";
            // 
            // toolstrip_help
            // 
            this.toolstrip_help.Index = 0;
            this.toolstrip_help.Text = "Help";
            this.toolstrip_help.Click += new System.EventHandler(this.toolstrip_help_Click);
            // 
            // toolstrip_about
            // 
            this.toolstrip_about.Index = 1;
            this.toolstrip_about.Text = "About";
            this.toolstrip_about.Click += new System.EventHandler(this.toolstrip_about_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(0, 518);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(959, 89);
            this.txtOutput.TabIndex = 21;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // btnHexEditor
            // 
            this.btnHexEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHexEditor.Location = new System.Drawing.Point(971, 7);
            this.btnHexEditor.Name = "btnHexEditor";
            this.btnHexEditor.Size = new System.Drawing.Size(126, 23);
            this.btnHexEditor.TabIndex = 22;
            this.btnHexEditor.Tag = "NeedOpenProject";
            this.btnHexEditor.Text = "Hex Editor (HxD)";
            this.btnHexEditor.UseVisualStyleBackColor = true;
            this.btnHexEditor.Click += new System.EventHandler(this.btnHexEditor_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 610);
            this.Controls.Add(this.btnHexEditor);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.pnlComponentZoo);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lbProjectControls);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "MainWindow";
            this.Text = "IcarusNet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbProjectControls;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel pnlComponentZoo;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem toolstrip_open;
        private System.Windows.Forms.MenuItem toolstrip_saveProject;
        private System.Windows.Forms.MenuItem toolstrip_new;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem toolstrip_build;
        private System.Windows.Forms.MenuItem toolstrip_buildAndRun;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem toolstrip_help;
        private System.Windows.Forms.MenuItem toolstrip_about;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.MenuItem toolstrip_buildOptions;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem toolstrip_newAssemblySource;
        private System.Windows.Forms.MenuItem toolstrip_generateHeaderFooterAssemblySource;
        private System.Windows.Forms.MenuItem toolstrip_addIPS;
        private System.Windows.Forms.MenuItem toolstrip_addExistingAssemblySource;
        private System.Windows.Forms.Button btnHexEditor;
    }
}

