using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            FileCopier fileCopier = new FileCopier(configuration.FrameGrabberSettings);

            FrameGrabberSimulator frameGrabberSimulator = new FrameGrabberSimulator(fileCopier);

            frameGrabberSimulator.Begin(configuration.DirectorySettings);
        }

        private static FrameGrabberConfiguration GetConfiguration()
        {
            ConfigurationReader configurationReader = new ConfigurationReader();
            return configurationReader.LoadConfiguration();
        }


    }
}
