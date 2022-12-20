﻿using PuyoTools.App.Cli.Commands.Textures;
using PuyoTools.Core.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuyoTools.App.Formats.Textures
{
    /// <inheritdoc/>
    internal partial class GvrFormat : ITextureFormat
    {
        public string CommandName => "gvr";

        public TextureFormatEncodeCommand GetEncodeCommand() => new GvrTextureEncodeCommand(this);
    }
}
