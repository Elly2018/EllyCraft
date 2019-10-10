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
            ESceneObject ButtonTest = editorModeScene.CreateInstance(new ESceneObject("Button"), UIParent);

            ESceneObject TestW = editorModeScene.CreateInstance(new ESceneObject("Test"));

            UIParent.AddComponent<CRectTransform>();
            CRectTransform r = TestW.AddComponent<CRectTransform>();
            ButtonTest.AddComponent<CRectTransform>();
            ButtonTest.AddComponent<CGUIRaycast>();

            CButton b = ButtonTest.AddComponent<CButton>();
            CWindow targetW = TestW.AddComponent<CWindow>();
            TestW.AddComponent<CMenuBar>();

            r.anchor.rect = new ERect(50, 80, 50, 100);
            r.anchor.anctorType = EAnchor.AnctorType.TopLeft;

            b.ButtonColor = new EColor(0.5f, 0.5f, 0.5f);
            b.ButtonHightLightColor = new EColor(0.8f, 0.5f, 0.5f);
            b.ButtonPressColor = new EColor(0.2f, 0.2f, 0.4f);

            editorModeScene.CompleteLoading();
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
