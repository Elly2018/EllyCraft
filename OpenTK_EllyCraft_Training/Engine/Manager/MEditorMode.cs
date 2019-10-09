using EllyCraft.GUI;
using EllyCraft.IO;
using OpenTK.Input;

namespace EllyCraft
{
    sealed class MEditorMode
    {
        private static EditorModeJsonFormat editorMode;
        private static EScene editorModeScene;

        /// <summary>
        /// Import resource, and create editor scene.
        /// </summary>
        public static void Initialize()
        {
            LoadSetting();

            if (!editorMode.Enable && !editorMode.RunningTimeChange) return;

            EScene EditorScene = new EScene("EditorMode");

            MSceneManager.LoadScene(EditorScene);
        }
        /// <summary>
        /// Import resource from drive
        /// If nothing there then create a default editor setting file
        /// </summary>
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
        /// <summary>
        /// Editor scene
        /// This should be only gui scene, and fuilfilled with control
        /// </summary>
        private static void CreateEditorModeScene()
        {
            editorModeScene = new EScene("EditorMode");

            ESceneObject UIParent = editorModeScene.CreateInstance(new ESceneObject("UI"));
            ESceneObject TestText = editorModeScene.CreateInstance(new ESceneObject("Test"), UIParent);

            UIParent.AddComponent<CRectTransform>();
            TestText.AddComponent<CRectTransform>();
            CText targetText = TestText.AddComponent<CText>();

            targetText.text = "Test";
            targetText.color = new EColor(1.0f, 1.0f, 1.0f);
            MSceneManager.LoadScene(editorModeScene);
        }

        /// <summary>
        /// Detect key for trigger editor console
        /// </summary>
        public static void ConsoleKeyDetect()
        {
            if (MInputManager.keyboardState.IsKeyDown(Key.F12)){
                editorModeScene.Active = !editorModeScene.Active;
            }
        }
    }
}
