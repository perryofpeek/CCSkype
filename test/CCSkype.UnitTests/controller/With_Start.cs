using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace CCSkype.UnitTests.controller
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Start
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

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


        [Test]
        public void Should_Start_running_the_application()
        {
            var container = new WindsorContainer();
            container.Register(AllTypes.FromAssembly(Assembly.GetAssembly(typeof(Timer))).Where(t => t.GetInterfaces().Any()).Configure(component => component.LifeStyle.Transient).WithService.FirstInterface());
            var timer = container.Resolve<ITimer>();
            timer.Start();
        }
    }
}