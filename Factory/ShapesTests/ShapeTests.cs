using Shapes;
using Shapes.Canvas;
using Shapes.Shapes;
using Xunit;

namespace ShapesTests
{
    public class ShapeTests
    {
        [Fact]
        public void TryToMakeEllipseWithCorrectParameters_ReturnCorrectEllipse()
        {
            Point center = new Point(15, 21);
            int hradius = 9;
            int vradius = 13;

            Ellipse ellipse = new Ellipse(center, hradius, vradius, Color.Yellow);

            Assert.True(ellipse.Center == center && ellipse.HorizontalRadius == hradius &&
                ellipse.VerticalRadius == vradius && ellipse.Color == Color.Yellow);
        }

        [Fact]
        public void DrawEllipseOnCanvas()
        {
            Canvas canvas = new Canvas();
            PictureDraft draft = new PictureDraft();
            var expected = new List<string>()
            {
                "Set Color",
                "Draw Ellipse"
            };

            Ellipse ellipse = new Ellipse(new Point(6, 4), 15, 6, Color.Red);
            draft.AddShape(ellipse);
            Painter.DrawPicture(draft, canvas);

            Assert.Equal(expected, canvas.Commands);
        }

        [Fact]
        public void TryToMakeRectangleWithCorrectParameters_ReturnCorrectRectangle()
        {
            Point leftTop = new Point(15, 21);
            Point rightBottom = new Point(20, 16);

            Rectangle rectangle = new Rectangle(leftTop, rightBottom, Color.Black);

            Assert.True(rectangle.LeftTop == leftTop && rectangle.RightBottom == rightBottom &&
                rectangle.Color == Color.Black);
        }

        [Fact]
        public void DrawRectangleOnCanvas()
        {
            Canvas canvas = new Canvas();
            PictureDraft draft = new PictureDraft();
            var expected = new List<string>()
            {
                "Set Color",
                "Draw Line",
                "Draw Line",
                "Draw Line",
                "Draw Line"
            };

            Rectangle rectangle = new Rectangle(new Point(6, 2), new Point(9, 11), Color.Blue);
            draft.AddShape(rectangle);
            Painter.DrawPicture(draft, canvas);

            Assert.Equal(expected, canvas.Commands);
        }

        [Fact]
        public void TryToMakeRegularPolygonWithCorrectParameters_ReturnCorrectRegularPolygon()
        {
            Point center = new Point(1, 9);
            int vertexCount = 6;
            int radius = 11;

            RegularPolygon regularPolygon = new RegularPolygon(vertexCount, center, radius, Color.Red);

            Assert.True(regularPolygon.VertexCount == vertexCount && regularPolygon.Center == center &&
                regularPolygon.Radius == radius && regularPolygon.Color == Color.Red);
        }

        [Fact]
        public void TryToMakeTriangleWithCorrectParameters_ReturnCorrectTriangle()
        {
            Point vertex1 = new Point(15, 21);
            Point vertex2 = new Point(20, 16);
            Point vertex3 = new Point(6, 2);

            Triangle triangle = new Triangle(vertex1, vertex2, vertex3, Color.Blue);

            Assert.True(triangle.Vertex1 == vertex1 && triangle.Vertex2 == vertex2 &&
                triangle.Vertex3 == vertex3 && triangle.Color == Color.Blue);
        }

        [Fact]
        public void DrawSeveralShapesOnCanvas()
        {
            Canvas canvas = new Canvas();
            PictureDraft draft = new PictureDraft();
            var expected = new List<string>()
            {
                "Set Color",
                "Draw Line",
                "Draw Line",
                "Draw Line",
                "Draw Line",
                "Set Color",
                "Draw Line",
                "Draw Line",
                "Draw Line",
                "Draw Line",
                "Draw Line",
            };

            Rectangle rectangle = new Rectangle(new Point(6, 2), new Point(9, 11), Color.Blue);
            draft.AddShape(rectangle);
            RegularPolygon regularPolygon = new RegularPolygon(5, new Point(5, 4), 9, Color.Yellow);
            draft.AddShape(regularPolygon);
            Painter.DrawPicture(draft, canvas);

            Assert.Equal(expected, canvas.Commands);
        }
    }
}
