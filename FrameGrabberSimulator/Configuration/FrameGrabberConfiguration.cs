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
