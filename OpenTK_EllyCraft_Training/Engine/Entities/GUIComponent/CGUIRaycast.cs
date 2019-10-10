using OpenTK.Input;

namespace EllyCraft.GUI
{
    class CGUIRaycast : ESceneComponent
    {
        private float MouseRectSize = 5;
        private CRectTransform cRect;

        private bool Enter;

        public override void Awake()
        {
            base.Awake();
            cRect = sceneObject.GetComponent<CRectTransform>(true);
        }

        public virtual bool MouseEnter()
        {
            ERect RenderArea = cRect.GetViewportRenderArea();
            if (!Enter)
            {
                if (ERect.Checkcollide(RenderArea, GetMouseRect()))
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
                if (!ERect.Checkcollide(RenderArea, GetMouseRect()))
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

        private ERect GetMouseRect()
        {
            EIVertex2D pos = MInputManager.GetWindowMousePos();
            return new ERect(pos.x - MouseRectSize / 2,
                pos.y - MouseRectSize / 2,
                pos.x + MouseRectSize / 2,
                pos.y + MouseRectSize / 2);
        }
    }
}
