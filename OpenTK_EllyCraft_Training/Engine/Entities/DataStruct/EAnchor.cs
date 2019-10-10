namespace EllyCraft
{
    class EAnchor
    {
        public enum AnctorType
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

            VertStretchLeft,
            VertStretchRight,
            VertStretchCenter,

            HorStretchTop,
            HorStretchMiddle,
            HorStretchBottom,

            StretchAll
        }

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
        public AnctorType anctorType = AnctorType.Center;
        public PivotType pivotType = PivotType.Center;
    }
}
