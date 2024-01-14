using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class Lemon : CondimentDecorator
    {
        private uint _quantity;

        public override double CondimentCost => 10.0 * _quantity;
        public override string CondimentDescription => $"Lemon x{_quantity}";

        public Lemon(IBeverage beverage, uint quantity = 1)
            : base(beverage)
        {
            _quantity = quantity;
        }
    }
}
