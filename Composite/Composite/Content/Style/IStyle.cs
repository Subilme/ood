namespace Composite.Content.Style
{
    public interface IStyle
    {
        public uint Color { get; set; }
        public bool IsEnabled { get; }

        public void Enable();
        public void Disable();
    }
}
