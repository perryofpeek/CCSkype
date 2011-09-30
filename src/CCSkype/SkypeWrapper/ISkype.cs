using System.Collections.Generic;

namespace CCSkype.SkypeWrapper
{
    public interface ISkype
    {
        IClient SkypeClient();

        IChat CreateChatMultiple(IUserCollection userCollection, string name);
        
        IUser GetUser(string username);

        List<string> GetUsers();
    }
}