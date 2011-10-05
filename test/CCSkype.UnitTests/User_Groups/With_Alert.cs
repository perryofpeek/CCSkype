using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.User_Groups
{
    // ReSharper disable InconsistentNaming
    [TestFixture]    
    public class With_Alert
    {
        private IBuildCollection buildCollection;

        [SetUp]
        public void SetUp()
        {
            buildCollection = MockRepository.GenerateMock<IBuildCollection>();
        }

        [Test]
        public void Should_send_a_single_message_to_group()
        {
            var message = "some message";
            var pipelineName = "A";
            var userGroup = MockRepository.GenerateMock<IUserGroup>();
            
            userGroup.Expect(x => x.Name).Return(pipelineName);
            userGroup.Expect(x => x.Send(message));
            var projectMock = MockRepository.GenerateMock<IProject>();
            projectMock.Expect(x => x.GetMessage()).Return(message);
            projectMock.Expect(x => x.PipelineName).Return(pipelineName);

            var userGroups = new UserGroups(buildCollection);
            userGroups.Add(userGroup);

            buildCollection.Expect(x => x.ShouldAlert(projectMock)).Return(true).Repeat.Once();

            //Test
            userGroups.Alert(projectMock);

            //Assert
            userGroup.VerifyAllExpectations();
            projectMock.VerifyAllExpectations();
            buildCollection.VerifyAllExpectations();
        }

        [Test]
        public void Should_not_send_message_to_group_as_it_does_not_exsist()
        {
            var message = "some message";
            var pipelineName = "A";
            var userGroup = MockRepository.GenerateMock<IUserGroup>();
            userGroup.Expect(x => x.Name).Return(pipelineName);
            userGroup.AssertWasNotCalled(x => x.Send(message));

            var projectMock = MockRepository.GenerateMock<IProject>();            
            projectMock.Expect(x => x.PipelineName).Return("not found");


            var userGroups = new UserGroups(buildCollection );
            userGroups.Add(userGroup);

            //Test
            userGroups.Alert(projectMock);

            //Assert
            userGroup.VerifyAllExpectations();
            projectMock.VerifyAllExpectations();
        }

        [Test]
        public void Should_not_send_second_message_to_group_as_it_does_not_exsist()
        {
            var message = "some message";
            var pipelineName = "A";
            var userGroup = MockRepository.GenerateMock<IUserGroup>();
            userGroup.Expect(x => x.Name).Return(pipelineName);
            userGroup.Expect(x => x.Send(message)).Repeat.Once();
            userGroup.Stub(x => x.Send(message)).Throw(new InvalidOperationException("Should not be called"));
            var projectMock = MockRepository.GenerateMock<IProject>();
            projectMock.Expect(x => x.PipelineName).Return(pipelineName);
            projectMock.Expect(x => x.GetMessage()).Return(message);

            buildCollection.Expect(x => x.ShouldAlert(projectMock)).Return(true).Repeat.Once();
            buildCollection.Expect(x => x.ShouldAlert(projectMock)).Return(false).Repeat.Once();


            var userGroups = new UserGroups(buildCollection);
            userGroups.Add(userGroup);           
            //Test
            userGroups.Alert(projectMock);
            userGroups.Alert(projectMock);
            //Assert
            userGroup.VerifyAllExpectations();
            projectMock.VerifyAllExpectations();
            buildCollection.VerifyAllExpectations();
        }
    }
}