namespace CoffeeShop.Beverages
{
    public enum ShakeSize
    {
        Small,
        Medium,
        Large
    }

    public class MilkShake : Beverage
    {
        private string _description = "";
        public override string Description => $"{_description} {base.Description}";

        public MilkShake(ShakeSize shakeSize) 
            : base("Milkshake")
        {
            switch (shakeSize)
            {
                case ShakeSize.Small:
                    _description = "Small";
                    Cost = 50;
                    break;
                case ShakeSize.Medium:
                    _description = "Medium";
                    Cost = 60;
                    break;
                case ShakeSize.Large:
                    _description = "Large";
                    Cost = 80;
                    break;
            }
        }
    }
}
