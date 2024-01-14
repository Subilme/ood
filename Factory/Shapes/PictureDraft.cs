using Shapes.Shapes;

namespace Shapes
{
    public class PictureDraft
    {
        private List<Shape> _shapes;

        public PictureDraft()
        {
            _shapes = new List<Shape>();
        }

        public int GetShapesCount() => _shapes.Count;

        public Shape GetShape(int index)
        {
            if (index >= _shapes.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return _shapes[index];
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
    }
}
