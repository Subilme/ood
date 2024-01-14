namespace GumballMachineWithMenu.Commands
{
    public class EjectQuarterCommand : ICommand
    {
        private GumballMachine _gumballMachine;

        public EjectQuarterCommand(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Execute()
        {
            _gumballMachine.EjectQuarter();
        }
    }
}
