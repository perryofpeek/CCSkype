using System.Collections.Generic;
using System.Linq;

namespace CCSkype
{
    public class Loader
    {
        private readonly ISkypeClient _iSkypeClient;

        public Loader(ISkypeClient iSkypeClient)
        {
            _iSkypeClient = iSkypeClient;
        }

        public IUserGroups GetUserGroups(Configuration configuration)
        {
            IUserGroups userGroups = new UserGroups();
            foreach (var pipeline in configuration.Items)
            {                              
                userGroups.Add(new UserGroup(_iSkypeClient, GetUserList(pipeline), pipeline.name));
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