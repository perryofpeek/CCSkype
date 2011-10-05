using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.User_Groups
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class With_IsMonitoring
    {
        private IBuildCollection buildCollection;

        [SetUp]
        public void SetUp()
        {
            buildCollection = MockRepository.GenerateMock<IBuildCollection>();
        }

        [Test]
        public void Should_return_false_for_empty_list()
        {

            var userGroup = new UserGroups(buildCollection);
            Assert.That(userGroup.IsMonitoring("ShouldNotFind"),Is.EqualTo(false));
        }

        [Test]
        public void Should_return_true_for_single_monitor()
        {
            var someGroup = new UserGroup(null,null,"ShouldFind");
            var userGroup = new UserGroups(buildCollection);
            userGroup.Add(someGroup);
            Assert.That(userGroup.IsMonitoring("ShouldFind"), Is.EqualTo(true));
        }

        [Test]
        public void Should_return_true_for_multiple_monitors()
        {
            var someGroup = new UserGroup(null, null, "A");
            var someGroup1 = new UserGroup(null, null, "B");
            var someGroup2 = new UserGroup(null, null, "C");

            var userGroup = new UserGroups(buildCollection);
            userGroup.Add(someGroup);
            userGroup.Add(someGroup1);
            userGroup.Add(someGroup2);
            Assert.That(userGroup.IsMonitoring("A"), Is.EqualTo(true));
            Assert.That(userGroup.IsMonitoring("C"), Is.EqualTo(true));
        }
    }
}