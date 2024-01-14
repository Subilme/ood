using Xunit;
using CoffeeShop.Beverages;

namespace CoffeeShopTest
{
    public class CoffeeTest
    {
        [Fact]
        public void MakeLatteStandardPortion()
        {
            Latte latte = new Latte(CoffeePortion.Standard);

            Assert.Equal(90, latte.Cost);
            Assert.Equal("Standard Latte", latte.Description);
        }

        [Fact]
        public void MakeLatteDoublePortion()
        {
            Latte latte = new Latte(CoffeePortion.Double);

            Assert.Equal(130, latte.Cost);
            Assert.Equal("Double Latte", latte.Description);
        }

        [Fact]
        public void MakeCappuccinoStandardPortion()
        {
            Cappuccino cappuccino = new Cappuccino(CoffeePortion.Standard);

            Assert.Equal(80, cappuccino.Cost);
            Assert.Equal("Standard Cappuccino", cappuccino.Description);
        }

        [Fact]
        public void MakeCappuccinoDoublePortion()
        {
            Cappuccino cappuccino = new Cappuccino(CoffeePortion.Double);

            Assert.Equal(120, cappuccino.Cost);
            Assert.Equal("Double Cappuccino", cappuccino.Description);
        }
    }
}
