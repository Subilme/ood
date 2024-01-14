namespace GumballMachineWithMenu.Commands
{
    public class MenuExitCommand : ICommand
    {
        private Menu _menu;

        public MenuExitCommand(Menu menu)
        {
            _menu = menu;
        }

        public void Execute()
        {
            _menu.Exit();
        }
    }
}
