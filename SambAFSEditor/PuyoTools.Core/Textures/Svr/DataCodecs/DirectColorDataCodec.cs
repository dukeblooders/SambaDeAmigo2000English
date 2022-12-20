﻿using PuyoTools.Core.Textures.Svr.PixelCodecs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuyoTools.Core.Textures.Svr.DataCodecs
{
    /// <inheritdoc/>
    internal class DirectColorDataCodec : DataCodec
    {
        public override bool CanEncode => true;

        public override int BitsPerPixel => pixelCodec.BitsPerPixel;

        public DirectColorDataCodec(PixelCodec pixelCodec) : base(pixelCodec)
        {
        }

        public override byte[] Decode(byte[] source, int width, int height)
        {
            int bytesPerPixel = BitsPerPixel / 8;

            var destination = new byte[width * height * 4];

            int sourceIndex = 0;
            int destinationIndex = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pixelCodec.DecodePixel(source, sourceIndex, destination, destinationIndex);

                    sourceIndex += bytesPerPixel;
                    destinationIndex += 4;
                }
            }

            return destination;
        }

        public override byte[] Encode(byte[] source, int width, int height)
        {
            int bytesPerPixel = BitsPerPixel / 8;

            var destination = new byte[width * height * bytesPerPixel];

            int sourceIndex = 0;
            int destinationIndex = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pixelCodec.EncodePixel(source, sourceIndex, destination, destinationIndex);

                    sourceIndex += 4;
                    destinationIndex += bytesPerPixel;
                }
            }

            return destination;
        }
    }
}
