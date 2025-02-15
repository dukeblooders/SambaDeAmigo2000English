using PuyoTools.Core.Textures.Pvr;
using System.Drawing.Imaging;


namespace SambAFSEditor
{
    public partial class FrmPvrConverter : Form, IDisposable
    {
        private string? pvrPath;
        private Bitmap? pvrBaseBitmap;
        private Bitmap? pvrBitmap;
        private ContentFileCompression? pvrCompression;
        private PvrTextureDecoder? pvrDecoder;

        private string? pvpPath;
        private Color[]? pvpColors;


        public FrmPvrConverter()
        {
            InitializeComponent();
        }


        private void btnPVR_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = Properties.Resources.FilterPVR
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                try
                {
                    pvrPath = dialog.FileName;

                    FileConverter.Identify(pvrPath, out _, out ContentFileCompression compression);
                    pvrCompression = compression;

                    pvrBaseBitmap = FileConverter.DecodePVR(pvrPath, compression, out PvrTextureDecoder decoder);
                    pvrDecoder = decoder;

                    pvrBitmap = new Bitmap(pvrBaseBitmap);

                    lblPVR.Text = Path.GetFileName(pvrPath);
                    pbTexture.Image = pvrBitmap;
                    pbTexture.Size = pvrBitmap.Size;

                    lblSize.Text = $"{decoder.Width} x {decoder.Height}";
                    lblFormat.Text = decoder.DataFormat.ToString();
                    lblIndex.Text = decoder.GlobalIndex.ToString();
                    lblPixel.Text = decoder.PixelFormat.ToString();

                    if (decoder.IncludedPaletteData == null)
                    {
                        lblPVP.Text = string.IsNullOrEmpty(pvpPath) ? "-" : Path.GetFileName(pvpPath);
                        btnPVP.Enabled = true;

                        if (pvpPath != null)
                            ApplyPaletteToPVR();
                    }
                    else
                    {
                        lblPVP.Text = "Included";
                        btnPVP.Enabled = false;

                        pvpPath = null;
                    }

                    btnExport.Enabled = true;
                    btnPNG.Enabled = true;
                }
                catch (Exception ex)
                {
                    DialogBox.Error(this, ex.ToString());
                }
        }


        private void btnPVP_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = Properties.Resources.FilterPVP
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                try
                {
                    pvpPath = dialog.FileName;

                    lblPVP.Text = Path.GetFileName(pvpPath);

                    using var stream = new FileStream(pvpPath, FileMode.Open, FileAccess.Read);

                    pvpColors = PVP.Read(stream);

                    ApplyPaletteToPVR();
                }
                catch (Exception ex)
                {
                    DialogBox.Error(this, ex.ToString());
                }
        }


        private void ApplyPaletteToPVR()
        {
            if (pvrBaseBitmap == null || pvrBitmap == null || pvrDecoder == null || pvpColors == null)
                return;
            if (pvrDecoder.DataFormat != PvrDataFormat.Index8)
                return;

            for (int x = 0; x < pvrBaseBitmap.Width; x++)
                for (int y = 0; y < pvrBaseBitmap.Height; y++)
                {
                    var color = pvrBaseBitmap.GetPixel(x, y);

                    pvrBitmap.SetPixel(x, y, pvpColors[color.R + 1]);
                }

            pbTexture.Refresh();
        }


        private void btnPNG_Click(object sender, EventArgs e)
        {
            if (pvrBaseBitmap == null)
                return;

            using var dialog = new OpenFileDialog
            {
                Filter = Properties.Resources.FilterPNG
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                try
                {
                    btnPNG.Enabled = false;
                    lblPNG.Text = Path.GetFileName(dialog.FileName);

                    using var inStream = File.OpenRead(dialog.FileName);

                    pvrBitmap?.Dispose();
                    pvrBitmap = new Bitmap(inStream);

                    if (pvrBitmap.Size.Width == pvrBaseBitmap.Width && pvrBitmap.Size.Height == pvrBaseBitmap.Height)
                    {
                        if (pvpColors != null)
                            GetPNGClosestPixels();

                        pbTexture.Image = pvrBitmap;

                        btnPVR.Enabled = false;
                        btnPVP.Enabled = false;
                        btnReplacePVR.Enabled = true;
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
                    btnPNG.Enabled = true;
                }
        }


        private void GetPNGClosestPixels()
        {
            if (pvrBitmap == null || pvrDecoder == null || pvpColors == null)
                return;
            if (pvrDecoder.DataFormat != PvrDataFormat.Index8)
                return;

            for (int x = 0; x < pvrBitmap.Width; x++)
                for (int y = 0; y < pvrBitmap.Height; y++)
                {
                    var color = pvrBitmap.GetPixel(x, y);
                    pvrBitmap.SetPixel(x, y, GetPaletteClosestColor(color));
                }
        }


        private Color GetPaletteClosestColor(Color color)
        {
            if (pvpColors == null)
                return Color.Black;

            if (color.A == 0)
                return pvpColors.First(c => c.A == 0); // Ugly transparency hack

            var colors = pvpColors.Select(c => new { Value = c, Diff = GetColorDiff(c, color) }).ToList();
            var min = colors.Min(c => c.Diff);

            return colors.First(c => c.Diff == min).Value;
        }


        private static int GetColorDiff(Color color, Color baseColor)
        {
            var a = color.A - baseColor.A;
            var r = color.R - baseColor.R;
            var g = color.G - baseColor.G;
            var b = color.B - baseColor.B;

            return a * a + r * r + g * g + b * b;
        }


        private void btnReplacePVR_Click(object sender, EventArgs e)
        {
            if (pvrPath == null || pvrBitmap == null || pvrCompression == null || pvrDecoder == null)
                return;

            try
            {
                using var dialog = new SaveFileDialog 
                { 
                    FileName = Path.GetFileName(pvrPath),
                    Filter = Properties.Resources.FilterPVR,
                    InitialDirectory = Path.GetDirectoryName(pvrPath),
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using var stream = new MemoryStream();
                    pvrBitmap.Save(stream, ImageFormat.Bmp);

                    stream.Position = 0;

                    FileConverter.EncodePVR(stream, pvrCompression.Value, dialog.FileName, pvrDecoder, pvpColors);

                    Close();
                }
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = Properties.Resources.FilterPNG };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                try
                {
                    using var stream = File.OpenWrite(dialog.FileName);

                    pbTexture.Image.Save(stream, ImageFormat.Png);
                }
                catch (Exception)
                {
                    DialogBox.Error(this, Properties.Resources.ErrorCannotSaveFile);
                }
        }
    }
}
