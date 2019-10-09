using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.ES30;

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

        protected override void OnLoad(EventArgs e)
        {
            /* Register system */
            MLoggerManager.AddLogger(new SystemLogger(1));
            MLoggerManager.Log("Logger initialized");

            MInputManager.targetWindow = this;

            /* Display the window and grpahics api information */
            MLoggerManager.Log("Game initialized");

            /* Editor mode scene ready, and import editor setting */
            MEditorMode.Initialize();

            /* Load the default scene and set this scene as active scene */
            MSceneManager.LoadScene(EScene.GetDefaultScene());
            MSceneManager.SetActiveScene(EScene.DefaultSceneName);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            /* Clear the screen color buffer and depth bit, or update the frame */
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            /* Render every scene 3D object */
            MSceneManager.SceneRender();

            /* Render every scene 2D object */
            MSceneManager.SceneGUIRender();

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

            MLoggerManager.Log(MInputManager.GetWindowMousePos().x + "  " + MInputManager.GetWindowMousePos().y);

            base.OnUpdateFrame(e);
        }
    }
}
