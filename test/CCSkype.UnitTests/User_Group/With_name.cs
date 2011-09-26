using NUnit.Framework;

namespace CCSkype.UnitTests.User_Group
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class With_name
    {      
        [Test]
        public void Should_Set_Group_name()
        {
            var name = "name";
            var userGroup = new UserGroup(null, null, name);
            Assert.That(userGroup.Name, Is.EqualTo(name));
        }
    }
}