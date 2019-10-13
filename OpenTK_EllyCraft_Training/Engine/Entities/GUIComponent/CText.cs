using NanoVGDotNet.FontStash;
using NanoVGDotNet.NanoVG;

namespace EllyCraft.GUI
{
    [RequireComponent(typeof(CSpriteRender))]
    class CText : CSpriteRender
    {
        public string text = "";
        public EColor color = new EColor();
        public bool FitParentRect = true;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Update()
        {
            base.Update();
            if (FitParentRect)
            {
                renderRect.anchor.rect = new ERect(sceneObject.Parent.GetComponent<CRectTransform>(true).anchor.rect);
                ELogger.Log(renderRect.anchor.rect);
            }
        }

        public override void RenderGUI()
        {
            base.RenderGUI();
            FillTextInRect(new EColor(1, 1, 1, 1), 12, text);
        }
    }
}
