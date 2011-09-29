using NUnit.Framework;

namespace CCSkype.UnitTests.controller
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Start
    {
        [Test, Ignore("Debug only")]
        public void test()
        {
            var controller = new Controller();
            controller.CcTrayUrl = "http://localhost/Cctray.xml";
            controller.CcTrayUsername = "username";
            controller.CcTrayPassword = "password";
            controller.HttpTimeout = 30;
            controller.Configuration = @"TestData/Config/RealUsers.xml";
            controller.Start();
        }     
    }
}