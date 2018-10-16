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
            string workingDirectory;
#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif
            var filePath = Path.Combine(workingDirectory, "doc", "test.pdf");
            return xpdfNet.ToText(filePath);
        }
    }
}
