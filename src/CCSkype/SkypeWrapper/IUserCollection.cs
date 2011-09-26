using System.Collections.Generic;

namespace CCSkype.SkypeWrapper
{
    public interface IUserCollection
    {
        SKYPE4COMLib.UserCollection GetUserCollection { get; }
        
        List<string> GetUsers();
        
        void Add(IUser user);
    }
}