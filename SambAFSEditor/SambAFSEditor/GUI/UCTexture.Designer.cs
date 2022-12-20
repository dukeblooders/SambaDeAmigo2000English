namespace SambAFSEditor
{
    partial class UCTexture
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbTexture = new System.Windows.Forms.PictureBox();
            this.lblSizeTitle = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblIndexTitle = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblPixel = new System.Windows.Forms.Label();
            this.lblPixelTitle = new System.Windows.Forms.Label();
            this.lblFormatTitle = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbTexture)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTexture
            // 
            this.pbTexture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTexture.Location = new System.Drawing.Point(0, 0);
            this.pbTexture.Name = "pbTexture";
            this.pbTexture.Size = new System.Drawing.Size(100, 100);
            this.pbTexture.TabIndex = 0;
            this.pbTexture.TabStop = false;
            // 
            // lblSizeTitle
            // 
            this.lblSizeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeTitle.AutoSize = true;
            this.lblSizeTitle.Location = new System.Drawing.Point(10, 9);
            this.lblSizeTitle.Name = "lblSizeTitle";
            this.lblSizeTitle.Size = new System.Drawing.Size(30, 15);
            this.lblSizeTitle.TabIndex = 0;
            this.lblSizeTitle.Text = "Size:";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(10, 27);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(12, 15);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "-";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(7, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(175, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export image";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(7, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(175, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import Image";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfo.BackColor = System.Drawing.SystemColors.Window;
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.lblIndexTitle);
            this.panelInfo.Controls.Add(this.lblIndex);
            this.panelInfo.Controls.Add(this.lblPixel);
            this.panelInfo.Controls.Add(this.lblPixelTitle);
            this.panelInfo.Controls.Add(this.lblFormatTitle);
            this.panelInfo.Controls.Add(this.lblFormat);
            this.panelInfo.Controls.Add(this.lblSizeTitle);
            this.panelInfo.Controls.Add(this.lblSize);
            this.panelInfo.Location = new System.Drawing.Point(7, 72);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(175, 195);
            this.panelInfo.TabIndex = 2;
            // 
            // lblIndexTitle
            // 
            this.lblIndexTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndexTitle.AutoSize = true;
            this.lblIndexTitle.Location = new System.Drawing.Point(10, 147);
            this.lblIndexTitle.Name = "lblIndexTitle";
            this.lblIndexTitle.Size = new System.Drawing.Size(39, 15);
            this.lblIndexTitle.TabIndex = 6;
            this.lblIndexTitle.Text = "Index:";
            // 
            // lblIndex
            // 
            this.lblIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(10, 162);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(12, 15);
            this.lblIndex.TabIndex = 7;
            this.lblIndex.Text = "-";
            // 
            // lblPixel
            // 
            this.lblPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPixel.AutoSize = true;
            this.lblPixel.Location = new System.Drawing.Point(10, 117);
            this.lblPixel.Name = "lblPixel";
            this.lblPixel.Size = new System.Drawing.Size(12, 15);
            this.lblPixel.TabIndex = 5;
            this.lblPixel.Text = "-";
            // 
            // lblPixelTitle
            // 
            this.lblPixelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPixelTitle.AutoSize = true;
            this.lblPixelTitle.Location = new System.Drawing.Point(10, 102);
            this.lblPixelTitle.Name = "lblPixelTitle";
            this.lblPixelTitle.Size = new System.Drawing.Size(74, 15);
            this.lblPixelTitle.TabIndex = 4;
            this.lblPixelTitle.Text = "Pixel format:";
            // 
            // lblFormatTitle
            // 
            this.lblFormatTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormatTitle.AutoSize = true;
            this.lblFormatTitle.Location = new System.Drawing.Point(10, 57);
            this.lblFormatTitle.Name = "lblFormatTitle";
            this.lblFormatTitle.Size = new System.Drawing.Size(48, 15);
            this.lblFormatTitle.TabIndex = 2;
            this.lblFormatTitle.Text = "Format:";
            // 
            // lblFormat
            // 
            this.lblFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(10, 72);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(12, 15);
            this.lblFormat.TabIndex = 3;
            this.lblFormat.Text = "-";
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.panelInfo);
            this.panelRight.Controls.Add(this.btnImport);
            this.panelRight.Controls.Add(this.btnExport);
            this.panelRight.Location = new System.Drawing.Point(518, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(182, 512);
            this.panelRight.TabIndex = 3;
            // 
            // UCTexture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.pbTexture);
            this.Name = "UCTexture";
            this.Size = new System.Drawing.Size(700, 512);
            ((System.ComponentModel.ISupportInitialize)(this.pbTexture)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbTexture;
        private Label lblSizeTitle;
        private Label lblSize;
        private Button btnExport;
        private Button btnImport;
        private Panel panelInfo;
        private Label lblFormatTitle;
        private Label lblFormat;
        private Label lblIndexTitle;
        private Label lblIndex;
        private Label lblPixel;
        private Label lblPixelTitle;
        private Panel panelRight;
    }
}
