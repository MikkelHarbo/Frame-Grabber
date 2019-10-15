using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FrameGrabberSimulator.Configuration
{
    class XmlReader
    {
        public Configuration ReadFile()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            string configPath = Path.Combine(currentDirectory, "xmlconfig.xml");
            var configuration = LoadXml(configPath);
            return configuration;
        }
        public static Configuration LoadXml(string configPath)
        {
            Configuration result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            using (StreamReader fileStream = new StreamReader(new FileStream(configPath, FileMode.Open)))
            {
                result = (Configuration)serializer.Deserialize(fileStream);
            }

            return result;
        }

        public static Configuration LoadJson(string configPath)
        {
            Configuration result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            using (StreamReader fileStream = new StreamReader(new FileStream(configPath, FileMode.Open)))
            {
                result = JsonConvert.DeserializeObject<Configuration>(fileStream.ReadToEnd());
            }

            return result;
        }
    }
}
