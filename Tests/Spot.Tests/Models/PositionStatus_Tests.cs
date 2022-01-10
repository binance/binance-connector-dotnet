namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class PositionStatus_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = PositionStatus.HOLDING;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}