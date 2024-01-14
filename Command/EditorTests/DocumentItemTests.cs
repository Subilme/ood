using Command.Content;
using Command.Document;
using Command;
using Xunit;

namespace EditorTests
{
    public class DocumentItemTests
    {
        private History _history;

        #region Test DocumentItem

        [Fact]
        public void CreateDocumentItem_Image_CreateNewItemWithImage()
        {
            Image image = new Image("obi-wan.jpg", 640, 480);
            DocumentItem item = new DocumentItem(image);

            Assert.Null(item.Paragraph);
            Assert.Equal(image.Path, item.Image.Path);
            Assert.Equal(image.Width, item.Image.Width);
            Assert.Equal(image.Height, item.Image.Height);
        }

        [Fact]
        public void CreateDocumentItem_Paragraph_CreateNewItemWithParagraph()
        {
            Paragraph paragraph = new Paragraph("Hello");
            DocumentItem item = new DocumentItem(paragraph);

            Assert.Null(item.Image);
            Assert.Equal(paragraph.Text, item.Paragraph.Text);
        }

        #endregion

        #region Test ConstDocumentItem

        [Fact]
        public void CreateConstDocumentItem_Image_CreateNewItemWithImage()
        {
            Image image = new Image("obi-wan.jpg", 640, 480);
            ConstDocumentItem item = new ConstDocumentItem(image);

            Assert.Null(item.Paragraph);
            Assert.Equal(image.Path, item.Image.Path);
            Assert.Equal(image.Width, item.Image.Width);
            Assert.Equal(image.Height, item.Image.Height);
        }

        [Fact]
        public void CreateConstDocumentItem_Paragraph_CreateNewItemWithParagraph()
        {
            Paragraph paragraph = new Paragraph("Hello");
            ConstDocumentItem item = new ConstDocumentItem(paragraph);

            Assert.Null(item.Image);
            Assert.Equal(paragraph.Text, item.Paragraph.Text);
        }

        #endregion
    }
}
