namespace Binance.Common.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class BinanceParametersUtils_Tests
    {
        [Fact]
        public void EnsureOnlyOneValidKey()
        {
            var parameters = new Dictionary<string, object> { { "symbol", "BNBBTC" } };
            var validKeys = new string[] { "symbol", "symbols", "permissions" };
            BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, validKeys);
        }

        [Fact]
        public void EnsureOnlyOneValidKey_Throws()
        {
            var parameters = new Dictionary<string, object> { { "symbol", "BNBBTC" }, { "symbols", "BNBBTC" } };
            var validKeys = new string[] { "symbol", "symbols", "permissions" };
            Assert.Throws<System.ArgumentException>(() => BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, validKeys));
        }
    }
}
