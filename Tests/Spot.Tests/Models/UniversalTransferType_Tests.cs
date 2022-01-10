namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class UniversalTransferType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = UniversalTransferType.MAIN_C2C;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}