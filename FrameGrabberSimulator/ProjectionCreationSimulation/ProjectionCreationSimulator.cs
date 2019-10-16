using System;
using System.Collections.Generic;
using System.Threading;
using MathNet.Numerics.Distributions;

namespace FrameGrabberSimulator.ProjectionCreationSimulation
{
    public class ProjectionCreationSimulator : IProjectionCreationSimulator
    {
        private readonly List<int> _normalDistribution;
        private int _counter;

        public ProjectionCreationSimulator(int amountOfProjections, int frequency)
        {
            _normalDistribution = CreateNormalDistributedList(amountOfProjections, frequency);
            _counter = 0;
        }
        public void SimulateProjectionCreation()
        {
            Thread.Sleep(_normalDistribution[_counter]);
            _counter++;
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
            for (int i = 0; i < sortedDistribution.Count; i++)
            {
                if (i == 0)
                {
                    sortedDistribution[i] = -0.99;
                }
                else if (IsOutlier(sortedDistribution[i]))
                {
                    sortedDistribution[i] = sortedDistribution[i - 1];
                }
            }
        }

        private bool IsOutlier(double value)
        {
            return value < -1 || value > 1;
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
    }
}