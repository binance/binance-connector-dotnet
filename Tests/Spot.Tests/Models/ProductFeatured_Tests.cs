namespace Binance.Spot.Tests
{
    using Binance.Spot.Models;
    using Xunit;

    public class ProductFeatured_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = ProductFeatured.ALL;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}