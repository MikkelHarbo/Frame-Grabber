using System;
using System.IO;
using System.Threading;

namespace FrameGrabberSimulator
{
    class FileCopier
    {
        public int AmountOfProjections { get; }
        public int Frequency { get; }

        public FileCopier(int amountOfProjections, int frequency)
        {
            AmountOfProjections = amountOfProjections;
            Frequency = frequency;
        }
        public void InputFiles(string sourceDir, string targetDir)
        {
            var filetype = "*.xim";
            Directory.CreateDirectory(targetDir);
            string[] files = Directory.GetFiles(sourceDir, filetype);

            for (int i = 0; i < AmountOfProjections; i++)
            {
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

        public int CalculationOfFrequency(double freqeuncy)
        {
            if (freqeuncy % 1 != 0)
            {
               var newFrequency = Math.Round((double) freqeuncy, 0, MidpointRounding.AwayFromZero);
               return (int) newFrequency;
            }

            return (int) freqeuncy;
        }

    }
}
