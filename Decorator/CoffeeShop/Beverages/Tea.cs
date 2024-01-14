namespace CoffeeShop.Beverages
{
    public enum TeaSort
    {
        Black,
        Green,
        White,
        Yellow
    }

    public class Tea : Beverage
    {
        private string _description = "";
        public override string Description => $"{_description} {base.Description}";

        public Tea(TeaSort teaSort) 
            : base("Tea") 
        {
            switch (teaSort)
            {
                case TeaSort.Black:
                    _description = "Black";
                    break;
                case TeaSort.Green:
                    _description = "Green";
                    break;
                case TeaSort.White:
                    _description = "White";
                    break;
                case TeaSort.Yellow:
                    _description = "Yellow";
                    break;
            }
            Cost = 30;
        }
    }
}
