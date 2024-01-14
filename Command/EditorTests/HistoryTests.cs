using Command.Commands;
using Command;
using Xunit;

namespace EditorTests
{
    public class HistoryTests
    {
        private History _history = new History();

        [Fact]
        public void InitHistory_HistoryIsEmpty()
        {
            Assert.False(_history.CanRedo());
            Assert.False(_history.CanUndo());
        }

        [Fact]
        public void AddCommand_CanUndo_CannotRedo()
        {
            _history.AddAndExecuteCommand(new CommandMock());

            Assert.True(_history.CanUndo());
            Assert.False(_history.CanRedo());
        }

        [Fact]
        public void UndoCommand_RemoveCommandFromHistory()
        {
            _history.AddAndExecuteCommand(new CommandMock());

            _history.Undo();

            Assert.False(_history.CanUndo());
            Assert.True(_history.CanRedo());
        }

        [Fact]
        public void RedoCommand_BringBackCanceledCommand()
        {
            _history.AddAndExecuteCommand(new CommandMock());

            _history.Undo();
            _history.Redo();

            Assert.True(_history.CanUndo());
            Assert.False(_history.CanRedo());
        }

        [Fact]
        public void AddCommand_HistoryIsNotEmpty_DeleteAllCommandsForRedo()
        {
            _history.AddAndExecuteCommand(new CommandMock());
            _history.AddAndExecuteCommand(new CommandMock());
            _history.AddAndExecuteCommand(new CommandMock());
            _history.AddAndExecuteCommand(new CommandMock());
            _history.AddAndExecuteCommand(new CommandMock());

            _history.Undo();
            _history.Undo();

            _history.AddAndExecuteCommand(new CommandMock());

            Assert.False(_history.CanRedo());
        }

        [Fact]
        public void AddCommand_HistoryOverflow_SaveOnlyLastTenCommands()
        {
            for (int i = 0; i < 15; i++)
            {
                _history.AddAndExecuteCommand(new CommandMock());
            }

            int counter = 0;
            for (int i = 0; i < 15; i++)
            {
                if (_history.CanUndo())
                {
                    _history.Undo();
                    counter++;
                }
            }

            Assert.False(_history.CanUndo());
            Assert.Equal(10, counter);
        }
    }
}
