using System.Collections.Generic;
using CCSkype.Config;
using NUnit.Framework;

namespace CCSkype.UnitTests.configuration
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class With_load
    {
        [Test]
        public void Should_load_configration()
        {
            var configurationLoader = new ConfigurationLoader();
            var config = configurationLoader.Load(@"Testdata\config\OnePipeline.xml");
            Assert.That(config.Items.Length, Is.EqualTo(1));
            Assert.That(config.Items[0].name, Is.EqualTo("Trumps"));
            Assert.That(config.Items[0].users.Length, Is.EqualTo(2));
            Assert.That(config.Items[0].users[0].skypeName, Is.EqualTo("dave"));
            Assert.That(config.Items[0].users[1].skypeName, Is.EqualTo("fish"));
        }


        [Test]
        public void Should_load_single_configration_into_internal_config()
        {

            var config = new Configuration();
            config.Items = new ConfigurationPipeline[1];
            config.Items[0] = new ConfigurationPipeline();
            config.Items[0].name = "name";
            config.Items[0].users = new ConfigurationPipelineUsersUser[2];
            config.Items[0].users[0] = new ConfigurationPipelineUsersUser();
            config.Items[0].users[1] = new ConfigurationPipelineUsersUser();
            config.Items[0].users[0].skypeName = "dave";
            config.Items[0].users[1].skypeName = "fish";

            var intConfig = new InternalConfiguration(config);
            Assert.That(intConfig.Items["name"], Is.Not.Null);
            Assert.That(intConfig.Items["name"].Contains("dave"), Is.True);
            Assert.That(intConfig.Items["name"].Contains("fish"), Is.True);
            Assert.That(intConfig.Items.Count, Is.EqualTo(1));

        }

        [Test]
        public void Should_load_multiple_different_configration_into_internal_config()
        {

            var config = new Configuration();
            config.Items = new ConfigurationPipeline[2];
            config.Items[0] = new ConfigurationPipeline { name = "name0", users = MakeUsersUserArray(new List<string>() { "dave0", "fish" }) };
            config.Items[1] = new ConfigurationPipeline { name = "name1", users = MakeUsersUserArray(new List<string>() { "dave1" }) };

            var intConfig = new InternalConfiguration(config);
            Assert.That(intConfig.Items["name0"], Is.Not.Null);
            Assert.That(intConfig.Items["name1"], Is.Not.Null);
            Assert.That(intConfig.Items["name0"].Contains("dave0"), Is.True);
            Assert.That(intConfig.Items["name0"].Contains("fish"), Is.True);
            Assert.That(intConfig.Items["name1"].Contains("dave1"), Is.True);
            Assert.That(intConfig.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void Should_load_multiple_whit_same_configration_into_internal_config()
        {

            var config = new Configuration();
            config.Items = new ConfigurationPipeline[3];
            config.Items[0] = new ConfigurationPipeline { name = "name0", users = MakeUsersUserArray(new List<string>() { "dave0", "fish" }) };
            config.Items[1] = new ConfigurationPipeline { name = "name1", users = MakeUsersUserArray(new List<string>() { "dave1" }) };
            config.Items[2] = new ConfigurationPipeline { name = "name0", users = MakeUsersUserArray(new List<string>() { "ted" }) };
            var intConfig = new InternalConfiguration(config);
            Assert.That(intConfig.Items["name0"], Is.Not.Null);
            Assert.That(intConfig.Items["name1"], Is.Not.Null);
            Assert.That(intConfig.Items["name0"].Contains("dave0"), Is.True);
            Assert.That(intConfig.Items["name0"].Contains("fish"), Is.True);
            Assert.That(intConfig.Items["name0"].Contains("ted"), Is.True);
            Assert.That(intConfig.Items["name1"].Contains("dave1"), Is.True);
            Assert.That(intConfig.Items.Count, Is.EqualTo(2));
        }


        [Test]
        public void Should_load_multiple_with_duplicate_users_only_add_once_into_internal_config()
        {

            var config = new Configuration();
            config.Items = new ConfigurationPipeline[3];
            config.Items[0] = new ConfigurationPipeline { name = "name0", users = MakeUsersUserArray(new List<string>() { "dave0", "fish" }) };
            config.Items[1] = new ConfigurationPipeline { name = "name1", users = MakeUsersUserArray(new List<string>() { "dave1" }) };
            config.Items[2] = new ConfigurationPipeline { name = "name0", users = MakeUsersUserArray(new List<string>() { "ted", "fish" }) };
            var intConfig = new InternalConfiguration(config);
            Assert.That(intConfig.Items["name0"], Is.Not.Null);
            Assert.That(intConfig.Items["name1"], Is.Not.Null);
            Assert.That(intConfig.Items["name0"].Contains("dave0"), Is.True);
            Assert.That(intConfig.Items["name0"].Contains("fish"), Is.True);
            Assert.That(intConfig.Items["name0"].Contains("ted"), Is.True);
            Assert.That(intConfig.Items["name0"].Count, Is.EqualTo(3));
            Assert.That(intConfig.Items["name1"].Contains("dave1"), Is.True);
            Assert.That(intConfig.Items.Count, Is.EqualTo(2));
        }


        private ConfigurationPipelineUsersUser[] MakeUsersUserArray(List<string> usernames)
        {
            var rtn = new ConfigurationPipelineUsersUser[usernames.Count];
            var i = 0;
            foreach (var username in usernames)
            {
                rtn[i] = new ConfigurationPipelineUsersUser { skypeName = username };
                i++;
            }
            return rtn;
        }

    }

    public class InternalConfiguration
    {
        public Dictionary<string, List<string>> Items { get; private set; }

        public InternalConfiguration(Configuration config)
        {
            Items = new Dictionary<string, List<string>>();
            MapConfigurationIntoDictionary(config);
        }

        private void MapConfigurationIntoDictionary(Configuration config)
        {
            foreach (var item in config.Items)
            {
                if (!Items.ContainsKey(item.name))
                {
                    Items.Add(item.name, new List<string>());
                }
                AddAllUsers(item);
            }
        }

        private void AddAllUsers(ConfigurationPipeline item)
        {
            foreach (var user in item.users)
            {
                if(!Items[item.name].Contains(user.skypeName))
                {
                    Items[item.name].Add(user.skypeName);    
                }                
            }
        }
    }
}