using Command.App;
using Xunit;

namespace EditorTests
{
    public class MenuTests
    {
        [Fact]
        public void AddCommand_MenuContainNewCommand()
        {
            Menu menu = new Menu();
            menu.AddCommand("command", "print text", (string command) => { Console.WriteLine("text"); });
            string expected = "1. command: print text\r\n";

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            menu.ShowCommands();

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void CallUndefinedCommand_PrintError()
        {
            Menu menu = new Menu();
            menu.AddCommand("command", "print text", (string command) => { Console.WriteLine("text"); });
            string expected = ">Error, wrong command\r\n>";

            string commands = "print\r\n";
            StringReader reader = new StringReader(commands);
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            menu.Run();

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void Exit_StopTheWork_CloseMenu()
        {
            Menu menu = new Menu();
            menu.AddCommand("hello", "print hello", (string command) => { Console.WriteLine("Hello"); });
            menu.AddCommand("there", "print there", (string command) => { Console.WriteLine("There"); });
            menu.AddCommand("exit", "print there", (string command) => { menu.Exit(); });
            string expected = ">Hello\r\n>";

            string commands = "hello\r\nexit\r\nthere";
            StringReader reader = new StringReader(commands);
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            menu.Run();

            Assert.Equal(expected, writer.ToString());
        }
    }
}
