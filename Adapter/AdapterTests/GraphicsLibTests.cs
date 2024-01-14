using Xunit;
using AdapterObjectApp.GraphicsLib;

namespace AdapterTests
{
    public class GraphicsLibTests
    {
        [Fact]
        public void SetColor_PrintsCorrectValue()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Canvas canvas = new Canvas();
            canvas.SetColor(4612191);

            Assert.Equal("SetColor 46605F\r\n", writer.ToString());
        }

        [Fact]
        public void MoveTo_PrintsCorrectValue()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Canvas canvas = new Canvas();
            canvas.MoveTo(5, 6);

            Assert.Equal("MoveTo (5, 6)\r\n", writer.ToString());
        }

        [Fact]
        public void LineTo_PrintssCorrectValue()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Canvas canvas = new Canvas();
            canvas.LineTo(12, 18);

            Assert.Equal("LineTo (12, 18)\r\n", writer.ToString());
        }
    }
}
