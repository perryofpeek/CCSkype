using System;
using System.Collections.Generic;
using SKYPE4COMLib;

namespace CCSkype.SkypeWrapper
{
    public class Skype : ISkype
    {
        private SKYPE4COMLib.Skype _skype;

        public Skype()
        {
            _skype = new SKYPE4COMLib.Skype();
            _skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);

            Console.WriteLine("MAKE SKYPE");
        }

        private void skype_MessageStatus(ChatMessage msg, TChatMessageStatus status)
        {
            Console.WriteLine(msg.Body);
            // Proceed only if the incoming message is a trigger
            //if (msg.Body.IndexOf(trigger) >= 0)
            //{
                // Remove trigger string and make lower case
            //    string command = msg.Body.Remove(0, trigger.Length).ToLower();

                // Send processed message back to skype chat window
                //_skype.SendMessage(msg.Sender.Handle, nick + " Says: " + ProcessCommand(command));
           // }
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
            return new User(_skype.get_User(username));
        }

        public List<string> GetUsers()
        {
            var f = _skype.Friends;
            return new UserCollection(f).GetUsers();
        }
    }
}