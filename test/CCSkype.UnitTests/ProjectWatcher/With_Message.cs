using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.ProjectWatcher
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class With_Message
    {
        [Test]
        public void Should_message_a_single_group_where_the_pipeline_names_match()
        {
            var message = "build failed";
            var userGroups = MockRepository.GenerateMock<IUserGroups>();
            userGroups.Expect(x => x.Alert("ABC", message));                        
            var list = new List<Project>();
            list.Add(new Project("ABC", "Failed", "Failed", "Failed", "10:20", "http://some.place"));
            var projectwatcher = new Projectwatcher(userGroups);

            //Test
            projectwatcher.Message(list, message);
            //Assert
            userGroups.VerifyAllExpectations();
        }
    }
}