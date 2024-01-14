using Composite.App;
using Composite.Common;
using Composite.Content.Shapes;
using Composite.Content.Style;

namespace Composite.Content
{
    public class Group : IGroup
    {
        private List<IShape> _shapes;

        public Group()
        {
            _shapes = new List<IShape>();
        }

        public Frame Frame
        {
            get
            {
                if (!_shapes.Any())
                {
                    return null;
                }

                double maxX = double.MinValue;
                double maxY = double.MinValue;
                double minX = double.MaxValue;
                double minY = double.MaxValue;

                foreach (var shape in _shapes)
                {
                    var frame = shape.Frame;

                    maxX = Math.Max(maxX, frame.LeftTop.X + frame.Width);
                    minX = Math.Min(minX, frame.LeftTop.X);
                    maxY = Math.Max(maxY, frame.LeftTop.Y + frame.Height);
                    minY = Math.Min(minY, frame.LeftTop.Y);
                }

                return new Frame
                {
                    LeftTop = new Point(minX, minY),
                    Width = maxX - minX,
                    Height = maxY - minY
                };
            }
            set
            {
                foreach (var shape in _shapes)
                {
                    var leftTopX = value.LeftTop.X + (shape.Frame.LeftTop.X - Frame.LeftTop.X);
                    var leftTopY = value.LeftTop.Y + (shape.Frame.LeftTop.Y - Frame.LeftTop.Y);
                    var width = shape.Frame.Width * (value.Width / Frame.Width);
                    var height = shape.Frame.Height * (value.Height / Frame.Height);

                    shape.Frame = new Frame
                    {
                        LeftTop = new Point(leftTopX, leftTopY),
                        Width = width,
                        Height = height
                    };
                }
            }
        }
        public IBorderStyle BorderStyle { get; }
        public IStyle FillStyle { get; }

        public IShape GetShape(int index)
        {
            return _shapes[index];
        }

        public int GetShapesCount()
        {
            return _shapes.Count;
        }

        public void InsertShape(int index, IShape shape)
        {
            if (index < 0 || index > GetShapesCount())
            {
                throw new IndexOutOfRangeException("Wrong Index");
            }

            _shapes.Insert(index, shape);
        }

        public void RemoveShape(int index)
        {
            if (index < 0 || index > GetShapesCount())
            {
                throw new IndexOutOfRangeException("Wrond Index");
            }

            _shapes.RemoveAt(index);
        }

        public void Draw(ICanvas canvas)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(canvas);
            }
        }
    }
}
