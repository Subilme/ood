using AdapterObjectApp.GraphicsLib;
using AdapterObjectApp.ModernGraphicsLib;
using AdapterObjectApp.ShapeDrawingLib;

namespace AdapterObjectApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Should we use new API?(y)");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (userInput.ToLower() == "y")
            {
                PaintPictureOnModernGraphicsRenderer();
            }
            else
            {
                PaintPictureOnCanvas();
            }
        }

        private static void PaintPicture(CanvasPainter painter)
        {
            Rectangle rectangle = new Rectangle(new Point(5, 6),
                new Point(10, 18), 15915654);
            painter.Draw(rectangle);

            Triangle triangle = new Triangle(new Point(15, 25), new Point(5, 10), new Point(20, 16), 4612191);
            painter.Draw(triangle);
        }

        private static void PaintPictureOnCanvas()
        {
            Canvas canvas = new Canvas();
            CanvasPainter painter = new CanvasPainter(canvas);

            PaintPicture(painter);
        }

        private static void PaintPictureOnModernGraphicsRenderer()
        {
            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer();

            renderer.BeginDraw();
            ModernGraphicsLibAdapter canvas = new ModernGraphicsLibAdapter(renderer);
            CanvasPainter painter = new CanvasPainter(canvas);
            PaintPicture(painter);
            renderer.EndDraw();
        }
    }
}
