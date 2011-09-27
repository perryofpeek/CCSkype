using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.timer
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_run
    {
        private IWantToBeRun task;
        private ISleeper sleeper;
        private Timer timer;


        [SetUp]
        public void SetUp()
        {
            task = MockRepository.GenerateMock<IWantToBeRun>();
            sleeper = MockRepository.GenerateMock<ISleeper>();
            timer = new Timer(task, sleeper);
        }

        [Test]
        public void Should_execute_task_every_interval_twice()
        {
            task.Expect(x => x.Execute()).Repeat.Times(2);
            sleeper.Expect(x => x.Sleep()).Return(true).Repeat.Times(2);
            sleeper.Expect(x => x.Sleep()).Return(false).Repeat.Once();
            //Test            
            timer.Start();
            //Assert
            sleeper.VerifyAllExpectations();
            task.VerifyAllExpectations();
        }

        [Test]
        public void Should_execute_task_every_interval_once()
        {
            task.Expect(x => x.Execute()).Repeat.AtLeastOnce();
            sleeper.Expect(x => x.Sleep()).Return(true).Repeat.Once();
            sleeper.Expect(x => x.Sleep()).Return(false).Repeat.Once();

            timer.Start();

            sleeper.VerifyAllExpectations();
            task.VerifyAllExpectations();
        }
    }
}