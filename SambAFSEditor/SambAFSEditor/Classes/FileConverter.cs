using PuyoTools.Core.Archives;
using PuyoTools.Core.Compression;
using PuyoTools.Core.Textures;
using PuyoTools.Core.Textures.Pvr;
using System.IO;


namespace SambAFSEditor
{
    internal class FileConverter
    {
        public static void Identify(WorkingStruct workStruct, ContentFile contentFile)
        {
            var path = contentFile.GetPath(workStruct);
            var type = ContentFileType.Unknown;
            var compression = ContentFileCompression.None;

            using var inStream = File.OpenRead(path);

            if (PvmArchive.Identify(inStream))
                type = ContentFileType.PVM;
            else if (PvrTexture.Identify(ResetStream(inStream)))
                type = ContentFileType.PVR;
            else
            {
                if (PrsCompression.Identify(ResetStream(inStream)))
                {
                    compression = ContentFileCompression.PRS;

                    var prs = new PrsCompression();
                    using var msStream = prs.Decompress(ResetStream(inStream));

                    if (PvmArchive.Identify(ResetStream(msStream)))
                        type = ContentFileType.PVM;
                    else if (PvrTexture.Identify(ResetStream(msStream)))
                        type = ContentFileType.PVR;
                }
            }

            contentFile.Type = type;
            contentFile.Compression = compression;
        }


        private static void EncodeParent(WorkingStruct workStruct, ContentFile contentFile)
        {
            var parent = workStruct.ContentFiles.FirstOrDefault(f => f.Id == contentFile.ParentId);
            if (parent == null)
                return;

            switch (parent.Type)
            {
                case ContentFileType.PVM:
                    EncodePVM(workStruct, parent);
                    break;
            }

            EncodeParent(workStruct, parent);
        }



        #region PVR

        public static void EncodePVR(WorkingStruct workStruct, ContentFile contentFile, String sourcePath, PvrTextureDecoder decoder)
        {
            var destinationPath = contentFile.GetPath(workStruct);
            var tempPath = Path.GetTempFileName();

            try
            {
                var pvr = new PvrTexture
                {
                    CompressionFormat = decoder.CompressionFormat,
                    DataFormat = decoder.DataFormat,
                    GlobalIndex = decoder.GlobalIndex ?? 0,
                    HasGlobalIndex = decoder.GlobalIndex != null,
                    PixelFormat = decoder.PixelFormat,
                };

                using (var inStream = File.OpenRead(sourcePath))
                using (var outStream = File.OpenWrite(tempPath))
                    switch (contentFile.Compression)
                    {
                        case ContentFileCompression.PRS:
                            using (var prsStream = pvr.Write(inStream))
                                new PrsCompression().Compress(prsStream, outStream);
                            break;

                        default:
                            pvr.Write(inStream, outStream);
                            break;
                    }

                File.Copy(tempPath, destinationPath, true);
            }
            finally
            {
                File.Delete(tempPath);
            }

            EncodeParent(workStruct, contentFile);
        }


        public static Bitmap DecodePVR(WorkingStruct workStruct, ContentFile contentFile, out PvrTextureDecoder decoder)
        {
            var sourcePath = contentFile.GetPath(workStruct);

            using var fileStream = File.OpenRead(sourcePath);

            switch (contentFile.Compression)
            {
                case ContentFileCompression.PRS:
                    using (var prsStream = new PrsCompression().Decompress(fileStream))
                        return DecodePVR(prsStream, out decoder);

                default:
                    return DecodePVR(fileStream, out decoder);
            }
        }


        private static Bitmap DecodePVR(Stream stream, out PvrTextureDecoder decoder)
        {
            using var pvrStream = new PvrTexture().Read(stream);

            var bitmap = new Bitmap(pvrStream);

            decoder = new PvrTextureDecoder(ResetStream(stream));

            return bitmap;
        }

        #endregion


        #region PVM

        public static void EncodePVM(WorkingStruct workStruct, ContentFile contentFile)
        {
            var destinationPath = contentFile.GetPath(workStruct);
            var tempPath = Path.GetTempFileName();

            try
            {
                var entryStreams = new List<Stream>();

                using (var outStream = File.OpenWrite(tempPath))
                using (var writer = new PvmArchive().Create(outStream))
                    foreach (var entry in workStruct.ContentFiles.Where(f => f.ParentId == contentFile.Id))
                    {
                        if (entry.Compression != ContentFileCompression.None)
                            throw new NotImplementedException(entry.Compression.ToString());

                        var entryStream = File.OpenRead(entry.GetPath(workStruct));
                        entryStreams.Add(entryStream);

                        writer.CreateEntry(entryStream, entry.FileName ?? entry.Name);
                    }

                foreach (var entryStream in entryStreams)
                    entryStream.Dispose();

                switch (contentFile.Compression)
                {
                    case ContentFileCompression.PRS:
                        new PrsCompression().Compress(tempPath, destinationPath);
                        break;
                    default:
                        File.Copy(tempPath, destinationPath, true);
                        break;
                }
            }
            finally
            {
                File.Delete(tempPath);
            }

            EncodeParent(workStruct, contentFile);
        }


        public static void DecodePVM(WorkingStruct workStruct, ContentFile contentFile)
        {
            var sourcePath = contentFile.GetPath(workStruct);

            using var fileStream = File.OpenRead(sourcePath);

            switch (contentFile.Compression)
            {
                case ContentFileCompression.PRS:
                    using (var prsStream = new PrsCompression().Decompress(fileStream))
                        DecodePVM(prsStream, workStruct, contentFile);
                    break;

                default:
                    DecodePVM(fileStream, workStruct, contentFile);
                    break;
            }
        }


        private static void DecodePVM(Stream stream, WorkingStruct workStruct, ContentFile contentFile)
        {
            var folderPath = contentFile.FileName ?? contentFile.Name;
            var outPath = Path.Combine(workStruct.Directory, folderPath);
            var index = workStruct.ContentFiles.Max(f => f.Id) + 1;

            var archive = new PvmArchive().Open(stream);
            var files = new List<ContentFile>();
            var fileCount = archive.Entries.Count;

            for (int i = 0; i < fileCount; i++)
            {
                var entry = archive.Entries[i];
                var entryData = entry.Open();

                var newContentFile = new ContentFile
                {
                    Id = index + i,
                    ParentId = contentFile.Id,
                    Name = entry.FullName,
                    FileName = i.ToString("D" + fileCount.ToString().Length) + Path.GetExtension(entry.Name),
                    FolderPath = folderPath
                };
                files.Add(newContentFile);

                using var outStream = File.Create(newContentFile.GetPath(workStruct));

                entryData.CopyTo(outStream);
            }

            contentFile.FileCount = fileCount;
            workStruct.ContentFiles.RemoveAll(f => f.FolderPath.Equals(folderPath));
            workStruct.ContentFiles.AddRange(files);
        }

        #endregion



        public static Stream ResetStream(Stream stream)
        {
            stream.Position = 0;
            return stream;
        }
    }
}
