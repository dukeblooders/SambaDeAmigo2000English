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
            this.btnWorkingDir = new System.Windows.Forms.Button();
            this.btnOpenAFS = new System.Windows.Forms.Button();
            this.lblWorkingDir = new System.Windows.Forms.Label();
            this.lblAFSFile = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.treeContent = new System.Windows.Forms.TreeView();
            this.btnSaveAFS = new System.Windows.Forms.Button();
            this.btnPuyoTools = new System.Windows.Forms.Button();
            this.btnWorkingDirBrowse = new System.Windows.Forms.Button();
            this.btnOpenAFSBrowse = new System.Windows.Forms.Button();
            this.panelFile = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWorkingDir
            // 
            this.btnWorkingDir.Location = new System.Drawing.Point(17, 16);
            this.btnWorkingDir.Name = "btnWorkingDir";
            this.btnWorkingDir.Size = new System.Drawing.Size(175, 23);
            this.btnWorkingDir.TabIndex = 0;
            this.btnWorkingDir.Text = "Select working directory";
            this.btnWorkingDir.UseVisualStyleBackColor = true;
            this.btnWorkingDir.Click += new System.EventHandler(this.btnWorkingDir_Click);
            // 
            // btnOpenAFS
            // 
            this.btnOpenAFS.Enabled = false;
            this.btnOpenAFS.Location = new System.Drawing.Point(17, 45);
            this.btnOpenAFS.Name = "btnOpenAFS";
            this.btnOpenAFS.Size = new System.Drawing.Size(175, 23);
            this.btnOpenAFS.TabIndex = 3;
            this.btnOpenAFS.Text = "Open AFS file";
            this.btnOpenAFS.UseVisualStyleBackColor = true;
            this.btnOpenAFS.Click += new System.EventHandler(this.btnOpenAFS_Click);
            // 
            // lblWorkingDir
            // 
            this.lblWorkingDir.AutoSize = true;
            this.lblWorkingDir.Location = new System.Drawing.Point(228, 20);
            this.lblWorkingDir.Name = "lblWorkingDir";
            this.lblWorkingDir.Size = new System.Drawing.Size(12, 15);
            this.lblWorkingDir.TabIndex = 2;
            this.lblWorkingDir.Text = "-";
            // 
            // lblAFSFile
            // 
            this.lblAFSFile.AutoSize = true;
            this.lblAFSFile.Enabled = false;
            this.lblAFSFile.Location = new System.Drawing.Point(228, 49);
            this.lblAFSFile.Name = "lblAFSFile";
            this.lblAFSFile.Size = new System.Drawing.Size(12, 15);
            this.lblAFSFile.TabIndex = 5;
            this.lblAFSFile.Text = "-";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.treeContent);
            this.panel.Enabled = false;
            this.panel.Location = new System.Drawing.Point(17, 89);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(955, 560);
            this.panel.TabIndex = 8;
            // 
            // treeContent
            // 
            this.treeContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeContent.CheckBoxes = true;
            this.treeContent.FullRowSelect = true;
            this.treeContent.HideSelection = false;
            this.treeContent.Location = new System.Drawing.Point(0, 0);
            this.treeContent.Name = "treeContent";
            this.treeContent.Size = new System.Drawing.Size(300, 560);
            this.treeContent.TabIndex = 0;
            this.treeContent.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeContent_AfterCheck);
            this.treeContent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeContent_AfterSelect);
            // 
            // btnSaveAFS
            // 
            this.btnSaveAFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAFS.Enabled = false;
            this.btnSaveAFS.Location = new System.Drawing.Point(797, 45);
            this.btnSaveAFS.Name = "btnSaveAFS";
            this.btnSaveAFS.Size = new System.Drawing.Size(175, 23);
            this.btnSaveAFS.TabIndex = 7;
            this.btnSaveAFS.Text = "Save AFS file";
            this.btnSaveAFS.UseVisualStyleBackColor = true;
            this.btnSaveAFS.Click += new System.EventHandler(this.btnSaveAFS_Click);
            // 
            // btnPuyoTools
            // 
            this.btnPuyoTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPuyoTools.Location = new System.Drawing.Point(797, 16);
            this.btnPuyoTools.Name = "btnPuyoTools";
            this.btnPuyoTools.Size = new System.Drawing.Size(175, 23);
            this.btnPuyoTools.TabIndex = 6;
            this.btnPuyoTools.Text = "Open Puyo Tools";
            this.btnPuyoTools.UseVisualStyleBackColor = true;
            this.btnPuyoTools.Click += new System.EventHandler(this.btnPuyoTools_Click);
            // 
            // btnWorkingDirBrowse
            // 
            this.btnWorkingDirBrowse.Enabled = false;
            this.btnWorkingDirBrowse.Image = global::SambAFSEditor.Properties.Resources.folder_small;
            this.btnWorkingDirBrowse.Location = new System.Drawing.Point(195, 16);
            this.btnWorkingDirBrowse.Name = "btnWorkingDirBrowse";
            this.btnWorkingDirBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnWorkingDirBrowse.TabIndex = 1;
            this.btnWorkingDirBrowse.UseVisualStyleBackColor = true;
            this.btnWorkingDirBrowse.Click += new System.EventHandler(this.btnWorkingDirBrowse_Click);
            // 
            // btnOpenAFSBrowse
            // 
            this.btnOpenAFSBrowse.Enabled = false;
            this.btnOpenAFSBrowse.Image = global::SambAFSEditor.Properties.Resources.folder_small;
            this.btnOpenAFSBrowse.Location = new System.Drawing.Point(195, 45);
            this.btnOpenAFSBrowse.Name = "btnOpenAFSBrowse";
            this.btnOpenAFSBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnOpenAFSBrowse.TabIndex = 4;
            this.btnOpenAFSBrowse.UseVisualStyleBackColor = true;
            this.btnOpenAFSBrowse.Click += new System.EventHandler(this.btnOpenAFSBrowse_Click);
            // 
            // panelFile
            // 
            this.panelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFile.BackColor = System.Drawing.SystemColors.Control;
            this.panelFile.Location = new System.Drawing.Point(323, 89);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(649, 560);
            this.panelFile.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panelFile);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lblAFSFile);
            this.Controls.Add(this.lblWorkingDir);
            this.Controls.Add(this.btnPuyoTools);
            this.Controls.Add(this.btnSaveAFS);
            this.Controls.Add(this.btnOpenAFS);
            this.Controls.Add(this.btnOpenAFSBrowse);
            this.Controls.Add(this.btnWorkingDirBrowse);
            this.Controls.Add(this.btnWorkingDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SambAFSEditor";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}