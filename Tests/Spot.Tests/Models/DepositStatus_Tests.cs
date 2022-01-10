namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class DepositStatus_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = DepositStatus.PENDING;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}