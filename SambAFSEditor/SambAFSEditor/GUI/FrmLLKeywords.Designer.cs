namespace SambAFSEditor
{
    partial class FrmLLKeywords
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
            lbl1stRead = new Label();
            btn1stRead = new Button();
            listKeywords = new ListView();
            colPointer = new ColumnHeader();
            colIndex = new ColumnHeader();
            colValue = new ColumnHeader();
            lblIndex = new Label();
            ttbIndex = new TextBox();
            lblNewValue = new Label();
            ttbNewValue = new TextBox();
            btnReplace = new Button();
            lblCurrentValue = new Label();
            ttbCurrentValue = new TextBox();
            SuspendLayout();
            // 
            // lbl1stRead
            // 
            lbl1stRead.AutoSize = true;
            lbl1stRead.Location = new Point(123, 25);
            lbl1stRead.Name = "lbl1stRead";
            lbl1stRead.Size = new Size(12, 15);
            lbl1stRead.TabIndex = 1;
            lbl1stRead.Text = "-";
            // 
            // btn1stRead
            // 
            btn1stRead.Location = new Point(23, 21);
            btn1stRead.Name = "btn1stRead";
            btn1stRead.Size = new Size(75, 23);
            btn1stRead.TabIndex = 0;
            btn1stRead.Text = "1st_read";
            btn1stRead.UseVisualStyleBackColor = true;
            btn1stRead.Click += btn1stRead_Click;
            // 
            // listKeywords
            // 
            listKeywords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listKeywords.Columns.AddRange(new ColumnHeader[] { colPointer, colIndex, colValue });
            listKeywords.FullRowSelect = true;
            listKeywords.GridLines = true;
            listKeywords.Location = new Point(23, 64);
            listKeywords.Name = "listKeywords";
            listKeywords.Size = new Size(433, 476);
            listKeywords.TabIndex = 2;
            listKeywords.UseCompatibleStateImageBehavior = false;
            listKeywords.View = View.Details;
            listKeywords.SelectedIndexChanged += listKeywords_SelectedIndexChanged;
            // 
            // colPointer
            // 
            colPointer.Text = "Pointer";
            colPointer.Width = 100;
            // 
            // colIndex
            // 
            colIndex.Text = "Index";
            colIndex.Width = 100;
            // 
            // colValue
            // 
            colValue.Text = "Value";
            colValue.Width = 200;
            // 
            // lblIndex
            // 
            lblIndex.AutoSize = true;
            lblIndex.Location = new Point(471, 64);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(35, 15);
            lblIndex.TabIndex = 3;
            lblIndex.Text = "Index";
            // 
            // ttbIndex
            // 
            ttbIndex.Location = new Point(471, 82);
            ttbIndex.MaxLength = 6;
            ttbIndex.Name = "ttbIndex";
            ttbIndex.Size = new Size(292, 23);
            ttbIndex.TabIndex = 4;
            // 
            // lblNewValue
            // 
            lblNewValue.AutoSize = true;
            lblNewValue.Location = new Point(471, 179);
            lblNewValue.Name = "lblNewValue";
            lblNewValue.Size = new Size(62, 15);
            lblNewValue.TabIndex = 7;
            lblNewValue.Text = "New value";
            // 
            // ttbNewValue
            // 
            ttbNewValue.Location = new Point(471, 197);
            ttbNewValue.MaxLength = 9;
            ttbNewValue.Name = "ttbNewValue";
            ttbNewValue.Size = new Size(292, 23);
            ttbNewValue.TabIndex = 8;
            // 
            // btnReplace
            // 
            btnReplace.Location = new Point(580, 259);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(75, 23);
            btnReplace.TabIndex = 9;
            btnReplace.Text = "Replace";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += btnReplace_Click;
            // 
            // lblCurrentValue
            // 
            lblCurrentValue.AutoSize = true;
            lblCurrentValue.Location = new Point(471, 121);
            lblCurrentValue.Name = "lblCurrentValue";
            lblCurrentValue.Size = new Size(78, 15);
            lblCurrentValue.TabIndex = 5;
            lblCurrentValue.Text = "Current value";
            // 
            // ttbCurrentValue
            // 
            ttbCurrentValue.Location = new Point(471, 139);
            ttbCurrentValue.MaxLength = 10;
            ttbCurrentValue.Name = "ttbCurrentValue";
            ttbCurrentValue.ReadOnly = true;
            ttbCurrentValue.Size = new Size(292, 23);
            ttbCurrentValue.TabIndex = 6;
            // 
            // FrmLLKeywords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnReplace);
            Controls.Add(ttbCurrentValue);
            Controls.Add(lblCurrentValue);
            Controls.Add(ttbNewValue);
            Controls.Add(lblNewValue);
            Controls.Add(ttbIndex);
            Controls.Add(lblIndex);
            Controls.Add(listKeywords);
            Controls.Add(lbl1stRead);
            Controls.Add(btn1stRead);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLLKeywords";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Love Love Keywords";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl1stRead;
        private Button btn1stRead;
        private ListView listKeywords;
        private ColumnHeader colPointer;
        private ColumnHeader colIndex;
        private ColumnHeader colValue;
        private Label lblIndex;
        private TextBox ttbIndex;
        private Label lblNewValue;
        private TextBox ttbNewValue;
        private Button btnReplace;
        private Label lblCurrentValue;
        private TextBox ttbCurrentValue;
    }
}