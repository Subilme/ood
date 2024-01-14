using Command.Commands;
using Command.Content;
using Command.Document;
using Xunit;

namespace EditorTests.Commands
{
    public class ResizeImageCommandTests
    {
        private static List<DocumentItem> _items = new List<DocumentItem> { new DocumentItem(new Image("obi-wan.jpg", 640, 480)) };

        [Fact]
        public void ResizeImage_Execute_SetNewSizeOfImage()
        {
            ResizeImageCommand command = new ResizeImageCommand(_items,
                new DocumentItem(new Image(_items[0].Image.Path, 1920, 1080)), 0);

            command.Execute();

            Assert.Equal(1920, _items[0].Image.Width);
            Assert.Equal(1080, _items[0].Image.Height);
        }

        [Fact]
        public void ResizeImage_Unexecute_BringBackOldSizeOfImage()
        {
            ResizeImageCommand command = new ResizeImageCommand(_items,
                new DocumentItem(new Image(_items[0].Image.Path, 1920, 1080)), 0);

            command.Execute();
            command.Unexecute();

            Assert.Equal(640, _items[0].Image.Width);
            Assert.Equal(480, _items[0].Image.Height);
        }

        [Fact]
        public void ResizeImage_WrongParameters_ThrowException()
        {
            ResizeImageCommand command = new ResizeImageCommand(_items,
                new DocumentItem(new Image(_items[0].Image.Path, 1920, 1080)), 0);

            int width = 0;
            int height = 1080;

            Assert.Throws<ArgumentException>(() => {
                new ResizeImageCommand(_items, new DocumentItem(new Image(_items[0].Image.Path, 0, 1080)), 0);
            });
        }
    }
}
