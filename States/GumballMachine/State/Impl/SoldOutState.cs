namespace GumballMachine.State.Impl
{
    public class SoldOutState : IState
    {
        private IGumballMachine _gumballMachine;

        public SoldOutState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
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
