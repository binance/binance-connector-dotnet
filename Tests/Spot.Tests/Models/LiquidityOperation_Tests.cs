namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class LiquidityOperation_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = LiquidityOperation.ADD;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}