using Shapes.Canvas;

namespace Shapes
{
    public class Painter
    {
        public static void DrawPicture(PictureDraft draft, ICanvas canvas)
        {
            for (int i = 0; i < draft.GetShapesCount(); i++)
            {
                draft.GetShape(i).Draw(canvas);
            }
        }
    }
}
