using Command.Commands;

namespace Command
{
    public class History : IDisposable
    {
        private const int HISTORY_LIMIT = 10;

        private List<ICommand> _items;
        private int _next;

        public History()
        {
            _items = new List<ICommand>();
            _next = 0;
        }

        public bool CanUndo()
        {
            return _next > 0;
        }

        public bool CanRedo()
        {
            return _next < _items.Count;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                _next--;
                _items[_next].Unexecute();
            }
        }

        public void Redo()
        {
            if (CanRedo())
            {
                _items[_next].Execute();
                _next++;
            }
        }

        public void AddAndExecuteCommand(ICommand command)
        {
            command.Execute();

            _items.GetRange(_next, _items.Count - _next).ForEach(x => x.Dispose());
            _items.RemoveRange(_next, _items.Count - _next);
            _items.Add(command);
            _next++;

            if (_next > HISTORY_LIMIT)
            {
                _items.ElementAt(0).Dispose();
                _items.RemoveAt(0);
                _next--;
            }
        }

        public void Dispose()
        {
            foreach (ICommand command in _items)
            {
                command.Dispose();
            }
        }
    }
}
