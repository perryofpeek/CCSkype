using CCSkype.Interfaces;

namespace CCSkype.Commands
{
    public class StartWatchCommand : ICommand
    {        
        private readonly CommandEntity _commandEntity;

        public StartWatchCommand(CommandEntity commandEntity)
        {
            _commandEntity = commandEntity;                     
        }

        public CommandEntity CommandEntity
        {
            get { return _commandEntity; }
        }

        public string Execute()
        {
            return "";
        }
    }
}