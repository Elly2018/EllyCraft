using NanoVGDotNet.FontStash;
using NanoVGDotNet.NanoVG;

namespace EllyCraft.GUI
{
    [RequireComponent(typeof(CSpriteRender))]
    class CText : CSpriteRender
    {
        public string text = "";
        public EColor color = new EColor();

        public override void Awake()
        {
            base.Awake();
        }

        public override void RenderGUI()
        {
            base.RenderGUI();
            FillTextInRect(new EColor(1, 1, 1, 1), 12, text);
        }
    }
}
