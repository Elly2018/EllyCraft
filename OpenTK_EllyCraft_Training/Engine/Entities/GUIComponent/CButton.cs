using NanoVGDotNet.NanoVG;
using OpenTK.Input;

namespace EllyCraft.GUI
{
    class CButton : CSpriteRender
    {
        public enum ButtonState
        {
            None, HightLight, Press
        }

        public EColor ButtonColor;
        public EColor ButtonPressColor;
        public EColor ButtonHightLightColor;

        private CRectTransform rect;
        private CGUIRaycast raycast;
        private ButtonState buttonState = ButtonState.None;

        public override void Awake()
        {
            base.Awake();
            rect = sceneObject.GetComponent<CRectTransform>(true);
            raycast = sceneObject.GetComponent<CGUIRaycast>(true);
        }

        public override void Update()
        {
            base.Update();
            if (raycast.MouseMove() && raycast.MouseEnter() && !raycast.MouseDown(MouseButton.Left)) buttonState = ButtonState.HightLight;
            if (raycast.MouseMove() && raycast.MouseDown(MouseButton.Left)) buttonState = ButtonState.Press;
            if (!raycast.MouseMove()) buttonState = ButtonState.None;
        }

        public override void RenderGUI()
        {
            base.RenderGUI();
            ERect RenderArea = rect.GetViewportRenderArea();

            /* Base background render */
            NanoVg.BeginPath(CSpriteRender.ctx);
            NanoVg.Rect(CSpriteRender.ctx,
                (float)RenderArea.x,
                (float)RenderArea.y,
                (float)RenderArea.width,
                (float)RenderArea.height);
            switch (buttonState)
            {
                case ButtonState.None:
                    NanoVg.FillColor(CSpriteRender.ctx, EColorToNvgColor(ButtonColor));
                    break;
                case ButtonState.HightLight:
                    NanoVg.FillColor(CSpriteRender.ctx, EColorToNvgColor(ButtonHightLightColor));
                    break;
                case ButtonState.Press:
                    NanoVg.FillColor(CSpriteRender.ctx, EColorToNvgColor(ButtonPressColor));
                    break;
            }
            NanoVg.Fill(CSpriteRender.ctx);
        }


    }
}
