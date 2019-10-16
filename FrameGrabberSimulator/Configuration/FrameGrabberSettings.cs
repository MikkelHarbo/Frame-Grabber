namespace FrameGrabberSimulator.Configuration
{
    public class FrameGrabberSettings
    {
        public FrameGrabberSettings(string fileType, int frequency, int startingProjection, int amount, string mode)
        {
            FileType = fileType;
            Frequency = frequency;
            StartingProjection = startingProjection;
            Amount = amount;
            Mode = mode;
        }

        public string FileType { get; set; }
        public int Frequency { get; set; }
        public int StartingProjection { get; set; }
        public int Amount { get; set; }
        public string Mode { get; set; }
    }
}