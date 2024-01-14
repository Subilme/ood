using CoffeeShop.Beverages;

namespace CoffeeShop.Condiments
{
    public enum IceCubeType
    {
        Dry,
        Water
    }

    public class IceCubes : CondimentDecorator
    {
        private uint _quantity;
        private IceCubeType _type;

        public override double CondimentCost => (_type == IceCubeType.Dry ? 10 : 5) * _quantity;
        public override string CondimentDescription => $"{(_type == IceCubeType.Dry ? "dry" : "water")} ice cubes x{_quantity}";

        public IceCubes(IBeverage beverage, uint quantity, IceCubeType type = IceCubeType.Water)
            : base(beverage)
        {
            _quantity = quantity;
            _type = type;
        }
    }
}
