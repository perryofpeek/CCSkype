using System.Collections.Generic;
using System.Linq;

namespace CCSkype
{
    public class Loader : ILoader
    {
        private readonly IMessengerClient _messengerClient;
        private readonly IBuildCollection _buildCollection;

        public Loader(IMessengerClient messengerClient,IBuildCollection buildCollection)
        {
            _messengerClient = messengerClient;
            _buildCollection = buildCollection;
        }

        public IUserGroups GetUserGroups(Configuration configuration)
        {
            IUserGroups userGroups = new UserGroups(_buildCollection);
            foreach (var pipeline in configuration.Items)
            {
                var users = GetUserList(pipeline);
                if(_messengerClient.AllKnownUsers(users))
                {
                    userGroups.Add(new UserGroup(_messengerClient, users, pipeline.name));     
                }               
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