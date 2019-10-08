using System.IO;
using Newtonsoft.Json;

namespace EllyCraft.IO
{
    class LoadEditorMode
    {
        public static bool EditorModeFileExist()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), "EditMode.json");
            return File.Exists(path);
        }

        public static EditorModeJsonFormat GetEditorModeData()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), "EditMode.json");
            EditorModeJsonFormat result = JsonConvert.DeserializeObject<EditorModeJsonFormat>(File.ReadAllText(path));
            if (result == null)
            {
                MLoggerManager.LogError(MLoggerManager.LoggerMessage.LoadingFailed(path));
            }

            return result;
        }
    }
}
