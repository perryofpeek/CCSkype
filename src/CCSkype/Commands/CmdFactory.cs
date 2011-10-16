using ICommand = CCSkype.Interfaces.ICommand;

namespace CCSkype.Commands
{ 
    public class CmdFactory : ICmdFactory
    {
        private readonly ICommandParser _commandParser;
        private readonly ICcTray _ccTray;

        public CmdFactory(ICommandParser commandParser, ICcTray ccTray)
        {
            _commandParser = commandParser;
            _ccTray = ccTray;
        }

        public ICommand Create(string command)
        {
            var cmdEntity = _commandParser.Parse(command);
            switch (cmdEntity.Command.ToLower())
            {
                case "list":
                    {
                        return new ListCommand(cmdEntity, _ccTray);
                    }
                case "startwatch":
                    {
                        return new StartWatchCommand(cmdEntity);
                    }
            }
            return new UnknownCommand(cmdEntity);
        }
    }
}