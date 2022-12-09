namespace MultiGumballMachine.State.Impl
{
    public class MaxQuartersState : IState
    {
        private IGumballMachine _gumballMachine;

        public MaxQuartersState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine($"You can`t insert another quarter: max is {_gumballMachine.MaxQuartersCount}");
        }

        public void EjectQuarter()
        {
            Console.WriteLine($"Quarter returned");
            _gumballMachine.QuartersCount = 0;
            _gumballMachine.SetNoQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            if (_gumballMachine.QuartersCount > 0)
            {
                _gumballMachine.QuartersCount--;
            }
            _gumballMachine.SetSoldState();
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public override string ToString()
        {
            return "filled in. Waiting for turn of crank";
        }
    }
}
