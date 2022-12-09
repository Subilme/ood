using DuckSimulator.DanceBehavior.Impl;
using DuckSimulator.FlyBehavior.Impl;

namespace DuckSimulator.Ducks
{
    class RedHeadDuck : Duck
    {
        public RedHeadDuck()
        {
            FlyBehavior = new FlyWithWings();
            QuackBehavior = new QuackBehavior.Impl.QuackBehavior();
            DanceBehavior = new DanceMenuet();
        }

        public override void Display()
        {
            Console.WriteLine("I'm redhead duck");
        }
    }
}
