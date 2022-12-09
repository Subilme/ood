using Shapes;
using Shapes.Factory;
using Shapes.Shapes;
using Xunit;

namespace ShapesTests
{
    // TODO: Переименовать тесты
    public class FactoryTests
    {
        ShapeFactory shapeFactory = new ShapeFactory();

        [Fact]
        public void CreateShapeWithEmptyInput_ThrowInvalidDatatException()
        {
            Assert.Throws<InvalidDataException>(() => shapeFactory.CreateShape(""));
        }

        [Fact]
        public void CreateWrongShape_ThrowInvalidDatatException()
        {
            Assert.Throws<InvalidDataException>(() => shapeFactory.CreateShape("rektangle yellow 7 8 15 21"));
        }

        [Fact]
        public void CreateShapeWithLackParameters_ThrowInvalidDatatException()
        {
            Assert.Throws<InvalidDataException>(() => shapeFactory.CreateShape("ellipse black 5 6 16"));
        }

        [Fact]
        public void TryCreateEllipseWithCorrectParameters_MakeCorrectEllipse()
        {
            var shape = shapeFactory.CreateShape("ellipse black 5 6 16 9");
            Ellipse ellipse = (Ellipse)shape;

            Assert.True(ellipse.Color == Color.Black && new Point(5, 6) == ellipse.Center
                && ellipse.HorizontalRadius == 16 && ellipse.VerticalRadius == 9);
        }

        [Fact]
        public void TryCreateRectangleWithCorrectParameters_MakeCorrectRectangle()
        {
            var shape = shapeFactory.CreateShape("rectangle yellow 7 8 15 21");
            Rectangle rectangle = (Rectangle)shape;

            Assert.True(rectangle.Color == Color.Yellow && new Point(7, 8) == rectangle.LeftTop 
               && new Point(15, 21) == rectangle.RightBottom);
        }

        [Fact]
        public void TryCreateTriangleWithCorrectParameters_MakeCorrectTriangle()
        {
            var shape = shapeFactory.CreateShape("triangle blue 5 6 9 4 23 15");
            Triangle triangle = (Triangle)shape;

            Assert.True(triangle.Color == Color.Blue && new Point(5, 6) == triangle.Vertex1
                && new Point(9, 4) == triangle.Vertex2 && new Point(23, 15) == triangle.Vertex3);
        }

        [Fact]
        public void TryCreateRegularPolygonWithCorrectParameters_MakeCorrectRegularPolygon()
        {
            var shape = shapeFactory.CreateShape("regular_polygon green 5 15 19 4");
            RegularPolygon regularPolygon = (RegularPolygon)shape;

            Assert.True(regularPolygon.Color == Color.Green && regularPolygon.VertexCount == 5
                && new Point(15, 19) == regularPolygon.Center && regularPolygon.Radius == 4);
        }
    }
}
