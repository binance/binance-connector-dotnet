namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class IsolatedMarginAccountTransferType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = IsolatedMarginAccountTransferType.SPOT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}