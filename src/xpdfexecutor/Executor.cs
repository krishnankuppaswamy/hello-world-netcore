using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace xpdfexecutor
{
    public class Executor
    {
        public static void Exec(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\""
                }
            };

            process.Start();
            process.WaitForExit();
        }

        public string Execute()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Trace.WriteLine($"executingDirectory: {executingDirectory}");

            var fileName = Path.Combine(executingDirectory, "lib", "pdftotext.exe");
            var argumentsPath = Path.Combine(executingDirectory, "doc", "test.pdf");
            var arguments = $@"-simple -f 1 ""{argumentsPath}"" ""test.txt""";

            Trace.WriteLine($"FileName: {fileName}, FullPath: {Path.GetFullPath(fileName)}");

            if (!File.Exists(fileName))
                throw new Exception($"FileName: {fileName}, FullPath: {Path.GetFullPath(fileName)}");

            try
            {
                Exec($"chmod 644 {fileName}");
            }
            catch { }

            try
            {
                Exec($"chown -R $USER:$USER {fileName}");
            }
            catch { }

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

        //public string GetVersionInfo()
        //{
        //    var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    Trace.WriteLine($"executingDirectory: {executingDirectory}");

        //    var fileName = Path.Combine(executingDirectory, "lib", "pdftotext.exe");
        //    Trace.WriteLine($"FileName: {fileName}, FullPath: {Path.GetFullPath(fileName)}");

        //    if (!File.Exists(fileName))
        //        throw new Exception($"FileName: {fileName}, FullPath: {Path.GetFullPath(fileName)}");

        //    var processStartInfo = new ProcessStartInfo(fileName, "-v");
        //    processStartInfo.RedirectStandardError = true;
        //    processStartInfo.UseShellExecute = false;
        //    processStartInfo.CreateNoWindow = true;
        //    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    Process process = Process.Start(processStartInfo);
        //    string error = process.StandardError.ReadToEnd();
        //    process.WaitForExit();
        //    if (process.ExitCode != 0)
        //        throw new Exception(error);

        //    var pdfContent = File.ReadAllText(@".\vtest.txt");
        //    return pdfContent;
        //}
    }
}
