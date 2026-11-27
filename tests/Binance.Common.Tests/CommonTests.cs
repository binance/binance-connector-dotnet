//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using Binance.Common.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Binance.Common.Tests;

public class ConfigTests
{
    [Fact]
    public void InvalidConfigurationThrowsAConfigException()
    {
        Assert.Throws<BinanceConfigException>(() => new RestApiClient(new RestApiConfig { BasePath = "api.binance.com" }));
        Assert.Throws<BinanceConfigException>(() => new RestApiClient(new RestApiConfig { BasePath = "https://x", Retries = -1 }));
        Assert.Throws<BinanceConfigException>(() => new WebSocketApiConfig { Url = "https://x" }.Validate());
        Assert.Throws<ArgumentOutOfRangeException>(() => WebSocketMode.Pool(0));
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", TimeOffset = TimeSpan.FromSeconds(1), TimestampProvider = () => DateTimeOffset.UtcNow }.Validate());
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", ClientCertificatePem = "c" }.Validate());
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", ClientKeyFile = "k" }.Validate());
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", ClientCertificatePem = "c", ClientCertificateFile = "f", ClientKeyPem = "k" }.Validate());
        new RestApiConfig { BasePath = "https://x", ClientCertificateFile = "c", ClientKeyPem = "k" }.Validate();
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", PrivateKeyPem = "a", PrivateKeyFile = "b" }.Validate());
        Assert.Throws<ArgumentNullException>(() => new RestApiClient(null!));
    }

    [Fact]
    public void ConfigurationNeverPrintsSecrets()
    {
        var text = new RestApiConfig
        {
            BasePath = "https://x",
            ApiKey = "key-123",
            ApiSecret = "secret-456",
            PrivateKeyPem = "pem-789",
            PrivateKeyPassphrase = "pass-000",
            Proxy = new("proxy", 8080, ProxyProtocol.Http, "u", "proxy-pass"),
            CustomHeaders = new() { ["X-Token"] = "header-secret" },
            ClientCertificatePem = "client-cert",
            ClientKeyPem = "client-key-111",
            ClientKeyPassphrase = "client-pass-222",
        }.ToString();

        foreach (var secret in new[] { "key-123", "secret-456", "pem-789", "pass-000", "proxy-pass", "header-secret", "client-key-111", "client-pass-222" }) Assert.DoesNotContain(secret, text);
        Assert.Contains("https://x", text);
        Assert.Contains("X-Token", text); // header names stay visible
    }

    [Fact]
    public void TimeOffsetIsWholeMillisecondsOnTheWireAndValidated()
    {
        Assert.Contains("\"time_offset_ms\":-1500", new RestApiConfig { BasePath = "https://x", TimeOffset = TimeSpan.FromSeconds(-1.5) }.ToString());
        Assert.Contains("\"time_offset_ms\":250", new WebSocketApiConfig { Url = "wss://x", TimeOffset = TimeSpan.FromMilliseconds(250.4) }.ToString());
        Assert.Contains("\"time_offset_ms\":3600000", new WebSocketStreamsConfig { Url = "wss://x", TimeOffset = TimeSpan.FromHours(1) }.ToString());
        Assert.DoesNotContain("time_offset_ms", new RestApiConfig { BasePath = "https://x" }.ToString());
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", TimeOffset = TimeSpan.FromDays(2) }.Validate());
        Assert.Throws<BinanceConfigException>(() => new WebSocketStreamsConfig { Url = "wss://x", TimeOffset = TimeSpan.FromDays(-2) }.Validate());
        new RestApiConfig { BasePath = "https://x", TimeOffset = TimeSpan.FromDays(-1) }.Validate();
    }

    [Fact]
    public void DurationsAndProxyProtocolKeepTheirWireFormat()
    {
        var rest = new RestApiConfig { BasePath = "https://x", Timeout = TimeSpan.FromSeconds(2.5), Backoff = TimeSpan.FromMilliseconds(7), Proxy = new("p", 1, ProxyProtocol.Socks5h) }.ToString();
        Assert.Contains("\"timeout_ms\":2500", rest);
        Assert.Contains("\"backoff_ms\":7", rest);
        Assert.Contains("\"protocol\":\"socks5h\"", rest);
        var ws = new WebSocketApiConfig { Url = "wss://x", ReconnectDelay = TimeSpan.FromSeconds(3), ConnectTimeout = TimeSpan.FromSeconds(4) }.ToString();
        Assert.Contains("\"reconnect_delay_ms\":3000", ws);
        Assert.Contains("\"connect_timeout_ms\":4000", ws);
        Assert.Throws<BinanceConfigException>(() => new RestApiConfig { BasePath = "https://x", Timeout = TimeSpan.FromSeconds(-1) }.Validate());
    }

