namespace SambAFSEditor
{
    internal class WorkingStruct
    {
        public string Directory { get; set; } = null!;
        public string? AFSFilePath { get; set; }
        public List<ContentFile> ContentFiles { get; set; }



        public WorkingStruct()
        {
            ContentFiles = new List<ContentFile>();
        }
    }


    internal class ContentFile
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FolderPath { get; set; } = null!;
        public ContentFileType Type { get; set; }
        public ContentFileCompression Compression { get; set; }
        public Boolean Checked { get; set; }
        public Boolean UpToDate { get; set; }
        public int FileCount { get; set; }



        public string GetPath(WorkingStruct workStruct)
        {
            var path = Path.Combine(workStruct.Directory, FolderPath);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return Path.Combine(path, FileName ?? Name);
        }


        public override string ToString()
        {
            var name = String.IsNullOrEmpty(Name) ? FileName : Name;

            switch (Type)
            {
                case ContentFileType.Unknown:
                    // Empty
                    break;
                case ContentFileType.PVM:
                    name += $" ({Type} - {string.Format(Properties.Resources.FileCount, FileCount)})";
                    break;
                default:
                    name += $" ({Type})";
                    break;
            }

            return name;
        }
    }


    public enum ContentFileType
    { 
        Unknown,
        PVM,
        PVR,
    }

    public enum ContentFileCompression
    {
        None,
        PRS
    }
}
