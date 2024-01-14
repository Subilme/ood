using GraphicsLib;

namespace ShapeDrawingLib
{
    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private Point _rightBottom;
        private uint _color;

        public Rectangle(Point leftTop, Point rightBottom, uint color = 0)
        {
            _leftTop = leftTop;
            _rightBottom = rightBottom;
            _color = color;
        }

        public void Draw(ICanvas canvas)
        {
            canvas.SetColor(_color);
            canvas.MoveTo(_leftTop.X, _leftTop.Y);
            
            canvas.LineTo(_rightBottom.X, _leftTop.Y);
            canvas.LineTo(_rightBottom.X, _rightBottom.Y);
            canvas.LineTo(_leftTop.X, _rightBottom.Y);
            canvas.LineTo(_leftTop.X, _leftTop.Y);
        }
    }
}
