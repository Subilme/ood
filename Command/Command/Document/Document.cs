using Command.Commands;
using Command.Content;

namespace Command.Document
{
    public class Document : IDocument
    {
        private History _history = new History();
        private List<DocumentItem> _items = new List<DocumentItem>();
        private Title _title = new Title { Value = string.Empty };

        public string Title
        {
            get
            {
                return _title.Value;
            }
            set
            {
                _history.AddAndExecuteCommand(new SetTitleCommand(_title, value));
            }
        }

        public IParagraph InsertParagraph(string text, int position)
        {
            IParagraph newParagraph = new Paragraph(text);
            DocumentItem newDocumentItem = new DocumentItem(newParagraph);
            _history.AddAndExecuteCommand(new InsertDocumentItemCommand(_items, newDocumentItem, position));

            return newParagraph;
        }

        public IImage InsertImage(string path, int width, int height, int position)
        {
            IImage newImage = new Image(path, width, height);
            DocumentItem newDocumentItem = new DocumentItem(newImage);
            _history.AddAndExecuteCommand(new InsertDocumentItemCommand(_items, newDocumentItem, position));

            return newImage;
        }

        public ConstDocumentItem GetConstItem(int index)
        {
            return _items[index];
        }

        public DocumentItem GetItem(int index)
        {
            return _items[index];
        }

        public int GetItemsCount()
        {
            return _items.Count;
        }

        public void ResizeImage(int index, int width, int height)
        {
            if (index > GetItemsCount())
            {
                throw new IndexOutOfRangeException("Index greater than size of document");
            }

            var item = _items.ElementAt(index);
            if (item.Image == null)
            {
                throw new NullReferenceException("No image on position");
            }

            IImage newImage = new Image(_items[index].Image.Path, width, height);
            _history.AddAndExecuteCommand(new ResizeImageCommand(_items, new DocumentItem(newImage), index));
        }

        public void ReplaceText(int index, string text)
        {
            if (index > _items.Count)
            {
                throw new IndexOutOfRangeException("Index greater than size of document");
            }

            var item = _items.ElementAt(index);
            if (item.Paragraph == null)
            {
                throw new NullReferenceException("No text on position");
            }

            _history.AddAndExecuteCommand(new ReplaceTextCommand(_items, new DocumentItem(new Paragraph(text)), index));
        }

        public void RemoveItem(int index)
        {
            _history.AddAndExecuteCommand(new DeleteItemCommand(_items, index));
        }

        public bool CanUndo()
        {
            return _history.CanUndo();
        }

        public void Undo()
        {
            _history.Undo();
        }

        public bool CanRedo()
        {
            return _history.CanRedo();
        }

        public void Redo()
        {
            _history.Redo();
        }

        public void Dispose()
        {
            _history.Dispose();
        }
    }
}
