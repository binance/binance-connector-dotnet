namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class FiatOrderTransactionType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = FiatOrderTransactionType.DEPOSIT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}