//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.C2C.RestApi;

namespace Binance.C2C.Tests.RestApi;

[Trait("Category", "Native")]
public class StatusTests
{
    [Theory]
    [InlineData(418, typeof(BinanceRateLimitBanException))]
    [InlineData(429, typeof(BinanceTooManyRequestsException))]
    public async Task RateLimitsCarryRetryAfter(int status, Type kind)
    {
        using var server = new Loopback(_ => (status, """{"code":-1003,"msg":"Too many requests."}"""));
        server.Headers["Retry-After"] = "7";
        using var client = new C2CRestApi(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

        var error = await Assert.ThrowsAnyAsync<BinanceApiException>(() => client.GetC2CTradeHistoryAsync());

        Assert.IsType(kind, error);
        Assert.Equal(status, error.HttpStatus);
        Assert.Equal(TimeSpan.FromSeconds(7), error.RetryAfter);
    }
}
