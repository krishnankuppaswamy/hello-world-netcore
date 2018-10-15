using Xunit;

namespace hello_world_netstandard.UnitTest
{
    public class HelloWorldTest
    {
        [Fact]
        public void ShouldReturnNameAlongWithHello()
        {
            var name = "MAKS!";
            var hw = new HelloWorld();

            var actual = hw.Hello(name);

            Assert.Equal("Hello - MAKS!", actual);
        }
    }
}
