using Command.Document;

namespace Command.Commands
{
    public class ReplaceTextCommand : AbstractCommand
    {
        private List<DocumentItem> _items;
        private DocumentItem _item;
        private int _index;

        public ReplaceTextCommand(List<DocumentItem> items, DocumentItem item, int index)
        {
            _items = items;
            _item = item;
            _index = index;
        }

        protected override void DoExecute()
        {
            (_items[_index], _item) = (_item, _items[_index]);
        }

        protected override void DoUnexecute()
        {
            (_items[_index], _item) = (_item, _items[_index]);
        }
    }
}
