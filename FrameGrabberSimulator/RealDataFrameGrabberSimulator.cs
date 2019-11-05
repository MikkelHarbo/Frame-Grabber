using System;
using System.IO;
using FrameGrabberSimulator.Configuration;

namespace FrameGrabberSimulator
{
    class RealDataFrameGrabberSimulator
    {
        private readonly FileCopier _fileCopier;

        public RealDataFrameGrabberSimulator(FileCopier fileCopier)
        {
            _fileCopier = fileCopier;
        }

        public void Begin(DirectorySettings directorySettings)
        {
            var baseTargetPath = directorySettings.BaseTargetPath;

            var targetPath = CreateTargetPathFromUserInput(baseTargetPath);

            Directory.CreateDirectory(targetPath);

            CopyFiles(directorySettings.SourcePath, targetPath);
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
