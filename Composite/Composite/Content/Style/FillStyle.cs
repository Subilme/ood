namespace Composite.Content.Style
{
    public class FillStyle : IStyle
    {
        public uint Color { get; set; }
        public bool IsEnabled { get; private set; }

        public FillStyle()
        {
            Color = 0;
            IsEnabled = false;
        }

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
