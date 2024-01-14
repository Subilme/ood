namespace AdapterObjectApp.ModernGraphicsLib
{
    public class ModernGraphicsRenderer
    {
        private bool _drawing = false;

        public void BeginDraw()
        {
            if (_drawing)
            {
                throw new InvalidOperationException("Drawing has already begun");
            }

            Console.WriteLine("<draw>");
            _drawing = true;
        }

        public void DrawLine(Point start, Point end, RGBAColor color)
        {
            if (!_drawing)
            {
                throw new InvalidOperationException("DrawLine is allowed between BeginDraw()/EndDraw() only");
            }

            Console.WriteLine($"<line from ({start.X}, {start.Y}) to ({end.X}, {end.Y})>");
            Console.WriteLine($"<color ({(int)color.Red}, {(int)color.Green}, {(int)color.Blue}, {(int)color.Alpha})/>");
            Console.WriteLine("</line>");
        }

        public void EndDraw()
        {
            if (!_drawing)
            {
                throw new InvalidOperationException("Drawing has not been started");
            }

            Console.WriteLine("</draw>");
            _drawing = false;
        }

        ~ModernGraphicsRenderer()
        {
            if (_drawing)
            {
                EndDraw();
            }
        }
    }
}
