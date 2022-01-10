namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class LendingType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = LendingType.DAILY;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}