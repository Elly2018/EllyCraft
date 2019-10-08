using EllyCraft.IO;

namespace EllyCraft
{
    class MEditorMode
    {
        private static EditorModeJsonFormat editorMode;

        public static void Initialize()
        {
            LoadSetting();

            if (!editorMode.Enable && !editorMode.RunningTimeChange) return;

            EScene EditorScene = new EScene("EditorMode");

            MSceneManager.LoadScene(EditorScene);
        }

        private static void LoadSetting()
        {
            if (LoadEditorMode.EditorModeFileExist())
            {
                editorMode = LoadEditorMode.GetEditorModeData();
            }
            else
            {
                editorMode = SaveEditMode.CreateDefault();
            }
        }
    }
}
