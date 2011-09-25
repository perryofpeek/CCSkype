using System.IO;
using System.Xml.Serialization;

namespace CCSkype.Config
{
    public class ConfigurationLoader
    {
        public Configuration Load(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(Configuration));
            var sw = new StreamReader(path);
            var config = (Configuration) xmlSerializer.Deserialize(sw);
            sw.Close();
            return config;
        }
    }
}