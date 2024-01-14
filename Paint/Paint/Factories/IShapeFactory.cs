using Paint.Enums;
using Paint.Models;

namespace Paint.Factories
{
    public interface IShapeFactory
    {
        public Shape CreateShape(ShapeType shapeType, Frame frame);
    }
}
