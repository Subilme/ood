using Composite.Content.Shapes;

namespace Composite.App
{
    public class Slide : ISlide
    {
        private List<IShape> _shapes;

        public double Width { get; private init; }
        public double Height { get; private init; }

        public Slide(double width, double height)
        {
            _shapes = new List<IShape>();
            Width = width;
            Height = height;
        }

        public int GetShapesCount()
        {
            return _shapes.Count;
        }

        public IShape GetShape(int index)
        {
            if (index > GetShapesCount())
            {
                throw new IndexOutOfRangeException();
            }

            return _shapes[index];
        }

        public void InsertShape(int index, IShape shape)
        {
            if (index > GetShapesCount())
            {
                throw new IndexOutOfRangeException();
            }

            _shapes.Insert(index, shape);
        }

        public void RemoveShape(int index)
        {
            if (index > GetShapesCount())
            {
                throw new IndexOutOfRangeException();
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
