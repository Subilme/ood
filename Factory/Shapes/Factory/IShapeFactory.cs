using Shapes.Shapes;

namespace Shapes.Factory
{
    public interface IShapeFactory
    {
        public Shape CreateShape(string description);
    }
}
