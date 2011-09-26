namespace CCSkype.SkypeWrapper
{
    public class User
    {
        private readonly SKYPE4COMLib.User _user;

        public User(SKYPE4COMLib.User user)
        {
            _user = user;
        }

        public SKYPE4COMLib.User GetUser()
        {
            return _user;
        }       
    }
}