    [Fact]
    public void StreamNameFollowsTheTemplate()
    {
        Assert.Equal("btcusdt@depth5@100ms", StreamName.Build("/<symbol>@depth<levels>@<updateSpeed>", ("symbol", "BTCUSDT"), ("levels", "5"), ("updateSpeed", "100ms")));
        Assert.Equal("btcusdt@depth5", StreamName.Build("/<symbol>@depth<levels>@<updateSpeed>", ("symbol", "BTCUSDT"), ("levels", "5"), ("updateSpeed", null)));
        Assert.Equal("!miniTicker@arr", StreamName.Build("/!miniTicker@arr"));
        Assert.Equal("BTC@x", StreamName.Build("<symbol>@x", ("symbol", "BTC")));
        Assert.Equal("AbC123xYz@orderReportV2", StreamName.Build("/<listenKey>@orderReportV2", ("listenKey", "AbC123xYz")));
        Assert.Equal("AbC", StreamName.Build("/<listen_key>", ("listenKey", "AbC")));
    }
}

public class ExtensibleValueTests
{
    [Fact]
    public void KnownAndUnknownValuesRoundTrip()
    {
        var known = JsonSerializer.Deserialize("""{"side":"BUY"}""", TestJson.Default.TimeDto)!;
        Assert.Equal(Side.Buy, known.Side);

        var unknown = JsonSerializer.Deserialize("""{"side":"ICEBERG"}""", TestJson.Default.TimeDto)!;
        Assert.Equal("ICEBERG", unknown.Side!.Value.Value);
        Assert.NotEqual(Side.Buy, unknown.Side.Value);
        Assert.Contains("\"side\":\"ICEBERG\"", JsonSerializer.Serialize(unknown, TestJson.Default.TimeDto));
    }

    [Fact]
    public void ValueSemantics()
    {
        Side fromString = "BUY";
        Assert.True(fromString == Side.Buy);
        Assert.Equal(Side.Buy.GetHashCode(), fromString.GetHashCode());
        Assert.Equal("BUY", Side.Buy.ToString());
        Assert.Equal(string.Empty, default(Side).Value);
        Assert.Equal("BUY", Wire.Node(Side.Buy)!.ToString());
        Assert.Throws<ArgumentNullException>(() => new Side(null!));
    }

    [Fact]
    public void NumbersSentAsStringsDecode()
    {
        var dto = JsonSerializer.Deserialize("""{"serverTime":"1700000000000","price":"0.10000000"}""", TestJson.Default.TimeDto)!;
        Assert.Equal(1700000000000L, dto.ServerTime);
        Assert.Equal(0.1m, dto.Price);
    }
}

public class OneOfTests
{
    [Fact]
    public void ADecodedAlternativeIsDecodedOnDemand()
    {
        var circle = JsonSerializer.Deserialize("""{"radius":"1.50"}""", TestJson.Default.Shape)!;
        Assert.Equal(1.5m, circle.As<Circle>()!.Radius);
        var list = JsonSerializer.Deserialize("[1,2]", TestJson.Default.Shape)!;
        Assert.Null(list.As<Circle>());
        Assert.Equal([1L, 2L], list.As<List<long>>());
        Assert.Equal("[1,2]", JsonSerializer.Serialize(list, TestJson.Default.Shape));
    }

    [Fact]
    public void TryAsTellsAFailureFromAZero()
    {
        var zero = JsonSerializer.Deserialize("0", TestJson.Default.Shape)!;
        Assert.True(zero.TryAs<long>(out var n));
        Assert.Equal(0, n);
        var text = JsonSerializer.Deserialize("\"1.5\"", TestJson.Default.Shape)!;
        Assert.False(text.TryAs<long>(out _));
        var list = JsonSerializer.Deserialize("[1,2]", TestJson.Default.Shape)!;
        Assert.False(list.TryAs<long>(out _));
        Assert.False(list.TryAs<Circle>(out var circle));
        Assert.Null(circle);
        Assert.True(list.TryAs<List<long>>(out var numbers));
        Assert.Equal([1L, 2L], numbers);
        Assert.Throws<InvalidOperationException>(() => list.TryAs<TimeSpan>(out _));
    }
}

public class DependencyInjectionTests
{
    private sealed record FakeClient(RestApiConfig? Config)
    {
        public static FakeClient Production(RestApiConfig? config = null) => new((config ?? new()) with { BasePath = "https://prod" });

