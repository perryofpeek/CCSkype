using NUnit.Framework;

namespace CCSkype.UnitTests.Usr
{
    // ReSharper disable InconsistentNaming
    [TestFixture]    
    public class With_User
    {       
        [Test]
        public void Should_create_user_object()
        {
            var username = "someUser";
            var user = new User(username);
            Assert.That(user.Username, Is.EqualTo(username));
        }
    }
}