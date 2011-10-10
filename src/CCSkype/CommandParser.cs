namespace CCSkype
{
    public class CommandParser : ICommandParser
    {
        private const string Space = " ";

        public CommandEntity Parse(string commandline)
        {
            commandline = commandline.Trim();            
            var pos = commandline.IndexOf(Space);
            return pos > 0 ? SplitCommandLineIntoCommandEntity(commandline, pos) : new CommandEntity(commandline, string.Empty);
        }

        private CommandEntity SplitCommandLineIntoCommandEntity(string commandline, int pos)
        {
            var cmd = commandline.Substring(0, pos);
            var param = commandline.Substring(pos + 1, (commandline.Length - (pos + 1)));
            return new CommandEntity(cmd, param);
        }
    }
}