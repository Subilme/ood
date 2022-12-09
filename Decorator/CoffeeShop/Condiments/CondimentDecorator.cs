using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public class CondimentDecorator : IBeverage
    {
        private IBeverage _beverage;

        public virtual string CondimentDescription { get; }
        public virtual double CondimentCost { get; }

        public string Description => $"{_beverage.Description}, {CondimentDescription}";

        public double Cost => _beverage.Cost + CondimentCost;

        protected CondimentDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }
    }
}
