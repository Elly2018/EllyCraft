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
            if (EditModeReader.CheckFileExist())
            {
                editorMode = EditModeReader.ReadTargetFile<EditorModeJsonFormat>();
            }
            else
            {
                editorMode = EditModeWriter.CreateDefault();
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

            ESceneObject UIParent = editorModeScene.CreateInstance(new ESceneObject("Menu"));
            ESceneObject TestW = editorModeScene.CreateInstance(new ESceneObject("Test"));

            UIParent.AddComponent<CRectTransform>();
            CRectTransform r = TestW.AddComponent<CRectTransform>();

            r.rect = new ERect(50, 80, 50, 100);
            CWindow targetW = TestW.AddComponent<CWindow>();
            TestW.AddComponent<CMenuBar>();

            editorModeScene.CompleteLoading();

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
