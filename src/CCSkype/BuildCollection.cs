using System.Collections.Generic;

namespace CCSkype
{
    public class BuildCollection : IBuildCollection
    {        
        private readonly SortedDictionary<string,string> _builds;

        public BuildCollection()
        {
            _builds = new SortedDictionary<string, string>();
        }

        public bool ShouldAlert(IProject project)
        {           
            if (_builds.ContainsKey(project.GetUniqueKey()))
            {
                return false;   
            }
            _builds.Add(project.GetUniqueKey(), "");
            return true;            
        }
    }
}