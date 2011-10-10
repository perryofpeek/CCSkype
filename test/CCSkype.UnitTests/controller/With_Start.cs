using System.ComponentModel;
using NUnit.Framework;
using Rhino.Mocks;

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
            var stopperMock = MockRepository.GenerateMock<IStopper>();
            stopperMock.Expect(x => x.Stop).Return(false).Repeat.Once();
            stopperMock.Expect(x => x.Stop).Return(true).Repeat.Once();
            controller.Container.Kernel.AddComponentInstance<IStopper>(stopperMock); 
            controller.CcTrayUrl = "http://localhost/Cctray.xml";
            controller.CcTrayUsername = "username";
            controller.CcTrayPassword = "password";
            controller.HttpTimeout = 30;
            controller.PollTime = 1;
            controller.Configuration = @"TestData/Config/RealUsers.xml";
            controller.Start();
            stopperMock.VerifyAllExpectations();
        }     
    }
}