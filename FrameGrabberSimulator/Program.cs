using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            var fileCopier = new FileCopier(configuration.FrameGrabberSettings);

            var frameGrabberSimulator = new FrameGrabberSimulator(fileCopier);

            frameGrabberSimulator.Begin(configuration.DirectorySettings);
        }
        private static FrameGrabberConfiguration GetConfiguration()
        {
            var configurationReader = new ConfigurationReader();
            return configurationReader.LoadConfiguration();
        }
    }
}
