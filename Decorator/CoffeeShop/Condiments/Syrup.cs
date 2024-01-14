using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public enum SyrupType
    {
        Chocolate,
        Maple
    }

    public class Syrup : CondimentDecorator
    {
        private SyrupType _syrupType;

        public override double CondimentCost => 15;
        public override string CondimentDescription => $"{(_syrupType == SyrupType.Chocolate ? "Chocolate" : "Maple")} syrup";

        public Syrup(IBeverage beverage, SyrupType syrupType)
            : base(beverage)
        {
            _syrupType = syrupType;
        }
    }
}
