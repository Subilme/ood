namespace Command.Content
{
    public class Image : IImage
    {
        private const string IMAGE_DIRECTORY = "img";
        private static readonly List<string> EXTENSIONS = new List<string>() { ".jpg", ".png", ".svg" };

        public string Path { get; private init; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Image(string path, int width, int height)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File does not exist");
            }

            if (!ValidateExtension(path))
            {
                throw new FormatException("Wrong extension");
            }

            if (height < 1 || height > 10000 || width < 1 || width > 10000)
            {
                throw new ArgumentException("Wrong image size[1, 10000]");
            }

            Width = width;
            Height = height;

            if (!Directory.Exists(IMAGE_DIRECTORY))
            {
                Directory.CreateDirectory(IMAGE_DIRECTORY);
            }
            Path = $"{Directory.GetCurrentDirectory()}\\{IMAGE_DIRECTORY}\\{GenerateFileName()}{System.IO.Path.GetExtension(path)}";
            File.Copy(path, Path, true);
        }

        public void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Remove()
        {
            File.Delete(Path);
        }

        private string GenerateFileName()
        {
            string availableChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string name = string.Empty;

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                name += availableChars[rand.Next(0, availableChars.Length - 1)];
            }

            return name;
        }

        private bool ValidateExtension(string path)
        {
            return EXTENSIONS.Contains(System.IO.Path.GetExtension(path));
        }
    }
}
