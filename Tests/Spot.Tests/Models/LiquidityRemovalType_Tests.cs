namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class LiquidityRemovalType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = LiquidityRemovalType.SINGLE;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}