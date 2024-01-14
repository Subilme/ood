namespace Command.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected bool IsExecuted { get; private set; }

        public void Execute()
        {
            if (!IsExecuted)
            {
                DoExecute();
                IsExecuted = true;
            }
        }

        public void Unexecute()
        {
            if (IsExecuted)
            {
                DoUnexecute();
                IsExecuted = false;
            }
        }

        public virtual void Dispose() { }

        protected abstract void DoExecute();
        protected abstract void DoUnexecute();
    }
}
