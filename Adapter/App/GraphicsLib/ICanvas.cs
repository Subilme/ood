namespace AdapterObjectApp.GraphicsLib
{
    public interface ICanvas
    {
        public void SetColor(uint color);
        public void MoveTo(int x, int y);
        public void LineTo(int x, int y);
    }
}
