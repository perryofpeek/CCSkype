﻿using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.skypeMessenger
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_execute
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
        public void Should_execute_the_main_processing()
        {
            var message = "someMessage";
            var ccTray = MockRepository.GenerateMock<ICcTray>();
            var projectWatcher = MockRepository.GenerateMock<IProjectwatcher>();
            var projects = new List<Project>();
            ccTray.Expect(x => x.FailedPipelines).Return(projects);
            ccTray.Expect(x => x.Load());
            projectWatcher.Expect(x => x.Message(projects, message));
            var skypeMessenger = new SkypeMessenger(ccTray,projectWatcher,message);
            //Test
            skypeMessenger.Execute();

            //Assert
            ccTray.VerifyAllExpectations();
            projectWatcher.VerifyAllExpectations();
        }
    }
}