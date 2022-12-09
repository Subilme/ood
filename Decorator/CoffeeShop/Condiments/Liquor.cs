using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public enum LiquorType
    {
        Nut,
        Chocolate
    }

    public class Liquor : CondimentDecorator
    {
        private LiquorType _type;
        public override double CondimentCost => 50;
        public override string CondimentDescription => $"{(_type == LiquorType.Nut ? "Nut" : "Chocolate")} Liquor";

        public Liquor(IBeverage beverage, LiquorType liquorType)
            : base(beverage)
        {
            _type = liquorType;
        }
    }
}
