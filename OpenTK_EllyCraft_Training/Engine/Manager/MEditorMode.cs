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

            /* Top title menu */
            ESceneObject UIMenu = editorModeScene.CreateInstance(new ESceneObject("Menu"));
            ESceneObject UIMenuHorizontalLayout = editorModeScene.CreateInstance(new ESceneObject("HorizontalLayout"), UIMenu);

            /* Top title button */
            ESceneObject ButtonFile = editorModeScene.CreateInstance(new ESceneObject("TitleFile"), UIMenuHorizontalLayout);
            ESceneObject ButtonFileText = editorModeScene.CreateInstance(new ESceneObject("TitleFileText"), ButtonFile);
            ESceneObject ButtonHelp = editorModeScene.CreateInstance(new ESceneObject("TitleHelp"), UIMenuHorizontalLayout);

            /* Top title menu rect */
            CRectTransform UIParentRect = UIMenu.AddComponent<CRectTransform>();
            CRectTransform UIMenuHorizontalLayoutRect = UIMenuHorizontalLayout.AddComponent<CRectTransform>();
            CRectTransform ButtonFileRect = ButtonFile.AddComponent<CRectTransform>();
            CRectTransform ButtonFileTextRect = ButtonFileText.AddComponent<CRectTransform>();
            CRectTransform ButtonHelpRect = ButtonHelp.AddComponent<CRectTransform>();

            /* Top title menu comp */
            CHorizontalLayout UIMenuHorizontalLayoutHorizontalLayout = UIMenuHorizontalLayout.AddComponent<CHorizontalLayout>();
            CMenuBar UIParentMenubar = UIMenu.AddComponent<CMenuBar>();

            CButton ButtonFileButton = ButtonFile.AddComponent<CButton>();
            CText ButtonFileButtonText = ButtonFileText.AddComponent<CText>();

            CButton ButtonHelpButton = ButtonHelp.AddComponent<CButton>();
            CGUIRaycast ButtonFileRaycast = ButtonFile.AddComponent<CGUIRaycast>();
            CGUIRaycast ButtonHelpRaycast = ButtonHelp.AddComponent<CGUIRaycast>();

            UIParentRect.anchor.rect = new ERect(0, 0, 0, 40);
            UIMenuHorizontalLayoutHorizontalLayout.ElementArea = new ERect(0, 0, 70, 30);
            UIMenuHorizontalLayoutHorizontalLayout.ElementMargin.Left = 5;
            UIMenuHorizontalLayoutHorizontalLayout.ElementMargin.Right = 5;
            UIMenuHorizontalLayoutHorizontalLayout.ElementMargin.Top = 5;
            UIMenuHorizontalLayoutHorizontalLayout.ElementMargin.Bottom = 4;

            ButtonFileButtonText.text = "File";
            ButtonFileButton.ButtonColor = new EColor(0.8f, 0.5f, 0.5f);
            ButtonFileButton.ButtonHightLightColor = new EColor(0.9f, 0.6f, 0.6f);
            ButtonFileButton.ButtonPressColor = new EColor(0.2f, 0.2f, 0.4f);

            ButtonHelpButton.ButtonColor = new EColor(0.5f, 0.9f, 0.5f);
            ButtonHelpButton.ButtonHightLightColor = new EColor(0.6f, 1.0f, 0.6f);
            ButtonHelpButton.ButtonPressColor = new EColor(0.2f, 0.2f, 0.4f);

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
