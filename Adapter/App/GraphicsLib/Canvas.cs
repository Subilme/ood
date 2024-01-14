namespace AdapterObjectApp.GraphicsLib
{
    public class Canvas : ICanvas
    {
        public void SetColor(uint color)
        {
            Console.WriteLine($"SetColor {Convert.ToString(color, 16).ToUpper()}");
        }

        public void LineTo(int x, int y)
        {
            Console.WriteLine($"LineTo ({x}, {y})");
        }

        public void MoveTo(int x, int y)
        {
            Console.WriteLine($"MoveTo ({x}, {y})");
        }

    }
}
