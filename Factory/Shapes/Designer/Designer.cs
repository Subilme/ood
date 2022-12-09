using Shapes.Factory;

namespace Shapes.Designer
{
    public class Designer : IDesigner
    {
        private IShapeFactory _factory;

        public Designer(IShapeFactory factory)
        {
            _factory = factory;
        }

        public PictureDraft CreateDraft()
        {
            PictureDraft draft = new PictureDraft();
            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();

                if (command == "help")
                {
                    Console.WriteLine("rectangle [color] [left top point x] [left top point y] [right bottom x] [right bottom y]");
                    Console.WriteLine("triangle [color] [first vertex x] [first vertex y] [second vertex x] [second vertex y] [third vertex x] [third vertex y]");
                    Console.WriteLine("ellipse [color] [center point x] [center point y] [horizontal radius] [vertical radius]");
                    Console.WriteLine("regular_polygon [color] [vertex count] [center point x] [center point y] [radius]");
                }

                try
                {
                    draft.AddShape(_factory.CreateShape(command));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return draft;
        }
    }
}
