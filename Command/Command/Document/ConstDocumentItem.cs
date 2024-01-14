using Command.Content;

namespace Command.Document
{
    public class ConstDocumentItem : IConstDocumentItem
    {
        public IImage Image { get; set; } = null;
        public IParagraph Paragraph { get; set; } = null;

        public ConstDocumentItem(IImage image)
        {
            Image = image;
        }

        public ConstDocumentItem(IParagraph paragraph)
        {
            Paragraph = paragraph;
        }
    }
}
