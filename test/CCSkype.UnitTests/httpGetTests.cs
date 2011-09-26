using NUnit.Framework;

namespace CCSkype.UnitTests
{
    [TestFixture]
    public class HTTPGetTests
    {
        [Test]
        public void ShouldGetWebDocument()
        {
            var httpGet = new HttpGet(20,"","");
            httpGet.Request("http://www.google.co.uk");
            var document = httpGet.ResponseBody;
            Assert.IsTrue(document.Contains("google"));
        }                  
    }
}
