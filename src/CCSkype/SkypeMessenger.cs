using System;

namespace CCSkype
{
    public class SkypeMessenger : IWantToBeRun
    {
        private readonly ICcTray _ccTray;
        private readonly IProjectwatcher _projectwatcher;
        private readonly string _messageTemplate;

        public SkypeMessenger(ICcTray ccTray, IProjectwatcher projectwatcher, string messageTemplate)
        {
            _ccTray = ccTray;
            _projectwatcher = projectwatcher;
            _messageTemplate = messageTemplate;
        }

        public void Execute()
        {
            _ccTray.Load();
            _projectwatcher.Message(_ccTray.FailedPipelines, _messageTemplate);
        }
    }
}