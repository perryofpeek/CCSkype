using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CCSkype
{
    public class CcTray : ICcTray
    {
        private readonly IEndPoint _endPoint;

        public List<Project> FailedPipelines { get; private set; }

        public CcTray(IEndPoint endPoint)
        {
            _endPoint = endPoint;
        }

        public void Load()
        {
            FailedPipelines = GetProjectsWithLastBuildStatus("Failure").ToList();
        }

        private IEnumerable<Project> GetProjectsWithLastBuildStatus(string status)
        {
            var data = GetRemoteData();
            var x = (from c in data.Descendants("Projects").Descendants("Project")
                     where c.Attribute("lastBuildStatus").Value.Equals(status)
                     select
                         new Project(c.Attribute("name").Value, 
                                     c.Attribute("lastBuildStatus").Value,
                                     c.Attribute("activity").Value, 
                                     c.Attribute("lastBuildLabel").Value,
                                     c.Attribute("lastBuildTime").Value, 
                                     c.Attribute("webUrl").Value)
                    );
            return x;
        }

        private XDocument GetRemoteData()
        {
            return XDocument.Load(new StringReader(_endPoint.GetXml()));            
        }
    }
}