using CCSkype.Interfaces;

namespace CCSkype.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly CommandEntity _commandEntity;

        public HelpCommand(CommandEntity commandEntity)
        {
            _commandEntity = commandEntity;                     
        }

        public CommandEntity CommandEntity
        {
            get { return _commandEntity; }
        }

        public string Execute()
        {
            return "commands are: \r\nHelp\r\nList\r\n";
        }
    }
}