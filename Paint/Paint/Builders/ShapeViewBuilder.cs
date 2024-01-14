using Paint.Enums;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Builders
{
    public static class ShapeViewBuilder
    {
        public static Shape BuildView(Models.Shape shape)
        {
            Shape _shape = shape.ShapeType switch
            {
                ShapeType.Ellipse => BuildEllipseView(shape),
                ShapeType.Rectangle => BuildRectangleView(shape),
                ShapeType.Triangle => BuildTriangleView(shape),
                _ => throw new InvalidEnumArgumentException("Unknown shape type"),
            };
            return _shape;
        }

        private static Ellipse BuildEllipseView(Paint.Models.Shape shape)
        {
            if (shape is null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            return new Ellipse()
            {
                Fill = StringToBrushOrDefault(shape.Color),
                Uid = shape.Uid,
                Height = shape.Frame.Height,
                Width = shape.Frame.Width,
                Focusable = true
            };
        }

        private static Rectangle BuildRectangleView(Paint.Models.Shape shape)
        {
            if (shape is null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            return new Rectangle()
            {
                Fill = StringToBrushOrDefault(shape.Color),
                Uid = shape.Uid,
                Height = shape.Frame.Height,
                Width = shape.Frame.Width,
                Focusable = true
            };
        }

        private static Polygon BuildTriangleView(Paint.Models.Shape shape)
        {
            if (shape is null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            Polygon triangle = new()
            {
                Fill = StringToBrushOrDefault(shape.Color),
                Uid = shape.Uid,
                Height = shape.Frame.Height,
                Width = shape.Frame.Width,
                Focusable = true,
                Stretch = Stretch.Fill
            };
            triangle.Points.Add(new Point(0, triangle.Height));
            triangle.Points.Add(new Point(triangle.Width / 2, 0));
            triangle.Points.Add(new Point(triangle.Width, triangle.Height));

            return triangle;
        }

        private static Brush StringToBrushOrDefault(string color)
        {
            Brush? brush = null;

            try
            {
                brush = new BrushConverter().ConvertFromString(color) as Brush;
            }
            catch
            {
            }

            return brush ?? Brushes.DarkBlue;
        }
    }
}
