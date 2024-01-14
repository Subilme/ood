namespace GumballMachineWithMenu.Commands
{
    public class InsertBallsCommand : ICommand
    {
        private GumballMachine _gumballMachine;

        public InsertBallsCommand(GumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Execute()
        {
            uint count = uint.Parse(Console.ReadLine());
            _gumballMachine.InsertBalls(count);
        }
    }
}
