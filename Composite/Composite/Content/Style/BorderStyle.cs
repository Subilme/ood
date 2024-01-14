namespace Composite.Content.Style
{
    public class BorderStyle : IBorderStyle
    {
        public bool IsEnabled { get; private set; }
        public uint Color { get; set; }
        public double Thickness { get; set; }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }
    }
}
