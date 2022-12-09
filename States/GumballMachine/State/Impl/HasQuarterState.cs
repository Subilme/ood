namespace GumballMachine.State.Impl
{
    public class HasQuarterState : IState
    {
        private IGumballMachine _gumballMachine;

        public HasQuarterState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can`t insert another quarter");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
            _gumballMachine.SetNoQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            _gumballMachine.SetSoldState();
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public override string ToString()
        {
            return "waiting for turn of crank";
        }
    }
}
