using CCSkype.Interfaces;

namespace CCSkype.Commands
{
    public class UnknownCommand : ICommand
    {
        private readonly CommandEntity _cmdEntity;

        public UnknownCommand(CommandEntity cmdEntity)
        {
            _cmdEntity = cmdEntity;            
        }

        public CommandEntity CommandEntity
        {
            get { return _cmdEntity; }
        }

        public string Execute()
        {
            //throw new System.NotImplementedException();
            return "!Help for help";
        }
    }
}