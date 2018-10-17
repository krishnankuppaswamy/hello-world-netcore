using System;
using System.IO;

namespace FileOps
{
    public class FileManager
    {
        public void CreateFile()
        {
            using (var sw = new StreamWriter(@"test.txt", false))
            {
                sw.WriteLine($"FileManager.CreateFile test at {DateTime.Now}");
            }
        }

        public string ReadFile()
        {
            var fileContent = string.Empty;
            using (var sr = new StreamReader(@"test.txt"))
            {
                fileContent = sr.ReadToEnd();
            }
            return fileContent;
        }

        public bool Exists()
        {
            return File.Exists(@"test.txt");
        }
    }
}
