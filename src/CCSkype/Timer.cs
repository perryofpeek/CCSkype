namespace CCSkype
{
    public class Timer : ITimer
    {
        private readonly IWantToBeRun _task;
        private readonly ISleeper _sleeper;
        private readonly IStopper _stopper;

        public Timer(IWantToBeRun task, ISleeper sleeper,IStopper stopper)
        {
            _task = task;
            _sleeper = sleeper;
            _stopper = stopper;
        }

        public void Start()
        {
            _task.Execute();
            while (_sleeper.Sleep() && _stopper.Stop == false)
            {
                _task.Execute();
            }
        }
    }
}