using CoffeeShop.Beverages;
using CoffeeShop.Condiments;

namespace CoffeeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Beverage beverage2 = new("Beverage");

            var latte = new Latte(CoffeePortion.Standard);
            var cinnamon = new Cinnamon(latte);
            var lemon = new Lemon(cinnamon, 2);
            var iceCubes = new IceCubes(lemon, 2, IceCubeType.Dry);
            var beverage = new ChocolateCrumbs(iceCubes, 2);

            Console.WriteLine($"{beverage.Description}, cost: {beverage.Cost}");

            var beverage1 = new ChocolateCrumbs(
                    new IceCubes(
                        new Lemon(
                            new Cinnamon(
                                new Latte(CoffeePortion.Standard)),
                            2),
                        2, IceCubeType.Dry),
                    2);

            Console.WriteLine($"{beverage.Description}, cost: {beverage.Cost}");
        }
    }
}