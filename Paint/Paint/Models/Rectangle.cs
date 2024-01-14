using Paint.Enums;

namespace Paint.Models
{
    public class Rectangle : Shape
    {
        public Rectangle(Frame frame)
            : base(ShapeType.Rectangle, frame)
        {
        }
    }
}
