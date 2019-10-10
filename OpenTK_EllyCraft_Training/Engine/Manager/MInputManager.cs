using EllyCraft.IO;
using OpenTK;
using OpenTK.Input;

namespace EllyCraft
{
    /// <summary>
    /// The work handle the input event in the game
    /// </summary>
    sealed class MInputManager
    {
        public static NativeWindow targetWindow;
        public static KeyboardState keyboardState;
        public static MouseState mouseState;
        public static MouseState mouseCursorState;

        private static HotkeyJsonFormat hotkeyJson;

        /// <summary>
        /// Active at the begining of the process
        /// It will import hotkey file in to memory
        /// </summary>
        public static void Initialize()
        {
            LoadHotkey();
        }
        private static void LoadHotkey()
        {
            if (HotkeyReader.CheckFileExist())
            {
                hotkeyJson = HotkeyReader.ReadTargetFile<HotkeyJsonFormat>();
            }
            else
            {
                hotkeyJson = HotkeyWriter.CreateDefault();
            }
        }

        /// <summary>
        /// According to opengl window, calculate the position of the mouse
        /// </summary>
        /// <returns></returns>
        public static EIVertex2D GetWindowMousePos()
        {
            return new EIVertex2D(MInputManager.mouseCursorState.X - targetWindow.X, MInputManager.mouseCursorState.Y - targetWindow.Y);
        }

        public static EIVertex2D GetWindowSize()
        {
            return new EIVertex2D(targetWindow.Width, targetWindow.Height);
        }
    }
}
