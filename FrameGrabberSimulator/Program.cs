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
            Configuration.Configuration configuration = new Configuration.Configuration();
            
            XmlReader xml = new XmlReader();
            
           configuration = xml.ReadFile();

            frameGrabberSimulator.Begin(configuration);

        }


    }
}
