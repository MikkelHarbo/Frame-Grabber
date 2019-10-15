using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FrameGrabberSimulator.Configuration
{
    public class FrameGrabberConfiguration
    {
        public FrameGrabberConfiguration(DirectorySettings directorySettings, FrameGrabberSettings frameGrabberSettings)
        {
            DirectorySettings = directorySettings;
            FrameGrabberSettings = frameGrabberSettings;
        }
        public DirectorySettings DirectorySettings { get; set; }
        public FrameGrabberSettings FrameGrabberSettings { get; set; }
    }
}
