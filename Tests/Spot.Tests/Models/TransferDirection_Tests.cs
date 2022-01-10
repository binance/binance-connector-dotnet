namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class TransferDirection_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = TransferDirection.TRANSFER_IN;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}