using System;
using System.IO;
using CCSkype.Config;
using NUnit.Framework;

namespace CCSkype.UnitTests.Configuration_Repository
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Save
    {
        //private ISerialiseConfiguration configurationSerialiser;

        [SetUp]
        public void SetUp()
        {
            //configurationSerialiser = MockRepository.GenerateMock<ISerialiseConfiguration>();
            //configRepo = new ConfigurationRepository(configurationSerialiser, file);
        }
      
        [Test]
        public void should_save_configuration()
        {
            var config = new Configuration();            
            var path = Guid.NewGuid().ToString();
            var configurationLoader = new ConfigurationLoader();
            configurationLoader.Save(config, path);
            var xml = File.ReadAllText(path);
            Assert.That(xml, Is.EqualTo("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Configuration xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />"));
        }
    }
}