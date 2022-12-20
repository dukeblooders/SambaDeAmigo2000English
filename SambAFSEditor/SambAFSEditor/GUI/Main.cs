using PuyoTools.GUI;
using System.Diagnostics;


namespace SambAFSEditor
{
    public partial class Main : Form
    {
        private WorkingStruct? workStruct = null!;


        public Main()
        {
            InitializeComponent();
        }


        #region WORKING DIR

        /// <summary>
        /// Define a working directory where temporary files will be created
        /// </summary>
        private void btnWorkingDir_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                SelectedPath = Directory.Exists(lblWorkingDir.Text) ? lblWorkingDir.Text : string.Empty
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                treeContent.Nodes.Clear();

                if (WorkingTree.Exists(dialog.SelectedPath))
                {
                    workStruct = WorkingTree.Read(dialog.SelectedPath);

                    if (workStruct != null)
                    {
                        workStruct.Directory = dialog.SelectedPath;
                        loadTree();
                    }
                }
                else
                {
                    workStruct = new WorkingStruct
                    {
                        Directory = dialog.SelectedPath
                    };
                }

                updateGui();
            }
        }


        /// <summary>
        /// Update the GUI depending the state of the working structure
        /// </summary>
        private void updateGui()
        {
            var isNull = workStruct == null;
            var isNew = !WorkingTree.Exists(workStruct?.Directory);

            panel.Enabled = !isNull && !isNew;
            btnOpenAFS.Enabled = isNew;
            btnSaveAFS.Enabled = !isNull && !isNew;

            lblWorkingDir.Text = workStruct?.Directory ?? "-";
            btnWorkingDirBrowse.Enabled = !isNull;

            lblAFSFile.Text = workStruct?.AFSFilePath ?? "-";
            btnOpenAFSBrowse.Enabled = File.Exists(workStruct?.AFSFilePath);

            if (treeContent.SelectedNode == null)
                clearFilePanel();
        }


        /// <summary>
        /// Open the selected working directory in Windows Explorer
        /// </summary>
        private void btnWorkingDirBrowse_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"\"{workStruct?.Directory}\"");
        }

        #endregion


        #region AFS

        /// <summary>
        /// Open a .afs file and extract the content in the working directory
        /// </summary>
        private void btnOpenAFS_Click(object sender, EventArgs e)
        {
            if (workStruct == null)
                return;

            using var dialog = new OpenFileDialog { Filter = Properties.Resources.FilterAFS };

            try
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    btnOpenAFS.Enabled = false;
                    btnOpenAFS.Refresh();

                    AFS.Extract(dialog.FileName, workStruct);

                    workStruct.AFSFilePath = dialog.FileName;

                    WorkingTree.Write(workStruct);
                    loadTree();
                }
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
            }
            finally
            {
                updateGui();
            }
        }


        /// <summary>
        /// Open the selected .afs file location in Windows Explorer
        /// </summary>
        private void btnOpenAFSBrowse_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"\"{Path.GetDirectoryName(workStruct?.AFSFilePath)}\"");
        }


        /// <summary>
        /// Update the selected .afs file (or create a new file) with the content of the working directory
        /// </summary>
        private void btnSaveAFS_Click(object sender, EventArgs e)
        {
            if (workStruct == null)
                return;

            try
            {
                btnSaveAFS.Enabled = false;
                btnSaveAFS.Refresh();

                AFS.Write(this, workStruct);
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
            }
            finally
            {
                updateGui();
            }
        }

        #endregion


        #region TREE

        /// <summary>
        /// Fill the tree from the working structure
        /// </summary>
        private void loadTree()
        {
            if (workStruct == null)
                return;

            try
            {
                treeContent.BeginUpdate();

                foreach (var contentFile in workStruct.ContentFiles)
                    if (contentFile.ParentId == null)
                    {
                        var node = new TreeNode(contentFile.ToString())
                        {
                            Checked = contentFile.Checked,
                            Tag = contentFile
                        };

                        treeContent.Nodes.Add(node);

                        addChildrenFiles(workStruct, contentFile, node);
                    }
                
                clearFilePanel();
            }
            catch (Exception ex)
            {
                treeContent.Nodes.Clear();
                workStruct = null;

                DialogBox.Error(this, ex.ToString());
            }
            finally
            {
                treeContent.EndUpdate();
            }
        }


        /// <summary>
        /// Add children files to a node (recursive) 
        /// </summary>
        internal void addChildrenFiles(WorkingStruct workStruct, ContentFile parentFile, TreeNode? parentNode = null)
        {
            parentNode ??= getNodeById(null, parentFile.Id);
            if (parentNode == null)
                throw new Exception($"ID NOT FOUND : {parentFile.Id}");

            parentNode.Nodes.Clear();

            foreach (var childfile in workStruct.ContentFiles.Where(f => f.ParentId == parentFile.Id))
            {
                var childNode = new TreeNode(childfile.ToString())
                {
                    Checked = childfile.Checked,
                    Tag = childfile
                };

                parentNode.Nodes.Add(childNode);

                addChildrenFiles(workStruct, childfile, childNode);
            }
        }


        /// <summary>
        /// Get a node by content file id (recursive)
        /// </summary>
        internal TreeNode? getNodeById(TreeNode? node, int id)
        {
            var nodes = node == null ? treeContent.Nodes : node.Nodes;

            foreach (TreeNode child in nodes)
                if (((ContentFile)child.Tag).Id == id)
                    return child;

            return null;           
        }


        /// <summary>
        /// Try to open a content file extracted from the .afs file
        /// </summary>
        private void treeContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (workStruct == null)
                return;

            try
            {
                treeContent.BeginUpdate();
                treeContent.SelectedNode = e.Node;

                clearFilePanel();

                if (e.Node?.Tag is ContentFile contentFile)
                {
                    if (contentFile.Type == ContentFileType.Unknown)
                        FileConverter.Identify(workStruct, contentFile);

                    e.Node.Text = contentFile.ToString();

                    readArchive(contentFile, e.Node);
                    showFilePanel(contentFile);

                    WorkingTree.Write(workStruct);
                }
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
            }
            finally
            {
                treeContent.EndUpdate();
            }
        }


        /// <summary>
        /// Update the tree if an archive is selected
        /// </summary>
        private void readArchive(ContentFile contentFile, TreeNode node)
        {
            if (workStruct != null)
                switch (contentFile.Type)
                {
                    case ContentFileType.PVM:
                        if (contentFile.FileCount == 0)
                        {
                            FileConverter.DecodePVM(workStruct, contentFile);

                            addChildrenFiles(workStruct, contentFile, node);

                            node.Text = contentFile.ToString();
                            node.Expand();
                            checkNodes(node, node.Checked);
                        }
                        break;
                }
        }


        /// <summary>
        /// Check or uncheck nodes depending the state of the parent/children nodes
        /// </summary>
        private void treeContent_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || workStruct == null || e.Action == TreeViewAction.Unknown)
                return;

            var parent = e.Node.Parent;
            while (parent != null)
            {
                if (e.Node.Checked)
                    parent.Checked = parent.Nodes.Cast<TreeNode>().All(n => n.Checked);
                else
                    parent.Checked = false;

                ((ContentFile)parent.Tag).Checked = parent.Checked;

                parent = parent.Parent;
            }

            checkNodes(e.Node, e.Node.Checked);

            WorkingTree.Write(workStruct);
        }


        /// <summary>
        /// Check/Uncheck children nodes (recursive)
        /// </summary>
        private void checkNodes(TreeNode node, Boolean value)
        {
            node.Checked = value;
            ((ContentFile)node.Tag).Checked = value;

            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = value;
                ((ContentFile)child.Tag).Checked = value;

                checkNodes(child, value);
            }
        }

        #endregion


        #region PANEL

        /// <summary>
        /// Show an editing panel for the selected content file
        /// </summary>
        private void showFilePanel(ContentFile contentFile)
        {
            UserControl? control = null;

            if (workStruct != null)
                switch (contentFile.Type)
                {
                    case ContentFileType.PVR:
                        control = new UCTexture().Init(workStruct, contentFile);
                        break;
                    case ContentFileType.PVM:
                        control = new UCArchive().Init(this, workStruct, contentFile);
                        break;
                    default:
                        control = new UCUnknown().Init(workStruct, contentFile);
                        break;
                }

            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                panelFile.Controls.Add(control);
            }
        }


        /// <summary>
        /// Remove all controls in the file panel
        /// </summary>
        private void clearFilePanel()
        {
            for (int i = panelFile.Controls.Count - 1; i >= 0; i--)
            {
                var control = panelFile.Controls[i];

                panelFile.Controls.RemoveAt(i);

                control.Dispose();
            }
        }

        #endregion



        /// <summary>
        /// Open Puyo Tools (https://github.com/nickworonekin/puyotools.git)
        /// </summary>
        private void btnPuyoTools_Click(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }
    }
}