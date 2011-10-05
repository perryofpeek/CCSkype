using NUnit.Framework;

namespace CCSkype.UnitTests.project
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_GetMessage
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
        public void Should_get_default_message()
        {
            var activity = "failed";
            var label = "label";
            var url = "webUrl";
            var name = "DevEnv01_Deploy_Bff :: Deployment_Stage_1 :: BestFareFinder_Harvester_and_Seeder_Splitter";
            var project = new Project(name, activity, "lbs", label, "lbt", url);

            var msg = string.Format("{0} has {2} build {1} {3}", project.PipelineName, label, activity, url);
            Assert.That(project.GetMessage(), Is.EqualTo(msg));
        }
    }
}