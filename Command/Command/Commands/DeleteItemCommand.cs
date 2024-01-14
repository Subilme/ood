using Command.Document;

namespace Command.Commands
{
    public class DeleteItemCommand : AbstractCommand
    {
        private List<DocumentItem> _items;
        private DocumentItem _item;
        private int _index;

        public DeleteItemCommand(List<DocumentItem> items, int index)
        {
            _items = items;

            if (index >= _items.Count)
            {
                throw new IndexOutOfRangeException("Index greater than size of document");
            }
            _index = index;
            _item = _items[index];
        }

        protected override void DoExecute()
        {
            _items.RemoveAt(_index);
        }

        protected override void DoUnexecute()
        {
            _items.Insert(_index, _item);
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
