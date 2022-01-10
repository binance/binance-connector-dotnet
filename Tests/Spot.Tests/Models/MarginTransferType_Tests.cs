namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class MarginTransferType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = MarginTransferType.SPOT_TO_MARGIN;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}