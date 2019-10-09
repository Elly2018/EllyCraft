using EllyCraft.GUI;
using EllyCraft.IO;
using OpenTK.Input;

namespace EllyCraft
{
    sealed class MEditorMode
    {
        private static EditorModeJsonFormat editorMode;
        private static EScene editorModeScene;

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
            CreateEditorModeScene();
        }
        private static void CreateEditorModeScene()
        {
            editorModeScene = new EScene("EditorMode");

            ESceneObject UIParent = editorModeScene.CreateInstance(new ESceneObject("UI"));
            ESceneObject TestText = editorModeScene.CreateInstance(new ESceneObject("Test"), UIParent);

            UIParent.AddComponent<CRectTransform>(new CRectTransform());
            TestText.AddComponent<CRectTransform>(new CRectTransform());
            CText targetText = TestText.AddComponent<CText>(new CText());
            targetText.text = "Test";

            MSceneManager.LoadScene(editorModeScene);
        }

        public static void ConsoleKeyDetect()
        {
            if (MInputManager.keyboardState.IsKeyDown(Key.F12)){
                editorModeScene.Active = !editorModeScene.Active;
            }
        }
    }
}
