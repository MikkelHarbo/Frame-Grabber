using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FrameGrabberSimulator.Configuration
{
    class ConfigurationReader
    {
        public FrameGrabberConfiguration LoadConfiguration()
        {
            var sourcePath = ConfigurationManager.AppSettings["SourcePath"];
            var baseTargetPath = ConfigurationManager.AppSettings["BaseTargetPath"];
            var fileType = ConfigurationManager.AppSettings["FileType"];
            var amount = Convert.ToInt32(ConfigurationManager.AppSettings["Amount"]);
            var startingProjection = Convert.ToInt32(ConfigurationManager.AppSettings["StartingProjection"]);
            var frequency = Convert.ToInt32(ConfigurationManager.AppSettings["Frequency"]);

            FrameGrabberSettings frameGrabberSettings = new FrameGrabberSettings(fileType, frequency, startingProjection, amount);
            DirectorySettings directorySettings = new DirectorySettings(baseTargetPath, sourcePath);

            return new FrameGrabberConfiguration(directorySettings, frameGrabberSettings);

        }
    }
}
