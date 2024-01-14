using System;
using System.Windows.Shapes;

namespace Paint.Events
{
    public class ShapeViewEventArgs : EventArgs
    {
        public Shape Shape { get; }

        public ShapeViewEventArgs(Shape shape)
        {
            Shape = shape;
        }
    }
}
