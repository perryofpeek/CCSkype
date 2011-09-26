using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.User_Groups
{
    // ReSharper disable InconsistentNaming
    [TestFixture]    
    public class With_Message
    {
        [Test]
        public void Should_send_message_to_group()
        {
            var message = "some message";
            var pipelineName = "A";
            var userGroup = MockRepository.GenerateMock<IUserGroup>();
            userGroup.Expect(x => x.Name).Return(pipelineName);
            userGroup.Expect(x => x.Send(message));
            
            var userGroups = new UserGroups();
            userGroups.Add(userGroup);
           
            //Test
            userGroups.Alert(pipelineName, message);
            
            //Assert
            userGroup.VerifyAllExpectations();
        }

        [Test]
        public void Should_not_send_message_to_group_as_it_does_not_exsist()
        {
            var message = "some message";
            var pipelineName = "A";
            var userGroup = MockRepository.GenerateMock<IUserGroup>();
            userGroup.Expect(x => x.Name).Return(pipelineName);
            userGroup.AssertWasNotCalled(x => x.Send(message));

            var userGroups = new UserGroups();
            userGroups.Add(userGroup);

            //Test
            userGroups.Alert("not found", message);

            //Assert
            userGroup.VerifyAllExpectations();
        }

    }
}