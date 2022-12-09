namespace MultiGumballMachine.State
{
    public interface IState
    {
        public void InsertQuarter();
        public void EjectQuarter();
        public void TurnCrank();
        public void Dispense();
    }
}
