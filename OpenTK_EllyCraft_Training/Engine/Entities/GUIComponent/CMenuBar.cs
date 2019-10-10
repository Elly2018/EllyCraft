using NanoVGDotNet.NanoVG;

namespace EllyCraft.GUI
{
    class CMenuBar : CSpriteRender
    {
        public const float Height = 50;

        private CRectTransform rect;

        public override void Awake()
        {
            base.Awake();
            rect = sceneObject.GetComponent<CRectTransform>(true);
        }

        public override void RenderGUI()
        {
            base.RenderGUI();
            /* Base background render */
            NanoVg.BeginPath(CSpriteRender.ctx);
            NanoVg.Rect(CSpriteRender.ctx,
                (float)0f,
                (float)0f,
                (float)MInputManager.GetWindowSize().x,
                (float)Height);
            NanoVg.FillColor(CSpriteRender.ctx, EColorToNvgColor(style.BackgroundColor));
            NanoVg.Fill(CSpriteRender.ctx);
        }
    }
}
