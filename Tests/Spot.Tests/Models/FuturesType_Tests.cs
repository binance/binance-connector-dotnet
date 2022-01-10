namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class FuturesType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = FuturesType.USDT_MARGINED_FUTURES;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}