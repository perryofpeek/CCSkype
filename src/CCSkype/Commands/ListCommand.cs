using CCSkype.Interfaces;

namespace CCSkype.Commands
{
    public class ListCommand : ICommand
    {
        private readonly CommandEntity _commandEntity;
        private readonly ICcTray _ccTray;

        public ListCommand(CommandEntity commandEntity, ICcTray ccTray)
        {
            _commandEntity = commandEntity;
            _ccTray = ccTray;
        }

        public CommandEntity CommandEntity
        {
            get { return _commandEntity; }
        }

        public string Execute()
        {
            //Make this unique list            
            var response = string.Empty;
            foreach (var name in _ccTray.AllPipelineNames())
            {
                response = string.Concat(response,string.Format("{0}\r\n", name));
            }
            return response;
        }
    }
}