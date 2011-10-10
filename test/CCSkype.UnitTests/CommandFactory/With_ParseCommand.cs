using NUnit.Framework;

namespace CCSkype.UnitTests.CommandFactory
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_ParseCommand
    {       
        [Test]
        public void Should_parse_simple_command()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse("cmd");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo(""));
        }

        [Test]
        public void Should_parse_to_command_and_param()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse("cmd param");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo("param"));
        }

        [Test]
        public void Should_parse_to_command_and_param_with_space_at_end()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse("cmd param ");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo("param"));
        }

        [Test]
        public void Should_parse_to_command_and_param_with_space_at_begining()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse(" cmd param ");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo("param"));
        }

        [Test]
        public void Should_parse_to_command_and_param_with_double_space()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse(" cmd  param ");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo("param"));
        }

        [Test]
        public void Should_parse_to_command_and_param_with_tripple_space()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse(" cmd   param ");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo("param"));
        }

        [Test]
        public void Should_parse_to_command_and_mutliple_params()
        {
            var cmdParser = new CommandParser();
            var e = cmdParser.Parse(" cmd param1  param2 ");
            Assert.That(e.Command, Is.EqualTo("cmd"));
            Assert.That(e.Parameter[0], Is.EqualTo("param1"));
            Assert.That(e.Parameter[1], Is.EqualTo("param2"));
        }


    }
}