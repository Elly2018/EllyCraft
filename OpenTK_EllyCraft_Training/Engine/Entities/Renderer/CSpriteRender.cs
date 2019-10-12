using EllyCraft.Base;
using EllyCraft.IO;
using NanoVGDotNet.FontStash;
using NanoVGDotNet.NanoVG;
using System.IO;

namespace EllyCraft.GUI
{
    class CSpriteRender : RendererBase, _2DRenderer
    {
        public static NvgContext ctx;
        public static int SystemFont = -1;
        public static EGUIStyle style;

        protected CRectTransform renderRect;

        public void Render(CRectTransform t)
        {
            
        }

        public override void Awake()
        {
            base.Awake();
            renderRect = sceneObject.GetComponent<CRectTransform>(true);
        }

        public static ERect CheckMask(ERect MasterRenderArea, ERect TargetRenderArea)
        {
            ERect result = new ERect(TargetRenderArea);
            return result;
        }

        public static NvgColor EColorToNvgColor(EColor c)
        {
            NvgColor result;
            result.R = c.r;
            result.G = c.g;
            result.B = c.b;
            result.A = c.a;
            return result;
        }

        public void FillColorCurrentRect(EColor color)
        {
            ERect RenderArea = renderRect.GetViewportRenderArea();

            /* Base background render */
            NanoVg.BeginPath(CSpriteRender.ctx);
            NanoVg.Rect(CSpriteRender.ctx,
                (float)RenderArea.x,
                (float)RenderArea.y,
                (float)RenderArea.width,
                (float)RenderArea.height);
            NanoVg.FillColor(CSpriteRender.ctx, EColorToNvgColor(color));
            NanoVg.Fill(CSpriteRender.ctx);
        }

        public void FillTextInRect(EColor color, float Size, string _string)
        {
            ERect RenderArea = renderRect.GetViewportRenderArea();

            if (RenderArea == null) MLoggerManager.Log("Render area is null");

            if (CSpriteRender.SystemFont == -1)
                NanoVg.CreateFont(CSpriteRender.ctx, "Roboto-Bold", File.ReadAllBytes(Path.Combine(EPath.GetResourcePath(), "Roboto-Bold.ttf")));
            else
                NanoVg.FontFace(CSpriteRender.ctx, "Roboto-Bold");
            NanoVg.TextAlign(CSpriteRender.ctx, NvgAlign.Left);
            NanoVg.FontSize(CSpriteRender.ctx, Size);
            NanoVg.FontBlur(CSpriteRender.ctx, 0.5f);
            NanoVg.Text(CSpriteRender.ctx, (float)RenderArea.x, (float)RenderArea.y, _string);
            NanoVg.Save(CSpriteRender.ctx);
        }
    }
}
