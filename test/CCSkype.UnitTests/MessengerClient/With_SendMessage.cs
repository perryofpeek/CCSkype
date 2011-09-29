using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.MessengerClient
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_SendMessage
    {
        [Test]
        public void Should_send_a_single_message_to_a_group()
        {
            var message = "someMessage";
            var skype = MockRepository.GenerateMock<ISkype>();
            var chat = MockRepository.GenerateMock<IChat>();
            var userCollection = MockRepository.GenerateMock<IUserCollection>();
            var client = MockRepository.GenerateMock<IClient>();
            var chats = MockRepository.GenerateMock<IChats>();
            client.Expect(x => x.IsRunning()).Return(true);
            skype.Expect(x => x.CreateChatMultiple(userCollection)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.Leave());
            chat.Expect(x => x.SendMessage(message));
            var messengerClient = new global::CCSkype.MessengerClient(skype, userCollection, chats);
            //Test
            messengerClient.SendMessage(message, userCollection);
            //Assert
            skype.VerifyAllExpectations();
            chat.VerifyAllExpectations();
            client.VerifyAllExpectations();
        }

        [Test]
        public void Should_start_skype_if_not_running()
        {
            var message = "someMessage";
            var skype = MockRepository.GenerateMock<ISkype>();
            var chat = MockRepository.GenerateMock<IChat>();
            var userCollection = MockRepository.GenerateMock<IUserCollection>();
            var client = MockRepository.GenerateMock<IClient>();
            var chats = MockRepository.GenerateMock<IChats>();
            client.Expect(x => x.IsRunning()).Return(false);
            client.Expect(x => x.Start(false, true));
            skype.Expect(x => x.CreateChatMultiple(userCollection)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.Leave());
            chat.Expect(x => x.SendMessage(message));
            
            var messengerClient = new global::CCSkype.MessengerClient(skype, userCollection,chats);
            //Test
            messengerClient.SendMessage(message, userCollection);
            //Assert
            skype.VerifyAllExpectations();
            chat.VerifyAllExpectations();
            client.VerifyAllExpectations();
        }
    }
}