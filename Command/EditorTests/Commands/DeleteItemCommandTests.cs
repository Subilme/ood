using Command.Commands;
using Command.Content;
using Command.Document;
using Command;
using Xunit;

namespace EditorTests.Commands
{
    public class DeleteItemCommandTests
    {
        private List<DocumentItem> _items = new List<DocumentItem>();

        [Fact]
        public void DeleteItem_IndexOutOfRange_ThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                new DeleteItemCommand(_items, 0);
            });
        }

        [Fact]
        public void DeleteItem_Execute_DeleteItemOnSpecifiedIndex()
        {
            _items.Add(new DocumentItem(new Paragraph("Hello")));
            _items.Add(new DocumentItem(new Paragraph("There")));

            DeleteItemCommand command = new DeleteItemCommand(_items, 1);
            command.Execute();

            Assert.Single(_items);
            Assert.Equal("Hello", _items[0].Paragraph.Text);
        }

        [Fact]
        public void DeleteItem_Unexecute_BringBackDeletedItem()
        {
            _items.Add(new DocumentItem(new Paragraph("Hello")));
            _items.Add(new DocumentItem(new Paragraph("There")));

            DeleteItemCommand command = new DeleteItemCommand(_items, 0);
            command.Execute();

            Assert.Single(_items);
            Assert.Equal("There", _items[0].Paragraph.Text);

            command.Unexecute();

            Assert.Equal(2, _items.Count);
            Assert.Equal("There", _items[1].Paragraph.Text);
        }
    }
}
