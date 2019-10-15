using System;
using System.IO;
using System.Threading;
using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class FileCopier
    {
        
        private int AmountOfProjections { get; }
        private int Frequency { get; }
        private int StartProjection { get; }
        private string FileType { get; }

        public FileCopier(FrameGrabberSettings frameGrabberSettings)
        {
            AmountOfProjections = frameGrabberSettings.Amount;
            Frequency = frameGrabberSettings.Frequency;
            StartProjection = frameGrabberSettings.StartingProjection;
            FileType = frameGrabberSettings.FileType;
        }


        public void CopyFiles(string sourceDir, string targetDir)
        {
            //TODO: Naming: fileType
            Directory.CreateDirectory(targetDir);
            string[] files = Directory.GetFiles(sourceDir, FileType);
            
            for (int i = StartProjection; i < AmountOfProjections; i++)
            {
                SimulateProjectionCreation(i,files,targetDir);
            }

        }

        public void SimulateProjectionCreation(int i,string[] files,string targetDir)
        {
            if (i < 0.25 * AmountOfProjections || i > 0.75 * AmountOfProjections)
            {
                Thread.Sleep(1000 / CalculateFrequency(Frequency * 0.5));
            }
            else
            {
                Thread.Sleep(1000 / Frequency);
            }

            File.Copy(files[i], Path.Combine(targetDir, Path.GetFileName(files[i]) ?? throw new InvalidOperationException()));
            Console.WriteLine(Path.GetFileName(files[i]));
        }

        private int CalculateFrequency(double maxFrequency)
        {
            if (Math.Abs(maxFrequency) < 0)
            {
               var newFrequency = Math.Round((double) maxFrequency, 0, MidpointRounding.AwayFromZero);
               return (int) newFrequency;
            }

            return (int) maxFrequency;
        }

    }
}
