namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class CrossMarginTransferType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = CrossMarginTransferType.ROLL_IN;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}