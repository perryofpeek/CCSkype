using System;
using System.IO;
using CCSkype.Config;
using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.AcceptTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class End_To_End_Tests
    {
        [Test]
        public void As_A_user_I_want_to_have_a_message_when_a_build_fails_so_that_I_can_fix_the_build()
        {
            var message = "someMessage - " + Guid.NewGuid().ToString();
            var skype = new Skype();
            var configurationLoader = new ConfigurationLoader();
            var loader = new Loader(new MessengerClient(skype, new UserCollection(new SKYPE4COMLib.UserCollection())));
            var projectwatcher = new Projectwatcher(loader.GetUserGroups(configurationLoader.Load("OnePipeline.xml")));

            string url = "someUrl";

            var httpGet = MockRepository.GenerateMock<IHttpGet>();
            httpGet.Expect(x => x.Request(url));
            httpGet.Expect(x => x.StatusCode).Return(200);
            httpGet.Expect(x => x.ResponseBody).Return(File.ReadAllText("cctray.xml"));

            ICcTray ccTray = new CcTray(new EndpointImpl(httpGet, url));
            ccTray.Load();

            //Test
            projectwatcher.Message(ccTray.FailedPipelines, message);
        }

        [Test]
        public void As_A_unknown_user_I_want_to_have_an_error_message_when_configuration_is_loaded()
        {            
            var skype = new Skype();
            var configurationLoader = new ConfigurationLoader();
            var loader = new Loader(new MessengerClient(skype, new UserCollection(new SKYPE4COMLib.UserCollection())));
            Assert.Throws<UserNotKnowException>(() => loader.GetUserGroups(configurationLoader.Load("UnknownUserPipeline.xml")));
        }
    }
}



