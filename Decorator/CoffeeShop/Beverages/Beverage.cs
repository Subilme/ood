namespace CoffeeShop.Beverages
{
    public class Beverage : IBeverage
    {
        public virtual string Description { get; protected set; }
        public double Cost { get; protected set; }

        public Beverage(string description)
        {
            Description = description;
        }
    }
}
