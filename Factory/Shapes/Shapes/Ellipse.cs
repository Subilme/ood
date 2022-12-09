using Shapes.Canvas;

namespace Shapes.Shapes
{
    public class Ellipse : Shape
    {
        public Point Center { get; private init; }
        public int HorizontalRadius { get; private init; }
        public int VerticalRadius { get; private init; }

        public Ellipse(Point center, int horizontalRadius, int verticalRadius, Color color)
            : base(color)
        {
            Center = center;
            HorizontalRadius = horizontalRadius;
            VerticalRadius = verticalRadius;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);

            canvas.DrawEllipse(Center, HorizontalRadius, VerticalRadius);
        }
    }
}
