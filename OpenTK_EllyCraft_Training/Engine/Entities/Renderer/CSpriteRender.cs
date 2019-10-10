using EllyCraft.Base;
using NanoVGDotNet.NanoVG;

namespace EllyCraft.GUI
{
    class CSpriteRender : RendererBase, _2DRenderer
    {
        public static NvgContext ctx;
        public static EGUIStyle style;

        public void Render(CRectTransform t)
        {
            
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
    }
}
