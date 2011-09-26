using System.Collections.Generic;

namespace CCSkype.SkypeWrapper
{
    public interface ISkype
    {
        IClient SkypeClient();

        IChat CreateChatMultiple(IUserCollection userCollection);
        
        IUser GetUser(string username);

        List<string> GetUsers();
    }
}