using AdapterClassApp.GraphicsLib;

namespace AdapterClassApp.ShapeDrawingLib
{
    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private Point _rightBottom;

        public Rectangle(Point leftTop, Point rightBottom)
        {
            _leftTop = leftTop;
            _rightBottom = rightBottom;
        }

        public void Draw(ICanvas canvas)
        {
            canvas.MoveTo(_leftTop.X, _leftTop.Y);

            canvas.LineTo(_rightBottom.X, _leftTop.Y);
            canvas.LineTo(_rightBottom.X, _rightBottom.Y);
            canvas.LineTo(_leftTop.X, _rightBottom.Y);
            canvas.LineTo(_leftTop.X, _leftTop.Y);
        }
    }
}
