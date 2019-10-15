using System.IO;

namespace FrameGrabberSimulator
{
    class FolderCreater
    {
        public void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
