namespace CoffeeShop.Beverages
{

    public class Latte : Coffee
    {
        private string _description = "";
        public override string Description => $"{_description} {base.Description}";

        public Latte(CoffeePortion portion) 
            : base("Latte")
        {
            switch (portion)
            {
                case CoffeePortion.Standard:
                    _description = "Standard";
                    Cost = 90;
                    break;
                case CoffeePortion.Double:
                    _description = "Double";
                    Cost = 130;
                    break;
            }
        }
    }
}
