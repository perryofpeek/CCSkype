using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Configuration_Repository
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Make
    {
        //private ISerialiseConfiguration serialiseConfiguration;
        private ConfigurationRepository configRepo;
        //private IFile fileMock;
       
        [SetUp]
        public void SetUp()
        {
            //fileMock = MockRepository.GenerateMock<IFile>();
            //serialiseConfiguration = MockRepository.GenerateMock<ISerialiseConfiguration>();
            configRepo = new ConfigurationRepository();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Should_save_configuration()
        {           
            configRepo.Add("name0", "skypeName");
            var config = configRepo.Make();
            Assert.That(config.Items[0].name, Is.EqualTo("name0"));
            Assert.That(config.Items[0].users[0].skypeName, Is.EqualTo("skypeName"));
        }

        [Test]
        public void Should_save_configuration_multiple_users()
        {            
            configRepo.Add("name0", "skypeName");
            configRepo.Add("name0", "skypeName1");
            var config = configRepo.Make();
            Assert.That(config.Items[0].name, Is.EqualTo("name0"));
            Assert.That(config.Items[0].users[0].skypeName, Is.EqualTo("skypeName"));
            Assert.That(config.Items[0].users[1].skypeName, Is.EqualTo("skypeName1"));
        }

        [Test]
        public void Should_save_multiple_pipelines_configuration_multiple_users()
        {            
            configRepo.Add("name0", "skypeName");
            configRepo.Add("name1", "skypeName1");
            var config = configRepo.Make();
            Assert.That(config.Items[0].name, Is.EqualTo("name0"));
            Assert.That(config.Items[0].users[0].skypeName, Is.EqualTo("skypeName"));
            Assert.That(config.Items[1].name, Is.EqualTo("name1"));            
            Assert.That(config.Items[1].users[0].skypeName, Is.EqualTo("skypeName1"));
        }        
    }
}