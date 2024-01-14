using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class Cinnamon : CondimentDecorator
    {
        public override double CondimentCost => 20;
        public override string CondimentDescription => "Cinnamon";

        public Cinnamon(IBeverage beverage) : base(beverage) { }

    }
}
