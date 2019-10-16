namespace FrameGrabberSimulator.Configuration
{
    public class DirectorySettings
    {
        public DirectorySettings(string baseTargetPath, string sourcePath)
        {
            BaseTargetPath = baseTargetPath;
            SourcePath = sourcePath;
        }
        public string BaseTargetPath { get; set; }
        public string SourcePath { get; set; }
    }
}