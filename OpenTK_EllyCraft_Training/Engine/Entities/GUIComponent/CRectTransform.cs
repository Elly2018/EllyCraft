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

        public ERect GetViewportRenderArea()
        {
            ERect result = new ERect();
            if (anchor.anctorType == EAnchor.AnctorType.TopLeft || anchor.anctorType == EAnchor.AnctorType.Top || anchor.anctorType == EAnchor.AnctorType.TopRight ||
                anchor.anctorType == EAnchor.AnctorType.MiddleLeft || anchor.anctorType == EAnchor.AnctorType.Center || anchor.anctorType == EAnchor.AnctorType.MiddleRight ||
                anchor.anctorType == EAnchor.AnctorType.BottomLeft || anchor.anctorType == EAnchor.AnctorType.Bottom || anchor.anctorType == EAnchor.AnctorType.BottomRight)
                result = GetViewportRenderAreaAnchorAdjustment(anchor.anctorType, anchor.rect);

            result = GetViewportRenderAreaPivotAdjustment(anchor.pivotType, result);

            return result;
        }

        /// <summary>
        /// According to anchor pos, adjust the position of Rect
        /// This will only change the x, y of Rect structor
        /// </summary>
        /// <param name="anchorType">Anchor enum</param>
        /// <param name="rect">Target to adjust</param>
        /// <returns></returns>
        private ERect GetViewportRenderAreaAnchorAdjustment(EAnchor.AnctorType anchorType, ERect rect)
        {
            switch (anchorType)
            {
                case EAnchor.AnctorType.TopLeft:
                    return rect;
                case EAnchor.AnctorType.Top:
                    rect.x += MInputManager.GetWindowSize().x / 2;
                    return rect;
                case EAnchor.AnctorType.TopRight:
                    rect.x += MInputManager.GetWindowSize().x;
                    return rect;

                case EAnchor.AnctorType.MiddleLeft:
                    rect.y += MInputManager.GetWindowSize().y / 2;
                    return rect;
                case EAnchor.AnctorType.Center:
                    rect.x += MInputManager.GetWindowSize().x / 2;
                    rect.y += MInputManager.GetWindowSize().y / 2;
                    return rect;
                case EAnchor.AnctorType.MiddleRight:
                    rect.x += MInputManager.GetWindowSize().x;
                    rect.y += MInputManager.GetWindowSize().y / 2;
                    return rect;

                case EAnchor.AnctorType.BottomLeft:
                    rect.y += MInputManager.GetWindowSize().y;
                    return rect;
                case EAnchor.AnctorType.Bottom:
                    rect.x += MInputManager.GetWindowSize().x / 2;
                    rect.y += MInputManager.GetWindowSize().y;
                    return rect;
                case EAnchor.AnctorType.BottomRight:
                    rect.x += MInputManager.GetWindowSize().x;
                    rect.y += MInputManager.GetWindowSize().y;
                    return rect;
            }

            MLoggerManager.LogError("Failed to transfer 2D coordinate system : Anchor Adjustment");
            return rect;
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
                    break;
                case EAnchor.PivotType.Top:
                    break;
                case EAnchor.PivotType.TopRight:
                    break;
                case EAnchor.PivotType.MiddleLeft:
                    break;
                case EAnchor.PivotType.Center:
                    break;
                case EAnchor.PivotType.MiddleRight:
                    break;
                case EAnchor.PivotType.BottomLeft:
                    break;
                case EAnchor.PivotType.Bottom:
                    break;
                case EAnchor.PivotType.BottomRight:
                    break;
            }

            MLoggerManager.LogError("Failed to transfer 2D coordinate system : Pivot Adjustment");
            return rect;
        }
    }
}
