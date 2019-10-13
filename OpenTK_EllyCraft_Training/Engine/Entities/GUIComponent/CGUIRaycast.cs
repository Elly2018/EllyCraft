using OpenTK.Input;

namespace EllyCraft.GUI
{
    class CGUIRaycast : ESceneComponent
    {
        public const float MouseRectSize = 0;

        private bool Enter;
        private CRectTransform cRect;

        public override void Awake()
        {
            base.Awake();
            cRect = sceneObject.GetComponent<CRectTransform>(true);
        }

        public override void Update()
        {
            base.Update();
            MouseEnter();
            MouseExit();
            MouseMove();
        }

        public virtual bool MouseEnter()
        {
            ERect RenderArea = cRect.GetViewportRenderArea();
            if (!Enter)
            {
                if (ERect.CheckCollide(RenderArea, GetMouseRect()))
                {
                    Enter = true;
                    return true;
                }
            }
            return false;
        }
        public virtual bool MouseExit()
        {
            ERect RenderArea = cRect.GetViewportRenderArea();
            if (Enter)
            {
                if (!ERect.CheckCollide(RenderArea, GetMouseRect()))
                {
                    Enter = false;
                    return true;
                }
            }
            return false;
        }
        public virtual bool MouseMove()
        {
            return Enter;
        }
        public virtual bool MouseDown(MouseButton button)
        {
            if (!Enter) return false;
            return MInputManager.mouseState.IsButtonDown(button);
        }
        public virtual bool MouseUp(MouseButton button)
        {
            if (!Enter) return false;
            return MInputManager.mouseState.IsButtonUp(button);
        }

        private static ERect GetMouseRect()
        {
            EIVertex2D pos = MInputManager.GetWindowMousePos();
            return new ERect(pos.x - MouseRectSize / 2,
                pos.y - MouseRectSize / 2 - 25,
                MouseRectSize,
                MouseRectSize);
        }

        public static void RenderMouseRect()
        {
            NanoVGDotNet.NanoVG.NvgColor c = new NanoVGDotNet.NanoVG.NvgColor();
            c.A = 1;
            c.B = 1;
            c.G = 0;
            c.R = 0;
            NanoVGDotNet.NanoVG.NanoVg.BeginPath(CSpriteRender.ctx);
            NanoVGDotNet.NanoVG.NanoVg.FillColor(CSpriteRender.ctx, c);
            NanoVGDotNet.NanoVG.NanoVg.Rect(CSpriteRender.ctx, (float)GetMouseRect().x, (float)GetMouseRect().y, (float)GetMouseRect().width, (float)GetMouseRect().height);
            NanoVGDotNet.NanoVG.NanoVg.Fill(CSpriteRender.ctx);
        }
    }
}
