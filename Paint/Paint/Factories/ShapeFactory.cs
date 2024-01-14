using Paint.Enums;
using Paint.Models;
using System.ComponentModel;

namespace Paint.Factories
{
    public class ShapeFactory : IShapeFactory
    {
        public Shape CreateShape(ShapeType shapeType, Frame frame)
        {
            return shapeType switch
            {
                ShapeType.Ellipse => new Ellipse(frame),
                ShapeType.Rectangle => new Rectangle(frame),
                ShapeType.Triangle => new Triangle(frame),
                _ => throw new InvalidEnumArgumentException("Unknown shape type"),
            };
        }
    }
}
