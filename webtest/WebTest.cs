// This is the initial test class for the webtest xUnit project.
using Xunit;

namespace webtest
{
    public class WebTest
    {
        [Fact]
        public void DemoTest()
        {
            int i = 1;
            bool result = false;
            if (i == 1)
            {
                result = true;
            }
            Assert.True(result, "The result should be true when i is 1.");

        }
    }
}
