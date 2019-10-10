using Newtonsoft.Json;
using System;
using System.IO;

namespace EllyCraft.IO
{
    public class EWriter<T> where T : new()
    {
        protected static string FileName;
        protected static T JsonData;

        public static void Initialize(string _FileName)
        {
            FileName = _FileName;
        }

        public static T CreateDefault()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), FileName);
            JsonData = new T();
            SaveJsonData<T>(JsonData);
            return JsonData;
        }

        public static bool CheckFileExist()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), FileName);
            return File.Exists(path);
        }

        public static void SaveJsonData<U>(U data)
        {
            string path = Path.Combine(EPath.GetPersistentPath(), FileName);
            if (CheckFileExist())
                File.Delete(path);

            File.WriteAllText(path, JsonConvert.SerializeObject(JsonData, Formatting.Indented));
        }
    }
}
