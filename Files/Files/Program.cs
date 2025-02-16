namespace Files
{
    internal class Program
    {
        static async Task Main()
        {
            DirectoryEditor directoryEditor = new();
            string[] paths = ["c:\\Otus\\TestDir1", "c:\\Otus\\TestDir2"];
            List<DirectoryInfo> directories = directoryEditor.CreateDirectories(paths);

            FileEditor fileEditor = new();
            List<FileStream> files = fileEditor.CreateFiles(3, directories);
            await fileEditor.WriteFileName(files);
            await fileEditor.WriteDate(files);

            string filesInfo = await fileEditor.ReadAllFiles(directories);
            Console.WriteLine(filesInfo);
        }
    }
}