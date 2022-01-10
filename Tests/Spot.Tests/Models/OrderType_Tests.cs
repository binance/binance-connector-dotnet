namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class OrderType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = OrderType.LIMIT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}