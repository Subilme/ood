using Command.Commands;
using Command.Content;
using Command.Document;
using Xunit;

namespace EditorTests.Commands
{
    public class ReplaceTextCommandTests
    {
        private static List<DocumentItem> _items = new List<DocumentItem>() { new DocumentItem(new Paragraph("old")) };
        private static string _newText = "new";

        [Fact]
        public void ReplaceText_Execute_ReplaceTextWithNew()
        {
            ReplaceTextCommand command = new ReplaceTextCommand(_items, new DocumentItem(new Paragraph(_newText)), 0);

            command.Execute();

            Assert.Equal("new", _items[0].Paragraph.Text);
        }

        [Fact]
        public void ReplaceText_Unexecute_BringBackOldText()
        {
            ReplaceTextCommand command = new ReplaceTextCommand(_items, new DocumentItem(new Paragraph(_newText)), 0);

            command.Execute();
            command.Unexecute();

            Assert.Equal("old", _items[0].Paragraph.Text);
        }
    }
}
