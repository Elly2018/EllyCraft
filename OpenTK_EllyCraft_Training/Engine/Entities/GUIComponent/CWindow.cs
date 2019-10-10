using NanoVGDotNet.NanoVG;

namespace EllyCraft.GUI
{
    class CWindow : CSpriteRender
    {
        public const float MinWidth = 80;
        public const float MinHeight = 100;

        public bool Moveable;
        public bool Resizeable;
        public bool Dock;

        private CRectTransform rect;

        public override void Awake()
        {
            base.Awake();
            rect = sceneObject.GetComponent<CRectTransform>(true);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void RenderGUI()
        {
            base.RenderGUI();
            ERect RenderArea = rect.GetViewportRenderArea();
            RenderArea = CheckSize(RenderArea);

            /* Base background render */
            NanoVg.BeginPath(CSpriteRender.ctx);
            NanoVg.Rect(CSpriteRender.ctx,
                (float)RenderArea.x,
                (float)RenderArea.y,
                (float)RenderArea.width,
                (float)RenderArea.height);
            NanoVg.FillColor(CSpriteRender.ctx, EColorToNvgColor(style.BackgroundColor));
            NanoVg.Fill(CSpriteRender.ctx);
        }

        private ERect CheckSize(ERect r)
        {
            if (r.width < MinWidth) r.width = MinWidth;
            if (r.height < MinHeight) r.height = MinHeight;
            return r;
        }
    }
}
