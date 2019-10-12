using NanoVGDotNet.NanoVG;

namespace EllyCraft.GUI
{
    class CMenuBar : CSpriteRender
    {
        public const float MinHeight = 30;

        public override void Update()
        {
            base.Update();
            renderRect.anchor.pivotType = EAnchor.PivotType.TopLeft;
            ERect local = renderRect.anchor.rect;
            renderRect.anchor.rect = new ERect(0, 0, MInputManager.GetWindowSize().x, local.height < MinHeight ? MinHeight : local.height);
        }

        public override void RenderGUI()
        {
            base.RenderGUI();
            ERect local = renderRect.anchor.rect;

            /* Base background render */
            FillColorCurrentRect(style.BackgroundColor);
        }
    }
}
