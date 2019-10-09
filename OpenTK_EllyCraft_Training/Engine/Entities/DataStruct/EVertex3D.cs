using System;

namespace EllyCraft
{
    class EVertex3D
    {
        public double x;
        public double y;
        public double z;

        public EVertex3D()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
        }

        public EVertex3D(double v1, double v2)
        {
            x = v1;
            y = v2;
        }

        public EVertex3D(double v1, double v2, double v3)
        {
            x = v1;
            y = v2;
            z = v3;
        }

        public static EVertex3D Zero()
        {
            return new EVertex3D(0.0f, 0.0f, 0.0f);
        }

        public static double Distance(EVertex3D v1, EVertex3D v2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(v2.x - v1.x), 2) + Math.Pow(Math.Abs(v2.y - v1.y), 2) + Math.Pow(Math.Abs(v2.z - v1.z), 2));
        }

        public static EVertex3D operator +(EVertex3D v1, EVertex3D v2)
        {
            return new EVertex3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static EVertex3D operator -(EVertex3D v1, EVertex3D v2)
        {
            return new EVertex3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static EVertex3D operator *(EVertex3D v1, EVertex3D v2)
        {
            return new EVertex3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static EVertex3D operator /(EVertex3D v1, EVertex3D v2)
        {
            return new EVertex3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }
    }
}
