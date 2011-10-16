using CCSkype.Commands;
using CCSkype.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.Message_Processor
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Process
    {        
        private ICmdFactory _cmdFactory;
        private IMessageProcessor _messageProcessor;

        [SetUp]
        public void SetUp()
        {            
            _cmdFactory = MockRepository.GenerateMock<ICmdFactory>();
            _messageProcessor = new MessageProcessor(_cmdFactory);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Should_process_list_command()
        {
            var command = "!List";
            var r = "some response";
            var  commandMock = MockRepository.GenerateMock<ICommand>();
            commandMock.Expect(x => x.Execute()).Return(r);
            _cmdFactory.Expect(x => x.Create(command)).Return(commandMock);            
            var response = _messageProcessor.Process(command);
            Assert.That(response.Message, Is.EqualTo(r));
            Assert.That(response.Success, Is.EqualTo(true));
            _cmdFactory.VerifyAllExpectations();            
            commandMock.VerifyAllExpectations();
        }        
    }
}