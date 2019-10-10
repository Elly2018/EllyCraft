namespace EllyCraft
{
    class EColor
    {
        public float r, g, b, a;

        public EColor()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
            this.a = 1;
        }
        public EColor(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1;
        }
        public EColor(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}
