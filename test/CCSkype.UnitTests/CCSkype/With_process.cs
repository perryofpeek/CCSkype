using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.CCSkype
{
    // ReSharper disable InconsistentNaming
    [TestFixture]   
    public class With_process
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Should_get_xml_and_issue_alert()
        {
            var failedProjectList = new List<Project>();
            failedProjectList.Add(new Project("SomeProject","Failed","Failed","label","10:20","http://some.place"));

            var alertMessenger = MockRepository.GenerateMock<IAlertMessenger>();            

            var ccTray = MockRepository.GenerateMock<ICcTray>();
            ccTray.Expect(x => x.Load());
            ccTray.Expect(x => x.FailedPipelines).Return(failedProjectList);
            
            var ccSkype = new CcSkype(ccTray);
            ccSkype.Process();

            ccTray.VerifyAllExpectations();
        }
    }
}