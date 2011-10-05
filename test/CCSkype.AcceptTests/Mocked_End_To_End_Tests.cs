using System.Collections.Generic;
using System.IO;
using CCSkype.Config;
using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.AcceptTests
{
    //ReSharper disable InconsistentNaming
    [TestFixture]
    public class Mocked_End_To_End_Tests
    {
        private ISkype skype;
        private IChat chat;
        private IUserCollection userCollection;
        private IClient client;
        private IUser user;
        private ConfigurationLoader configurationLoader;
        private MessengerClient messengerClient;
        private IHttpGet httpGet;
        private Loader loader;
        private IChats chats;
        private IBuildCollection buildCollection;


        [SetUp]
        public void SetUp()
        {
            skype = MockRepository.GenerateMock<ISkype>();
            chat = MockRepository.GenerateMock<IChat>();
            userCollection = MockRepository.GenerateMock<IUserCollection>();
            client = MockRepository.GenerateMock<IClient>();
            user = MockRepository.GenerateMock<IUser>();
            configurationLoader = new ConfigurationLoader();
            httpGet = MockRepository.GenerateMock<IHttpGet>();
            chats = MockRepository.GenerateMock<IChats>();
            messengerClient = new MessengerClient(skype, userCollection, chats);

            buildCollection = MockRepository.GenerateMock<IBuildCollection>();
            loader = new Loader(messengerClient, buildCollection);
        }

        [Test]
        public void Should_send_a_single_message_sucessfully_mocking_http_and_skype()
        {
            var message = "Trunk_QA_Env_PCIDSS has Failure build 03.13.00.207 http://build.london.ttldev.local:8153/go/pipelines/Trunk_QA_Env_PCIDSS/34/Deployment_to_QA_PCIDSS/1";
            var name = "Trunk_QA_Env_PCIDSS";
            client.Expect(x => x.IsRunning()).Return(true);
            chats.Expect(x => x.Get(name, userCollection)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            skype.Expect(x => x.GetUsers()).Return(new List<string> { "owainfperry" });
            skype.Expect(x => x.GetUser("owainfperry")).IgnoreArguments().Return(user).Repeat.Once();
            skype.Expect(x => x.GetUser("otherUser")).IgnoreArguments().Return(user).Repeat.Once();
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.SendMessage(message));
            userCollection.Expect(x => x.Add(user)).IgnoreArguments();

            var config = configurationLoader.Load("MockOnePipeline.xml");
            var userGroups = loader.GetUserGroups(config);
            var projectwatcher = new Projectwatcher(userGroups);
            string url = "someUrl";


            HttpClientReadXml(url);

            ICcTray ccTray = new CcTray(new EndpointImpl(httpGet, url));
            ccTray.Load();

            //Test
            projectwatcher.Message(ccTray.FailedPipelines);

            chat.VerifyAllExpectations();
            skype.VerifyAllExpectations();
            client.VerifyAllExpectations();
            userCollection.VerifyAllExpectations();
        }

        private void HttpClientReadXml(string url)
        {
            httpGet.Expect(x => x.Request(url));
            httpGet.Expect(x => x.StatusCode).Return(200);
            httpGet.Expect(x => x.ResponseBody).Return(File.ReadAllText("cctray.xml"));
        }

        [Test]
        public void Should_send_a_multiple_message_sucessfully_mocking_http_and_skype()
        {
            var message = "Trunk_QA_Env_PCIDSS has Failure build 03.13.00.207 http://build.london.ttldev.local:8153/go/pipelines/Trunk_QA_Env_PCIDSS/34/Deployment_to_QA_PCIDSS/1";
            var name = "Trunk_QA_Env_PCIDSS";
            //name="a1";
            client.Expect(x => x.IsRunning()).Return(true);
            chats.Expect(x => x.Get(name, userCollection)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            skype.Expect(x => x.GetUsers()).Return(new List<string> { "owainfperry" });
            skype.Expect(x => x.GetUser("owainfperry")).IgnoreArguments().Return(user).Repeat.Once();
            skype.Expect(x => x.GetUser("otherUser")).IgnoreArguments().Return(user).Repeat.Once();
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.SendMessage(message));
            userCollection.Expect(x => x.Add(user)).IgnoreArguments();

            var config = configurationLoader.Load("MockOnePipeline.xml");
            var userGroups = loader.GetUserGroups(config);
            var projectwatcher = new Projectwatcher(userGroups);
            string url = "someUrl";


            HttpClientReadXml(url);

            ICcTray ccTray = new CcTray(new EndpointImpl(httpGet, url));
            ccTray.Load();
            //ccTray.FailedPipelines.Add(new Project("a1", "Failed", "broken", "label", "10:20", "a.b"));
            //Test
            projectwatcher.Message(ccTray.FailedPipelines);
            projectwatcher.Message(ccTray.FailedPipelines);


            chat.VerifyAllExpectations();
            skype.VerifyAllExpectations();
            client.VerifyAllExpectations();
            userCollection.VerifyAllExpectations();
        }

        [Test]
        public void As_A_unknown_user_I_want_to_have_an_error_message_when_configuration_is_loaded()
        {
            skype.Expect(x => x.GetUsers()).Return(new List<string> { "Mark" });
            skype.Expect(x => x.SkypeClient()).Return(client);
            client.Expect(x => x.IsRunning()).Return(true);
            Assert.Throws<UserNotKnowException>(() => loader.GetUserGroups(configurationLoader.Load("UnknownUserPipeline.xml")));
        }
    }
}



