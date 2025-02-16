
using System.IO;
using System.Runtime;

namespace Files
{
    public class DirectoryEditor
    {
        private void CreateDirectory(DirectoryInfo dir)
        {
            if (!dir.Exists)
            {
                dir.Create();
            }
        }
        public List<DirectoryInfo> CreateDirectories(string[] paths)
        {
            List<DirectoryInfo> directories = [];
            foreach (string path in paths)
            {
                DirectoryInfo directory = new(path);
                CreateDirectory(directory);
                directories.Add(directory);
            }
            return directories;
        }
    }
}
