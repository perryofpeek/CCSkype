using System.Collections.Generic;
using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.MessengerClient
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_AllKnownUsers
    {
        private ISkype _skype;

        private IUserCollection _userCollection;

        private IMessengerClient _messengerClient;

        [SetUp]
        public void SetUp()
        {
            _skype = MockRepository.GenerateMock<ISkype>();
            _userCollection = MockRepository.GenerateMock<IUserCollection>();
            _messengerClient = new global::CCSkype.MessengerClient(_skype, _userCollection);
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
            var configUsers = new List<User> { new User("Dave") };
            //Test
            Assert.That(_messengerClient.AllKnownUsers(configUsers), Is.EqualTo(true));
            //Assert            
            _skype.VerifyAllExpectations();
        }

        [Test]
        public void Should_return_true_all_configuration_users_are_known_users_by_skype()
        {
            var skypeUsers = new List<string> { "Dave" };
            _skype.Expect(x => x.GetUsers()).Return(skypeUsers);
            var configUsers = new List<User> { new User("Fred") };
            //Test
            var ex = Assert.Throws<UserNotKnowException>(() => _messengerClient.AllKnownUsers(configUsers));
            Assert.That(ex.Message.Contains("Fred"), Is.EqualTo(true));
            //Assert            
            _skype.VerifyAllExpectations();
        }

    }
}