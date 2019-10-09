using Newtonsoft.Json;
using System.IO;

namespace EllyCraft.IO
{
    class SaveEditMode
    {
        public static EditorModeJsonFormat CreateDefault()
        {
            string path = Path.Combine(EPath.GetPersistentPath(), "EditMode.json");
            EditorModeJsonFormat editorMode = new EditorModeJsonFormat();
            editorMode.Enable = false;
            editorMode.RunningTimeChange = true;
            editorMode.EnableDevelopModeButton = true;
            SaveEditModeData(editorMode);
            return editorMode;
        }

        public static void SaveEditModeData(EditorModeJsonFormat editorMode)
        {
            string path = Path.Combine(EPath.GetPersistentPath(), "EditMode.json");
            if (LoadEditorMode.EditorModeFileExist())
                File.Delete(path);

            File.WriteAllText(path, JsonConvert.SerializeObject(editorMode, Formatting.Indented));
        }
    }
}
