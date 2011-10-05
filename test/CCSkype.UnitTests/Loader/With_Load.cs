using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Loader
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Load
    {
        [Test]
        public void Should_load_user_groups_from_config()
        {
            var skypeClient = MockRepository.GenerateMock<IMessengerClient>();
            skypeClient.Expect(x => x.AllKnownUsers(null)).IgnoreArguments().Return(true);

            var buildCollection = MockRepository.GenerateMock<IBuildCollection>();

            var name = "somename";
            Configuration configuration = new Configuration();
            configuration.Items = new ConfigurationPipeline[1];
            configuration.Items[0] = new ConfigurationPipeline();
            configuration.Items[0].name = name;
            configuration.Items[0].users = new ConfigurationPipelineUsersUser[1];
            configuration.Items[0].users[0] = new ConfigurationPipelineUsersUser();
            configuration.Items[0].users[0].skypeName = "skypeName";
            var loader = new global::CCSkype.Loader(skypeClient, buildCollection);
            //Test
            var userGroups = loader.GetUserGroups(configuration);
            //Assert
            Assert.That(userGroups.IsMonitoring(name));
            skypeClient.VerifyAllExpectations();
        }
    }
}