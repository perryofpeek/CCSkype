using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Messenger_Client
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_SendMessage
    {

        private ISkype skype;
        private IChat chat;
        private IUserCollection userCollection;
        private IClient client;
        private IChats chats;
        private MessengerClient messengerClient;

        [SetUp]
        public void SetUp()
        {
            skype = MockRepository.GenerateMock<ISkype>();
            chat = MockRepository.GenerateMock<IChat>();
            userCollection = MockRepository.GenerateMock<IUserCollection>();
            client = MockRepository.GenerateMock<IClient>();
            chats = MockRepository.GenerateMock<IChats>();
            messengerClient = new MessengerClient(skype, userCollection, chats);
        }

        [Test]
        public void Should_send_a_single_message_to_a_group()
        {
            var message = "someMessage";
            var name = "name";
            client.Expect(x => x.IsRunning()).Return(true);
            chats.Expect(x => x.Get(name, userCollection)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.Leave());
            chat.Expect(x => x.SendMessage(message));           
            //Test
            messengerClient.SendMessage(message, userCollection, name);
            //Assert
            skype.VerifyAllExpectations();
            chat.VerifyAllExpectations();
            client.VerifyAllExpectations();
            chats.VerifyAllExpectations(); 
            
        }

        [Test]
        public void Should_create_a_new_chat_window()
        {
            var message = "someMessage";
            var name = "name";
            client.Expect(x => x.IsRunning()).Return(true);
            chats.Expect(x => x.Get(name, userCollection)).Return(chat);
           //skype.Expect(x => x.CreateChatMultiple(userCollection)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.Leave());
            chat.Expect(x => x.SendMessage(message));            
            //Test
            messengerClient.SendMessage(message, userCollection, name);
            //Assert
            skype.VerifyAllExpectations();
            chat.VerifyAllExpectations();
            client.VerifyAllExpectations();
            chats.VerifyAllExpectations();
        }

        [Test]
        public void Should_start_skype_if_not_running()
        {
            var name = "name";
            var message = "someMessage";  
            client.Expect(x => x.IsRunning()).Return(false);
            client.Expect(x => x.Start(false, true));
            skype.Expect(x => x.CreateChatMultiple(userCollection, name)).Return(chat);
            skype.Expect(x => x.SkypeClient()).Return(client);
            chat.Expect(x => x.OpenWindow());
            chat.Expect(x => x.Leave());
            chat.Expect(x => x.SendMessage(message));            
            //Test
            messengerClient.SendMessage(message, userCollection, name);
            //Assert
            skype.VerifyAllExpectations();
            chat.VerifyAllExpectations();
            client.VerifyAllExpectations();
        }
    }
}