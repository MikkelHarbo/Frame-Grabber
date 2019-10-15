using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrameGrabberSimulator
{
    class FrameGrabberSimulator
    {

        FolderCreater folderCreater = new FolderCreater();

        public void Begin(Configuration.Configuration configuration)
        {
            var baseTargetPath = configuration.BaseTargetPath;

            var sourcePath = configuration.SourcePath;

            Console.WriteLine("Type in the name of folder that will be created");

            var targetPath = CreateFolder(baseTargetPath);

            folderCreater.CreateFolder(targetPath);

            CopyFiles(sourcePath, targetPath,configuration);

        }

        private string CreateFolder(string baseTargetPath)
        {
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

        private void CopyFiles(string sourcePath,string targetPath,Configuration.Configuration configuration)
        {
            int frequenzy = configuration.Frequency;

            int amount = configuration.Amount;

            FileCopier fileCopier = new FileCopier(amount, frequenzy);

            fileCopier.InputFiles(sourcePath, targetPath);
        }

    }
}
