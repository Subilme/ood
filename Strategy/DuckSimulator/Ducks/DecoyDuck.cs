using DuckSimulator.DanceBehavior.Impl;
using DuckSimulator.FlyBehavior.Impl;
using DuckSimulator.QuackBehavior.Impl;

namespace DuckSimulator.Ducks
{
    class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new MuteQuackBehavior();
            DanceBehavior = new DanceNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm decoy duck");
        }
    }
}
