using System;

namespace EllyCraft
{
    public class EVertex2D
    {
        public double x;
        public double y;

        public EVertex2D()
        {
            x = 0.0;
            y = 0.0;
        }
        public EVertex2D(double v1, double v2)
        {
            x = v1;
            y = v2;
        }
        public EVertex2D(EIVertex2D v1)
        {
            x = (double)v1.x;
            y = (double)v1.y;
        }

        public static EVertex2D Zero()
        {
            return new EVertex2D(0.0f, 0.0f);
        }

        public static double Distance(EVertex2D v1, EVertex2D v2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(v2.x - v1.x), 2) + Math.Pow(Math.Abs(v2.y - v1.y), 2));
        }

        public static EVertex2D operator +(EVertex2D v1, EVertex2D v2)
        {
            return new EVertex2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static EVertex2D operator -(EVertex2D v1, EVertex2D v2)
        {
            return new EVertex2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static EVertex2D operator *(EVertex2D v1, EVertex2D v2)
        {
            return new EVertex2D(v1.x * v2.x, v1.y * v2.y);
        }

        public static EVertex2D operator /(EVertex2D v1, EVertex2D v2)
        {
            return new EVertex2D(v1.x / v2.x, v1.y / v2.y);
        }
    }
}
