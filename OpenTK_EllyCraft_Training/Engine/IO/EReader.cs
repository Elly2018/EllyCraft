using Newtonsoft.Json;
using System.IO;

namespace EllyCraft.IO
{
    public class EReader
    {
        protected static string FileName;
        public static void Initialize(string _FileName)
        {
            FileName = _FileName;
        }
        public static bool CheckFileExist()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), FileName);
            return File.Exists(path);
        }
        public static T ReadTargetFile<T>() where T : new()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), FileName);
            T result = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            if (result == null)
            {
                MLoggerManager.LogError(MLoggerManager.LoggerMessage.LoadingFailed(path));
            }

            return result;
        }
    }
}