        public static FakeClient Testnet(RestApiConfig? config = null) => new((config ?? new()) with { BasePath = "https://test" });
    }

    private sealed record FakeStreams(WebSocketStreamsConfig? Config)
    {
        public static FakeStreams Demo(WebSocketStreamsConfig? config = null) => new(config);
    }

    [Fact]
    public void ClientsAreRegisteredWithTheirFactoryAndOptions()
    {
        var services = new ServiceCollection();
        services.AddBinanceRestApi<FakeClient>(FakeClient.Testnet, o => o.ApiKey = "k");
        services.AddBinanceWebSocketStreams<FakeStreams>(FakeStreams.Demo, o => o.Mode = WebSocketMode.Pool(3));
        using var provider = services.BuildServiceProvider();

        var rest = provider.GetRequiredService<FakeClient>();
        Assert.Equal("https://test", rest.Config!.BasePath);
        Assert.Equal("k", rest.Config.ApiKey);
        Assert.Same(rest, provider.GetRequiredService<FakeClient>());
        Assert.Equal(WebSocketMode.Pool(3), provider.GetRequiredService<FakeStreams>().Config!.Mode);
    }

    [Fact]
    public void TheNameSelectsTheOptions()
    {
        var services = new ServiceCollection();
        services.AddBinanceRestApi<FakeClient>(FakeClient.Production, name: "custom");
        services.Configure<RestApiConfig>("custom", o => o.ApiKey = "bound");
        using var provider = services.BuildServiceProvider();

        Assert.Equal("bound", provider.GetRequiredService<FakeClient>().Config!.ApiKey);
    }

    [Fact]
    public void TheModeBindsFromText()
    {
        Assert.Equal(WebSocketMode.Single, WebSocketMode.Parse("single"));
        Assert.Equal(WebSocketMode.Pool(4), WebSocketMode.Parse(" Pool(4) "));
        Assert.Equal("Pool(4)", WebSocketMode.Pool(4).ToString());
        Assert.Throws<FormatException>(() => WebSocketMode.Parse("Pool(0)"));
        Assert.Throws<FormatException>(() => WebSocketMode.Parse("pool"));
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(WebSocketMode));
        Assert.Equal(WebSocketMode.Pool(2), converter.ConvertFromInvariantString("Pool(2)"));
    }
}

[Trait("Category", "Native")]
public class RestClientTests
{
    private static RestApiClient Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task TheTimestampProviderStampsSignedRequests()
    {
        using var server = new Loopback(_ => (200, "{}"));
        var calls = 0;
        using var client = new RestApiClient(new RestApiConfig
        {
            BasePath = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
            Retries = 0,
            TimestampProvider = () => { Interlocked.Increment(ref calls); return DateTimeOffset.FromUnixTimeMilliseconds(1234567890123); },
        });
        using var throwing = new RestApiClient(new RestApiConfig
        {
            BasePath = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
            Retries = 0,
            TimestampProvider = () => throw new InvalidOperationException("no clock"),
        });

        await client.SendAsync(new RestRequest("GET", "/api/v3/account", signed: true), TestJson.Default.TimeDto);
        await throwing.SendAsync(new RestRequest("GET", "/api/v3/account", signed: true), TestJson.Default.TimeDto);

        Assert.Contains("timestamp=1234567890123", server.Requests[0].Url);
        Assert.Equal(1, Volatile.Read(ref calls));
        Assert.Contains("timestamp=", server.Requests[1].Url); // the host clock
        Assert.DoesNotContain("timestamp=1234567890123", server.Requests[1].Url);
    }

    [Fact]
    public async Task SignedGetCarriesTimestampSignatureAndKey()
    {
        using var server = new Loopback(_ => (200, """{"serverTime":"1700000000000"}"""));
        server.Headers["X-MBX-USED-WEIGHT-1M"] = "7";
        using var client = Client(server);

        var response = await client.SendAsync(new RestRequest("GET", "/api/v3/account", signed: true).Query("omitZeroBalances", true), TestJson.Default.TimeDto);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("test-key", seen.Key);
        Assert.Contains("omitZeroBalances=true", seen.Url);
        Assert.Contains("timestamp=", seen.Url);
        Assert.Matches("signature=[0-9a-f]{64}", seen.Url);
        Assert.Equal(1700000000000L, response.Data()!.ServerTime);
        var limit = Assert.Single(response.RateLimits);
        Assert.Equal((RateLimitType.RequestWeight, RateLimitInterval.Minute, 1, 7L), (limit.RateLimitType, limit.Interval, limit.IntervalNum, limit.Count));
        Assert.Equal(200, response.Status);
    }

