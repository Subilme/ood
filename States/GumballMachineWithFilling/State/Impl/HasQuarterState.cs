namespace GumballMachineWithFilling.State.Impl
{
    public class HasQuarterState : IState
    {
        private IGumballMachine _gumballMachine;

        public HasQuarterState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void AddBalls(uint count)
        {
            Console.WriteLine($"You inserted gumball");
            _gumballMachine.AddBalls(count);
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You inserted another quarter");
            _gumballMachine.QuartersCount++;
            if (_gumballMachine.QuartersCount == _gumballMachine.MaxQuartersCount)
            {
                _gumballMachine.SetMaxQuartersState();
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
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
            return "waiting for turn of crank";
        }
    }
}
