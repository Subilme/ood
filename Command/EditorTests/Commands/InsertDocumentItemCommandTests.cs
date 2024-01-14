using Command.Commands;
using Command.Content;
using Command.Document;
using Command;
using Xunit;

namespace EditorTests.Commands
{
    public class InsertDocumentItemCommandTests
    {
        private List<DocumentItem> _items = new List<DocumentItem>();
        private Paragraph _paragraph = new Paragraph("Hello");
        private Image _image = new Image("obi-wan.jpg", 640, 480);

        [Fact]
        public void InsertDocumentItem_IndexOutOfRange_ThrowException()
        {
            Assert.Empty(_items);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                new InsertDocumentItemCommand(_items, new DocumentItem(_paragraph), 2);
            });
        }

        [Fact]
        public void InsertDocumentItem_Execute_Paragraph_AddNewItem()
        {
            InsertDocumentItemCommand command = new InsertDocumentItemCommand(_items, new DocumentItem(_paragraph), 0);
            command.Execute();

            Assert.Single(_items);
            Assert.Equal(_paragraph, _items[0].Paragraph);
        }

        [Fact]
        public void InsertDocumentItem_Execute_Image_AddNewItem()
        {
            InsertDocumentItemCommand command = new InsertDocumentItemCommand(_items, new DocumentItem(_image), _items.Count);
            command.Execute();
    
            Assert.Single(_items);
            Assert.Equal(_image, _items[0].Image);
        }

        [Fact]
        public void InsertDocumentItem_Unexecute_RemoveLastAddedItem()
        {
            InsertDocumentItemCommand command = new InsertDocumentItemCommand(_items, new DocumentItem(_paragraph), 0);

            command.Execute();

            Assert.NotEmpty(_items);
            Assert.Equal(_paragraph, _items[0].Paragraph);

            command.Unexecute();

            Assert.Empty(_items);
        }
    }
}
