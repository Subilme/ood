namespace CoffeeShop.Beverages
{
    public class Cappuccino : Coffee
    {
        private string _description = "";
        public override string Description => $"{_description} {base.Description}";

        public Cappuccino(CoffeePortion portion) 
            : base("Cappuccino") 
        {
            switch (portion)
            {
                case CoffeePortion.Standard:
                    _description = "Standard";
                    Cost = 80;
                    break;
                case CoffeePortion.Double:
                    _description = "Double";
                    Cost = 120;
                    break;
            }
        }
    }
}
