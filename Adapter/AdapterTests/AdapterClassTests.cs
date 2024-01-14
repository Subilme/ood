using Xunit;
using AdapterClassApp;
using AdapterClassApp.ShapeDrawingLib;

namespace AdapterTests
{
    public class AdapterClassTests
    {
        [Fact]
        public void AdapterClass_DrawCorrectTriangle()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ModernGraphicsLibAdapter canvas = new ModernGraphicsLibAdapter();
            CanvasPainter painter = new CanvasPainter(canvas);
            Triangle triangle = new Triangle(new Point(15, 25), new Point(5, 10), new Point(20, 16));

            canvas.BeginDraw();
            painter.Draw(triangle);
            canvas.EndDraw();

            string expected = "<draw>\r\n<line from (15, 25) to (5, 10)>\r\n</line>\r\n<line from (5, 10) to (20, 16)>\r\n" +
                "</line>\r\n<line from (20, 16) to (15, 25)>\r\n</line>\r\n</draw>\r\n";
            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void AdapterClass_DrawCorrectRectangle()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ModernGraphicsLibAdapter canvas = new ModernGraphicsLibAdapter();
            CanvasPainter painter = new CanvasPainter(canvas);
            Rectangle rectangle = new Rectangle(new Point(5, 6), new Point(10, 18));

            canvas.BeginDraw();
            painter.Draw(rectangle);
            canvas.EndDraw();

            string expected = "<draw>\r\n<line from (5, 6) to (10, 6)>\r\n</line>\r\n" +
                "<line from (10, 6) to (10, 18)>\r\n</line>\r\n<line from (10, 18) to (5, 18)>\r\n</line>\r\n" +
                "<line from (5, 18) to (5, 6)>\r\n</line>\r\n</draw>\r\n";
            Assert.Equal(expected, writer.ToString());
        }
    }
}
