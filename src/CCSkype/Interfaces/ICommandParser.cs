namespace CCSkype
{
    public interface ICommandParser
    {
        CommandEntity Parse(string commandline);
    }
}