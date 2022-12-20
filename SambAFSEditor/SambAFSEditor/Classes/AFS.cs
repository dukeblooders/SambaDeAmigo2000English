using PuyoTools.Core.Archives;


namespace SambAFSEditor
{
    internal class AFS
    {
        private const String FOLDER_NAME = "_AFSDIR_";


        public static void Extract(string afsFilePath, WorkingStruct workStruct)
        {
            var archive = new AfsArchive().Open(afsFilePath);

            for (int i = 0; i < archive.Entries.Count; i++)
            {
                var entry = archive.Entries[i];
                var entryData = entry.Open();

                var contentfile = new ContentFile
                {
                    Id = i + 1,
                    Name = entry.FullName,
                    FileName = i.ToString("D" + archive.Entries.Count.ToString().Length) + Path.GetExtension(entry.Name),
                    FolderPath = FOLDER_NAME
                };

                workStruct.ContentFiles.Add(contentfile);

                using var outStream = File.Create(contentfile.GetPath(workStruct));

                entryData.CopyTo(outStream);
            }
        }


        public static void Write(IWin32Window parent, WorkingStruct workStruct)
        {
            var afsPath = GetAFSFilePath(parent, workStruct);
            if (afsPath == null)
                return;

            var inDir = GetAFSPath(workStruct);

            using var outStream = File.Create(afsPath);
            using var archive = new AfsArchive().Create(outStream);

            foreach (var entry in workStruct.ContentFiles)
                if (entry.ParentId == null)
                    archive.CreateEntryFromFile(Path.Combine(inDir, entry.FileName ?? entry.Name), entry.Name);
        }


        private static string GetAFSPath(WorkingStruct workStruct)
        {
            var path = Path.Combine(workStruct.Directory, FOLDER_NAME);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }


        private static string? GetAFSFilePath(IWin32Window parent, WorkingStruct workStruct)
        {
            if (File.Exists(workStruct.AFSFilePath))
                switch (DialogBox.Question(parent, Properties.Resources.ReplaceAFS, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        return workStruct.AFSFilePath;
                    case DialogResult.Cancel:
                        return null;
                }

            using var dialog = new SaveFileDialog 
            { 
                Filter = Properties.Resources.FilterAFS,
                FileName = String.IsNullOrEmpty(workStruct.AFSFilePath) ? String.Empty : workStruct.AFSFilePath
            };

            if (dialog.ShowDialog(parent) == DialogResult.OK)
            {
                workStruct.AFSFilePath = dialog.FileName;
                WorkingTree.Write(workStruct);

                return dialog.FileName;
            }

            return null;
        }
    }
}
