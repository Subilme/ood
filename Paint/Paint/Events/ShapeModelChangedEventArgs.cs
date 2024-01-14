using Paint.Models;
using System;

namespace Paint.Events
{
    public class ShapeModelChangedEventArgs : EventArgs
    {
        public Shape Shape { get; }

        public ShapeModelChangedEventArgs(Shape shape)
        {
            Shape = shape;
        }
    }
}
