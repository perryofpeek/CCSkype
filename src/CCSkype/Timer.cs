namespace CCSkype
{
    public class Timer : ITimer
    {
        private readonly IWantToBeRun _task;
        private readonly ISleeper _sleeper;

        public Timer(IWantToBeRun task, ISleeper sleeper)
        {
            _task = task;
            _sleeper = sleeper;
        }

        public void Start()
        {
            _task.Execute();
            while (_sleeper.Sleep())
            {
                _task.Execute();
            }
        }
    }
}