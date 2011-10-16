using System.Collections.Generic;
using System.Linq;

namespace CCSkype
{
    public class ConfigurationRepository
    {        
        public ConfigurationRepository()
        {            
            Items = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> Items { get; private set; }

        public void Load(Configuration config)
        {
            Items = new Dictionary<string, List<string>>();
            MapConfigurationIntoDictionary(config);
        }

        private void MapConfigurationIntoDictionary(Configuration config)
        {
            foreach (var item in config.Items)
            {
                Add(item);
            }
        }

        private void Add(ConfigurationPipeline item)
        {
            if (!Items.ContainsKey(item.name))
            {
                Items.Add(item.name, new List<string>());
            }
            AddAllUsers(item);
        }

        private void AddAllUsers(ConfigurationPipeline item)
        {
            foreach (var user in item.users)
            {
                if (!Items[item.name].Contains(user.skypeName))
                {
                    Items[item.name].Add(user.skypeName);
                }
            }
        }

        public void Add(string name, string skypeName)
        {
            var c = new ConfigurationPipeline { name = name, users = new ConfigurationPipelineUsersUser[1] };
            c.users[0] = new ConfigurationPipelineUsersUser { skypeName = skypeName };
            Add(c);
        }

        public void Save(Configuration configuration,string filename)
        {
            //ConfigurationLoader
            //var doc = _serialiseConfiguration.Serialise(configuration);
            //doc.Save(filename);
        }

        public Configuration Make()
        {
            var configuration = new Configuration();
            configuration.Items = CreateConfigurationPipelines();
            return configuration;
        }

        private ConfigurationPipeline[] CreateConfigurationPipelines()
        {
            return Items.Select(CreateConfigurationPipeline).ToArray();
        }

        private ConfigurationPipeline CreateConfigurationPipeline(KeyValuePair<string, List<string>> item)
        {
            return new ConfigurationPipeline { name = item.Key, users = CreatePipelineusers(item) };
        }

        private ConfigurationPipelineUsersUser[] CreatePipelineusers(KeyValuePair<string, List<string>> item)
        {
            return item.Value.Select(CreateConfigurationPipelineUser).ToArray();
        }

        private static ConfigurationPipelineUsersUser CreateConfigurationPipelineUser(string user)
        {
            return new ConfigurationPipelineUsersUser { skypeName = user };
        }
    }
}