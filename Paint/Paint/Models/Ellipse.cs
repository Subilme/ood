using Paint.Enums;

namespace Paint.Models
{
    public class Ellipse : Shape
    {
        public Ellipse(Frame frame)
            : base(ShapeType.Ellipse, frame)
        {
        }
    }
}
