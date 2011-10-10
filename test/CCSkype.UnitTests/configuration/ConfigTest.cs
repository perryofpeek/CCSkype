using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using NUnit.Framework;

namespace CCSkype.UnitTests.configuration
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class ConfigTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Should_()
        {

            var c = new ConfigT();
            c.data = new Dictionary<string, string>();
            c.data.Add("test", "test123");
            Console.WriteLine(MakeXml(c));
        }

        public static string MakeXml(ConfigT projects)
        {
            var serializer = new XmlSerializer(typeof(ConfigT));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);
            string utf8;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, projects, ns);
                utf8 = writer.ToString();
            }
            return utf8;
        }

    }

    public class ConfigT
    {
        public ConfigT()
        {
        }

        public System.Collections.Generic.Dictionary<string, string> data { get; set; }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}