    [Fact]
    public async Task DecimalsAreSentExactlyAndBodiesAsForms()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var client = Client(server);

        await client.SendAsync(new RestRequest("POST", "/api/v3/order", signed: true).Query("quantity", 1.50m).Query("side", Side.Buy).Body("price", 0.1m).Body("n", 12345678901234L), TestJson.Default.TimeDto);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Contains("quantity=1.50", seen.Url);
        Assert.Contains("side=BUY", seen.Url);
        Assert.Contains("price=0.1", seen.Body);
        Assert.Contains("n=12345678901234", seen.Body);
    }

    [Theory]
    [InlineData(400, typeof(BinanceBadRequestException))]
    [InlineData(401, typeof(BinanceUnauthorizedException))]
    [InlineData(403, typeof(BinanceForbiddenException))]
    [InlineData(404, typeof(BinanceNotFoundException))]
    [InlineData(418, typeof(BinanceRateLimitBanException))]
    [InlineData(429, typeof(BinanceTooManyRequestsException))]
    [InlineData(500, typeof(BinanceServerException))]
    public async Task StatusMapsToTypedException(int status, Type expected)
    {
        using var server = new Loopback(_ => (status, """{"code":-1003,"msg":"Too many requests."}"""));
        server.Headers["Retry-After"] = "7";
        using var client = Client(server);

        var error = await Assert.ThrowsAnyAsync<BinanceApiException>(() => client.SendAsync(new RestRequest("GET", "/api/v3/ping"), TestJson.Default.TimeDto));

        Assert.IsType(expected, error);
        Assert.IsAssignableFrom<BinanceException>(error);
        Assert.Equal(status, error.HttpStatus);
        Assert.Equal(-1003, error.Code);
        if (status is 418 or 429) Assert.Equal(TimeSpan.FromSeconds(7), error.RetryAfter);
        // The response that caused the error.
        Assert.Equal("""{"code":-1003,"msg":"Too many requests."}""", error.Body);
        Assert.Equal("7", error.Headers["retry-after"]);
    }

    [Fact]
    public async Task ABodyThatDoesNotDecodeFailsOnlyWhenItIsRead()
    {
        using var server = new Loopback(_ => (200, """{"serverTime":"not a number"}"""));
        using var client = Client(server);

        var response = await client.SendAsync(new RestRequest("GET", "/api/v3/time"), TestJson.Default.TimeDto);

        Assert.Equal(200, response.Status);
        Assert.Throws<BinanceClientException>(() => response.Data());
        Assert.Throws<BinanceClientException>(() => response.Data());
    }

    [Fact]
    public async Task TheUserAgentNamesTheProductAndTheRuntime()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var named = new RestApiClient(new RestApiConfig { BasePath = server.Url, Retries = 0 }, "spot", typeof(RestApiClient).Assembly);
        using var explicitly = new RestApiClient(new RestApiConfig { BasePath = server.Url, Retries = 0, UserAgent = "mine/1" }, "spot", typeof(RestApiClient).Assembly);
        using var plain = new RestApiClient(new RestApiConfig { BasePath = server.Url, Retries = 0 });

        await named.SendAsync(new RestRequest("GET", "/a"), TestJson.Default.TimeDto);
        await explicitly.SendAsync(new RestRequest("GET", "/b"), TestJson.Default.TimeDto);
        await plain.SendAsync(new RestRequest("GET", "/c"), TestJson.Default.TimeDto);

        Assert.Matches(@"^binance-connector-dotnet/spot/\d+\.\d+\.\d+ \(\.NET/[\d.]+; (windows|macos|linux); [a-z0-9]+\)$", server.Requests[0].Header("User-Agent"));
        Assert.Equal("mine/1", server.Requests[1].Header("User-Agent"));
        Assert.StartsWith("binance-connector-dotnet/common/", server.Requests[2].Header("User-Agent"));
    }

    [Fact]
    public async Task ModelsAndListsOfModelsAreSentAsJson()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var client = Client(server);
        var one = new TimeDto { ServerTime = 1, Price = 1.50m, Side = "FUTURE" };

        await client.SendAsync(
            new RestRequest("POST", "/x", signed: true).Query("orders", Wire.Json(new List<TimeDto> { one }, TestJson.Default.ListTimeDto)).Body("order", Wire.Json(one, TestJson.Default.TimeDto)),
            TestJson.Default.TimeDto);

        var seen = Assert.Single(server.Requests);
        Assert.Contains("\"serverTime\":1", seen.Param("orders"), StringComparison.Ordinal);
        Assert.Contains("\"side\":\"FUTURE\"", seen.Param("order"), StringComparison.Ordinal);
    }

    [Fact]
    public async Task RefusedConnectionIsANetworkException()
    {
        using var client = new RestApiClient(new RestApiConfig { BasePath = "http://127.0.0.1:1", Retries = 0 });

        var error = await Assert.ThrowsAsync<BinanceNetworkException>(() => client.SendAsync(new RestRequest("GET", "/x"), TestJson.Default.TimeDto));

        Assert.NotEqual(0, error.TransportCode);
        Assert.NotEmpty(error.TransportCategory);
        Assert.False(error.RequestSent);
    }

    [Fact]
    public async Task CancellingTheTokenCancelsTheRequestInFlight()
    {
        using var server = new Loopback(_ => (200, "{}")) { Delay = TimeSpan.FromSeconds(5) };
        using var client = Client(server);
        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(200));

        var started = DateTime.UtcNow;
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => client.SendAsync(new RestRequest("GET", "/x"), TestJson.Default.TimeDto, cts.Token));

        Assert.True(DateTime.UtcNow - started < TimeSpan.FromSeconds(3));
    }

    [Fact]
    public async Task AnAlreadyCancelledTokenSendsNothing()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var client = Client(server);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => client.SendAsync(new RestRequest("GET", "/x"), TestJson.Default.TimeDto, new CancellationToken(true)));

        Assert.Empty(server.Requests);
    }

    [Fact]
    public async Task DisposingTheClientCancelsPendingRequests()
    {
        using var server = new Loopback(_ => (200, "{}")) { Delay = TimeSpan.FromSeconds(5) };
        var client = Client(server);

        var call = client.SendAsync(new RestRequest("GET", "/x"), TestJson.Default.TimeDto);
        await Task.Delay(300);
        client.Dispose();

        await Assert.ThrowsAnyAsync<BinanceException>(() => call.WaitAsync(TimeSpan.FromSeconds(5)));
        client.Dispose(); // idempotent
    }
}

