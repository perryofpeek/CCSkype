using System;

namespace CCSkype
{
    public class SkypeMessenger : IWantToBeRun
    {
        private readonly ICcTray _ccTray;
        private readonly IProjectwatcher _projectwatcher;        

        public SkypeMessenger(ICcTray ccTray, IProjectwatcher projectwatcher)
        {
            _ccTray = ccTray;
            _projectwatcher = projectwatcher;            
        }

        public void Execute()
        {
            _ccTray.Load();
            _projectwatcher.Message(_ccTray.FailedPipelines);
        }
    }
}