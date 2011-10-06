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
                     let attribute = c.Attribute("lastBuildStatus")
                     where attribute != null
                     where attribute.Value.Equals(status)
                     let xAttribute = c.Attribute("name")
                     where xAttribute != null
                     let xAttribute1 = c.Attribute("activity")
                     where xAttribute1 != null
                     let attribute1 = c.Attribute("lastBuildLabel")
                     where attribute1 != null
                     let xAttribute2 = c.Attribute("lastBuildTime")
                     where xAttribute2 != null
                     let attribute2 = c.Attribute("webUrl")
                     where attribute2 != null
                     select
                         new Project(xAttribute.Value, 
                                     attribute.Value,
                                     xAttribute1.Value, 
                                     attribute1.Value,
                                     xAttribute2.Value, 
                                     attribute2.Value)
                    );
            return x;
        }

        private XDocument GetRemoteData()
        {
            return XDocument.Load(new StringReader(_endPoint.GetXml()));            
        }
    }
}