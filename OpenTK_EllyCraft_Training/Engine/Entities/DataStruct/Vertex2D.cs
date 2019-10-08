using System;

namespace EllyCraft
{
    public class Vertex2D
    {
        public double x;
        public double y;

        public Vertex2D()
        {
            x = 0.0;
            y = 0.0;
        }

        public Vertex2D(double v1, double v2)
        {
            x = v1;
            y = v2;
        }

        public static Vertex2D Zero()
        {
            return new Vertex2D(0.0f, 0.0f);
        }

        public static double Distance(Vertex2D v1, Vertex2D v2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(v2.x - v1.x), 2) + Math.Pow(Math.Abs(v2.y - v1.y), 2));
        }

        public static Vertex2D operator +(Vertex2D v1, Vertex2D v2)
        {
            return new Vertex2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vertex2D operator -(Vertex2D v1, Vertex2D v2)
        {
            return new Vertex2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vertex2D operator *(Vertex2D v1, Vertex2D v2)
        {
            return new Vertex2D(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vertex2D operator /(Vertex2D v1, Vertex2D v2)
        {
            return new Vertex2D(v1.x / v2.x, v1.y / v2.y);
        }
    }
}
