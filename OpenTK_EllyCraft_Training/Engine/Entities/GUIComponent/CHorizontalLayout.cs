namespace EllyCraft.GUI
{
    class CHorizontalLayout : ESceneComponent
    {
        public ERect ElementMargin = new ERect();
        public ERect ElementArea = new ERect();
        public EAnchor.PivotType PivotType = EAnchor.PivotType.Center;
        public bool FileBar;

        private CRectTransform cRect;

        public override void Awake()
        {
            base.Awake();
            cRect = sceneObject.GetComponent<CRectTransform>(true);
        }

        public override void Update()
        {
            base.Update();
            
            ERect RenderArea = cRect.GetParentViewportRenderArea();
            ESceneObject[] eo = sceneObject.GetAllChild();

            for(int i = 0; i < eo.Length; i++)
            {
                CRectTransform localRect = eo[i].GetComponent<CRectTransform>(true);
                if(localRect != null)
                {
                    localRect.anchor.pivotType = EAnchor.PivotType.TopLeft;
                    localRect.anchor.rect = new ERect(
                        (ElementMargin.Left + RenderArea.x) + (i * (ElementMargin.Left + ElementMargin.Right + ElementArea.width)),
                        (ElementMargin.Top + RenderArea.y),
                        ElementArea.width,
                        ElementArea.height
                        );
                }
            }
        }
    }
}
