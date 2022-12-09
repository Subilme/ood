using Shapes.Shapes;

namespace Shapes.Factory
{
    public class ShapeFactory : IShapeFactory
    {
        private static Dictionary<string, Color> _colors = new Dictionary<string, Color>()
        {
            {"green", Color.Green},
            {"red", Color.Red},
            {"blue", Color.Blue},
            {"yellow", Color.Yellow},
            {"pink", Color.Pink},
            {"black", Color.Black},
        };

        public Shape CreateShape(string description)
        {
            List<string> parameters = description.Split().ToList();
            if (parameters.Count == 0)
            {
                throw new InvalidDataException("Error, wrong count of parameters");
            }

            switch (parameters[0])
            {
                case "rectangle":
                    return CreateRectangle(parameters);
                case "triangle":
                    return CreateTriangle(parameters);
                case "ellipse":
                    return CreateEllipse(parameters);
                case "regular_polygon":
                    return CreateRegularPolygon(parameters);
                default:
                    throw new InvalidDataException("Error, wrong name of shape");
            }
        }

        private Shape CreateRectangle(List<string> args)
        {
            if (args.Count != 6)
            {
                throw new InvalidDataException("Error, wrong params count for rectangle");
            }

            Color color = _colors[args[1]];
            Point leftTop = new Point(double.Parse(args[2]), double.Parse(args[3]));
            Point rightTop = new Point(double.Parse(args[4]), double.Parse(args[5]));

            return new Rectangle(leftTop, rightTop, color);
        }

        private Shape CreateTriangle(List<string> args)
        {
            if (args.Count != 8)
            {
                throw new InvalidDataException("Error, wrong params count for triangle");
            }

            Color color = _colors[args[1]];
            Point vertex1 = new Point(double.Parse(args[2]), double.Parse(args[3]));
            Point vertex2 = new Point(double.Parse(args[4]), double.Parse(args[5]));
            Point vertex3 = new Point(double.Parse(args[6]), double.Parse(args[7]));

            return new Triangle(vertex1, vertex2, vertex3, color);
        }

        private Shape CreateEllipse(List<string> args)
        {
            if (args.Count != 6)
            {
                throw new InvalidDataException("Error, wrong params count for ellipse");
            }

            Color color = _colors[args[1]];
            Point center = new Point(double.Parse(args[2]), double.Parse(args[3]));
            int horRadius = int.Parse(args[4].ToString());
            int vertRadius = int.Parse(args[5].ToString());

            return new Ellipse(center, horRadius, vertRadius, color);
        }

        private Shape CreateRegularPolygon(List<string> args)
        {
            if (args.Count != 6)
            {
                throw new InvalidDataException("Error, wrong params count for regular polygon");
            }

            Color color = _colors[args[1]];
            int vertexCount = int.Parse(args[2].ToString());
            Point center = new Point(double.Parse(args[3]), double.Parse(args[4]));
            int radius = int.Parse(args[5].ToString());

            return new RegularPolygon(vertexCount, center, radius, color);
        }
    }
}
