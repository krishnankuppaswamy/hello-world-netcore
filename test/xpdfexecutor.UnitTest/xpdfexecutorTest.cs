using Xunit;

namespace xpdfexecutor.UnitTest
{
    public class xpdfexecutorTest
    {
        //[Fact]
        //public void ShouldReturnXpdfVersionInfo()
        //{
        //    var xpdfexecutor = new Executor();

        //    var actual = xpdfexecutor.GetVersionInfo();

        //    Assert.StartsWith("pdftotext version 4.00", actual);
        //}

        [Fact]
        public void ShouldReturnPdfContent()
        {
            var xpdfexecutor = new Executor();

            var actual = xpdfexecutor.Execute();

            Assert.Equal("This is first line!\r\n\f", actual);
        }
    }
}
