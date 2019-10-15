using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FrameGrabberSimulator.Configuration
{
    //TODO This class needs formatting. 

    //TODO: I would have preferred splitting this class into two classes since I believe that you could
    //TODO: split the data into two different areas that actually makes sense in regards of the domain. 
public class Configuration
    {
        public string BaseTargetPath { get; set; }
        public string SourcePath { get; set; }
        public int Frequency { get; set; }
        //TODO StartingProjection is never used so it may just as well be deleted. 
        public int StartingProjection { get; set; }
        public int Amount { get; set; }
    }
}
