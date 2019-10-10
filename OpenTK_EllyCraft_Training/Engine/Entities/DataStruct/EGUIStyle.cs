namespace EllyCraft
{
    class EGUIStyle
    {
        public EColor ForegroundColor;
        public EColor BackgroundColor;

        public EGUIStyle()
        {
            ForegroundColor = new EColor();
            BackgroundColor = new EColor(0.2f, 0.2f, 0.2f);
        }
    }
}
