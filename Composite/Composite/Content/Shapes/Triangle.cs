using Composite.App;
using Composite.Common;
using Composite.Content.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Content.Shapes
{
    public class Triangle : Shape
    {
        private Point _vertex1;
        private Point _vertex2;
        private Point _vertex3;

        public override Frame Frame
        {

            get
            {
                var maxX = Math.Max(_vertex1.X, Math.Max(_vertex2.X, _vertex3.X));
                var minX = Math.Min(_vertex1.X, Math.Min(_vertex2.X, _vertex3.X));
                var maxY = Math.Max(_vertex1.Y, Math.Max(_vertex2.Y, _vertex3.Y));
                var minY = Math.Min(_vertex1.Y, Math.Min(_vertex2.Y, _vertex3.Y));

                return new Frame
                {
                    LeftTop = new Point(minX, minY),
                    Width = maxX - minX,
                    Height = maxY - minY
                };
            }
            set
            {
                _vertex1 = new Point(
                    value.LeftTop.X + (_vertex1.X - Frame.LeftTop.X) * (value.Width / Frame.Width),
                    value.LeftTop.Y + (_vertex1.Y - Frame.LeftTop.Y) * (value.Height / Frame.Height)
                    );
                _vertex2 = new Point(
                    value.LeftTop.X + (_vertex2.X - Frame.LeftTop.X) * (value.Width / Frame.Width),
                    value.LeftTop.Y + (_vertex2.Y - Frame.LeftTop.Y) * (value.Height / Frame.Height)
                    );
                _vertex3 = new Point(
                    value.LeftTop.X + (_vertex3.X - Frame.LeftTop.X) * (value.Width / Frame.Width),
                    value.LeftTop.Y + (_vertex3.Y - Frame.LeftTop.Y) * (value.Height / Frame.Height)
                    );
            }
        }

        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _vertex3 = vertex3;
        }

        public override void Draw(ICanvas canvas)
        {
            List<Point> points = new List<Point> { _vertex1, _vertex2, _vertex3 };

            if (BorderStyle != null)
            {
                canvas.DrawLine(points[0], points[1], BorderStyle.Color, BorderStyle.Thickness);
                canvas.DrawLine(points[1], points[2], BorderStyle.Color, BorderStyle.Thickness);
                canvas.DrawLine(points[2], points[0], BorderStyle.Color, BorderStyle.Thickness);
            }

            if (FillStyle != null)
            {
                canvas.FillPolygon(points, FillStyle.Color);
            }
        }
    }
}
