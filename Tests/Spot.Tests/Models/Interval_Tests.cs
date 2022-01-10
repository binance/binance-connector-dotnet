namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class Interval_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = Interval.ONE_MINUTE;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}