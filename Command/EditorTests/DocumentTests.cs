using Command.Document;
using Xunit;

namespace EditorTests
{
    public class DocumentTests
    {
        private Document _document = new Document();

        [Fact]
        public void InitDocument_DocumentIsEmpty()
        {
            Assert.Empty(_document.Title);
            Assert.Equal(0, _document.GetItemsCount());
        }

        [Fact]
        public void SetTitle_SetNewTitleOnDocument()
        {
            _document.Title = "Tilt";

            Assert.Equal("Tilt", _document.Title);
        }

        [Fact]
        public void InsertParagraph_AddNewItemInDocument()
        {
            _document.InsertParagraph("Hello", 0);

            Assert.Equal(1, _document.GetItemsCount());
            Assert.Equal("Hello", _document.GetItem(0).Paragraph.Text);
        }

        [Fact]
        public void InsertImage_AddNewItemInDocument()
        {
            _document.InsertImage("obi-wan.jpg", 640, 480, 0);

            Assert.Equal(1, _document.GetItemsCount());
            Assert.Equal(640, _document.GetItem(0).Image.Width);
            Assert.Equal(480, _document.GetItem(0).Image.Height);
            Assert.NotEmpty(_document.GetItem(0).Image.Path);
        }

        [Fact]
        public void RemoveItem_DeleteItemOnSpecifiedIndex()
        {
            _document.InsertParagraph("Hello There", 0);
            _document.InsertImage("obi-wan.jpg", 640, 480, 1);

            Assert.Equal(2, _document.GetItemsCount());

            _document.RemoveItem(0);

            Assert.Equal(1, _document.GetItemsCount());
            Assert.NotNull(_document.GetItem(0).Image);
        }

        [Fact]
        public void ReplaceText_IndexOutOfRange_ThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => { _document.ReplaceText(1, "hi"); });
        }

        [Fact]
        public void ReplaceText_ItemIsImage_ThrowException()
        {
            _document.InsertImage("obi-wan.jpg", 640, 480, 0);

            Assert.Throws<NullReferenceException>(() => { _document.ReplaceText(0, "hi"); });
        }

        [Fact]
        public void ReplaceText_ItemIsParagraph_ChangeTextInParagraph()
        {
            _document.InsertParagraph("Hello", 0);
            _document.ReplaceText(0, "There");

            Assert.Equal("There", _document.GetItem(0).Paragraph.Text);
        }
    }
}
