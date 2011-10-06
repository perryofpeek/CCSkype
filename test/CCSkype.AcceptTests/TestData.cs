using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using NUnit.Framework;

namespace CCSkype.AcceptTests
{
    public class TestData
    {
        public static Projects CreateProjects(int numberSuccess, int numberFailure)
        {
            var projects = new Projects { Project = new Project[numberSuccess + numberFailure] };
            MakeSuccessProjects(numberSuccess).CopyTo(projects.Project, 0);
            MakeFailureProjects(numberFailure).CopyTo(projects.Project, numberSuccess );
            return projects;                       
        }

        private static Project[] MakeFailureProjects(int number)
        {
            var rtn = new Project[number];
            for (var i = 0; i < number; i++)
            {
                rtn[i] = new Project("Failure-" + i, "Sleeping", "Failure", "lbl." + i, "11:11", "http://some.url/" + i);
            }
            return rtn;
        }

        private static Project[] MakeSuccessProjects(int number)
        {
            var rtn = new Project[number];
            for (var i = 0; i < number; i++)
            {
                rtn[i] = new Project("name" + i, "Sleeping", "Success", "lbl." + i, "10:20", "http://some.url/" + i);
            }
            return rtn;
        }

        public static string MakeXml(Projects projects)
        {
            var serializer = new XmlSerializer(typeof(Projects));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); 
            ns.Add(String.Empty, String.Empty); 
            string utf8;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, projects,ns);
                utf8 = writer.ToString();
            }
            return utf8;
        }
    }

    [XmlRoot(ElementName = "Projects")]
    public class Projects
    {
        [XmlElementAttribute("Project", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Project[] Project { get; set; }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }


}