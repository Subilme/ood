using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class Chocolate : CondimentDecorator
    {
        private static int MAX_COUNT = 5;
        private int _sliceCount;

        public override double CondimentCost => 10 * _sliceCount;
        public override string CondimentDescription => $"Chocolate slices x{_sliceCount}";

        public Chocolate(IBeverage beverage, int sliceCount)
            : base(beverage)
        {
            _sliceCount = Math.Min(sliceCount, MAX_COUNT);
        }
    }
}
