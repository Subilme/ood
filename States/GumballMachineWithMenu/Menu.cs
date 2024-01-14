using GumballMachineWithMenu.Commands;

namespace GumballMachineWithMenu
{
    public class Menu
    {
        private class Item
        {
            public string Shortcut { get; }
            public string Description { get; }
            public ICommand Command { get; }

            public Item(string shortcut, string description, ICommand command)
            {
                Shortcut = shortcut;
                Description = description;
                Command = command;
            }
        }

        private List<Item> _commands = new List<Item>();
        private bool _exit = false;

        public void Run()
        {
            Console.Write(">");
            string command = Console.ReadLine();

            while (Execute(command))
            {
                Console.Write(">");
                command = Console.ReadLine();
            }
        }

        public void AddCommand(string shortcut, string description, ICommand command)
        {
            _commands.Add(new Item(shortcut, description, command));
        }

        public void ShowCommands()
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_commands[i].Shortcut}: {_commands[i].Description}");
            }
        }

        public void Exit()
        {
            _exit = true;
        }

        private bool Execute(string instruction)
        {
            var command = _commands.FirstOrDefault(x => x.Shortcut == instruction);
            if (command == null)
            {
                Console.WriteLine("Error, wrong command");
            }
            else
            {
                command.Command.Execute();
            }

            return !_exit;
        }
    }
}
