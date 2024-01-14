using DuckSimulator.DanceBehavior.Impl;
using DuckSimulator.FlyBehavior.Impl;

namespace DuckSimulator.Ducks
{
    class MallardDuck : Duck
    {
        public MallardDuck()
        {
            FlyBehavior = new FlyWithWings();
            QuackBehavior = new QuackBehavior.Impl.QuackBehavior();
            DanceBehavior = new DanceWaltz();
        }

        public override void Display()
        {
            Console.WriteLine("I'm mallard duck");
        }
    }
}
