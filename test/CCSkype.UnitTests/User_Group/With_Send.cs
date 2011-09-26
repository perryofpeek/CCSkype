using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.User_Group
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class With_Send
    {
        private IMessengerClient _messengerClient;

        [SetUp]
        public void SetUp()
        {            
             _messengerClient = MockRepository.GenerateMock<IMessengerClient>();
        }


        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        [Test]
        public void Should_send_group_a_message()
        {
            var message = "Some message";
            var users = new List<User>();
            _messengerClient.Expect(x => x.SetUserList(users));
            _messengerClient.Expect(x => x.SendMessage(message));


            string name = "someName";
            var group = new UserGroup(_messengerClient, users, name);
            group.Send(message);

            _messengerClient.VerifyAllExpectations();
        }
    }
}