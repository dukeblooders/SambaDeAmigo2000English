namespace SambAFSEditor
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnWorkingDir = new Button();
            btnOpenAFS = new Button();
            lblWorkingDir = new Label();
            lblAFSFile = new Label();
            panel = new Panel();
            treeContent = new TreeView();
            btnSaveAFS = new Button();
            btnPuyoTools = new Button();
            btnWorkingDirBrowse = new Button();
            btnOpenAFSBrowse = new Button();
            panelFile = new Panel();
            btnPNGConverter = new Button();
            btnLLKeywords = new Button();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // btnWorkingDir
            // 
            btnWorkingDir.Location = new Point(17, 16);
            btnWorkingDir.Name = "btnWorkingDir";
            btnWorkingDir.Size = new Size(175, 23);
            btnWorkingDir.TabIndex = 0;
            btnWorkingDir.Text = "Select working directory";
            btnWorkingDir.UseVisualStyleBackColor = true;
            btnWorkingDir.Click += btnWorkingDir_Click;
            // 
            // btnOpenAFS
            // 
            btnOpenAFS.Enabled = false;
            btnOpenAFS.Location = new Point(17, 45);
            btnOpenAFS.Name = "btnOpenAFS";
            btnOpenAFS.Size = new Size(175, 23);
            btnOpenAFS.TabIndex = 3;
            btnOpenAFS.Text = "Open AFS file";
            btnOpenAFS.UseVisualStyleBackColor = true;
            btnOpenAFS.Click += btnOpenAFS_Click;
            // 
            // lblWorkingDir
            // 
            lblWorkingDir.AutoSize = true;
            lblWorkingDir.Location = new Point(228, 20);
            lblWorkingDir.Name = "lblWorkingDir";
            lblWorkingDir.Size = new Size(12, 15);
            lblWorkingDir.TabIndex = 2;
            lblWorkingDir.Text = "-";
            // 
            // lblAFSFile
            // 
            lblAFSFile.AutoSize = true;
            lblAFSFile.Enabled = false;
            lblAFSFile.Location = new Point(228, 49);
            lblAFSFile.Name = "lblAFSFile";
            lblAFSFile.Size = new Size(12, 15);
            lblAFSFile.TabIndex = 5;
            lblAFSFile.Text = "-";
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(treeContent);
            panel.Enabled = false;
            panel.Location = new Point(17, 113);
            panel.Name = "panel";
            panel.Size = new Size(955, 536);
            panel.TabIndex = 10;
            // 
            // treeContent
            // 
            treeContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeContent.CheckBoxes = true;
            treeContent.FullRowSelect = true;
            treeContent.HideSelection = false;
            treeContent.Location = new Point(0, 0);
            treeContent.Name = "treeContent";
            treeContent.Size = new Size(300, 536);
            treeContent.TabIndex = 0;
            treeContent.AfterCheck += treeContent_AfterCheck;
            treeContent.AfterSelect += treeContent_AfterSelect;
            // 
            // btnSaveAFS
            // 
            btnSaveAFS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveAFS.Enabled = false;
            btnSaveAFS.Location = new Point(17, 74);
            btnSaveAFS.Name = "btnSaveAFS";
            btnSaveAFS.Size = new Size(175, 23);
            btnSaveAFS.TabIndex = 6;
            btnSaveAFS.Text = "Save AFS file";
            btnSaveAFS.UseVisualStyleBackColor = true;
            btnSaveAFS.Click += btnSaveAFS_Click;
            // 
            // btnPuyoTools
            // 
            btnPuyoTools.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPuyoTools.Location = new Point(797, 16);
            btnPuyoTools.Name = "btnPuyoTools";
            btnPuyoTools.Size = new Size(175, 23);
            btnPuyoTools.TabIndex = 7;
            btnPuyoTools.Text = "Open Puyo Tools";
            btnPuyoTools.UseVisualStyleBackColor = true;
            btnPuyoTools.Click += btnPuyoTools_Click;
            // 
            // btnWorkingDirBrowse
            // 
            btnWorkingDirBrowse.Enabled = false;
            btnWorkingDirBrowse.Image = Properties.Resources.folder_small;
            btnWorkingDirBrowse.Location = new Point(195, 16);
            btnWorkingDirBrowse.Name = "btnWorkingDirBrowse";
            btnWorkingDirBrowse.Size = new Size(25, 23);
            btnWorkingDirBrowse.TabIndex = 1;
            btnWorkingDirBrowse.UseVisualStyleBackColor = true;
            btnWorkingDirBrowse.Click += btnWorkingDirBrowse_Click;
            // 
            // btnOpenAFSBrowse
            // 
            btnOpenAFSBrowse.Enabled = false;
            btnOpenAFSBrowse.Image = Properties.Resources.folder_small;
            btnOpenAFSBrowse.Location = new Point(195, 45);
            btnOpenAFSBrowse.Name = "btnOpenAFSBrowse";
            btnOpenAFSBrowse.Size = new Size(25, 23);
            btnOpenAFSBrowse.TabIndex = 4;
            btnOpenAFSBrowse.UseVisualStyleBackColor = true;
            btnOpenAFSBrowse.Click += btnOpenAFSBrowse_Click;
            // 
            // panelFile
            // 
            panelFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFile.BackColor = SystemColors.Control;
            panelFile.Location = new Point(323, 113);
            panelFile.Name = "panelFile";
            panelFile.Size = new Size(649, 536);
            panelFile.TabIndex = 11;
            // 
            // btnPNGConverter
            // 
            btnPNGConverter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPNGConverter.Location = new Point(797, 45);
            btnPNGConverter.Name = "btnPNGConverter";
            btnPNGConverter.Size = new Size(175, 23);
            btnPNGConverter.TabIndex = 8;
            btnPNGConverter.Text = "PVR Converter";
            btnPNGConverter.UseVisualStyleBackColor = true;
            btnPNGConverter.Click += btnPVRConverter_Click;
            // 
            // btnLLKeywords
            // 
            btnLLKeywords.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLLKeywords.Location = new Point(797, 74);
            btnLLKeywords.Name = "btnLLKeywords";
            btnLLKeywords.Size = new Size(175, 23);
            btnLLKeywords.TabIndex = 9;
            btnLLKeywords.Text = "Love Love Keywords";
            btnLLKeywords.UseVisualStyleBackColor = true;
            btnLLKeywords.Click += btnLLKeywords_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(btnLLKeywords);
            Controls.Add(btnPNGConverter);
            Controls.Add(panelFile);
            Controls.Add(panel);
            Controls.Add(lblAFSFile);
            Controls.Add(lblWorkingDir);
            Controls.Add(btnPuyoTools);
            Controls.Add(btnSaveAFS);
            Controls.Add(btnOpenAFS);
            Controls.Add(btnOpenAFSBrowse);
            Controls.Add(btnWorkingDirBrowse);
            Controls.Add(btnWorkingDir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 700);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SambAFSEditor";
            panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnWorkingDir;
        private Button btnOpenAFS;
        private Label lblWorkingDir;
        private Label lblAFSFile;
        private Panel panel;
        private TreeView treeContent;
        private Button btnSaveAFS;
        private Button btnPuyoTools;
        private Button btnWorkingDirBrowse;
        private Button btnOpenAFSBrowse;
        private Panel panelFile;
        private Button btnPNGConverter;
        private Button btnLLKeywords;
    }
}