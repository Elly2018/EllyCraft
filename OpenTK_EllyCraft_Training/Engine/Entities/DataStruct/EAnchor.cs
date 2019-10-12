namespace EllyCraft
{
    class EAnchor
    {
        public enum PivotType
        {
            TopLeft,
            Top,
            TopRight,

            MiddleLeft,
            Center,
            MiddleRight,

            BottomLeft,
            Bottom,
            BottomRight,
        }

        public ERect rect = new ERect();
        public PivotType pivotType = PivotType.Center;
    }
}
