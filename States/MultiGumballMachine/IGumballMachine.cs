namespace MultiGumballMachine
{
    public interface IGumballMachine
    {
        public uint MaxQuartersCount { get; }
        public uint BallCount { get; }
        public uint QuartersCount { get; internal set; }
        internal void ReleaseBall();
        internal void SetSoldOutState();
        internal void SetNoQuarterState();
        internal void SetHasQuarterState();
        internal void SetMaxQuartersState();
        internal void SetSoldState();
    }
}
