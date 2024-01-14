using Command.Content;

namespace Command.Document
{
    public interface IDocument : IDisposable 
    {
        public string Title { get; set; }

        public IParagraph InsertParagraph(string text, int position);
        public IImage InsertImage(string path, int width, int height, int position);
        public ConstDocumentItem GetConstItem(int index);
        public DocumentItem GetItem(int index);
        public int GetItemsCount();
        public void ResizeImage(int index, int width, int height);
        public void ReplaceText(int index, string text);
        public void RemoveItem(int index);
        public bool CanUndo();
        public void Undo();
        public bool CanRedo();
        public void Redo();
    }
}
