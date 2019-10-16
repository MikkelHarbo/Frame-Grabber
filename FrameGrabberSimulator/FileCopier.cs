using System;
using System.IO;
using FrameGrabberSimulator.Configuration;
using FrameGrabberSimulator.ProjectionCreationSimulation;

namespace FrameGrabberSimulator
{
    class FileCopier
    {
        private readonly int _amountOfProjections;
        private readonly int _startProjection;
        private readonly string _fileType;
        private readonly IProjectionCreationSimulator _simulator;

        public FileCopier(FrameGrabberSettings frameGrabberSettings)
        {
            _simulator = SimulatorFactory.CreateSimulator(frameGrabberSettings.Mode, frameGrabberSettings.Amount,
                frameGrabberSettings.Frequency);
            _amountOfProjections = frameGrabberSettings.Amount;
            _startProjection = frameGrabberSettings.StartingProjection;
            _fileType = frameGrabberSettings.FileType;
        }

        public void CopyFiles(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            string[] files = Directory.GetFiles(sourceDir, _fileType);

            for (int i = _startProjection; i < _amountOfProjections; i++)
            {
                _simulator.SimulateProjectionCreation();
                File.Copy(files[i], Path.Combine(targetDir, Path.GetFileName(files[i]) ?? throw new InvalidOperationException()));
                Console.WriteLine(Path.GetFileName(files[i]));
            }
        }
    }
}

