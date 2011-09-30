using System.Collections.Generic;
using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Messenger_Client
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_AllKnownUsers
    {
        private ISkype _skype;

        private IUserCollection _userCollection;

        private IMessengerClient _messengerClient;
        
        private IChats _chats;

        private IClient _skypeClient;

        [SetUp]
        public void SetUp()
        {
            _skype = MockRepository.GenerateMock<ISkype>();
            _userCollection = MockRepository.GenerateMock<IUserCollection>();
            _chats = MockRepository.GenerateMock<IChats>();
            _messengerClient = new MessengerClient(_skype, _userCollection,_chats);
            _skypeClient = MockRepository.GenerateMock<IClient>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Should_return_true_a_single_configuration_user_is_known_users_by_skype()
        {
            var skypeUsers = new List<string> { "Dave" };
            _skype.Expect(x => x.GetUsers()).Return(skypeUsers);
            _skype.Expect(x => x.SkypeClient()).Return(_skypeClient);
            _skypeClient.Expect(x => x.IsRunning()).Return(true);
            var configUsers = new List<User> { new User("Dave") };
            //Test
            Assert.That(_messengerClient.AllKnownUsers(configUsers), Is.EqualTo(true));
            //Assert            
            _skype.VerifyAllExpectations();
            _skypeClient.VerifyAllExpectations();
        }

        [Test]
        public void Should_return_true_all_configuration_users_are_known_users_by_skype()
        {
            var skypeUsers = new List<string> { "Dave" };
            _skype.Expect(x => x.GetUsers()).Return(skypeUsers);
            _skype.Expect(x => x.SkypeClient()).Return(_skypeClient);
            _skypeClient.Expect(x => x.IsRunning()).Return(true);
            var configUsers = new List<User> { new User("Fred") };
            //Test
            var ex = Assert.Throws<UserNotKnowException>(() => _messengerClient.AllKnownUsers(configUsers));
            Assert.That(ex.Message.Contains("Fred"), Is.EqualTo(true));
            //Assert            
            _skype.VerifyAllExpectations();
            _skypeClient.VerifyAllExpectations();
        }

    }
}