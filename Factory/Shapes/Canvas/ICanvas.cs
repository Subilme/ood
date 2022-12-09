namespace Shapes.Canvas
{
    public interface ICanvas
    {
        public void SetColor(Color color);
        public void DrawLine(Point from, Point to);
        public void DrawEllipse(Point center, int horizontalRadius, int verticalRadius);
    }
}
