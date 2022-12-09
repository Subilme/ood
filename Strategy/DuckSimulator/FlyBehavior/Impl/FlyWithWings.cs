namespace DuckSimulator.FlyBehavior.Impl
{
    public class FlyWithWings : IFlyBehavior
    {
        private int _countOfFly = 0;

        public void Fly()
        {
            _countOfFly++;
            Console.WriteLine("I'm flying with wings!!");
            Console.WriteLine($"Flight number {_countOfFly}");
        }
    }
}
