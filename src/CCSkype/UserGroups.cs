using System.Collections;

namespace CCSkype
{
    public class UserGroups : IUserGroups
    {
        private readonly IBuildCollection _buildCollection;
        private readonly Hashtable _groups;

        public UserGroups(IBuildCollection buildCollection)
        {
            _buildCollection = buildCollection;
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
     
        public void Alert(IProject project)
        {
            if (IsMonitoring(project.PipelineName))
            {
                if(_buildCollection.ShouldAlert(project))
                {
                    var g = (IUserGroup)_groups[project.PipelineName];
                    g.Send(project.GetMessage());                    
                }
            }
        }       
    }
}