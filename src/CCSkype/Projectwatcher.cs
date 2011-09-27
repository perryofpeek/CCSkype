using System.Collections.Generic;

namespace CCSkype
{
    public class Projectwatcher : IProjectwatcher
    {
        private readonly IUserGroups _userGroups;

        public Projectwatcher(IUserGroups userGroups)
        {
            _userGroups = userGroups;
        }
       
        public void Message(List<Project> projectsToMessage, string message)
        {
            foreach (var project in projectsToMessage)
            {
                _userGroups.Alert(project.PipelineName, message);
            }
        }
    }
}