using System.Collections;
using NUnit.Framework;

namespace CCSkype.UnitTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_ShouldAlert
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
        public void Should_return_true_as_build_has_not_been_alerted_on_yet()
        {
            var buildCollection = new BuildCollection();
            var project = new Project("name", "activity", "lbs", "lbl", "lbt", "url");
            Assert.That(buildCollection.ShouldAlert(project), Is.EqualTo(true));
        }

        [Test]
        public void Should_return_false_as_build_has_already_been_alerted_on()
        {
            var buildCollection = new BuildCollection();
            var project = new Project("name", "activity", "lbs", "lbl", "lbt", "url");
            Assert.That(buildCollection.ShouldAlert(project), Is.EqualTo(true));
            Assert.That(buildCollection.ShouldAlert(project), Is.EqualTo(false));
        }
    }
}