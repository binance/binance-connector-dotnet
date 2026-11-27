//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Security.Cryptography;

namespace Binance.Common.Tests;

/// <summary>What the configuration of the REST client does on the wire (retries, headers, keys, time unit).</summary>
[Trait("Category", "Native")]
public sealed class RestBehaviorTests
{
    private static readonly RestRequest Get = new("GET", "/api/v3/time");

    private static RestApiClient Client(Loopback server, Action<RestApiConfig>? configure = null)
    {
        var config = new RestApiConfig { BasePath = server.Url, ApiKey = "k", ApiSecret = "s", Retries = 0 };
        configure?.Invoke(config);
        return new RestApiClient(config);
    }

    [Theory]
    [InlineData("GET", 503, 3, 3)]
    [InlineData("DELETE", 503, 3, 3)]
    [InlineData("POST", 503, 3, 1)]
    [InlineData("GET", 400, 3, 1)]
    [InlineData("GET", 503, 0, 1)]
    public async Task OnlyGetAndDeleteAreRetriedOnServerErrors(string method, int status, int retries, int attempts)
    {
        using var server = new Loopback(_ => (status, "{}"));
        using var client = Client(server, c => { c.Retries = retries; c.Backoff = TimeSpan.FromMilliseconds(1); });

        await Assert.ThrowsAnyAsync<BinanceException>(() => client.SendAsync(new RestRequest(method, "/x"), TestJson.Default.TimeDto));

        Assert.Equal(attempts, server.Requests.Count);
    }

    [Fact]
    public async Task ARetryThatSucceedsReturnsTheResponse()
    {
        var calls = 0;
        using var server = new Loopback(_ => Interlocked.Increment(ref calls) < 3 ? (502, "{}") : (200, """{"serverTime":5}"""));
        using var client = Client(server, c => { c.Retries = 3; c.Backoff = TimeSpan.FromMilliseconds(1); });

        var response = await client.SendAsync(Get, TestJson.Default.TimeDto);

        Assert.Equal(5, response.Data()!.ServerTime);
        Assert.Equal(3, server.Requests.Count);
    }

    [Fact]
    public async Task CustomHeadersAndCompressionAreSent()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var client = Client(server, c => c.CustomHeaders = new() { ["X-Trace"] = "abc" });
        using var plain = Client(server, c => c.Compression = false);

        await client.SendAsync(Get, TestJson.Default.TimeDto);
        await plain.SendAsync(Get, TestJson.Default.TimeDto);

        Assert.Equal("abc", server.Requests[0].Header("X-Trace"));
        Assert.Contains("gzip", server.Requests[0].Header("Accept-Encoding"));
        Assert.DoesNotContain("gzip", server.Requests[1].Header("Accept-Encoding") ?? "");
    }

    [Fact]
    public async Task TheTimeUnitIsSentPerRequest()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var client = Client(server, c => c.TimeUnit = TimeUnit.Microsecond);

        await client.SendAsync(new RestRequest("GET", "/x", hasTimeUnit: true), TestJson.Default.TimeDto);

        Assert.Equal("MICROSECOND", server.Requests[0].Header("X-MBX-TIME-UNIT"));
    }

    [Fact]
    public async Task TheTimeOffsetShiftsTheTimestampOfSignedRequests()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var ahead = Client(server, c => c.TimeOffset = TimeSpan.FromHours(1));
        using var behind = Client(server, c => c.TimeOffset = TimeSpan.FromHours(-1));
        var request = new RestRequest("GET", "/api/v3/account", signed: true);

        var before = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        await ahead.SendAsync(request, TestJson.Default.TimeDto);
        await behind.SendAsync(request, TestJson.Default.TimeDto);
        var after = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        var hour = (long)TimeSpan.FromHours(1).TotalMilliseconds;
        var shifted = long.Parse(server.Requests[0].Param("timestamp")!);
        var back = long.Parse(server.Requests[1].Param("timestamp")!);
        Assert.InRange(shifted, before + hour, after + hour);
        Assert.InRange(back, before - hour, after - hour);
    }

    [Fact]
    public async Task RsaKeysSignWithSha256AndPassphraseOrFile()
    {
        using var rsa = RSA.Create(2048);
        var file = Path.GetTempFileName();
        try
        {
            File.WriteAllText(file, rsa.ExportPkcs8PrivateKeyPem());
            using var server = new Loopback(_ => (200, "{}"));
            using var pem = Client(server, c => { c.ApiSecret = null; c.PrivateKeyPem = rsa.ExportPkcs8PrivateKeyPem(); });
            using var encrypted = Client(server, c => { c.ApiSecret = null; c.PrivateKeyPem = rsa.ExportEncryptedPkcs8PrivateKeyPem("pw", new PbeParameters(PbeEncryptionAlgorithm.Aes256Cbc, HashAlgorithmName.SHA256, 1000)); c.PrivateKeyPassphrase = "pw"; });
            using var fromFile = Client(server, c => { c.ApiSecret = null; c.PrivateKeyFile = file; });

            foreach (var client in new[] { pem, encrypted, fromFile })
                await client.SendAsync(new RestRequest("GET", "/api/v3/account", signed: true), TestJson.Default.TimeDto);

            Assert.Equal(3, server.Requests.Count);
            foreach (var seen in server.Requests)
            {
                var query = seen.Query;
                var cut = query.LastIndexOf("&signature=", StringComparison.Ordinal);
                var signature = Convert.FromBase64String(Uri.UnescapeDataString(query[(cut + "&signature=".Length)..]));
                Assert.True(rsa.VerifyData(System.Text.Encoding.UTF8.GetBytes(query[..cut]), signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
            }
        }
        finally { File.Delete(file); }
    }

    [Fact]
    public async Task Ed25519KeysSign()
    {
        using var server = new Loopback(_ => (200, "{}"));
        using var client = Client(server, c => { c.ApiSecret = null; c.PrivateKeyPem = TestKeys.Ed25519Pem; });

        await client.SendAsync(new RestRequest("GET", "/api/v3/account", signed: true), TestJson.Default.TimeDto);

        Assert.Matches("signature=[A-Za-z0-9%+/=]{80,}", server.Requests[0].Url);
    }

    [Fact]
    public void AnUnusableKeyIsAConfigException()
    {
        using var server = new Loopback(_ => (200, "{}"));

        Assert.Throws<BinanceConfigException>(() => Client(server, c => { c.ApiSecret = null; c.PrivateKeyPem = "not a key"; }));
    }

    [Fact]
    public async Task TheResponseExposesHeadersAndTheBodyOfAnErrorTheCodeAndMessage()
    {
        using var server = new Loopback(_ => (400, """{"code":-1102,"msg":"Mandatory parameter missing."}"""));
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SendAsync(Get, TestJson.Default.TimeDto));

        Assert.Equal(-1102, error.Code);
        Assert.Contains("Mandatory parameter missing", error.Message);
        Assert.True(error.RequestSent);
    }

    [Fact]
    public async Task AnUnreachableHostIsANetworkExceptionThatSaysTheRequestWasNotSent()
    {
        using var client = new RestApiClient(new RestApiConfig { BasePath = "http://127.0.0.1:1", Retries = 0 });

        var error = await Assert.ThrowsAsync<BinanceNetworkException>(() => client.SendAsync(Get, TestJson.Default.TimeDto));

        Assert.False(error.RequestSent);
        Assert.NotEqual(0, error.TransportCode);
    }
}
