using Xunit;
using CoffeeShop.Beverages;

namespace CoffeeShopTest
{
    public class MilkShakeTest
    {
        [Fact]
        public void MakeSmallMilkShake()
        {
            MilkShake milkShake = new MilkShake(ShakeSize.Small);

            Assert.Equal(50, milkShake.Cost);
            Assert.Equal("Small Milkshake", milkShake.Description);
        }

        [Fact]
        public void MakeMediumMilkShake()
        {
            MilkShake milkShake = new MilkShake(ShakeSize.Medium);

            Assert.Equal(60, milkShake.Cost);
            Assert.Equal("Medium Milkshake", milkShake.Description);
        }

        [Fact]
        public void MakeLargeMilkShake()
        {
            MilkShake milkShake = new MilkShake(ShakeSize.Large);

            Assert.Equal(80, milkShake.Cost);
            Assert.Equal("Large Milkshake", milkShake.Description);
        }
    }
}
