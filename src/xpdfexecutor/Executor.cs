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
            var xpdfNet = new XpdfNet.XpdfHelper();
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Trace.WriteLine($"executingDirectory: {executingDirectory}");
            var argumentsPath = Path.Combine(executingDirectory, "doc", "test.pdf");
            return xpdfNet.ToText(argumentsPath);
        }
    }
}
