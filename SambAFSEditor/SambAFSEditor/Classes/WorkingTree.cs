using System.Text.Json;
using System.Text.Json.Serialization;

namespace SambAFSEditor
{
    internal class WorkingTree
    {
        private const string NAME = "tree.json";


        public static Boolean Exists(string? workingDir)
        {
            if (workingDir == null)
                return false;

            return File.Exists(Path.Combine(workingDir, NAME));
        }


        public static WorkingStruct? Read(string workingDir)
        {
            var path = Path.Combine(workingDir, NAME);
            var content = File.ReadAllText(path);

            return JsonSerializer.Deserialize<WorkingStruct>(content, new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            });
        }


        public static void Write(WorkingStruct workStruct)
        {
            var path = Path.Combine(workStruct.Directory, NAME);
            var content = JsonSerializer.Serialize(workStruct, new JsonSerializerOptions
            { 
                Converters =
                {
                    new JsonStringEnumConverter()
                },
                WriteIndented = true
            });

            File.WriteAllText(path, content);
        }
    }
}
