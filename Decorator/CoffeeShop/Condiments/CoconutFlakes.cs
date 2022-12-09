using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class CoconutFlakes : CondimentDecorator
    {
        private uint _mass;

        public override double CondimentCost => 1.0 * _mass;
        public override string CondimentDescription => $"Coconut flakes {_mass}g";

        public CoconutFlakes(IBeverage beverage, uint mass)
            :base(beverage)
        { 
            _mass = mass;
        }
    }
}
