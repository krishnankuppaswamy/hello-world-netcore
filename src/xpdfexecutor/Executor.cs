using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace xpdfexecutor
{
    public class Executor
    {
        public string Execute()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Trace.WriteLine($"executingDirectory: {executingDirectory}");
            
            var fileName = Path.Combine(executingDirectory, @"lib\pdftotext.exe");
            var arguments = $@"-simple -f 1 ""{executingDirectory}\doc\test.pdf"" ""test.txt""";

            if (!File.Exists(fileName))
                throw new Exception($"FileName: {fileName}, FullPath: {Path.GetFullPath(fileName)}");

            Trace.WriteLine($"FileName: {fileName}, FullPath: {Path.GetFullPath(fileName)}");

            var processStartInfo = new ProcessStartInfo(fileName, arguments);
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = Process.Start(processStartInfo);
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (process.ExitCode != 0)
                throw new Exception(error);

            var pdfContent = File.ReadAllText(@".\test.txt");
            return pdfContent;
        }
    }
}
