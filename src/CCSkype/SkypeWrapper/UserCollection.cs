namespace CCSkype.SkypeWrapper
{
    public class UserCollection
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

        public void Add(User user)
        {            
            _userCollection.Add(user.GetUser());
        }
    }
}