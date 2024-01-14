using Shapes.Shapes;

namespace Shapes
{
    public interface IShapeFactory
    {
        public Shape CreateShape(string description);
    }
}
