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
        public static bool Checkcollide(ERect v1, ERect v2)
        {
            return true;
        }
    }
}
