namespace CoffeeShop.Beverages
{
    public enum CoffeePortion
    {
        Standard,
        Double
    }

    public class Coffee : Beverage
    {
        public Coffee(string description = "Coffee") 
            : base(description) 
        {
            Cost = 60;
        }
    }
}
