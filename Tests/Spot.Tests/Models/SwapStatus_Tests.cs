namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class SwapStatus_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = SwapStatus.PENDING_FOR_SWAP;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}