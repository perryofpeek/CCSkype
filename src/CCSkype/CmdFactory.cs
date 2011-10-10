using CCSkype.UnitTests.CommandFactory;

namespace CCSkype
{
    public class CmdFactory
    {
        private readonly ICommandParser _commandParser;

        public CmdFactory(ICommandParser commandParser)
        {
            _commandParser = commandParser;
        }

        public ICommand Create(string command)
        {
            var cmdEntity = _commandParser.Parse(command);
            switch (cmdEntity.Command.ToLower())
            {
                case "list":
                    {
                        return new ListCommand();
                    }
                case "startwatch":
                    {
                        return new StartWatchCommand(cmdEntity);
                    }
            }
            return new UnknownCommand(cmdEntity);
        }
    }

    public class UnknownCommand : ICommand
    {
        private readonly CommandEntity _cmdEntity;

        public UnknownCommand(CommandEntity cmdEntity)
        {
            _cmdEntity = cmdEntity;            
        }

        public CommandEntity CommandEntity
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}