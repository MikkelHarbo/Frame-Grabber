using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using FrameGrabberSimulator.Configuration;
using MathNet.Numerics.Distributions;

namespace FrameGrabberSimulator
{
    class FileCopier
    {
        private readonly int _amountOfProjections;
        private readonly int _frequency;
        private readonly int _startProjection;
        private readonly string _fileType;
        private readonly List<int> _normalDistribution;

        public FileCopier(FrameGrabberSettings frameGrabberSettings)
        {
            _amountOfProjections = frameGrabberSettings.Amount;
            _frequency = frameGrabberSettings.Frequency;
            _startProjection = frameGrabberSettings.StartingProjection;
            _fileType = frameGrabberSettings.FileType;
            _normalDistribution = CreateNormalDistributedList(_amountOfProjections, _frequency);

        }

        private List<int> CreateNormalDistributedList(int amount, int mean)
        {
            var rawNormalDistribution = CreateRawNormalDistributedList(amount);

            rawNormalDistribution.Sort();

            ModifyOutliers(rawNormalDistribution);

            return CreateNormalDistributedDelayList(rawNormalDistribution, mean);
        }

        private List<double> CreateRawNormalDistributedList(int amount)
        {
            var normal = new Normal(1, 0.5);
            List<double> rawNormalDistribution = new List<double>();
            for (int i = 0; i < amount; i++)
            {
                var value = normal.Sample() - 1;
                rawNormalDistribution.Add(value);
            }

            return rawNormalDistribution;
        }

        private void ModifyOutliers(List<double> sortedDistribution)
        {
            for (int i = 0; i < sortedDistribution.Count - 1; i++)
            {
                if (i == 0 && IsOutlier(sortedDistribution[i]-1))
                {
                    sortedDistribution[i] = -1;
                }
                else if (IsOutlier(sortedDistribution[i]-1))
                {
                    sortedDistribution[i] = sortedDistribution[i - 1];
                }
            }
        }

        private bool IsOutlier(double value)
        {
            return value < -1;
        }

        private List<int> CreateNormalDistributedDelayList(List<double> distribution, int mean)
        {
            List<int> delayList = new List<int>();

            foreach (var value in distribution)
            {
                var newValue = mean - Math.Abs(value * mean);
                delayList.Add((int)Math.Round(1000 / newValue));
            }

            return delayList;
        }


        public void CopyFiles(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            string[] files = Directory.GetFiles(sourceDir, _fileType);

            for (int i = _startProjection; i < _amountOfProjections; i++)
            {
                SimulateProjectionCreation(i, files, targetDir);
                File.Copy(files[i], Path.Combine(targetDir, Path.GetFileName(files[i]) ?? throw new InvalidOperationException()));
                Console.WriteLine(Path.GetFileName(files[i]));
            }
        }

        public void SimulateProjectionCreation(int i, string[] files, string targetDir)
        {
            Thread.Sleep(_normalDistribution[i]);
        }

        private int CalculateFrequency(double maxFrequency)
        {
            if (Math.Abs(maxFrequency) < 0)
            {
                var newFrequency = Math.Round((double)maxFrequency, 0, MidpointRounding.AwayFromZero);
                return (int)newFrequency;
            }

            return (int)maxFrequency;
        }
    }
}
