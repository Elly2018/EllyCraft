using OpenTK;
using OpenTK.Input;

namespace EllyCraft
{
    sealed class MInputManager
    {
        public static NativeWindow targetWindow;
        public static KeyboardState keyboardState;
        public static MouseState mouseState;
        public static MouseState mouseCursorState;

        public static EIVertex2D GetWindowMousePos()
        {
            return new EIVertex2D(MInputManager.mouseCursorState.X - targetWindow.X, MInputManager.mouseCursorState.Y - targetWindow.Y);
        }
    }
}
