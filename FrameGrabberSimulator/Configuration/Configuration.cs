using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FrameGrabberSimulator.Configuration
{
    
public class Configuration
    {
        public string BaseTargetPath { get; set; }
        public string SourcePath { get; set; }
        public int Frequency { get; set; }
        public int StartingProjection { get; set; }
        public int Amount { get; set; }
    }
}
