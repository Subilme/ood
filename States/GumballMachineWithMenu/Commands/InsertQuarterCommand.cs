namespace GumballMachineWithMenu.Commands
{
    public class InsertQuarterCommand : ICommand
    {
        private GumballMachine _gumballMachine;

        public InsertQuarterCommand(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Execute()
        {
            _gumballMachine.InsertQuarter();
        }
    }
}
