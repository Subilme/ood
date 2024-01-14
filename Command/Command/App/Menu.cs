namespace Command.App
{
    public delegate void Instruction(string command);

    public class Menu
    {
        private class Item
        {
            public string Shortcut { get; set; }
            public string Description { get; set; }
            public Instruction Instruction { get; set; }

            public Item(string shortcut, string description, Instruction command)
            {
                Shortcut = shortcut;
                Description = description;
                Instruction = command;
            }
        }

        private List<Item> _commands;
        private bool _exit;

        public Menu()
        {
            _commands = new List<Item>();
            _exit = false;
        }

        public void Run()
        {
            Console.Write(">");
            string command = Console.ReadLine();

            while ((command != null) && ExecuteCommand(command))
            {
                Console.Write(">");
                command = Console.ReadLine();
            }
        }

        public void AddCommand(string shortcut, string description, Instruction command)
        {
            if (_commands.FirstOrDefault(x => x.Shortcut == shortcut) != null)
            {
                return;
            }

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

        private bool ExecuteCommand(string instruction)
        {
            var command = _commands.FirstOrDefault(x => x.Shortcut == instruction.Split()[0]);
            if (command == null)
            {
                Console.WriteLine("Error, wrong command");
            }
            else
            {
                command.Instruction(instruction);
            }

            return !_exit;
        }
    }
}
