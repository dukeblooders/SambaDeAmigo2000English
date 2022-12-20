namespace SambAFSEditor
{
    public partial class UCArchive : UserControl
    {
        private Main mainform = null!;
        private WorkingStruct workStruct = null!;
        private ContentFile contentFile = null!;


        public UCArchive()
        {
            InitializeComponent();
        }


        internal UCArchive Init(Main mainform, WorkingStruct workStruct, ContentFile contentFile)
        {
            this.mainform = mainform;
            this.workStruct = workStruct;
            this.contentFile = contentFile;

            return this;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (DialogBox.Question(this, Properties.Resources.ReplaceArchive, MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                btnCreate.Enabled = false;
                btnCreate.Refresh();

                switch (contentFile.Type)
                {
                    case ContentFileType.PVM:
                        FileConverter.EncodePVM(workStruct, contentFile);
                        break;

                    default:
                        throw new NotImplementedException(contentFile.Type.ToString());
                }
            }
            finally
            {
                btnCreate.Enabled = true;
            }
        }


        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (DialogBox.Question(this, Properties.Resources.ExtractArchive, MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                btnExtract.Enabled = false;
                btnExtract.Refresh();

                switch (contentFile.Type)
                {
                    case ContentFileType.PVM:
                        FileConverter.DecodePVM(workStruct, contentFile);
                        break;

                    default:
                        throw new NotImplementedException(contentFile.Type.ToString());
                }

                WorkingTree.Write(workStruct);
                mainform.addChildrenFiles(workStruct, contentFile);
            }
            finally
            {
                btnExtract.Enabled = true;
            }
        }
    }
}
