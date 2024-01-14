using Command.Document;

namespace Command.Commands
{
    public class SetTitleCommand : AbstractCommand
    {
        private Title _currTitle;
        private string _newTitle;

        public SetTitleCommand(Title currTitle, string newTitle)
        {
            _currTitle = currTitle;
            _newTitle = newTitle;
        }

        protected override void DoExecute()
        {
            (_currTitle.Value, _newTitle) = (_newTitle, _currTitle.Value);
        }

        protected override void DoUnexecute()
        {
            (_currTitle.Value, _newTitle) = (_newTitle, _currTitle.Value);
        }
    }
}
