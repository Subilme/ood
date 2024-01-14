using AdapterClassApp.GraphicsLib;
using AdapterClassApp.ShapeDrawingLib;

namespace AdapterClassApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Should we use new API?(Y)");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (userInput.ToUpper() == "Y")
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
            Rectangle rectangle = new Rectangle(new Point(5, 6), new Point(10, 18));
            painter.Draw(rectangle);

            Triangle triangle = new Triangle(new Point(15, 25), new Point(5, 10), new Point(20, 16));
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
            ModernGraphicsLibAdapter canvas = new ModernGraphicsLibAdapter();
            canvas.BeginDraw();
            CanvasPainter painter = new CanvasPainter(canvas);
            PaintPicture(painter);
            canvas.EndDraw();
        }
    }
}