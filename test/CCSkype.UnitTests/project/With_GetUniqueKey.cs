using NUnit.Framework;

namespace CCSkype.UnitTests.project
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_GetUniqueKey
    {
        [Test]
        public void Should_get_key_in_correct_format()
        {
            var project = new Project("1", "2", "3", "4", "5", "6");
            var key = string.Format("{0}-{1}-{2}-{3}", project.PipelineName, project.lastBuildLabel,project.lastBuildTime, project.lastBuildStatus);
            Assert.That(project.GetUniqueKey(), Is.EqualTo(key));            
        }
    }
}