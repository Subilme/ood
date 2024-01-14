using Command.Document;

namespace Command
{
    public class HTMLSaver
    {
        private const string IMAGES_DIRECTORY = "images";
        private static Dictionary<char, string> _escapeChars = new Dictionary<char, string>()
        {
            { '&', "&amp;" },
            { '<', "&lt;" },
            { '>', "&gt;" },
            { '\"', "&quot;" },
            { '\'', "&apos;" },
        };

        public void Save(string path, IDocument document)
        {
            using StreamWriter writer = new StreamWriter(path);

            if (Path.GetDirectoryName(path) == string.Empty)
            {
                path = Directory.GetCurrentDirectory() + "\\" + Path.GetFileName(path);
            }
            string imgDirectory = Path.GetDirectoryName(path) + "\\" + IMAGES_DIRECTORY;

            if (!Directory.Exists(imgDirectory))
            {
                Directory.CreateDirectory(imgDirectory);
            }

            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine($"<title>{ConvertString(document.Title)}</title>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            for (int i = 0; i < document.GetItemsCount(); i++)
            {
                if (document.GetItem(i).Image != null)
                {
                    var image = document.GetItem(i).Image;

                    if (!File.Exists(imgDirectory + "\\" + Path.GetFileName(image.Path)))
                    {
                        File.Copy(image.Path, imgDirectory + "\\" + Path.GetFileName(image.Path));
                    }
                    writer.WriteLine($"<img src=\"{imgDirectory + "\\" + Path.GetFileName(image.Path)}\" width=\"{image.Width}\" height=\"{image.Height}\"/>");
                }
                else
                {
                    var paragraph = document.GetItem(i).Paragraph;
                    writer.WriteLine($"<p>{ConvertString(paragraph.Text)}</p>");
                }
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        private string ConvertString(string str)
        {
            string result = string.Empty;

            foreach (var ch in str)
            {
                if (_escapeChars.ContainsKey(ch))
                {
                    result += _escapeChars[ch];
                }
                else
                {
                    result += ch;
                }
            }

            return result;
        }
    }
}
