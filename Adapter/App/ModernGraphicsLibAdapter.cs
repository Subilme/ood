using AdapterObjectApp.GraphicsLib;
using AdapterObjectApp.ModernGraphicsLib;

namespace AdapterObjectApp
{
    public class ModernGraphicsLibAdapter : ICanvas
    {
        private ModernGraphicsRenderer _renderer;
        private RGBAColor _color;
        private Point _currPoint;

        public ModernGraphicsLibAdapter(ModernGraphicsRenderer renderer)
        {
            _renderer = renderer;
            _color = new RGBAColor(0, 0, 0, 0);
            _currPoint = new Point(0, 0);
        }

        public void LineTo(int x, int y)
        {
            Point point = new Point(x, y);
            _renderer.DrawLine(_currPoint, point, _color);
            _currPoint = point;
        }

        public void MoveTo(int x, int y)
        {
            _currPoint = new Point(x, y);
        }

        public void SetColor(uint color)
        {
            // TODO: Побитовые операции
            var red = (color >> 16) & 0xFF;
            var green = (color >> 8) & 0xFF;
            var blue = color & 0xFF;

            _color = new RGBAColor(red, green, blue, 1);
        }
    }
}
