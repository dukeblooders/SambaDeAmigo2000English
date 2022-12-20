namespace SambAFSEditor
{
    public partial class UCUnknown : UserControl
    {
        private WorkingStruct workStruct = null!;
        private ContentFile contentFile = null!;


        public UCUnknown()
        {
            InitializeComponent();
        }


        internal UCUnknown Init(WorkingStruct workStruct, ContentFile contentFile)
        {
            this.workStruct = workStruct;
            this.contentFile = contentFile;

            return this;
        }


        private void btnReplace_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
                if (dialog.ShowDialog(this) == DialogResult.OK)
                    try
                    {
                        btnReplace.Enabled = false;
                        btnReplace.Refresh();

                        File.Copy(dialog.FileName, contentFile.GetPath(workStruct), true);
                    }
                    finally
                    {
                        btnReplace.Enabled = true;
                    }
        }
    }
}
