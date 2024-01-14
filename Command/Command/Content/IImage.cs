namespace Command.Content
{
    public interface IImage
    {
        public string Path { get; }
        public int Width { get; }
        public int Height { get; }

        public void Resize(int width, int height);
        public void Remove();
    }
}
