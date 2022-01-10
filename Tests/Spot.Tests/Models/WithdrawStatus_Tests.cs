namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class WithdrawStatus_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = WithdrawStatus.EMAIL_SENT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}