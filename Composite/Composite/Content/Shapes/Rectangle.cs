using Composite.App;
using Composite.Common;

namespace Composite.Content.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(Point point, double width, double height)
        {
            Frame = new Frame
            {
                LeftTop = point,
                Width = width,
                Height = height
            };
        }

        public override void Draw(ICanvas canvas)
        {
            List<Point> points = new List<Point>
            {
                Frame.LeftTop,
                new Point(Frame.LeftTop.X + Frame.Width, Frame.LeftTop.Y),
                new Point(Frame.LeftTop.X + Frame.Width, Frame.LeftTop.Y + Frame.Height),
                new Point(Frame.LeftTop.X, Frame.LeftTop.Y + Frame.Height)
            };

            if (BorderStyle != null)
            {
                canvas.DrawLine(points[0], points[1], BorderStyle.Color, BorderStyle.Thickness);
                canvas.DrawLine(points[1], points[2], BorderStyle.Color, BorderStyle.Thickness);
                canvas.DrawLine(points[2], points[3], BorderStyle.Color, BorderStyle.Thickness);
                canvas.DrawLine(points[3], points[0], BorderStyle.Color, BorderStyle.Thickness);
            }

            if (FillStyle != null)
            {
                canvas.FillPolygon(points, FillStyle.Color);
            }
        }
    }
}
