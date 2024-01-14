using Xunit;
using AdapterObjectApp;
using AdapterObjectApp.ShapeDrawingLib;
using AdapterObjectApp.GraphicsLib;
using AdapterObjectApp.ModernGraphicsLib;

namespace AdapterTests
{
    public class ShapeDrawingLibTests
    {
        [Fact]
        public void Painter_DrawCorrectTriangle()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Canvas canvas = new Canvas();
            CanvasPainter painter = new CanvasPainter(canvas);
            var color = new RGBAColor(70, 96, 95, 1);
            Triangle triangle = new Triangle(new Point(15, 25), new Point(5, 10), new Point(20, 16), color.ParseToInt());            
            painter.Draw(triangle);

            Assert.Equal("SetColor 46605F\r\nMoveTo (15, 25)\r\nLineTo (5, 10)\r\nLineTo (20, 16)\r\nLineTo (15, 25)\r\n", 
                writer.ToString());
        }

        [Fact]
        public void Painter_DrawCorrectRectangle()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Canvas canvas = new Canvas();
            CanvasPainter painter = new CanvasPainter(canvas);
            var color = new RGBAColor(242, 218, 134, 1);
            Rectangle rectangle = new Rectangle(new Point(5, 6), new Point(10, 18), color.ParseToInt());
            painter.Draw(rectangle);

            Assert.Equal("SetColor F2DA86\r\nMoveTo (5, 6)\r\nLineTo (10, 6)\r\nLineTo (10, 18)\r\n" +
                "LineTo (5, 18)\r\nLineTo (5, 6)\r\n", writer.ToString());
        }
    }
}
