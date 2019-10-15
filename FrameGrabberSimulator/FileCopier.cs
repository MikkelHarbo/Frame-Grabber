using System;
using System.IO;
using System.Threading;

namespace FrameGrabberSimulator
{
    class FileCopier
    {
        //TODO Why are these properties and not private fields?
        public int AmountOfProjections { get; }
        public int Frequency { get; }

        public FileCopier(int amountOfProjections, int frequency)
        {
            AmountOfProjections = amountOfProjections;
            Frequency = frequency;
        }

        //TODO Naming: CopyFiles instead? InputFiles could be a noun. 
        public void InputFiles(string sourceDir, string targetDir)
        {
            //TODO: Naming: fileType
            var filetype = "*.xim"; //TODO Avoid hardcoded strings - Please extract this to a constant - Or consider loading it via the configuration. 
            Directory.CreateDirectory(targetDir);
            string[] files = Directory.GetFiles(sourceDir, filetype);

            
            for (int i = 0; i < AmountOfProjections; i++)
            {
                //TODO You could extract this if and else into a method called SimulateProjectionCreation or something. 
                if (i < 0.25 * AmountOfProjections || i > 0.75 * AmountOfProjections)
                {
                    Thread.Sleep(1000 / CalculationOfFrequency(Frequency*0.5));
                }
                else 
                {
                    Thread.Sleep(1000 / Frequency);
                }
                
                File.Copy(files[i], Path.Combine(targetDir, Path.GetFileName(files[i]) ?? throw new InvalidOperationException()));
                Console.WriteLine(Path.GetFileName(files[i]));
            }

        }

        //TODO Why is this public?
        //TODO Naming: CalculateFrequency and the parameter: maxFrequency
        public int CalculationOfFrequency(double freqeuncy)
        {
            //TODO This seems a bit weird. Why not just pass a integer and then check if it is 0?
            if (freqeuncy % 1 != 0)
            {
               var newFrequency = Math.Round((double) freqeuncy, 0, MidpointRounding.AwayFromZero);
               return (int) newFrequency;
            }

            return (int) freqeuncy;
        }

    }
}
