using Xunit;
using AdapterObjectApp;
using AdapterObjectApp.ModernGraphicsLib;

namespace AdapterTests
{
    public class ModerbGraphicsLibTests
    {
        [Fact]
        public void TryDrawLineBeforeBeginDraw_ThrowsInvalidOperationException()
        {
            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer();

            Assert.Throws<InvalidOperationException>(() => renderer.DrawLine(new Point(5, 6), new Point(12, 18),
                new RGBAColor(5, 56, 94, 1)));
        }

        [Fact]
        public void Renderer_DrawCorrectLine()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer();

            renderer.BeginDraw();
            renderer.DrawLine(new Point(2, 6), new Point(15, 19), new RGBAColor(70, 96, 95, 1));
            renderer.EndDraw();

            Console.SetOut(Console.Out);

            Assert.Equal("<draw>\r\n<line from (2, 6) to (15, 19)>\r\n<color (70, 96, 95, 1)/>\r\n</line>\r\n</draw>\r\n", 
                writer.ToString());
        }

        [Fact]
        public void TryDrawLineAfterEndDraw_ThrowsInvalidOperationException()
        {
            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer();

            renderer.BeginDraw();
            renderer.DrawLine(new Point(20, 64),
                new Point(5, 13),
                new RGBAColor(21, 64, 242, 1));
            renderer.EndDraw();

            Assert.Throws<InvalidOperationException>(() => renderer.DrawLine(new Point(5, 6), new Point(12, 18),
                new RGBAColor(5, 56, 94, 1)));
        }
    }
}