public class UrlTests
{
    [Fact]
    public void EveryEndpointIsAWellFormedAbsoluteUrl()
    {
        var endpoints = typeof(BinanceUrls).GetFields().ToList();
        Assert.NotEmpty(endpoints);
        foreach (var field in endpoints)
        {
            // Read-only fields, not constants: their values are not compiled into the code that uses them.
            Assert.True(field.IsStatic && field.IsInitOnly, field.Name);
            var value = (string)field.GetValue(null)!;
            Assert.True(Uri.TryCreate(value, UriKind.Absolute, out var uri), $"{field.Name}: {value}");
            var websocket = field.Name.Contains("WebSocket", StringComparison.Ordinal);
            Assert.True(websocket ? uri.Scheme is "ws" or "wss" : uri.Scheme is "http" or "https", $"{field.Name}: {value}");
            Assert.Matches("^[A-Za-z0-9]+(RestApi|WebSocketApi|WebSocketStreams)(Prod|Testnet|Demo|Market)Url$", field.Name);
        }
    }

    [Fact]
    public void TheFuturesDemoEndpointsAreTheDemoHosts()
    {
        Assert.Equal("https://demo-fapi.binance.com", BinanceUrls.DerivativesTradingUsdsFuturesRestApiDemoUrl);
        Assert.Equal("wss://demo-fstream.binance.com", BinanceUrls.DerivativesTradingUsdsFuturesWebSocketStreamsDemoUrl);
        Assert.Equal("https://demo-dapi.binance.com", BinanceUrls.DerivativesTradingCoinFuturesRestApiDemoUrl);
        Assert.Equal("wss://demo-dstream.binance.com", BinanceUrls.DerivativesTradingCoinFuturesWebSocketStreamsDemoUrl);
    }

    [Fact]
    public void EveryModuleThatHasAnEndpointHasAProductionOne()
    {
        var names = typeof(BinanceUrls).GetFields().Where(f => f.IsLiteral).Select(f => f.Name).ToHashSet();
        foreach (var name in names.Where(n => !n.EndsWith("ProdUrl", StringComparison.Ordinal) && !n.EndsWith("MarketUrl", StringComparison.Ordinal)))
            Assert.Contains(System.Text.RegularExpressions.Regex.Replace(name, "(Testnet|Demo)Url$", "ProdUrl"), names);
    }
}
