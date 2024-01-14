using DuckSimulator.DanceBehavior.Impl;
using DuckSimulator.FlyBehavior.Impl;
using DuckSimulator.QuackBehavior.Impl;

namespace DuckSimulator.Ducks
{
    class RubberDuck : Duck
    {
        public RubberDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new SqueakBehavior();
            DanceBehavior = new DanceNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm rubber duck");
        }
    }
}
