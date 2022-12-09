using Shapes.Canvas;

namespace Shapes.Shapes
{
    public class RegularPolygon : Shape
    {
        public List<Point> Vertexes { get; private init; }
        public int VertexCount { get; private init; }
        public Point Center { get; private init; }
        public int Radius { get; private init; }

        public RegularPolygon(int vertexCount, Point center, int radius, Color color)
            : base(color)
        {
            VertexCount = vertexCount;
            Center = center;
            Radius = radius;

            Vertexes = new List<Point>();
            var angle = 2 * Math.PI / VertexCount;
            for (int i = 0; i < VertexCount; i++)
            {
                Vertexes.Add(new Point(Center.X + Radius * Math.Cos(angle * i), Center.Y + Radius * Math.Sin(angle * i)));
            }
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);

            canvas.DrawLine(Vertexes[0], Vertexes[VertexCount - 1]);
            for (int i = 0; i < VertexCount - 1; i++)
            {
                canvas.DrawLine(Vertexes[i], Vertexes[i + 1]);
            }
        }
    }
}
