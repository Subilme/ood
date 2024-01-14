namespace GumballMachineWithMenu.Commands
{
    public class TurnCrankCommand : ICommand
    {
        private GumballMachine _gumballMachine;

        public TurnCrankCommand(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Execute()
        {
            _gumballMachine.TurnCrank();
        }
    }
}
