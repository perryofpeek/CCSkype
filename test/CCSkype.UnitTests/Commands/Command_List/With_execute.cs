using System.Collections.Generic;
using CCSkype.Commands;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Commands.Command_List
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_execute
    {       
        [Test]
        public void Should_return_multiple_pipelines()
        {
            var cmdParser = MockRepository.GenerateMock<ICommandParser>();
            var ccTray = MockRepository.GenerateMock<ICcTray>();
            var cmdFactory = new CmdFactory(cmdParser, ccTray);

            string cmdLine = "List";
            cmdParser.Expect(x => x.Parse(cmdLine)).Return(new CommandEntity(cmdLine, ""));
            ccTray.Expect(x => x.AllPipelineNames()).Return(new List<string>() { "a", "b", "c" });
            var cmd = cmdFactory.Create(cmdLine);
            //Test            

            var response = cmd.Execute();
            //Assert;
            Assert.That(response, Is.EqualTo("a\r\nb\r\nc\r\n"));
            cmdParser.VerifyAllExpectations();
            ccTray.VerifyAllExpectations();
        }

        [Test]
        public void Should_return_single_pipeline()
        {
            var cmdParser = MockRepository.GenerateMock<ICommandParser>();
            var ccTray = MockRepository.GenerateMock<ICcTray>();
            var cmdFactory = new CmdFactory(cmdParser, ccTray);

            string cmdLine = "List";
            cmdParser.Expect(x => x.Parse(cmdLine)).Return(new CommandEntity(cmdLine, ""));
            ccTray.Expect(x => x.AllPipelineNames()).Return(new List<string>() { "a"});
            var cmd = cmdFactory.Create(cmdLine);
            //Test            

            var response = cmd.Execute();
            //Assert;
            Assert.That(response, Is.EqualTo("a\r\n"));
            cmdParser.VerifyAllExpectations();
            ccTray.VerifyAllExpectations();
        }
    }
}