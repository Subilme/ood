namespace GumballMachineWithMenu.Commands
{
    public class MenuHelpCommand : ICommand
    {
        private Menu _menu;

        public MenuHelpCommand(Menu menu)
        {
            _menu = menu;
        }

        public void Execute()
        {
            _menu.ShowCommands();
        }
    }
}
