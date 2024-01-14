using Composite.App;
using Composite.Common;

namespace Composite.Content.Shapes
{
    public class Ellipse : Shape
    {
        private Point _center;
        private double _widthRadius;
        private double _heightRadius;

        public override Frame Frame
        {
            get
            {
                return new Frame
                {
                    LeftTop = new Point(_center.X - _widthRadius, _center.Y - _heightRadius),
                    Width = _widthRadius * 2,
                    Height = _heightRadius * 2
                };
            }
            set
            {
                _center = new Point(value.LeftTop.X + value.Width / 2, value.LeftTop.Y + value.Height / 2);
                _widthRadius = value.Width / 2;
                _heightRadius = value.Height / 2;
            }
        }

        public Ellipse(Point center, double widthRadius, double heightRadius)
        {
            _center = center;
            _widthRadius = widthRadius;
            _heightRadius = heightRadius;
        }

        public override void Draw(ICanvas canvas)
        {
            if (BorderStyle != null)
            {
                canvas.DrawEllipse(_center, _widthRadius, _heightRadius, BorderStyle.Color, BorderStyle.Thickness);
            }

            if (FillStyle != null)
            {
                canvas.FillEllipse(_center, _widthRadius, _heightRadius, FillStyle.Color);
            }
        }
    }
}
