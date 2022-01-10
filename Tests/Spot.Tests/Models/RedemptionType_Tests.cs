namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class RedemptionType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = RedemptionType.FAST;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}