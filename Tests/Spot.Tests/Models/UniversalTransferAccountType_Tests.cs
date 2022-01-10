namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class UniversalTransferAccountType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = UniversalTransferAccountType.SPOT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}