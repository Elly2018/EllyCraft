namespace EllyCraft
{
    public class EIVertex2D
    {
        public int x, y;

        public EIVertex2D()
        {
            x = 0;
            y = 0;
        }
        public EIVertex2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static EIVertex2D Zero()
        {
            return new EIVertex2D(0, 0);
        }

        public static double Distance(EIVertex2D v1, EIVertex2D v2)
        {
            return EVertex2D.Distance(new EVertex2D(v1), new EVertex2D(v2));
        }

        public static EIVertex2D operator +(EIVertex2D v1, EIVertex2D v2)
        {
            return new EIVertex2D(v1.x + v2.x, v1.y + v2.y);
        }
        public static EIVertex2D operator -(EIVertex2D v1, EIVertex2D v2)
        {
            return new EIVertex2D(v1.x - v2.x, v1.y - v2.y);
        }
        public static EIVertex2D operator *(EIVertex2D v1, EIVertex2D v2)
        {
            return new EIVertex2D(v1.x * v2.x, v1.y * v2.y);
        }
        public static EIVertex2D operator /(EIVertex2D v1, EIVertex2D v2)
        {
            return new EIVertex2D(v1.x / v2.x, v1.y / v2.y);
        }
    }
}
