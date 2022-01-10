namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class ProductStatus_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = ProductStatus.ALL;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}