using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class ChocolateCrumbs : CondimentDecorator
    {
        private uint _mass;

        public override double CondimentCost => 2.0 * _mass;
        public override string CondimentDescription => $"Chocolate crumbs {_mass}g";

        public ChocolateCrumbs(IBeverage beverage, uint mass)
            : base(beverage)
        {
            _mass = mass;
        }
    }
}
