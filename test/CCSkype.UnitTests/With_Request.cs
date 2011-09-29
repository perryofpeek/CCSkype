using NUnit.Framework;

namespace CCSkype.UnitTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Request
    {
        [Test, Ignore("Write this properly or use a better http library")]
        public void Should_Get_Web_Document()
        {
            var httpGet = new HttpGet(20, "", "");
            httpGet.Request("http://www.google.co.uk");
            var document = httpGet.ResponseBody;
            Assert.IsTrue(document.Contains("google"));
        }
    }
}
