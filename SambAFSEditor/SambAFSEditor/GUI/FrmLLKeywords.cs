using System.Text;


namespace SambAFSEditor
{
    public partial class FrmLLKeywords : Form
    {
        private const long POINTER_BEGIN = 0x8C010000;
        private const long BEGIN = 0x001D6790;
        private const long END = 0x001D6A58;

        private static Encoding? jisEncoding;

        private List<CharRow> charTable;




        public FrmLLKeywords()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            charTable = InitCharTable();
            jisEncoding = Encoding.GetEncoding(932); // Shift-JIS
        }


        private List<CharRow> InitCharTable()
        {
            return
            [
                new('A', [0x82, 0x60]), new('a', [0x82, 0x81]),
                new('B', [0x82, 0x61]), new('b', [0x82, 0x82]),
                new('C', [0x82, 0x62]), new('c', [0x82, 0x83]),
                new('D', [0x82, 0x63]), new('d', [0x82, 0x84]),
                new('E', [0x82, 0x64]), new('e', [0x82, 0x85]),
                new('F', [0x82, 0x65]), new('f', [0x82, 0x86]),
                new('G', [0x82, 0x66]), new('g', [0x82, 0x87]),
                new('H', [0x82, 0x67]), new('h', [0x82, 0x88]),
                new('I', [0x82, 0x68]), new('i', [0x82, 0x89]),
                new('J', [0x82, 0x69]), new('j', [0x82, 0x8A]),
                new('K', [0x82, 0x6A]), new('k', [0x82, 0x8B]),
                new('L', [0x82, 0x6B]), new('l', [0x82, 0x8C]),
                new('M', [0x82, 0x6C]), new('m', [0x82, 0x8D]),
                new('N', [0x82, 0x6D]), new('n', [0x82, 0x8E]),
                new('O', [0x82, 0x6E]), new('o', [0x82, 0x8F]),
                new('P', [0x82, 0x6F]), new('p', [0x82, 0x90]),
                new('Q', [0x82, 0x70]), new('q', [0x82, 0x91]),
                new('R', [0x82, 0x71]), new('r', [0x82, 0x92]),
                new('S', [0x82, 0x72]), new('s', [0x82, 0x93]),
                new('T', [0x82, 0x73]), new('t', [0x82, 0x94]),
                new('U', [0x82, 0x74]), new('u', [0x82, 0x95]),
                new('V', [0x82, 0x75]), new('v', [0x82, 0x96]),
                new('W', [0x82, 0x76]), new('w', [0x82, 0x97]),
                new('X', [0x82, 0x77]), new('x', [0x82, 0x98]),
                new('Y', [0x82, 0x78]), new('y', [0x82, 0x99]),
                new('Z', [0x82, 0x79]), new('z', [0x82, 0x9A]),
                new('1', [0x82, 0x50]),
                new('2', [0x82, 0x51]),
                new('3', [0x82, 0x52]),
                new('4', [0x82, 0x53]),
                new('5', [0x82, 0x54]),
                new('6', [0x82, 0x55]),
                new('7', [0x82, 0x56]),
                new('8', [0x82, 0x57]),
                new('9', [0x82, 0x58]),
                new(' ', [0x20, 0x20]),  new('.', [0x81, 0x44]),  new('!', [0x81, 0x49]), new('-', [0x81, 0x5C]),
                new('@', [0x81, 0x97])
            ];
        }


        #region READ FILE

