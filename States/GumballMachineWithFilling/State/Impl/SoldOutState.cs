namespace GumballMachineWithFilling.State.Impl
{
    public class SoldOutState : IState
    {
        private IGumballMachine _gumballMachine;

        public SoldOutState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void AddBalls(uint count)
        {
            Console.WriteLine($"You inserted gumball");
            _gumballMachine.AddBalls(count);

            if (_gumballMachine.BallCount == 0)
            {
                return;
            }

            if (_gumballMachine.QuartersCount == _gumballMachine.MaxQuartersCount)
            {
                _gumballMachine.SetMaxQuartersState();
            }
            else if (_gumballMachine.QuartersCount > 0)
            {
                _gumballMachine.SetHasQuarterState();
            }
            else
            {
                _gumballMachine.SetNoQuarterState();
            }
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void EjectQuarter()
        {
            if (_gumballMachine.QuartersCount > 0)
            {
                Console.WriteLine("Quarter returned");
                _gumballMachine.QuartersCount = 0;
            }
            else
            {
                Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
            }
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no gumballs");
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public override string ToString()
        {
            return "sold out";
        }
    }
}
