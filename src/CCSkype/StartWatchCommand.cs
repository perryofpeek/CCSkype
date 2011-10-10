namespace CCSkype.UnitTests.CommandFactory
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
    }
}