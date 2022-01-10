namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class SortBy_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = SortBy.START_TIME;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}