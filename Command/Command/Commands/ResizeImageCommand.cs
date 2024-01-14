using Command.Document;

namespace Command.Commands
{
    public class ResizeImageCommand : AbstractCommand
    {
        private List<DocumentItem> _items;
        private DocumentItem _item;
        private int _index;

        public ResizeImageCommand(List<DocumentItem> items, DocumentItem item, int index)
        {
            _items = items;

            if (item.Image.Width < 1 || item.Image.Height < 1 ||
                item.Image.Width > 10000 || item.Image.Height > 10000)
            {
                throw new ArgumentException("Wrong image size(1-10000)");
            }

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
