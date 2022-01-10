namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class FixedAndActivityProjectType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = FixedAndActivityProjectType.ACTIVITY;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}