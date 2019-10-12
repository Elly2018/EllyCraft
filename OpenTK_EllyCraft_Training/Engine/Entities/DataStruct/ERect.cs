using System;

namespace EllyCraft
{
    class ERect
    {
        public double x, y, width, height, Left, Right, Top, Bottom;

        public ERect()
        {
            this.x = 0;
            this.y = 0;
            this.width = 100;
            this.height = 100;
        }
        public ERect(ERect rect)
        {
            this.x = rect.x;
            this.y = rect.y;
            this.width = rect.width;
            this.height = rect.height;
        }
        public ERect(double width, double height)
        {
            this.x = 0;
            this.y = 0;
            this.width = width;
            this.height = height;
        }
        public ERect(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public static ERect operator +(ERect v1, ERect v2)
        {
            return new ERect(v1.x + v2.x, v1.y + v2.y, v1.width + v2.width, v1.height + v2.height);
        }
        public static ERect operator -(ERect v1, ERect v2)
        {
            return new ERect(v1.x - v2.x, v1.y - v2.y, v1.width * v2.width, v1.height * v2.height);
        }
        public static ERect operator *(ERect v1, ERect v2)
        {
            return new ERect(v1.x * v2.x, v1.y * v2.y, v1.width * v2.width, v1.height * v2.height);
        }
        public static ERect operator /(ERect v1, ERect v2)
        {
            return new ERect(v1.x / v2.x, v1.y / v2.y, v1.width / v2.width, v1.height / v2.height);
        }
        public static bool CheckCollide(ERect v1, ERect v2)
        {
            EVertex2D[] points = GetRectCornerPoint(v2);
            foreach (EVertex2D v in points)
            {
                if (Check2DPointCollide(v1, v)) return true;
            }
            return false;
        }
        public static bool Check2DPointCollide(ERect v1, EVertex2D point)
        {
            EVertex2D[] points = GetRectCornerPoint(v1);
            double area = v1.width * v1.height * 1.7;
            double[] Trianglearea = new double[]
            {
                GetTriangleArea(points[0], points[1], point),
                GetTriangleArea(points[1], points[2], point),
                GetTriangleArea(points[2], points[3], point),
                GetTriangleArea(points[3], points[0], point)
            };
            double TriangleAreaSum = Trianglearea[0] + Trianglearea[1] + Trianglearea[2] + Trianglearea[3];
            return !(area < TriangleAreaSum);
        }
        public static EVertex2D[] GetRectCornerPoint(ERect v)
        {
            EVertex2D[] points =
                new EVertex2D[4] { new EVertex2D(v.x, v.y),
                new EVertex2D(v.x + v.width, v.y),
                new EVertex2D(v.x + v.width, v.y + v.height),
                new EVertex2D(v.x , v.y + v.height)};
            return points;
        }
        public static double GetTriangleArea(EVertex2D v1, EVertex2D v2, EVertex2D v3)
        {
            double a = EVertex2D.Distance(v1, v2);
            double b = EVertex2D.Distance(v2, v3);
            double c = EVertex2D.Distance(v3, v1);
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public override string ToString()
        {
            return x + " " + y + " " + width + " " + height;
        }
    }
}
