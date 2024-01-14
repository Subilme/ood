using Paint.Events;
using System;
using System.Windows.Shapes;

namespace Paint.Views
{
    public interface IShapeView
    {
        public string Uid { get; }
        public Frame Frame { get; set; }

        public void SetFocus();
        public void UnsetFocus();

        public event EventHandler<ShapeViewEventArgs>? ShapeMouseDown;
        public event EventHandler<ShapeViewEventArgs>? ShapeMouseUp;
    }
}
