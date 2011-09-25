using System.Collections;

namespace CCSkype
{
    public class UserGroups : IUserGroups
    {
        private readonly Hashtable _groups;

        public UserGroups()
        {
            _groups = new Hashtable();
        }
      
        public bool IsMonitoring(string pipelineName)
        {
            return _groups.ContainsKey(pipelineName);
        }

        public void Add(IUserGroup someGroup)
        {
            _groups.Add(someGroup.Name, someGroup);           
        }


        public void Alert(string pipelineName, string message)
        {
            if(IsMonitoring(pipelineName))
            {
                var g = (IUserGroup) _groups[pipelineName];
                g.Send(message);
            }
        }
    }
}