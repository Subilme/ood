using Shapes;
using Shapes.Shapes;
using Xunit;

namespace ShapesTests
{
    public class PictureDraftTests
    {
        [Fact]
        public void InitPictureDraft()
        {
            PictureDraft draft = new PictureDraft();
            
            Assert.Equal(0, draft.GetShapesCount());
        }

        [Fact]
        public void AddShapesToDraft()
        {
            PictureDraft draft = new PictureDraft();
            Triangle triangle = new Triangle(new Point(15, 21), new Point(20, 16), new Point(6, 2), Color.Black);
            Ellipse ellipse = new Ellipse(new Point(6, 9), 15, 9, Color.Green);

            draft.AddShape(ellipse);
            draft.AddShape(triangle);

            Assert.Equal(2, draft.GetShapesCount());
        }

        [Fact]
        public void GetShapeFromDraft()
        {
            PictureDraft draft = new PictureDraft();
            Triangle triangle = new Triangle(new Point(15, 21), new Point(20, 16), new Point(6, 2), Color.Black);
            Ellipse ellipse = new Ellipse(new Point(6, 9), 15, 9, Color.Green);

            draft.AddShape(ellipse);
            draft.AddShape(triangle);

            Assert.Equal(triangle, draft.GetShape(1));
        }

        [Fact]
        public void GetShapeFromDraftOutOfRange_ThrowIndexOutOfRangeException()
        {
            PictureDraft draft = new PictureDraft();
            Assert.Throws<IndexOutOfRangeException>(() => draft.GetShape(0));
        }
    }
}
