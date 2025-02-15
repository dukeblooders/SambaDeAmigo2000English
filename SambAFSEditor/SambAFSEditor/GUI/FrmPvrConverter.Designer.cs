namespace SambAFSEditor
{
    partial class FrmPvrConverter
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
                pvrBaseBitmap?.Dispose();
                pvrBitmap?.Dispose();

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
            btnPVP = new Button();
            pbTexture = new PictureBox();
            lblPVR = new Label();
            btnPVR = new Button();
            panelInfo = new Panel();
            lblIndexTitle = new Label();
            lblIndex = new Label();
            lblPixel = new Label();
            lblPixelTitle = new Label();
            lblFormatTitle = new Label();
            lblFormat = new Label();
            lblSizeTitle = new Label();
            lblSize = new Label();
            lblPVP = new Label();
            btnExport = new Button();
            btnPNG = new Button();
            lblPNG = new Label();
            btnReplacePVR = new Button();
            ((System.ComponentModel.ISupportInitialize)pbTexture).BeginInit();
            panelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // btnPVP
            // 
            btnPVP.Location = new Point(23, 53);
            btnPVP.Name = "btnPVP";
            btnPVP.Size = new Size(75, 23);
            btnPVP.TabIndex = 2;
            btnPVP.Text = "Palette";
            btnPVP.UseVisualStyleBackColor = true;
            btnPVP.Click += btnPVP_Click;
            // 
            // pbTexture
            // 
            pbTexture.BackgroundImageLayout = ImageLayout.None;
            pbTexture.BorderStyle = BorderStyle.FixedSingle;
            pbTexture.Location = new Point(23, 130);
            pbTexture.Name = "pbTexture";
            pbTexture.Size = new Size(100, 100);
            pbTexture.TabIndex = 1;
            pbTexture.TabStop = false;
            // 
            // lblPVR
            // 
            lblPVR.AutoSize = true;
            lblPVR.Location = new Point(123, 25);
            lblPVR.Name = "lblPVR";
            lblPVR.Size = new Size(12, 15);
            lblPVR.TabIndex = 1;
            lblPVR.Text = "-";
            // 
            // btnPVR
            // 
            btnPVR.Location = new Point(23, 21);
            btnPVR.Name = "btnPVR";
            btnPVR.Size = new Size(75, 23);
            btnPVR.TabIndex = 0;
            btnPVR.Text = "Base PVR";
            btnPVR.UseVisualStyleBackColor = true;
            btnPVR.Click += btnPVR_Click;
            // 
            // panelInfo
            // 
            panelInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelInfo.BackColor = SystemColors.Window;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(lblIndexTitle);
            panelInfo.Controls.Add(lblIndex);
            panelInfo.Controls.Add(lblPixel);
            panelInfo.Controls.Add(lblPixelTitle);
            panelInfo.Controls.Add(lblFormatTitle);
            panelInfo.Controls.Add(lblFormat);
            panelInfo.Controls.Add(lblSizeTitle);
            panelInfo.Controls.Add(lblSize);
            panelInfo.Location = new Point(797, 130);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(175, 195);
            panelInfo.TabIndex = 8;
            // 
            // lblIndexTitle
            // 
            lblIndexTitle.AutoSize = true;
            lblIndexTitle.Location = new Point(10, 147);
            lblIndexTitle.Name = "lblIndexTitle";
            lblIndexTitle.Size = new Size(38, 15);
            lblIndexTitle.TabIndex = 6;
            lblIndexTitle.Text = "Index:";
            // 
            // lblIndex
            // 
            lblIndex.AutoSize = true;
            lblIndex.Location = new Point(10, 162);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(12, 15);
            lblIndex.TabIndex = 7;
            lblIndex.Text = "-";
            // 
            // lblPixel
            // 
            lblPixel.AutoSize = true;
            lblPixel.Location = new Point(10, 117);
            lblPixel.Name = "lblPixel";
            lblPixel.Size = new Size(12, 15);
            lblPixel.TabIndex = 5;
            lblPixel.Text = "-";
            // 
            // lblPixelTitle
            // 
            lblPixelTitle.AutoSize = true;
            lblPixelTitle.Location = new Point(10, 102);
            lblPixelTitle.Name = "lblPixelTitle";
            lblPixelTitle.Size = new Size(73, 15);
            lblPixelTitle.TabIndex = 4;
            lblPixelTitle.Text = "Pixel format:";
            // 
            // lblFormatTitle
            // 
            lblFormatTitle.AutoSize = true;
            lblFormatTitle.Location = new Point(10, 57);
            lblFormatTitle.Name = "lblFormatTitle";
            lblFormatTitle.Size = new Size(48, 15);
            lblFormatTitle.TabIndex = 2;
            lblFormatTitle.Text = "Format:";
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.Location = new Point(10, 72);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(12, 15);
            lblFormat.TabIndex = 3;
            lblFormat.Text = "-";
            // 
            // lblSizeTitle
            // 
            lblSizeTitle.AutoSize = true;
            lblSizeTitle.Location = new Point(10, 9);
            lblSizeTitle.Name = "lblSizeTitle";
            lblSizeTitle.Size = new Size(30, 15);
            lblSizeTitle.TabIndex = 0;
            lblSizeTitle.Text = "Size:";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(10, 27);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(12, 15);
            lblSize.TabIndex = 1;
            lblSize.Text = "-";
            // 
            // lblPVP
            // 
            lblPVP.AutoSize = true;
            lblPVP.Location = new Point(123, 57);
            lblPVP.Name = "lblPVP";
            lblPVP.Size = new Size(12, 15);
            lblPVP.TabIndex = 3;
            lblPVP.Text = "-";
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.Enabled = false;
            btnExport.Location = new Point(797, 53);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(175, 23);
            btnExport.TabIndex = 7;
            btnExport.Text = "Export image";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnPNG
            // 
            btnPNG.Enabled = false;
            btnPNG.Location = new Point(23, 85);
            btnPNG.Name = "btnPNG";
            btnPNG.Size = new Size(75, 23);
            btnPNG.TabIndex = 4;
            btnPNG.Text = "PNG";
            btnPNG.UseVisualStyleBackColor = true;
            btnPNG.Click += btnPNG_Click;
            // 
            // lblPNG
            // 
            lblPNG.AutoSize = true;
            lblPNG.Location = new Point(123, 89);
            lblPNG.Name = "lblPNG";
            lblPNG.Size = new Size(12, 15);
            lblPNG.TabIndex = 5;
            lblPNG.Text = "-";
            // 
            // btnReplacePVR
            // 
            btnReplacePVR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReplacePVR.Enabled = false;
            btnReplacePVR.Location = new Point(797, 21);
            btnReplacePVR.Name = "btnReplacePVR";
            btnReplacePVR.Size = new Size(175, 23);
            btnReplacePVR.TabIndex = 6;
            btnReplacePVR.Text = "Replace PVR";
            btnReplacePVR.UseVisualStyleBackColor = true;
            btnReplacePVR.Click += btnReplacePVR_Click;
            // 
            // FrmPvrConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(btnReplacePVR);
            Controls.Add(btnExport);
            Controls.Add(panelInfo);
            Controls.Add(lblPNG);
            Controls.Add(lblPVP);
            Controls.Add(lblPVR);
            Controls.Add(pbTexture);
            Controls.Add(btnPNG);
            Controls.Add(btnPVR);
            Controls.Add(btnPVP);
            MinimumSize = new Size(800, 500);
            Name = "FrmPvrConverter";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PVR Converter";
            ((System.ComponentModel.ISupportInitialize)pbTexture).EndInit();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPVP;
        private PictureBox pbTexture;
        private Label lblPVR;
        private Button btnPVR;
        private Panel panelInfo;
        private Label lblIndexTitle;
        private Label lblIndex;
        private Label lblPixel;
        private Label lblPixelTitle;
        private Label lblFormatTitle;
        private Label lblFormat;
        private Label lblSizeTitle;
        private Label lblSize;
        private Label lblPVP;
        private Button btnExport;
        private Button btnPNG;
        private Label lblPNG;
        private Button btnReplacePVR;
    }
}