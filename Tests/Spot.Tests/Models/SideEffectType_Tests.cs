namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class SideEffectType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = SideEffectType.NO_SIDE_EFFECT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}