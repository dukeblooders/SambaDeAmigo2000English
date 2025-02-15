using PuyoTools.Core.Textures.Pvr.PixelCodecs;
using System;


namespace PuyoTools.Core.Textures.Pvr.DataCodecs
{
    /// <inheritdoc/>
    internal class VqDataCodec : DataCodec
    {
        public override bool CanEncode => true;

        public override int BitsPerPixel => 2;

        public override int PaletteEntries => 1024; // Technically 256

        public override bool HasMipmaps => false;

        public VqDataCodec(PixelCodec pixelCodec) : base(pixelCodec)
        {
        }

        public override byte[] Decode(byte[] source, int width, int height)
        {
            if (Palette is null)
            {
                throw new InvalidOperationException("Palette must be set.");
            }

            var twiddleMap = CreateTwiddleMap(width);
            var destination = new byte[width * height * 4];

            for (int y = 0; y < height; y += 2)
                for (int x = 0; x < width; x += 2)
                {
                    var sourceIndex = (twiddleMap[x / 2] << 1) | twiddleMap[y / 2];
                    var paletteIndex = source[sourceIndex] * 4;

                    for (int x2 = 0; x2 < 2; x2++)
                        for (int y2 = 0; y2 < 2; y2++)
                        {
                            var destinationIndex = ((y + y2) * width + x + x2) * 4;

                            for (int i = 0; i < 4; i++)
                                destination[destinationIndex + i] = Palette[paletteIndex * 4 + i];

                            paletteIndex++;
                        }
                }

            return destination;
        }


        public override byte[] Encode(byte[] source, int width, int height)
        {
            if (Palette is null)
            {
                throw new InvalidOperationException("Palette must be set.");
            }
     
            var twiddleMap = CreateTwiddleMap(width);
            var destination = new byte[width * height / 4];

            for (int y = 0; y < height; y += 2)
                for (int x = 0; x < width; x += 2)
                {
                    var destinationIndex = (twiddleMap[x / 2] << 1) | twiddleMap[y / 2];
                    var block = new int[16];
                    var blockIndex = 0;

                    for (int x2 = 0; x2 < 2; x2++)
                        for (int y2 = 0; y2 < 2; y2++)
                        {
                            var sourceIndex = ((y + y2) * width + x + x2) * 4;

                            for (int i = 0; i < 4; i++)
                                block[blockIndex++] = source[sourceIndex + i];
                        }

                    destination[destinationIndex] = FindClosestPaletteIndex(block);
                }

            return destination;
        }


        private byte FindClosestPaletteIndex(int[] block)
        {
            var closestIndex = 0;
            var closestDistance = int.MaxValue;

            for (int i = 0; i < Palette.Length / 16; i++)
            {
                var distance = 0;

                for (int j = 0; j < block.Length / 4; j++)
                    if (block[j * 4 + 3] + Palette[i * 16 + j * 4 + 3] != 0) // Compare alphas, ignore transparent block
                        for (int k = 0; k < 4; k++)
                        {
                            var diff = block[j * 4 + k] - Palette[i * 16 + j * 4 + k];
                            distance += diff * diff;
                        }

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }

            return (byte)closestIndex;
        }


        private class VqColor
        {
            public int Index { get; set; }
            public int Diff { get; set; }
        }


        public override bool IsValidDimensions(int width, int height)
        {
            return width == height
                && width is >= 8 and <= 1024
                && MathHelper.IsPow2(width);
        }
    }
}
