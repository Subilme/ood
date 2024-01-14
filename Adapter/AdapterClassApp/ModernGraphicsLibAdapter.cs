using AdapterClassApp.GraphicsLib;
using AdapterClassApp.ModernGraphicsLib;

namespace AdapterClassApp
{
    public class ModernGraphicsLibAdapter : ModernGraphicsRenderer, ICanvas
    {
        private Point _currPoint;

        public ModernGraphicsLibAdapter()
            : base()
        {
            _currPoint = new Point(0, 0);
        }

        public void LineTo(int x, int y)
        {
            Point point = new Point(x, y);
            DrawLine(_currPoint, point);
            _currPoint = point;
        }

        public void MoveTo(int x, int y)
        {
            _currPoint = new Point(x, y);
        }
    }
}
