using DuckSimulator.DanceBehavior.Impl;
using DuckSimulator.FlyBehavior.Impl;

namespace DuckSimulator.Ducks
{
    class ModelDuck : Duck
    {
        public ModelDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new QuackBehavior.Impl.QuackBehavior();
            DanceBehavior = new DanceNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm model duck");
        }
    }
}
