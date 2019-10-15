using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrameGrabberSimulator
{
    //TODO: This class generally need formatting. 
    class FrameGrabberSimulator
    {
        //TODO Please add access specifier - and make it readonly. And rename it to _folderCreator (both _ and o) if you want to use it. 
        FolderCreater folderCreater = new FolderCreater();

        //TODO Please just import the configuration namespace instead. 
        public void Begin(Configuration.Configuration configuration)
        {
            var baseTargetPath = configuration.BaseTargetPath;

            var sourcePath = configuration.SourcePath;

            Console.WriteLine("Type in the name of folder that will be created"); //TODO Maybe move this line to the CreateFolder method. 

            var targetPath = CreateFolder(baseTargetPath); //TODO Why do you create a folder at the base target path? 

            folderCreater.CreateFolder(targetPath); //TODO What is the difference between folderCreater.CreateFolder and CreateFolder ? 

            CopyFiles(sourcePath, targetPath,configuration); //TODO Formatting
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

            //TODO Wouldn't it be nice if there existed an object with amout and frequency that you could just pass instead?
            FileCopier fileCopier = new FileCopier(amount, frequenzy);

            fileCopier.InputFiles(sourcePath, targetPath);
        }

    }
}
