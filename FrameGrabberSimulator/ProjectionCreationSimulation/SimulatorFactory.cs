namespace FrameGrabberSimulator.ProjectionCreationSimulation
{
    public class SimulatorFactory
    {
        public static IProjectionCreationSimulator CreateSimulator(string mode, int amount, int frequency)
        {
            if (mode == "Normal")
            {
                return new ProjectionCreationSimulator(amount, frequency);
            }
            else
            {
                return new SimpleProjectionCreationSimulator(frequency);
            }
        }
    }
}