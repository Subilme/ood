using Composite.Common;

namespace Composite.App
{
    public interface ICanvas
    {
        public void DrawLine(Point from, Point to, uint color, double thickness);
        public void FillPolygon(List<Point> points, uint color);
        public void DrawEllipse(Point center, double widthRadius, double heightRadius, uint color, double thickness);
        public void FillEllipse(Point center, double widthRadius, double heightRadius, uint color);
    }
}
