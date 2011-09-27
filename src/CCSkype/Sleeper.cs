using System.Threading;

namespace CCSkype
{
    public class Sleeper : ISleeper
    {
        private readonly int _timeInSeconds;

        public Sleeper(int timeInSeconds)
        {
            _timeInSeconds = timeInSeconds;
        }

        public bool Sleep()
        {
            const int oneSecond = 1000;
            const int sleepTime = 100;
            var totalIterations = ((oneSecond * _timeInSeconds) / sleepTime);
            for (int i = 0; i < totalIterations; i++)
            {
                Thread.Sleep(sleepTime);
            }
            return true;
        }
    }
}