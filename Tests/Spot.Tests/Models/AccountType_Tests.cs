namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class AccountType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = AccountType.SPOT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}