using System.Collections.Generic;
using System.Linq;

namespace CCSkype
{
    public class Loader
    {
        private readonly IMessengerClient _iMessengerClient;

        public Loader(IMessengerClient iMessengerClient)
        {
            _iMessengerClient = iMessengerClient;
        }

        public IUserGroups GetUserGroups(Configuration configuration)
        {
            IUserGroups userGroups = new UserGroups();
            foreach (var pipeline in configuration.Items)
            {                              
                userGroups.Add(new UserGroup(_iMessengerClient, GetUserList(pipeline), pipeline.name));
            }
            return userGroups;
        }

        private List<User> GetUserList(ConfigurationPipeline pipeline)
        {
            var userList = pipeline.users.Select(pipelineUser => new User(pipelineUser.skypeName)).ToList();
            return userList;
        }
    }
}