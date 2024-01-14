using Composite.Content.Shapes;

namespace Composite.Content
{
    public interface IGroup : IShape
    {
        public int GetShapesCount();
        public IShape GetShape(int index);
        public void InsertShape(int index, IShape shape);
        public void RemoveShape(int index);
    }
}
