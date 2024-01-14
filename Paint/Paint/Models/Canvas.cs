using Paint.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paint.Models
{
    public class Canvas
    {
        private readonly List<Shape> _shapes = new();
        public IReadOnlyList<Shape> Shapes => _shapes;

        public event EventHandler<CanvasModelShapeAddedEventArgs>? ShapeAdded;
        public event EventHandler<CanvasModelShapeRemovedEventArgs>? ShapeRemoved;

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
            ShapeAdded?.Invoke(this, new CanvasModelShapeAddedEventArgs(shape));
        }

        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
            ShapeRemoved?.Invoke(this, new CanvasModelShapeRemovedEventArgs(shape.Uid));
        }

        public Shape? GetShapeByUid(string uid)
        {
            return _shapes.Find(x => x.Uid == uid);
        }
    }
}
