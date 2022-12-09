namespace GumballMachine
{
    public interface IGumballMachine
    {
        // TODO: Переименовать свойство
        public uint BallCount { get; }

        internal void ReleaseBall();
        internal void SetSoldOutState();
        internal void SetNoQuarterState();
        internal void SetHasQuarterState();
        internal void SetSoldState();
    }
}
