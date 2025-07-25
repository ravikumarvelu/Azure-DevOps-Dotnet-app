// This is the initial test class for the webtest xUnit project.
using asp_webapp.Modules;
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

        [Fact]
        public void TestAddFunction()
        {
            Functions functions = new Functions();

            int sum = functions.Add(2, 3);
            bool res = false;
            if (sum == 5)
            {
                res = true;
            }
            Assert.True(res, "The Add function should return the correct sum of 2 and 3.");
        }
    }
}
