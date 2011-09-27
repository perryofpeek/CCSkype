using System.Collections.Generic;

namespace CCSkype
{
    public interface IProjectwatcher
    {
        void Message(List<Project> projectsToMessage, string message);
    }
}