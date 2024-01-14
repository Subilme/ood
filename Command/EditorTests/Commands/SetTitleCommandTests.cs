using Command.Commands;
using Command.Content;
using Command.Document;
using Xunit;

namespace EditorTests.Commands
{
    public class SetTitleCommandTests
    {
        private static Title _currTitle = new Title { Value = "old" };
        private static string _newTitle = "new";

        [Fact]
        public void SetTitle_Execute_ChangeOnNewTitle()
        {
            SetTitleCommand command = new SetTitleCommand(_currTitle, _newTitle);

            command.Execute();

            Assert.Equal("new", _currTitle.Value);
        }

        [Fact]
        public void SetTitle_Unexecute_BringBackOldTitle()
        {
            SetTitleCommand command = new SetTitleCommand(_currTitle, _newTitle);

            command.Execute();
            command.Unexecute();

            Assert.Equal("old", _currTitle.Value);
        }
    }
}
