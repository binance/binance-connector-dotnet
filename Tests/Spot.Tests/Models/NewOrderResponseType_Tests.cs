namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class NewOrderResponseType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = NewOrderResponseType.ACK;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}