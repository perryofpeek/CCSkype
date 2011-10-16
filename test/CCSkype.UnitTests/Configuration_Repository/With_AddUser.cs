using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Configuration_Repository
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_AddUser
    {        
        private ConfigurationRepository config;
       

        [SetUp]
        public void SetUp()
        {            
            //serialiseConfiguration = MockRepository.GenerateMock<ISerialiseConfiguration>();
            config = new ConfigurationRepository();
        }

        [Test]
        public void Should_add_a_single_user()
        {            
            config.Add("name0", "Dave");
            Assert.That(config.Items["name0"][0], Is.EqualTo("Dave"));
        }

        [Test]
        public void Should_add_a_multiple_users()
        {         
            config.Add("name0", "Dave");
            config.Add("name1", "Dave1");
            config.Add("name0", "ted");
            Assert.That(config.Items["name0"][0], Is.EqualTo("Dave"));
            Assert.That(config.Items["name0"][1], Is.EqualTo("ted"));
            Assert.That(config.Items["name1"][0], Is.EqualTo("Dave1"));
        }

        [Test]
        public void Should_Add_a_user_watching_an_exsisting_pipeline()
        {
            var skypename = "username";
            var pipeline = "somePipe";

            var configuration = new Configuration();
            configuration.Add(pipeline, skypename);
            Assert.That(configuration.Items[0].name, Is.EqualTo(pipeline));
            Assert.That(configuration.Items[0].users[0].skypeName, Is.EqualTo(skypename));
        }
    }
}