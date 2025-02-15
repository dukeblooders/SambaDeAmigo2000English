namespace SambAFSEditor
{
    internal class PVP
    {
        public static Color[] Read(Stream stream)
        {
            stream.Seek(0x08, SeekOrigin.Begin);

            var pixelType = stream.ReadByte();
            var mode = pixelType switch
            {
                1 => 565,
                2 => 4444,
                6 => 8888,
                _ => 555,
            };

            stream.Seek(0x0E, SeekOrigin.Begin);
            ushort ttlEntries = ReadUInt16(stream);

            stream.Seek(0x10, SeekOrigin.Begin);
            var colors = new Color[ttlEntries];

            for (int counter = 0; counter < ttlEntries; counter++)
                if (mode != 8888)
                {
                    var colorValue = ReadUInt16(stream);
                    colors[counter] = ReadColor(mode, colorValue);
                }
                else
                {
                    var colorValue = ReadUInt32(stream);
                    colors[counter] = ReadColor(mode, (int)colorValue);
                }

            return colors;
        }


        private static ushort ReadUInt16(Stream stream)
        {
            var buffer = new byte[2];
            stream.Read(buffer, 0, 2);

            return BitConverter.ToUInt16(buffer, 0);
        }


        private static uint ReadUInt32(Stream stream)
        {
            var buffer = new byte[4];
            stream.Read(buffer, 0, 4);

            return BitConverter.ToUInt32(buffer, 0);
        }


        private static Color ReadColor(int mode, int colorValue)
        {
            switch (mode)
            {
                case 565:
                    int r565 = (colorValue >> 11) & 0x1F;
                    int g565 = (colorValue >> 5) & 0x3F;
                    int b565 = colorValue & 0x1F;
                    return Color.FromArgb(r565 << 3, g565 << 2, b565 << 3);
                case 4444:
                    int r4444 = (colorValue >> 8) & 0x0F;
                    int g4444 = (colorValue >> 4) & 0x0F;
                    int b4444 = colorValue & 0x0F;
                    return Color.FromArgb((r4444 << 4), (g4444 << 4), (b4444 << 4));
                case 8888:
                    int a8888 = (colorValue >> 24) & 0xFF;
                    int r8888 = (colorValue >> 16) & 0xFF;
                    int g8888 = (colorValue >> 8) & 0xFF;
                    int b8888 = colorValue & 0xFF;
                    return Color.FromArgb(a8888, r8888, g8888, b8888);
                default: // 555
                    int r555 = (colorValue >> 10) & 0x1F;
                    int g555 = (colorValue >> 5) & 0x1F;
                    int b555 = colorValue & 0x1F;
                    return Color.FromArgb(r555 << 3, g555 << 3, b555 << 3);
            }
        }
    }
}
