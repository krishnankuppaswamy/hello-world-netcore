using System;
using Xunit;

namespace UsingEPPlus.UnitTest
{
    public class PackageCreatorTest
    {
        [Fact]
        public void GetExcelPackage_ForStoredFile()
        {
            var packageCreator = new PackageCreator();

            var actual = packageCreator.GetExcelPackage();

            Assert.Equal(3, actual.Workbook.Worksheets.Count);
        }
    }
}
