using System;
using System.Configuration;

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
            var mode = ConfigurationManager.AppSettings["Mode"];

            FrameGrabberSettings frameGrabberSettings = new FrameGrabberSettings(fileType, frequency, startingProjection, amount, mode);
            DirectorySettings directorySettings = new DirectorySettings(baseTargetPath, sourcePath);

            return new FrameGrabberConfiguration(directorySettings, frameGrabberSettings);
        }
    }
}
