using Paint.Events;
using System;
using System.Windows.Shapes;

namespace Paint.Views
{
    public interface ICanvasView
    {
        public void AddShape(Paint.Models.Shape shape);
        public void RemoveShapeByUid(string uid);
        public Shape? GetShapeByUid(string uid);

        public event EventHandler<CanvasViewShapeAddedEventArgs> ShapeAdded;
        public event EventHandler<CanvasViewEventArgs> CanvasMouseDown;
        public event EventHandler<CanvasViewEventArgs> CanvasKeyPressed;
        public event EventHandler DeleteButtonPressed;
    }
}
