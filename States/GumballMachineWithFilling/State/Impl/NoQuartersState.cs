namespace GumballMachineWithFilling.State.Impl
{
    public class NoQuarterState : IState
    {
        private IGumballMachine _gumballMachine;

        public NoQuarterState(IGumballMachine gumballMachine)
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
            Console.WriteLine("You inserted a quarter");
            _gumballMachine.QuartersCount++;
            _gumballMachine.SetHasQuarterState();
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no quarter");
        }

        public void Dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public override string ToString()
        {
            return "waiting for quarter";
        }
    }
}
