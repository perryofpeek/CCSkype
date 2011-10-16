using CCSkype.Commands;

namespace CCSkype
{
    public interface ICommandParser
    {
        CommandEntity Parse(string commandline);
    }
}