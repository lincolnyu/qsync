using System.IO;

namespace QInfra
{
    public class FileSys
    {
        public static DirectoryInfo Dir(string path)
        {
            if (Directory.Exists(path))
            {
                return new DirectoryInfo(path);
            }
            else
            {
                return Directory.CreateDirectory(path);
            }
        }
    }
}