namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class FuturesTransferType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}