using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;

namespace EllyCraft
{
    class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        [STAThread]
        static void Main()
        {   
            Game win = new Game(800, 600, "EllyCraft");
            win.Run(30);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MLoggerManager.Log("Game initialized");
            MEditorMode.Initialize();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            MInputManager.keyboardState = Keyboard.GetState();
            MInputManager.mouseState = Mouse.GetState();
            MInputManager.mouseCursorState = Mouse.GetCursorState();


        }
    }
}
