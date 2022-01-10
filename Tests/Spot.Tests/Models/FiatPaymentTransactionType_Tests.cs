namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class FiatPaymentTransactionType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = FiatPaymentTransactionType.BUY;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}