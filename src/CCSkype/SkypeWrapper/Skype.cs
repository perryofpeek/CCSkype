using System.Collections.Generic;
using SKYPE4COMLib;

namespace CCSkype.SkypeWrapper
{
    public class Skype : ISkype
    {
        private readonly SKYPE4COMLib.Skype _skype;
        private readonly IMessageProcessor _messageProcessor;


        public Skype(IMessageProcessor messageProcessor )
        {
            _messageProcessor = messageProcessor;
            _skype = new SKYPE4COMLib.Skype();
            UseSkypeProtocolSeven();          
            AttachMessageProcessorHandler();

        }
     
        private void MessageProcessor(ChatMessage msg, TChatMessageStatus status)
        {
            if (!IsLocalUser(msg)) return;
            var response = _messageProcessor.Process(msg.Body);
            if(response.Success)
            {
                _skype.SendMessage(msg.Sender.Handle, response.Message);     
            }
        }

        private void AttachMessageProcessorHandler()
        {
            _skype.MessageStatus += MessageProcessor;
        }

        private void UseSkypeProtocolSeven()
        {
            _skype.Attach(7, false);
        }

        private bool IsLocalUser(IChatMessage msg)
        {
            return msg.Sender.Handle != _skype.CurrentUser.Handle;
        }


        public IClient SkypeClient()
        {
            return new Client(_skype.Client);
        }

        public IChat CreateChatMultiple(IUserCollection userCollection, string name)
        {
            var userCol = userCollection.GetUserCollection;
            var chat = _skype.CreateChatMultiple(userCol);
            chat.Description = name;
            return new Chat(chat, name);
        }

        public IUser GetUser(string username)
        {
            return new User(_skype.User[username]);
        }

        public List<string> GetUsers()
        {
            var f = _skype.Friends;
            return new UserCollection(f).GetUsers();
        }
    }
}