        private void btn1stRead_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = Properties.Resources.FilterBIN
            };

            try
            {
                listKeywords.BeginUpdate();
                listKeywords.Items.Clear();

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    lbl1stRead.Text = dialog.FileName;

                    var keywords = ReadFile(dialog.FileName);

                    foreach (var keyword in keywords)
                    {
                        var item = new ListViewItem(keyword.Pointer.ToString("X2"));
                        item.SubItems.Add(keyword.Index.ToString("X2"));
                        item.SubItems.Add(keyword.ValueText);
                        item.Tag = keyword;

                        listKeywords.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
            }
            finally
            {
                listKeywords.EndUpdate();

                listKeywords_SelectedIndexChanged(listKeywords, new EventArgs());
            }
        }

        private List<Keyword> ReadFile(string path)
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            stream.Seek(BEGIN, SeekOrigin.Begin);

            var keywords = new List<Keyword>();

            while (stream.Position < END)
            {
                var keyword = new Keyword
                {
                    Pointer = stream.Position
                };

                var buffer = new byte[4];
                stream.Read(buffer, 0, buffer.Length);

                keyword.PointerValue = buffer;

                ReadValue(stream, keyword);

                keywords.Add(keyword);
            }

            return keywords;
        }


        private void ReadValue(Stream stream, Keyword keyword)
        {
            stream.Position = keyword.Index;

            var bytes = new List<byte>();

            int b;
            while ((b = stream.ReadByte()) != 0)
                bytes.Add((byte)b);

            keyword.Value = [.. bytes];

            stream.Position = keyword.Pointer + 4;
        }

        #endregion


        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKeywords.SelectedItems.Count == 0)
            {
                ttbIndex.Text = string.Empty;
                ttbCurrentValue.Text = string.Empty;
                ttbNewValue.Text = string.Empty;

                btnReplace.Enabled = false;
            }
            else
            {
                var keyword = (Keyword)listKeywords.SelectedItems[0].Tag!;

                ttbIndex.Text = keyword.Index.ToString("X2");
                ttbCurrentValue.Text = keyword.ValueText;
                ttbNewValue.Text = string.Empty;

                btnReplace.Enabled = true;
            }
        }


        #region REPLACE

        private void btnReplace_Click(object sender, EventArgs e)
        {
            var keyword = (Keyword)listKeywords.SelectedItems[0].Tag!;

            try
            {
                using var stream = new FileStream(lbl1stRead.Text, FileMode.Open, FileAccess.ReadWrite);

                ClearValue(stream, keyword);
                UpdatePointer(stream, keyword);
                WriteValue(stream, keyword);

                listKeywords.SelectedItems[0].Text = keyword.Pointer.ToString("X2");
                listKeywords.SelectedItems[0].SubItems[1].Text = keyword.Index.ToString("X2");
                listKeywords.SelectedItems[0].SubItems[2].Text = keyword.ValueText;
            }
            catch (Exception ex)
            {
                DialogBox.Error(this, ex.ToString());
            }
        }


        private static void ClearValue(Stream stream, Keyword keyword)
        {
            stream.Position = keyword.Index;

            for (int i = 0; i < keyword.Value.Length; i++)
                stream.WriteByte(0);
        }


        private void UpdatePointer(Stream stream, Keyword keyword)
        {
            stream.Position = keyword.Pointer;

            keyword.Index = Convert.ToInt64(ttbIndex.Text, 16);

            foreach (var b in keyword.PointerValue)
                stream.WriteByte(b);
        }


        private void WriteValue(Stream stream, Keyword keyword)
        {
            var bytes = new List<byte>();
            foreach (var c in ttbNewValue.Text.Trim())
                bytes.AddRange(charTable.First(t => t.Letter == c).Value);

            keyword.Value = [.. bytes];

            stream.Position = keyword.Index;

            foreach (var b in keyword.Value)
                stream.WriteByte(b);
        }

        #endregion


        #region CLASSES

        private class Keyword
        {
            public long Pointer { get; set; }
            public byte[] PointerValue { get; set; } = [];
            public byte[] Value { get; set; } = [];

            public long Index
            {
                get { return Convert.ToInt64($"{PointerValue[3]:X2}{PointerValue[2]:X2}{PointerValue[1]:X2}{PointerValue[0]:X2}", 16) - POINTER_BEGIN; }
                set 
                {
                    var v = (value + POINTER_BEGIN).ToString("X2");

                    PointerValue = [
                        Convert.ToByte($"0x{v[6..8]}", 16),
                        Convert.ToByte($"0x{v[4..6]}", 16),
                        Convert.ToByte($"0x{v[2..4]}", 16),
                        Convert.ToByte($"0x{v[..2]}", 16)
                    ];
                }
            }

            public string? ValueText
            {
                get { return jisEncoding?.GetString(Value); }
            }
        }


        private class CharRow(char letter, byte[] value)
        {
            public char Letter { get; set; } = letter;
            public byte[] Value { get; set; } = value;
        }

        #endregion
    }
}
