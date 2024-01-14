using Paint.Enums;
using System;
using System.Windows.Controls;

namespace Paint.Events
{
    public class CanvasViewShapeAddedEventArgs : EventArgs
    {
        public Canvas Canvas { get; }
        public ShapeType ShapeType { get; }

        public CanvasViewShapeAddedEventArgs(Canvas canvas, ShapeType shapeType)
        {
            Canvas = canvas;
            ShapeType = shapeType;
        }
    }
}
