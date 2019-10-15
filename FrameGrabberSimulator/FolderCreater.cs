using System.IO;

namespace FrameGrabberSimulator
{
    //TODO: This class seems redundant - You could just use Directory.CreateDirectory directly. There is no reason to wrap it. 
    //TODO: If you want to keep it - Then please rename it to FolderCreator. 
    class FolderCreater
    {
        public void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
