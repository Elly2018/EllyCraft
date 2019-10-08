namespace EllyCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game g = new Game(800, 600, "EllyCraft"))
            {
                g.Run();
            }
        }
    }
}
