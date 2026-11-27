//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Diagnostics;
using System.Text.Json;

namespace Binance.Common.Tests;

/// <summary>Custom CAs and the certificate validator over <c>wss</c>, for the WebSocket API and the WebSocket Streams.</summary>
[Trait("Category", "Native")]
public class TlsWebSocketTests
{
    private static string Config(string url, string? caPem = null, bool caOnly = false) =>
        $$"""{"url":"{{url}}","connect_timeout_ms":3000,"timeout_ms":2000,"reconnect_delay_ms":50{{(caPem is null ? "" : ",\"ca_pem\":" + JsonSerializer.Serialize(caPem))}}{{(caOnly ? ",\"ca_only\":true" : "")}}}""";

    private static async Task ConnectAsync(bool streams, string url, string? caPem = null, ServerCertificateValidator? validator = null, bool caOnly = false)
    {
        if (streams)
        {
            using var client = new WebSocketStreams(Config(url, caPem, caOnly), null, validator);
            await client.ConnectAsync();
            Assert.True(client.IsConnected);
        }
        else
        {
            using var client = new WebSocketApi(Config(url, caPem, caOnly), validator);
            await client.ConnectAsync();
            Assert.True(client.IsConnected);
            // The connection works end to end, not only the handshake.
            Assert.Contains("rateLimits", await client.SendAsync("""{"method":"ping"}"""), StringComparison.Ordinal);
        }
    }

    private static MiniWsServer Server(TestCertificate certificate) => new(MiniWsServer.ApiReplies(null), certificate.Certificate);

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task AnUntrustedCertificateIsRejectedUntilTheCaIsAdded(bool streams)
    {
        using var certificate = new TestCertificate();
        using var server = Server(certificate);

        var error = await Assert.ThrowsAsync<BinanceNetworkException>(() => ConnectAsync(streams, server.Url));
        Assert.NotEqual(0, error.TransportCode);

        await ConnectAsync(streams, server.Url, certificate.CaPem);
        await ConnectAsync(streams, server.Url, certificate.CaPem, caOnly: true);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task TheValidatorSeesTheDerCertificateAndDecides(bool streams)
    {
        using var certificate = new TestCertificate();
        using var server = Server(certificate);
        var seen = new List<(string Thumbprint, int Depth, bool Preverified)>();
        var accept = true;
        ServerCertificateValidator validator = (c, depth, preverified) =>
        {
            lock (seen) seen.Add((c.Thumbprint, depth, preverified));
            return accept && preverified;
        };

        await ConnectAsync(streams, server.Url, certificate.CaPem, validator);
        Assert.Contains(seen, s => s.Depth == 0 && s.Preverified && s.Thumbprint == certificate.Certificate.Thumbprint);

        accept = false;
        await Assert.ThrowsAsync<BinanceNetworkException>(() => ConnectAsync(streams, server.Url, certificate.CaPem, validator));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task PinningAcceptsOnlyThePinnedCertificate(bool streams)
    {
        using var certificate = new TestCertificate();
        using var other = new TestCertificate();
        using var server = Server(certificate);

        // No CA is added, so nothing is preverified: the pin alone decides.
        await ConnectAsync(streams, server.Url, validator: (c, depth, _) => depth != 0 || c.Thumbprint == certificate.Certificate.Thumbprint);
        await Assert.ThrowsAsync<BinanceNetworkException>(() => ConnectAsync(streams, server.Url, validator: (c, depth, _) => depth != 0 || c.Thumbprint == other.Certificate.Thumbprint));
        await Assert.ThrowsAsync<BinanceNetworkException>(() => ConnectAsync(streams, server.Url, certificate.CaPem, (_, _, _) => throw new InvalidOperationException("boom")));
    }

    [Fact]
    public async Task DisconnectCanBeCancelledWhileARequestIsPending()
    {
        using var server = new MiniWsServer((_, _, _) => null); // never answers
        using var api = new WebSocketApi($$"""{"url":"{{server.Url}}","timeout_ms":60000,"reconnect_delay_ms":50}""");
        await api.ConnectAsync();
        var pending = api.SendAsync("""{"method":"x"}""");
        Assert.True(await MiniWsServer.WaitFor(() => server.Received.Count == 1));
        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(200));
        var watch = Stopwatch.StartNew();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => api.DisconnectAsync(cts.Token));

        Assert.True(watch.Elapsed < TimeSpan.FromSeconds(3), $"took {watch.Elapsed}");
        api.Dispose(); // the pending request ends as cancelled
        await Assert.ThrowsAsync<BinanceCancelledException>(() => pending);
    }

    [Fact]
    public async Task DisconnectOfStreamsCanBeCancelled()
    {
        using var server = new MiniWsServer((_, _, _) => null);
        using var streams = new WebSocketStreams($$"""{"url":"{{server.Url}}","reconnect_delay_ms":50}""");
        await streams.ConnectAsync();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => streams.DisconnectAsync(cts.Token));
        streams.Dispose();
    }
}
