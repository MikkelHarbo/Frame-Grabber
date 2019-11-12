using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using FrameGrabberSimulator.Configuration;
using FrameGrabberSimulator.ProjectionCreationSimulation;
using MathNet.Numerics;

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
            var info = new DirectoryInfo(sourceDir);
            var files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

            for (var i = _startProjection; i < _amountOfProjections; i++)
            {
                _simulator.SimulateProjectionCreation();
                File.Copy(files[i].DirectoryName +"/"+ files[i].Name, Path.Combine(targetDir, Path.GetFileName(files[i].Name)), true);
                Console.WriteLine(Path.GetFileName(files[i].Name));
            }
        }
    }
}

