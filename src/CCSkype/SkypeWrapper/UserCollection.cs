using System.Collections.Generic;
using System.Linq;

namespace CCSkype.SkypeWrapper
{
    public class UserCollection : IUserCollection
    {
        private readonly SKYPE4COMLib.UserCollection _userCollection;

        public UserCollection(SKYPE4COMLib.UserCollection userCollection)
        {
            _userCollection = userCollection;
        }

        public SKYPE4COMLib.UserCollection GetUserCollection
        {
            get { return _userCollection; }
        }

        public List<string> GetUsers()
        {
            return (from SKYPE4COMLib.User user in _userCollection select user.Handle).ToList();
        }

        public void Add(IUser user)
        {
            _userCollection.Add(user.GetUser());
        }
    }
}