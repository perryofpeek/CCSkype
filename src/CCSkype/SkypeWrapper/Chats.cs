using System.Collections;
using System.Collections.Generic;

namespace CCSkype.SkypeWrapper
{
    public class Chats : IChats
    {
        private readonly ISkype _skype;

        private Dictionary<string, IChat> _chats;

        public Chats(ISkype skype)
        {
            _skype = skype;
            _chats = new Dictionary<string, IChat>();
        }

        public IChat Get(string name, IUserCollection userCollection)
        {
            if (!_chats.ContainsKey(name))
            {
               _chats.Add(name, _skype.CreateChatMultiple(userCollection, name));                
            }
            return _chats[name];
        }
    }
}