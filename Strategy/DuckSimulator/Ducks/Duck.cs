using DuckSimulator.DanceBehavior;
using DuckSimulator.FlyBehavior;
using DuckSimulator.QuackBehavior;

namespace DuckSimulator.Ducks
{
    abstract class Duck
    {
        public IFlyBehavior FlyBehavior { protected get; set; }
        public IQuackBehavior QuackBehavior { protected get; set; }
        public IDanceBehavior DanceBehavior { protected get; set; }

        public void Quack()
        {
            QuackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("I`m swimming");
        }

        public void Fly()
        {
            FlyBehavior.Fly();
        }

        public virtual void Dance()
        {
            DanceBehavior.Dance();
        }

        public virtual void Display() { }
    }
}
