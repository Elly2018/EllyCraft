using System;
using System.IO;

namespace EllyCraft.IO
{
    class EPath
    {
        public static string GetApplicationPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string GetResourcePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Resource");
        }

        public static string GetPersistentPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EllyCraft");
        }
    }
}
