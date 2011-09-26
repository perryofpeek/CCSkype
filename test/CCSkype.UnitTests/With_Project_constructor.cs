using NUnit.Framework;

namespace CCSkype.UnitTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]    
    public class With_Project_constructor
    {
        [Test]
        public void Should_set_pipeline_name_if_long()
        {
            var name = "DevEnv01_Deploy_Bff :: Deployment_Stage_1 :: BestFareFinder_Harvester_and_Seeder_Splitter";
            var project = new Project(name, "activity", "lbs", "lbl", "lbt", "webUrl");
            Assert.That(project.PipelineName, Is.EqualTo("DevEnv01_Deploy_Bff"));
        }

        [Test]
        public void Should_set_pipeline_name_if_short()
        {
            var name = "DevEnv01_Deploy_Bff ";
            var project = new Project(name, "activity", "lbs", "lbl", "lbt", "webUrl");
            Assert.That(project.PipelineName, Is.EqualTo("DevEnv01_Deploy_Bff"));
        }
    }
}