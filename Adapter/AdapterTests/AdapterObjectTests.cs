using Xunit;
using AdapterObjectApp;
using AdapterObjectApp.ModernGraphicsLib;
using AdapterObjectApp.ShapeDrawingLib;

namespace AdapterTests
{
    public class AdapterObjectTests
    {
        [Fact]
        public void AdapterObject_DrawCorrectTriangle()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer();
            ModernGraphicsLibAdapter adapter = new ModernGraphicsLibAdapter(renderer);
            CanvasPainter painter = new CanvasPainter(adapter);
            
            var color = new RGBAColor(70, 96, 95, 1);
            Triangle triangle = new Triangle(new Point(15, 25), new Point(5, 10), new Point(20, 16), color.ParseToInt()); 

            renderer.BeginDraw();
            painter.Draw(triangle);
            renderer.EndDraw();

            string expected = "<draw>\r\n<line from (15, 25) to (5, 10)>\r\n<color (70, 96, 95, 1)/>\r\n</line>\r\n" +
                "<line from (5, 10) to (20, 16)>\r\n<color (70, 96, 95, 1)/>\r\n</line>\r\n" +
                "<line from (20, 16) to (15, 25)>\r\n<color (70, 96, 95, 1)/>\r\n</line>\r\n</draw>\r\n";
            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void AdapterObject_DrawCorrectRectangle()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer();
            ModernGraphicsLibAdapter adapter = new ModernGraphicsLibAdapter(renderer);
            CanvasPainter painter = new CanvasPainter(adapter);
            
            var color = new RGBAColor(242, 218, 134, 1);
            Rectangle rectangle = new Rectangle(new Point(5, 6), new Point(10, 18), color.ParseToInt());

            renderer.BeginDraw();
            painter.Draw(rectangle);
            renderer.EndDraw();

            string expected = "<draw>\r\n<line from (5, 6) to (10, 6)>\r\n<color (242, 218, 134, 1)/>\r\n" +
                "</line>\r\n<line from (10, 6) to (10, 18)>\r\n<color (242, 218, 134, 1)/>\r\n</line>\r\n" +
                "<line from (10, 18) to (5, 18)>\r\n<color (242, 218, 134, 1)/>\r\n</line>\r\n" +
                "<line from (5, 18) to (5, 6)>\r\n<color (242, 218, 134, 1)/>\r\n</line>\r\n</draw>\r\n";
            Assert.Equal(expected, writer.ToString());
        }
    }
}
