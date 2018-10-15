using System;
using System.Diagnostics;
using System.IO;

namespace xpdfexecutor
{
    public class Executor
    {
        public string Execute()
        {
            var fileName = @".\lib\pdftotext.exe";
            var arguments = @"-simple -f 1 "".\doc\test.pdf"" ""test.txt""";

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
