using OfficeOpenXml;
using System;
using System.IO;

namespace UsingEPPlus
{
    public class PackageCreator
    {
        public ExcelPackage GetExcelPackage()
        {
            string workingDirectory;
#if NETCOREAPP1_1
            workingDirectory = AppContext.BaseDirectory;
#else
            workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
#endif
            var filePath = Path.Combine(workingDirectory, "doc", "test.xlsx");

            return new ExcelPackage(new FileInfo(filePath));
        }
    }
}
