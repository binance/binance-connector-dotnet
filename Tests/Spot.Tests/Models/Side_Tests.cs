namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class Side_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = Side.BUY;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}