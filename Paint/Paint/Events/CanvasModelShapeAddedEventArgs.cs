using Paint.Models;

namespace Paint.Events
{
    public class CanvasModelShapeAddedEventArgs
    {
        public Shape Shape { get; }

        public CanvasModelShapeAddedEventArgs(Shape shape)
        {
            Shape = shape;
        }
    }
}
