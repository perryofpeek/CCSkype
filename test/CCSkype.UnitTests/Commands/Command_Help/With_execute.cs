using System.Collections.Generic;
using CCSkype.Commands;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Commands.Command_Help
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
        public void Should_return_help()
        {
            var commandHelp = new HelpCommand(null);
            var response = commandHelp.Execute();
            //Assert;
            Assert.That(response, Is.EqualTo("commands are: \r\nHelp\r\nList\r\n"));           
        }
    }
}