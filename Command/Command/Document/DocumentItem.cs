using Command.Content;

namespace Command.Document
{
    public class DocumentItem : ConstDocumentItem
    {
        public DocumentItem(IImage image) : base(image) { }

        public DocumentItem(IParagraph paragraph) : base(paragraph) { }
    }
}
