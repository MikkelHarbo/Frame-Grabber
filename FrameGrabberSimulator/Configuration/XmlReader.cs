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
    //TODO: Class name doesn't make sense since it is only reading configurations - Not xml-files. 
    class XmlReader
    {
        public Configuration ReadFile()
        {
            var currentDirectory = Directory.GetCurrentDirectory(); //TODO Have you considered making a configuration path instead? What about default configuration if no configuration file is found?
            string configPath = Path.Combine(currentDirectory, "xmlconfig.xml"); //TODO I don't like hardcoded strings like this. Please use constants instead. Also consider naming the file "framegrabber.config" instead. 
            var configuration = LoadXml(configPath);
            return configuration;
        }

        //TODO Why is this method public and static when it is used only by a non-static public method? It doesn't make any sense :)
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

        
        //TODO Please delete this now you have decided to use a xml.config file instead of json. 
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
