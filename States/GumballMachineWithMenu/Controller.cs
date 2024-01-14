using GumballMachineWithMenu.Commands;

namespace GumballMachineWithMenu
{
    public class Controller
    {
        private GumballMachine _gumballMachine;
        private Menu _menu;

        public Controller()
        {
            _gumballMachine = new GumballMachine(0);
            _menu = new Menu();

            _menu.AddCommand("insert_quarter", "Inserting quarter", new InsertQuarterCommand(_gumballMachine));
            _menu.AddCommand("eject_quarter", "Ejecting quarter(s)", new EjectQuarterCommand(_gumballMachine));
            _menu.AddCommand("turn_crank", "Turning the crank", new TurnCrankCommand(_gumballMachine));
            _menu.AddCommand("insert_gumball", "Adding gumball", new InsertBallsCommand(_gumballMachine));
            _menu.AddCommand("state", "State of gumball machine", new GetStateCommand(_gumballMachine));
            _menu.AddCommand("help", "Show all available commands", new MenuHelpCommand(_menu));
            _menu.AddCommand("exit", "Exit the program", new MenuExitCommand(_menu));
        }

        public void Run()
        {
            _menu.Run();
        }
    }
}
