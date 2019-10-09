using System;
using System.IO;

namespace EllyCraft.IO
{
    class EPath
    {
        public static string GetApplicationPath()
        {
            string path = Directory.GetCurrentDirectory();
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

        public static string GetResourcePath()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Resource");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

        public static string GetPersistentPath()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EllyCraft");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }
    }
}
