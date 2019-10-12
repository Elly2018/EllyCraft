namespace EllyCraft.GUI
{
    class CRectTransform : ESceneComponent
    {
        public EAnchor anchor = new EAnchor();

        private CRectTransform parentRect;

        public override void Awake()
        {
            base.Awake();
            if(sceneObject.Parent != null)
                parentRect = sceneObject.Parent.GetComponent<CRectTransform>(true);
        }

        public ERect GetParentViewportRenderArea()
        {
            if (parentRect == null)
                return new ERect(0, 0, MInputManager.GetWindowSize().x, MInputManager.GetWindowSize().y);
            return parentRect.GetViewportRenderArea();
        }

        public ERect GetViewportRenderArea()
        {
            return GetViewportRenderAreaPivotAdjustment(anchor.pivotType, anchor.rect);
        }
        /// <summary>
        /// According to pivot type, adjust the size of Rect
        /// This will only change the width, height of Rect structor
        /// </summary>
        /// <param name="pivotType">Pivot enum</param>
        /// <param name="rect">Target to adjust</param>
        /// <returns></returns>
        private ERect GetViewportRenderAreaPivotAdjustment(EAnchor.PivotType pivotType, ERect rect)
        {
            switch (pivotType)
            {
                case EAnchor.PivotType.TopLeft:
                    return rect;
                case EAnchor.PivotType.Top:
                    rect.x -= rect.width / 2;
                    return rect;
                case EAnchor.PivotType.TopRight:
                    rect.x -= rect.width;
                    return rect;
                case EAnchor.PivotType.MiddleLeft:
                    rect.y -= rect.height / 2;
                    return rect;
                case EAnchor.PivotType.Center:
                    rect.x -= rect.width / 2;
                    rect.y -= rect.height / 2;
                    return rect;
                case EAnchor.PivotType.MiddleRight:
                    rect.x -= rect.width;
                    rect.y -= rect.height / 2;
                    return rect;
                case EAnchor.PivotType.BottomLeft:
                    rect.y -= rect.height;
                    return rect;
                case EAnchor.PivotType.Bottom:
                    rect.x -= rect.width / 2;
                    rect.y -= rect.height;
                    return rect;
                case EAnchor.PivotType.BottomRight:
                    rect.x -= rect.width;
                    rect.y -= rect.height;
                    return rect;
            }

            MLoggerManager.LogError("Failed to transfer 2D coordinate system : Pivot Adjustment");
            return rect;
        }

        private ERect ApplyParentRectToLocalRect(ERect rect)
        {
            rect.x += anchor.rect.x;
            rect.y += anchor.rect.y;
            rect.width = anchor.rect.width;
            rect.height = anchor.rect.height;
            return rect;
        }
    }
}
