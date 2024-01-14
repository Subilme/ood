namespace Command.Commands
{
    public interface ICommand : IDisposable
    {
        public void Execute();
        public void Unexecute();
    }
}
