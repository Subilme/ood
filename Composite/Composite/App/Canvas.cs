using Composite.Common;

namespace Composite.App
{
    public class Canvas : ICanvas
    {
        public void DrawEllipse(Point center, double widthRadius, double heightRadius, uint color, double thickness)
        {
            Console.WriteLine($"DrawEllipse: center ({center.X}, {center.Y}), widthRadius {widthRadius}, " +
                $"heightRadius {heightRadius}, color: {Convert.ToString(color, 16)}, " +
                $"thickness {Math.Round(thickness, MidpointRounding.AwayFromZero)}");
        }

        public void DrawLine(Point from, Point to, uint color, double thickness)
        {
            Console.WriteLine($"DrawLine: from ({from.X}, {from.Y}) to ({to.X}, {to.Y}), " +
                $"color: {Convert.ToString(color, 16)}, " +
                $"thickness {Math.Round(thickness, MidpointRounding.AwayFromZero)}");
        }

        public void FillEllipse(Point center, double widthRadius, double heightRadius, uint color)
        {
            Console.WriteLine($"DrawEllipse: center ({center.X}, {center.Y}), widthRadius {widthRadius}, " +
                $"heightRadius {heightRadius}, color: {Convert.ToString(color, 16)}");
        }

        public void FillPolygon(List<Point> points, uint color)
        {
            Console.WriteLine($"FillPolygon: color {Convert.ToString(color, 16)}");
        }
    }
}
