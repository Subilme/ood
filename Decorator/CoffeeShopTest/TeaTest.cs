using Xunit;
using CoffeeShop.Beverages;

namespace CoffeeShopTest
{
    public class TeaTest
    {
        [Fact]
        public void MakeBlackTea()
        {
            Tea tea = new Tea(TeaSort.Black);

            Assert.Equal(30, tea.Cost);
            Assert.Equal("Black Tea", tea.Description);
        }

        [Fact]
        public void MakeGreenTea()
        {
            Tea tea = new Tea(TeaSort.Green);

            Assert.Equal(30, tea.Cost);
            Assert.Equal("Green Tea", tea.Description);
        }

        [Fact]
        public void MakeWhiteTea()
        {
            Tea tea = new Tea(TeaSort.White);

            Assert.Equal(30, tea.Cost);
            Assert.Equal("White Tea", tea.Description);
        }

        [Fact]
        public void MakeYellowTea()
        {
            Tea tea = new Tea(TeaSort.Yellow);

            Assert.Equal(30, tea.Cost);
            Assert.Equal("Yellow Tea", tea.Description);
        }
    }
}
