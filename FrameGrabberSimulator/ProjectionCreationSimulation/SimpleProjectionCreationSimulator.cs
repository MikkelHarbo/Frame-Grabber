using System.Threading;

namespace FrameGrabberSimulator.ProjectionCreationSimulation
{
    public class SimpleProjectionCreationSimulator : IProjectionCreationSimulator
    {
        private readonly int _frequency;

        public SimpleProjectionCreationSimulator(int frequency)
        {
            _frequency = frequency;
        }
        public void SimulateProjectionCreation()
        {
            Thread.Sleep(1000 / _frequency);
        }
    }
}