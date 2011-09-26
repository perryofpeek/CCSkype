/*
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace CCSkype.UnitTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]    
    public class With_cctray
    {       
        [Test]
        public void Should_get_cctray_object()
        {
            var httpGet = new HttpGet(20, "owainp", "**Fish22");
            httpGet.Request("http://build.london.ttldev.local:8153/go/cctray.xml");
            var body = httpGet.ResponseBody;
            var tx = new StringReader(body);

            var data = XDocument.Load(tx);
            var x = (from c in data.Descendants("Projects").Descendants("Project")
                     where c.Attribute("lastBuildStatus").Value.Equals("Failure")
                     select new Project(c.Attribute("name").Value, c.Attribute("lastBuildStatus").Value, c.Attribute("activity").Value, c.Attribute("lastBuildLabel").Value, c.Attribute("lastBuildTime").Value, c.Attribute("webUrl").Value)
                      );

            foreach (var projectsProject in x)
            {
                Console.WriteLine(projectsProject.name);
            }
        }
    }
}
*/