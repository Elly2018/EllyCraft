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

        private CGUIRaycast raycast;
        private ButtonState buttonState = ButtonState.None;

        public override void Awake()
        {
            base.Awake();
            raycast = sceneObject.GetComponent<CGUIRaycast>(true);
        }

        public override void Update()
        {
            base.Update();
            if (raycast.MouseMove() && raycast.MouseUp(MouseButton.Left)) buttonState = ButtonState.HightLight;
            else if (raycast.MouseMove() && raycast.MouseDown(MouseButton.Left)) buttonState = ButtonState.Press;
            else if (!raycast.MouseMove()) buttonState = ButtonState.None;
        }

        public override void RenderGUI()
        {
            base.RenderGUI();

            switch (buttonState)
            {
                case ButtonState.None:
                    FillColorCurrentRect(ButtonColor);
                    break;
                case ButtonState.HightLight:
                    FillColorCurrentRect(ButtonHightLightColor);
                    break;
                case ButtonState.Press:
                    FillColorCurrentRect(ButtonPressColor);
                    break;
            }
        }
    }
}
