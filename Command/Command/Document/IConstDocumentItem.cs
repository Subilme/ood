using Command.Content;

namespace Command.Document
{
    public interface IConstDocumentItem
    {
        public IImage Image { get; set; }
        public IParagraph Paragraph { get; set; }
    }
}
