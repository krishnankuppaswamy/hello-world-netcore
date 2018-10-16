using System;
using Xunit;

namespace xpdfexecutor.UnitTest
{
    public class xpdfexecutorTest
    {
        [Fact]
        public void ShouldReturnPdfContent()
        {
            var xpdfexecutor = new Executor();

            var actual = xpdfexecutor.Execute();

            Assert.Equal($"This is first line!{Environment.NewLine}{Environment.NewLine}\f", actual);
        }
    }
}
