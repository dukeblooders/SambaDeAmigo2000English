using PuyoTools.Core.Textures.Pvr;
using System.Drawing.Imaging;

namespace SambAFSEditor
{
    public partial class UCTexture : UserControl
    {
        private WorkingStruct workStruct = null!;
        private ContentFile contentFile = null!;
        private PvrTextureDecoder decoder = null!;


        public UCTexture()
        {
            InitializeComponent();

            lblSizeTitle.Font = new Font(lblSizeTitle.Font, FontStyle.Bold);
            lblFormatTitle.Font = new Font(lblFormatTitle.Font, FontStyle.Bold);
            lblPixelTitle.Font = new Font(lblPixelTitle.Font, FontStyle.Bold);
            lblIndexTitle.Font = new Font(lblIndexTitle.Font, FontStyle.Bold);
        }


        internal UCTexture? Init(WorkingStruct workStruct, ContentFile contentFile)
        {
            this.workStruct = workStruct;
            this.contentFile = contentFile;

            switch (contentFile.Type)
            {
                case ContentFileType.PVR:
                    if (DecodePVR(workStruct, contentFile))
                        return this;
                    break;

                default:
                    throw new NotImplementedException(contentFile.Type.ToString());
            }

            return null;
        }


        private Boolean DecodePVR(WorkingStruct workStruct, ContentFile contentFile)
        {
            try
            {
                var bitmap = FileConverter.DecodePVR(workStruct, contentFile, out PvrTextureDecoder decoder);

                this.decoder = decoder;

                pbTexture.Image = bitmap;
                pbTexture.Size = bitmap.Size;

                lblSize.Text = $"{decoder.Width} x {decoder.Height}";
                lblFormat.Text = decoder.DataFormat.ToString();
                lblIndex.Text = decoder.GlobalIndex.ToString();
                lblPixel.Text = decoder.PixelFormat.ToString();

                return true;
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
                return false;
            }
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog { Filter = Properties.Resources.FilterPNG };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                try
                {
                    btnImport.Enabled = false;
                    btnImport.Refresh();

                    using var inStream = File.OpenRead(dialog.FileName);

                    var bitmap = new Bitmap(inStream);

                    if (bitmap.Size.Width == decoder.Width && bitmap.Size.Height == decoder.Height)
                    {
                        FileConverter.EncodePVR(workStruct, contentFile, dialog.FileName, decoder);

                        pbTexture.Image = bitmap;
                    }
                    else
                    {
                        DialogBox.Error(this, Properties.Resources.ErrorImageSize);
                    }
                }
                catch (Exception ex)
                {
                    DialogBox.Error(this, ex.ToString());
                }
                finally
                {
                    btnImport.Enabled = true;
                }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = Properties.Resources.FilterPNG };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                try
                {
                    using (var stream = File.OpenWrite(dialog.FileName))
                        pbTexture.Image.Save(stream, ImageFormat.Png);
                }
                catch (Exception)
                {
                    DialogBox.Error(this, Properties.Resources.ErrorCannotSaveFile);
                }
        }
    }
}
