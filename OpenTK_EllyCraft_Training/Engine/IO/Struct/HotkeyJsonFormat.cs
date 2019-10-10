using OpenTK.Input;

namespace EllyCraft.IO
{
    [System.Serializable]
    class HotkeyJsonFormat
    {
        public HotKeyElement[] hotKeys;

        /// <summary>
        /// Create default will trigger
        /// </summary>
        public HotkeyJsonFormat()
        {
            hotKeys = new HotKeyElement[2]{
                new HotKeyElement("Console", Key.F12, 
                    new HotKeyEvent(false, false, false, false, false, false, false)),
                new HotKeyElement("FullScreen", Key.F11,
                    new HotKeyEvent(false, false, false, false, false, false, false))
            };
        }
    }

    [System.Serializable]
    class HotKeyElement
    {
        public string HotkeyName;
        public Key Primary;
        public HotKeyEvent Event;

        public HotKeyElement()
        {

        }

        public HotKeyElement(string hotkeyName, Key primary)
        {
            HotkeyName = hotkeyName;
            Primary = primary;
        }
        public HotKeyElement(string hotkeyName, Key primary, HotKeyEvent @event)
        {
            HotkeyName = hotkeyName;
            Primary = primary;
            this.Event = @event;
        }
    }

    [System.Serializable]
    class HotKeyEvent
    {
        public bool L_Control;
        public bool R_Control;
        public bool L_Shift;
        public bool R_Shift;
        public bool L_Alt;
        public bool R_Alt;
        public bool Space;

        public HotKeyEvent()
        {

        }

        public HotKeyEvent(bool l_Control, bool r_Control, bool l_Shift, bool r_Shift, bool l_Alt, bool r_Alt, bool space)
        {
            L_Control = l_Control;
            R_Control = r_Control;
            L_Shift = l_Shift;
            R_Shift = r_Shift;
            L_Alt = l_Alt;
            R_Alt = r_Alt;
            Space = space;
        }
    }
}
