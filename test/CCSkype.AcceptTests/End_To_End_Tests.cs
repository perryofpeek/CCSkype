using System;
using System.IO;
using CCSkype.Config;
using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.AcceptTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture, Category("EndToEnd")]
    public class End_To_End_Tests
    {

        [Test, Ignore("To do")]
        public void As_a_User_I_want_an_error_message_when_the_cctray_end_point_is_not_up_so_I_can_resolve_the_issue()
        {
        }

        [Test, Ignore("To do")]
        public void As_a_user_I_want_an_error_message_when_the_cctray_end_point_is_miconfigured_so_I_can_resolve_the_issue()
        {
        }

        [Test, Ignore("To do")]
        public void As_a_user_I_want_one_one_error_message_when_the_build_is_broken_so_I_am_not_flooded_with_errors()
        {
        }

        [Test, Ignore("To do")]
        public void As_a_user_I_want_cctray_polled_every_x_seconds_so_I_can_be_sure_I_have_the_latest_information()
        {
        }

        [Test, Ignore("To do")]
        public void As_a_user_I_want_to_be_able_to_configure_the_application_using_my_browser()
        {
        }


        [Test]
        public void As_A_user_I_want_to_have_a_message_when_a_build_fails_so_that_I_can_fix_the_build()
        {
            var message = "someMessage - " + Guid.NewGuid().ToString();
            var skype = new Skype();
            var chats = new Chats(skype);
            var configurationLoader = new ConfigurationLoader();
            var loader = new Loader(new MessengerClient(skype, new UserCollection(new SKYPE4COMLib.UserCollection()), chats), new BuildCollection());
            var projectwatcher = new Projectwatcher(loader.GetUserGroups(configurationLoader.Load("OnePipeline.xml")));

            string url = "someUrl";

            var httpGet = MockRepository.GenerateMock<IHttpGet>();
            httpGet.Expect(x => x.Request(url));
            httpGet.Expect(x => x.StatusCode).Return(200);
            httpGet.Expect(x => x.ResponseBody).Return(File.ReadAllText("cctray.xml"));

            ICcTray ccTray = new CcTray(new EndpointImpl(httpGet, url));
            ccTray.Load();

            //Test
            projectwatcher.Message(ccTray.FailedPipelines);
        }

        

        [Test]
        public void As_A_user_I_want_to_two_messages_in_the_same_group_window_when_a_build_fails_so_that_I_can_fix_the_builds_when_each_fails()
        {           
            var skype = new Skype();
            var chats = new Chats(skype);
            var configurationLoader = new ConfigurationLoader();
            var loader = new Loader(new MessengerClient(skype, new UserCollection(new SKYPE4COMLib.UserCollection()), chats),new BuildCollection());
            var projectwatcher = new Projectwatcher(loader.GetUserGroups(configurationLoader.Load("OnePipeline.xml")));

            string url = "someUrl";

            var httpGet = MockRepository.GenerateMock<IHttpGet>();
            httpGet.Expect(x => x.Request(url));
            httpGet.Expect(x => x.StatusCode).Return(200);
            httpGet.Expect(x => x.ResponseBody).Return(File.ReadAllText("cctray.xml"));

            ICcTray ccTray = new CcTray(new EndpointImpl(httpGet, url));
            ccTray.Load();

            //Test
            projectwatcher.Message(ccTray.FailedPipelines);
        
            var p = new Project("Trunk_QA_Env_PCIDSS :: Deployment_to_QA_PCIDSS1", "Failed", "Failure", "1.2.3.4","2011-09-23T16:59:18", "web");
            ccTray.FailedPipelines.Add(p);
            projectwatcher.Message(ccTray.FailedPipelines);
            
            projectwatcher.Message(ccTray.FailedPipelines);
        }



        [Test]
        public void As_A_user_I_want_to_one_message_in_the_same_group_window_when_a_build_fails_so_that_I_can_fix_the_build()
        {           
            var skype = new Skype();
            var chats = new Chats(skype);
            var configurationLoader = new ConfigurationLoader();
            var loader = new Loader(new MessengerClient(skype, new UserCollection(new SKYPE4COMLib.UserCollection()), chats),new BuildCollection());
            var projectwatcher = new Projectwatcher(loader.GetUserGroups(configurationLoader.Load("OnePipeline.xml")));

            string url = "someUrl";

            var httpGet = MockRepository.GenerateMock<IHttpGet>();
            httpGet.Expect(x => x.Request(url));
            httpGet.Expect(x => x.StatusCode).Return(200);
            httpGet.Expect(x => x.ResponseBody).Return(File.ReadAllText("cctray.xml"));

            ICcTray ccTray = new CcTray(new EndpointImpl(httpGet, url));
            ccTray.Load();

            //Test
            projectwatcher.Message(ccTray.FailedPipelines);
            projectwatcher.Message(ccTray.FailedPipelines);
            projectwatcher.Message(ccTray.FailedPipelines);
        }



        [Test]
        public void As_an_unknown_skype_user_I_want_to_have_an_error_message_when_configuration_is_loaded()
        {
            var skype = new Skype();
            var chats = new Chats(skype);
            var configurationLoader = new ConfigurationLoader();
            var loader = new Loader(new MessengerClient(skype, new UserCollection(new SKYPE4COMLib.UserCollection()), chats),new BuildCollection());
            Assert.Throws<UserNotKnowException>(() => loader.GetUserGroups(configurationLoader.Load("UnknownUserPipeline.xml")));
        }
    }
}



