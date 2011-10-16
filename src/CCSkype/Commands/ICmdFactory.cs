using CCSkype.Interfaces;

namespace CCSkype.Commands
{
    public interface ICmdFactory
    {
        ICommand Create(string command);
    }
}