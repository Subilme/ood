namespace Shapes.Canvas
{
    public class Canvas : ICanvas
    {
        public List<string> Commands { get; private set; }

        public Canvas()
        {
            Commands = new List<string>();
        }

        public void DrawEllipse(Point center, int horizontalRadius, int verticalRadius)
        {
            Commands.Add("Draw Ellipse");
        }

        public void DrawLine(Point from, Point to)
        {
            Commands.Add("Draw Line");
        }

        public void SetColor(Color color)
        {
            Commands.Add("Set Color");
        }
    }
}
