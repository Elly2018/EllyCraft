namespace EllyCraft.GUI
{
    [RequireComponent(typeof(CSpriteRender))]
    class CText : CSpriteRender
    {
        public string text;
        public EColor color;

        public override void RenderGUI()
        {
            base.RenderGUI();
        }
    }
}
