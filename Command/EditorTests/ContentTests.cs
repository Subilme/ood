using Command.Content;
using Command;
using Xunit;

namespace EditorTests
{
    public class ContentTests
    {
        private History _history;

        #region Test Paragraph

        [Fact]
        public void CreateParagraph_CorrectParameters_MakeNewParagraph()
        {
            Paragraph paragraph = new Paragraph("Hello there");

            Assert.Equal("Hello there", paragraph.Text);
        }

        #endregion

        #region Test Image

        [Fact]
        public void CreateImage_FileDoesNotExist_ThrowException()
        {
            Assert.Throws<FileNotFoundException>(() => { new Image("image.png", 640, 480); });
        }

        [Fact]
        public void CreateImage_WrongExtension_ThrowException()
        {
            Assert.Throws<FormatException>(() => { new Image("image.txt", 640, 480); });
        }

        [Fact]
        public void CreateImage_WrongSize_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => { new Image("obi-wan.jpg", -1, 480); });
            Assert.Throws<ArgumentException>(() => { new Image("obi-wan.jpg", 640, 11500); });
        }

        [Fact]
        public void CreateImage_CorrectParameters_MakeNewImage()
        {
            Image image = new Image("obi-wan.jpg", 1920, 1080);

            Assert.Equal(1920, image.Width);
            Assert.Equal(1080, image.Height);
            Assert.NotNull(image.Path);
        }

        #endregion
    }
}
