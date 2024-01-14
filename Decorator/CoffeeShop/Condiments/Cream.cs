using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class Cream : CondimentDecorator
    {
        public override double CondimentCost => 25;
        public override string CondimentDescription => "Cream";

        public Cream(IBeverage beverage) : base(beverage) { }
    }
}
