using System;
using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick one of the following modes:");
            Console.WriteLine("[1] Simulation with real .xim-data.");
            Console.WriteLine("[2] Simulation with fake .xim-data with possible order check");
            Console.WriteLine("[Esc] Exit application");

            HandleUserInput();

            Console.ReadKey();
        }

        private static void HandleUserInput()
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    StartRealSimulation();
                    break;
                case ConsoleKey.D2:
                    StartFakeSimulation();
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    HandleUserInput();
                    break;
            }
        }

        private static void StartFakeSimulation()
        {
            var configuration = GetConfiguration();
            var fileCopier = new FileCopier(configuration.FrameGrabberSettings);
            var frameGrabberSimulator = new FakeDataFrameGrabberSimulator(fileCopier, configuration.FrameGrabberSettings);
            frameGrabberSimulator.Begin(configuration.DirectorySettings);
        }

        private static void StartRealSimulation()
        {
            var configuration = GetConfiguration();
            var fileCopier = new FileCopier(configuration.FrameGrabberSettings);
            var frameGrabberSimulator = new RealDataFrameGrabberSimulator(fileCopier);
            frameGrabberSimulator.Begin(configuration.DirectorySettings);
        }
        
        private static FrameGrabberConfiguration GetConfiguration()
        {
            var configurationReader = new ConfigurationReader();
            return configurationReader.LoadConfiguration();
        }


    }


}