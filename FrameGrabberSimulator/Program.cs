using System;
using System.IO;
using System.Linq;
using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class Program
    {

        static void Main(string[] args)
        {
            FrameGrabberSimulator frameGrabberSimulator = new FrameGrabberSimulator();
            Configuration.Configuration configuration = new Configuration.Configuration(); //TODO This is redundant since you are assigning it with the xmlreader anyway. 
            
            XmlReader xml = new XmlReader();
            
           configuration = xml.ReadFile();

            frameGrabberSimulator.Begin(configuration);

        }


    }
}
