using NUnit.Framework;

namespace CCSkype.UnitTests.configuration
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_AddUser
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
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