using NUnit.Framework;

namespace CCSkype.UnitTests.CommandFactory
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Create
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
        public void Should_Create_list_command()
        {
            var c = new CmdFactory(new CommandParser());
            var cmd = c.Create("List");
            Assert.That(cmd, Is.InstanceOf<ListCommand>());
        }

        [Test]
        public void Should_Create_StartWatch_command_with_pipeline_name()
        {
            var param1 = "param1";
            var param2 = "param2";

            var c = new CmdFactory(new CommandParser());
            var cmd = c.Create("StartWatch " + param1 + " " + param2);
            Assert.That(cmd, Is.InstanceOf<StartWatchCommand>());
            Assert.That(cmd.CommandEntity.Parameter[0], Is.EqualTo(param1));
            Assert.That(cmd.CommandEntity.Parameter[1], Is.EqualTo(param2));
        }
    }
}