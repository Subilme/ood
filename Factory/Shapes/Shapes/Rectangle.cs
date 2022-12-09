using Shapes.Canvas;

namespace Shapes.Shapes
{
    public class Rectangle : Shape
    {
        public Point LeftTop { get; private init; }
        public Point RightBottom { get; private init; }

        public Rectangle(Point leftTop, Point rightBottom, Color color)
            : base(color)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }

        public override void Draw(ICanvas canvas)
        {
            Point rightTop = new Point(RightBottom.X, LeftTop.Y);
            Point leftBottom = new Point(LeftTop.X, RightBottom.Y);

            canvas.SetColor(Color);

            canvas.DrawLine(LeftTop, rightTop);
            canvas.DrawLine(rightTop, RightBottom);
            canvas.DrawLine(RightBottom, leftBottom);
            canvas.DrawLine(leftBottom, LeftTop);
        }
    }
}
