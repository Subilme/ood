using Composite.Content.Shapes;

namespace Composite.App
{
    public interface ISlide
    {
        public double Width { get; }
        public double Height { get; }

        public int GetShapesCount();
        public IShape GetShape(int index);
        public void InsertShape(int index, IShape shape);
        public void RemoveShape(int index);
        public void Draw(ICanvas canvas);
    }
}
