using Xunit;
using CoffeeShop.Beverages;
using CoffeeShop.Condiments;

namespace CoffeeShopTest
{
    public class CondimentTest
    {
        [Fact]
        public void MakeLatteWithCream()
        {
            Latte latte = new Latte(CoffeePortion.Double);
            Cream latteWithCream = new Cream(latte);

            Assert.Equal(155, latteWithCream.Cost);
            Assert.Equal("Double Latte, Cream", latteWithCream.Description);
        }

        [Fact]
        public void MakeCappuccinoWithNutLiquor()
        {
            Cappuccino cappuccino = new Cappuccino(CoffeePortion.Standard);
            Liquor cappuccinoWithNutLiquor = new Liquor(cappuccino, LiquorType.Nut);

            Assert.Equal(130, cappuccinoWithNutLiquor.Cost);
            Assert.Equal("Standard Cappuccino, Nut Liquor", cappuccinoWithNutLiquor.Description);
        }

        [Fact]
        public void MakeMilkShakeWithChocolate()
        {
            MilkShake milkShake = new MilkShake(ShakeSize.Medium);
            Chocolate milkShakeWithChocolate = new Chocolate(milkShake, 8);

            Assert.Equal(110, milkShakeWithChocolate.Cost);
            Assert.Equal("Medium Milkshake, Chocolate slices x5", milkShakeWithChocolate.Description);
        }
    }
}
