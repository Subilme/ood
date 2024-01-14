using Command.Document;

namespace Command.Commands
{
    public class InsertDocumentItemCommand : AbstractCommand
    {
        private List<DocumentItem> _items;
        private DocumentItem _item;
        private int _index;

        public InsertDocumentItemCommand(List<DocumentItem> items, DocumentItem item, int index)
        {
            _items = items;

            if (index > _items.Count)
            {
                throw new IndexOutOfRangeException("Index greater than size of document");
            }
            _index = index;
            _item = item;
        }

        protected override void DoExecute()
        {
            _items.Insert(_index, _item);
        }

        protected override void DoUnexecute()
        {
            _items.RemoveAt(_index);
        }

        public override void Dispose()
        {
            if (_item.Image != null)
            {
                _item.Image.Remove();
            }
        }
    }
}
