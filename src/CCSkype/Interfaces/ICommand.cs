using CCSkype.Commands;

namespace CCSkype.Interfaces
{
    public interface ICommand
    {
        CommandEntity CommandEntity { get; }
        string Execute();        
    }
}