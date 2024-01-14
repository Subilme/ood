using Paint.Adorners;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace Paint.Extensions
{
    public static class ShapeViewExtensions
    {
        public static void EnableSelectionAdorner(this Shape shape)
        {
            AdornerLayer.GetAdornerLayer(shape).Add(new ShapeSelectionAdorner(shape));
        }

        public static void DisableSelectionAdorner(this Shape shape)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(shape);
            var adorners = adornerLayer.GetAdorners(shape);
            adornerLayer.Remove(adorners.First(x => x is ShapeSelectionAdorner));
        }
    }
}
