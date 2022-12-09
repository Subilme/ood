using DuckSimulator.Ducks;
using DuckSimulator.FlyBehavior.Impl;

namespace DuckSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MallardDuck mallardDuck = new MallardDuck();
            PlayWithDuck(mallardDuck);

            RedHeadDuck redheadDuck = new RedHeadDuck();
            PlayWithDuck(redheadDuck);

            RubberDuck rubberDuck = new RubberDuck();
            PlayWithDuck(rubberDuck);

            DecoyDuck decoyDuck = new DecoyDuck();
            PlayWithDuck(decoyDuck);

            ModelDuck modelDuck = new ModelDuck();
            PlayWithDuck(modelDuck);
            Console.WriteLine("Changing behavior");
            modelDuck.FlyBehavior = new FlyWithWings();
            PlayWithDuck(modelDuck);
        }

        private static void DrawDuck(Duck duck)
        {
            duck.Display();
        }

        private static void PlayWithDuck(Duck duck)
        {
            DrawDuck(duck);
            duck.Quack();
            duck.Fly();
            duck.Fly();
            duck.Fly();
            duck.Dance();
            Console.WriteLine();
        }
    }
}