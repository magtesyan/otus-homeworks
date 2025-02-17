﻿using System.IO;
using System.Reflection;
using System.Text;

namespace Files
{
    public class FileEditor
    {
        public List<FileStream> CreateFiles(int count, List<DirectoryInfo> directories)
        {
            List<FileStream> files = [];
            foreach (DirectoryInfo directory in directories)
            {
                for (int i = 1; i <= count; i++)
                {
                    string path = $"{directory.FullName}\\File{i}";
                    using FileStream fs = File.Create(path);
                    files.Add(fs);
                }
            }
            return files;
        }

        public async Task WriteFileName(List<FileStream> files)
        {
            foreach (FileStream file in files)
            {
                try
                {
                    using FileStream fileStream = File.OpenWrite(file.Name);
                    string fileName = Path.GetFileName(fileStream.Name);
                    byte[] bytesToWrite = Encoding.UTF8.GetBytes(fileName);
                    await fileStream.WriteAsync(bytesToWrite);
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public async Task WriteDate(List<FileStream> files)
        {
            foreach (FileStream file in files)
            {
                try
                {
                    using FileStream fileStream = new FileStream(file.Name, FileMode.Append);
                    string today = DateTime.Now.ToString();
                    byte[] bytesToWrite = Encoding.UTF8.GetBytes('\n' + today);
                    await fileStream.WriteAsync(bytesToWrite);
                }
                finally
                {
                    file.Close();
                }
            }
        }

        public async Task<string> ReadAllFiles(List<DirectoryInfo> directories)
        {
            string result = "";
            foreach (DirectoryInfo directory in directories)
            {
                FileInfo[] files = directory.GetFiles();
                result += $"Directory: {directory.Name}\n";

                foreach (FileInfo fileInfo in files)
                {
                    using FileStream file = File.OpenRead(fileInfo.FullName);
                    byte[] buffer = new byte[file.Length];
                    await file.ReadAsync(buffer);
                    result += $"{Encoding.UTF8.GetString(buffer)}\n";
                }
                result += '\n';
            }
            return result;
        }
    }
}
