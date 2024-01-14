namespace GumballMachineWithMenu.Commands
{
    public class GetStateCommand : ICommand
    {
        private GumballMachine _gumballMachine;

        public GetStateCommand(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Execute()
        {
            Console.WriteLine(_gumballMachine.ToString());
        }
    }
}
