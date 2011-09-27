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
            Assert.That(config.cctrayUri, Is.EqualTo("someUri"));
            Assert.That(config.pollTime, Is.EqualTo("30"));
        }
    }
}