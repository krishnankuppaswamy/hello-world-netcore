using System.IO;
using Xunit;

namespace FileOps.UnitTest
{
    public class FileManagerTest
    {
        [Fact]
        public void ShouldCreateTheFile()
        {
            var fileManager = new FileManager();

            fileManager.CreateFile();

            Assert.True(File.Exists(@"test.txt"));
        }

        [Fact]
        public void ShouldReadTheFile()
        {
            if (File.Exists(@"test.txt"))
                File.Delete(@"test.txt");
            var fileManager = new FileManager();
            fileManager.CreateFile();

            var actual = fileManager.ReadFile();

            Assert.Contains("FileManager.CreateFile test at ", actual);
        }

        [Fact]
        public void ShouldRetunFalseWhenNoFileExists()
        {
            if (File.Exists(@"test.txt"))
                File.Delete(@"test.txt");
            var fileManager = new FileManager();

            var actual = fileManager.Exists();

            Assert.False(actual);
        }

        [Fact]
        public void ShouldRetunTrueWhenFileExists()
        {
            if (File.Exists(@"test.txt"))
                File.Delete(@"test.txt");
            var fileManager = new FileManager();
            fileManager.CreateFile();

            var actual = fileManager.Exists();

            Assert.True(actual);
        }
    }
}
