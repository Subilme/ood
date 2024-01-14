using Paint.Enums;

namespace Paint.Models
{
    public class Triangle : Shape
    {
        public Triangle(Frame frame)
            : base(ShapeType.Triangle, frame)
        {
        }
    }
}
