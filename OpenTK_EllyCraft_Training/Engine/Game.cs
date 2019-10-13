using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.ES30;
using NanoVGDotNet.NanoVG;
using EllyCraft.IO;
using EllyCraft.GUI;

namespace EllyCraft
{
    /// <summary>
    /// 
    /// Ellycraft is a sandbox game
    /// 
    /// </summary>
    class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        /// <summary>
        /// Program enter point
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Game win = new Game(800, 600, "EllyCraft");
            win.Run(30);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(this.ClientRectangle);
        }

        protected override void OnLoad(EventArgs e)
        {
            /* Register system */
            ELogger.AddLogger(new SystemLogger(1));
            ELogger.Log("Logger initialized");

            /* Initialize all io */
            InitializeIO();

            /* Initialize all manager */
            MInputManager.targetWindow = this;
            InitializeManager();

            /* Display the window and grpahics api information */
            ELogger.Log("Game initialized");

            /* Editor mode scene ready, and import editor setting */
            MEditorMode.Initialize();

            /* Load the default scene and set this scene as active scene */
            EScene.GetDefaultScene();
            MSceneManager.SetActiveScene(EScene.DefaultSceneName);

            /* Initialize gui drawer */
            CSpriteRender.ctx = GlNanoVg.CreateGl(NvgCreateFlags.AntiAlias | NvgCreateFlags.StencilStrokes);
            CSpriteRender.style = new EGUIStyle();

            base.OnLoad(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            /* Clear the screen color buffer and depth bit, or update the frame */
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            /* Render every scene 3D object */
            MSceneManager.SceneRender();

            /* Render every scene 2D object */
            NanoVg.BeginFrame(CSpriteRender.ctx, Width, Height, (float)Width / (float)Height);
            MSceneManager.SceneGUIRender();
            NanoVg.EndFrame(CSpriteRender.ctx);
            
            /* Switch the frame pull update event */
            Context.SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            /* Receive input information from OpenTK.Input
             * Store in input manager */
            MInputManager.keyboardState = Keyboard.GetState();
            MInputManager.mouseState = Mouse.GetState();
            MInputManager.mouseCursorState = Mouse.GetCursorState();

            /* Pull logic update event through out every scene */
            MSceneManager.SceneUpdate();

            base.OnUpdateFrame(e);
        }

        private static void InitializeIO()
        {
            EditModeReader.Initialize("EditMode.json");
            EditModeWriter.Initialize("EditMode.json");
            ELogger.Log("EditMode io initialized");

            HotkeyReader.Initialize("Hotkey.json");
            HotkeyWriter.Initialize("Hotkey.json");
            ELogger.Log("Hotkey io initialized");
        }

        private static void InitializeManager()
        {
            MInputManager.Initialize();
        }
    }
}
