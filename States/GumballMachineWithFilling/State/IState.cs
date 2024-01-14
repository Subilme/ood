namespace GumballMachineWithFilling.State
{
    public interface IState
    {
        public void InsertQuarter();
        public void EjectQuarter();
        public void TurnCrank();
        public void Dispense();
        public void AddBalls(uint count);
    }
}
