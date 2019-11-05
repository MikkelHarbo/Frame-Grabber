using System;
using System.IO;
using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class FakeDataFrameGrabberSimulator
    {
        private readonly FileCopier _fileCopier;
        private readonly FrameGrabberSettings _settings;

        public FakeDataFrameGrabberSimulator(FileCopier fileCopier, FrameGrabberSettings settings)
        {
            _fileCopier = fileCopier;
            _settings = settings;
        }

        public void Begin(DirectorySettings directorySettings)
        {
            var baseTargetPath = directorySettings.BaseTargetPath;
            var targetPath = CreateTargetPathFromUserInput(baseTargetPath);

            Directory.CreateDirectory(targetPath);
            var sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "FakeXimData");

            if (Directory.Exists(sourcePath))
            {
                Directory.Delete(sourcePath, true);
            }
            
            Directory.CreateDirectory(sourcePath);
            
            CreateXimFiles(sourcePath);
            
            CopyFiles(sourcePath, targetPath);
        }

        private void CreateXimFiles(string basePath)
        {
            for (int i = 1; i < _settings.Amount + 1; i++)
            {
                var fileName = "proj" + i + ".xim";
                File.WriteAllText(basePath + "/" + fileName, "Projection " + i);
            }
        }
        
        private string CreateTargetPathFromUserInput(string baseTargetPath)
        {
            Console.WriteLine("Type in the name of folder that will be created");

            bool exists = false;

            var folderName = "";

            do
            {
                folderName = Console.ReadLine();

                if (!Directory.Exists(Path.Combine(baseTargetPath ?? throw new InvalidOperationException(),
                    folderName ?? throw new InvalidOperationException())))
                {
                    exists = true;
                }
                else
                {
                    Console.WriteLine("Folder already exists, try a new name");
                }
            } while (!exists);
            return Path.Combine(baseTargetPath, folderName);
        }

        private void CopyFiles(string sourcePath, string targetPath)
        {
            _fileCopier.CopyFiles(sourcePath, targetPath);
        }
    }
}