using Composite.Common;
using Composite.Content.Style;

namespace Composite.Content.Shapes
{
    public interface IShape : IDrawable
    {
        public Frame Frame { get; }
        public IBorderStyle BorderStyle { get; }
        public IStyle FillStyle { get; }
        public IGroup Group { get; }
    }
}
