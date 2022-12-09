using Shapes.Canvas;

namespace Shapes.Shapes
{
    public abstract class Shape
    {
        public Color Color { get; private init; }

        public Shape(Color color)
        {
            Color = color;
        }

        public abstract void Draw(ICanvas canvas);
    }
}
