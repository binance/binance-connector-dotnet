//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace Binance.Common.Tests;

// The tests that use the process-wide log (and the stress tests, which count threads and registry entries) run alone, not
// alongside the other tests.
[CollectionDefinition("Logging", DisableParallelization = true)]
public class LoggingCollection;

/// <summary>
/// Many clients, many requests, disposal and cancellation at awkward moments, against loopback servers.
/// The tests only check that nothing hangs, crashes or leaks, and that every operation ends in a defined way.
/// </summary>
[Collection("Logging")]
[Trait("Category", "Native")]
public class StressTests
{
    private static readonly TimeSpan Limit = TimeSpan.FromSeconds(15);

    private static readonly RestRequest Time = new("GET", "/api/v3/time");

    private static RestApiClient Rest(string url, Action<RestApiConfig>? configure = null)
    {
        var config = new RestApiConfig { BasePath = url, ApiKey = "k", ApiSecret = "s", Retries = 0, Timeout = TimeSpan.FromSeconds(10) };
        configure?.Invoke(config);
        return new RestApiClient(config);
    }

    private static string ApiConfig(string url) =>
        $$"""{"url":"{{url}}","timeout_ms":10000,"reconnect_delay_ms":50,"connect_timeout_ms":3000}""";

    private static string StreamsConfig(string url) =>
        $$"""{"url":"{{url}}","reconnect_delay_ms":50,"connect_timeout_ms":3000}""";

    // The table the native callbacks find their targets in; it must be empty when nothing is alive.
    private static int RegistryCount()
    {
        var registry = typeof(RestApiClient).Assembly.GetType("Binance.Common.Registry")!;
        var entries = (ICollection)registry.GetField("Entries", BindingFlags.NonPublic | BindingFlags.Static)!.GetValue(null)!;
        return entries.Count;
    }

    private static int Threads()
    {
        using var process = Process.GetCurrentProcess();
        return process.Threads.Count;
    }

    private static void Collect()
    {
        for (var i = 0; i < 3; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    // Exceptions of the connector that nobody observed.
    private sealed class Unobserved : IDisposable
    {
        private readonly List<Exception> _errors = [];

        public Unobserved() => TaskScheduler.UnobservedTaskException += OnUnobserved;

        private void OnUnobserved(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            lock (_errors) _errors.AddRange(e.Exception.Flatten().InnerExceptions.Where(x => x is BinanceException or OperationCanceledException));
        }

        public void AssertNone()
        {
            Collect();
            lock (_errors) Assert.Empty(_errors);
        }

        public void Dispose() => TaskScheduler.UnobservedTaskException -= OnUnobserved;
    }

    private static bool IsEndOfOperation(Exception e) =>
        e is OperationCanceledException or BinanceCancelledException or BinanceNetworkException or BinanceWebSocketException;

    private static async Task<(int Ok, int Ended)> Outcomes(IEnumerable<Task> tasks)
    {
        int ok = 0, ended = 0;
        foreach (var task in tasks)
        {
            try
            {
                await task.WaitAsync(Limit);
                ok++;
            }
            catch (Exception e) when (IsEndOfOperation(e))
            {
                ended++;
            }
        }
        return (ok, ended);
    }

    [Fact]
    public async Task CallsOnDisposedClientsLeaveNoRegistryEntries()
    {
        var rest = new RestClient("""{"base_path":"http://127.0.0.1:1"}""");
        var streams = new WebSocketStreams(StreamsConfig("ws://127.0.0.1:1"));
        var api = new WebSocketApi(ApiConfig("ws://127.0.0.1:1"));
        rest.Dispose();
        streams.Dispose();
        api.Dispose();
        var registry = RegistryCount();

        for (var i = 0; i < 10; i++)
        {
            await Assert.ThrowsAnyAsync<Exception>(() => rest.SendAsync("""{"method":"GET","path":"/x"}"""));
            await Assert.ThrowsAnyAsync<Exception>(() => streams.ConnectAsync());
            await Assert.ThrowsAnyAsync<Exception>(() => streams.DisconnectAsync());
            Assert.ThrowsAny<Exception>(() => streams.Subscribe("btcusdt@trade"));
            await Assert.ThrowsAnyAsync<Exception>(() => api.ConnectAsync());
            await Assert.ThrowsAnyAsync<Exception>(() => api.DisconnectAsync());
            await Assert.ThrowsAnyAsync<Exception>(() => api.SendAsync("""{"method":"time"}"""));
            await Assert.ThrowsAnyAsync<Exception>(() => api.SubscribeAsync("""{"method":"userDataStream.subscribe"}"""));
        }

        Assert.Equal(registry, RegistryCount());
    }

    // ---- REST ----

    [Fact]
    public async Task ManyRestClientsCanBeCreatedAndDisposedWithoutLeaking()
    {
        using (var warmup = Rest("http://127.0.0.1:1")) { }
        await Task.Delay(200);
        Collect();
        var threads = Threads();
        var memory = GC.GetTotalMemory(true);
        var registry = RegistryCount();

        for (var i = 0; i < 300; i++)
            using (Rest("http://127.0.0.1:1")) { }

        for (var i = 0; i < 100 && Threads() > threads + 8; i++) await Task.Delay(50);
        Collect();
        Assert.InRange(Threads(), 0, threads + 8);
        Assert.InRange(GC.GetTotalMemory(true), 0, memory + 32 * 1024 * 1024);
        Assert.Equal(registry, RegistryCount());
    }

    [Fact]
    public async Task ThreeThousandRequestsOnOneClientAllComplete()
    {
        using var server = new Loopback(seen => (200, $$"""{"serverTime":{{seen.Param("i")}}}"""));
        using var client = Rest(server.Url);
        var stopwatch = Stopwatch.StartNew();

        for (var batch = 0; batch < 30; batch++)
        {
            var tasks = Enumerable.Range(batch * 100, 100)
                .Select(async i => (i, response: await client.SendAsync(new RestRequest("GET", "/api/v3/time").Query("i", i), TestJson.Default.TimeDto)))
                .ToList();
            foreach (var (i, response) in await Task.WhenAll(tasks).WaitAsync(Limit))
            {
                Assert.Equal(200, response.Status);
                Assert.Equal(i, response.Data()!.ServerTime);
            }
        }

        Assert.Equal(3000, server.Requests.Count);
        Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(30));
    }

    [Fact]
    public async Task DisposingTheClientWithRequestsInFlightEndsEveryRequest()
    {
        using var unobserved = new Unobserved();
        using var server = new Loopback(_ => (200, """{"serverTime":1}""")) { Delay = TimeSpan.FromMilliseconds(100) };
        var client = Rest(server.Url);
        var tasks = Enumerable.Range(0, 500).Select(i => client.SendAsync(new RestRequest("GET", "/api/v3/time").Query("i", i), TestJson.Default.TimeDto)).Cast<Task>().ToList();
        await Task.Delay(200);
        var stopwatch = Stopwatch.StartNew();

        client.Dispose();
        var (ok, ended) = await Outcomes(tasks);

        Assert.Equal(500, ok + ended);
        Assert.True(stopwatch.Elapsed < Limit);
        unobserved.AssertNone();
    }

    [Fact]
    public async Task RequestsCancelledAtRandomMomentsEndAndTheClientStillWorks()
    {
        using var server = new Loopback(_ => (200, """{"serverTime":1}""")) { Delay = TimeSpan.FromMilliseconds(5) };
        using var client = Rest(server.Url);
        var random = new Random(20261026);
        var sources = new List<CancellationTokenSource>();
        var tasks = new List<Task>();
        for (var i = 0; i < 1000; i++)
        {
            var source = new CancellationTokenSource();
            sources.Add(source);
            source.CancelAfter(random.Next(0, 21));
            tasks.Add(client.SendAsync(Time, TestJson.Default.TimeDto, source.Token));
        }

        var (ok, ended) = await Outcomes(tasks);

        Assert.Equal(1000, ok + ended);
        sources.ForEach(s => s.Dispose());
        var after = await client.SendAsync(Time, TestJson.Default.TimeDto).WaitAsync(Limit);
        Assert.Equal(1, after.Data()!.ServerTime);
    }

    // ---- WebSocket API ----

    [Fact]
    public async Task AWebSocketApiClientSurvivesManyConnectDisconnectCycles()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies(null));
        using var api = new WebSocketApi(ApiConfig(server.Url));

        for (var i = 0; i < 50; i++)
        {
            await api.ConnectAsync().WaitAsync(Limit);
            Assert.True(api.IsConnected);
            await api.DisconnectAsync().WaitAsync(Limit);
            Assert.False(api.IsConnected);
        }

        await api.ConnectAsync().WaitAsync(Limit);
        Assert.NotNull(await api.SendAsync("""{"method":"time"}""").WaitAsync(Limit));
    }

    [Fact]
    public async Task ManyWebSocketApiClientsCanConnectAndBeDisposed()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies(null));
        var registry = RegistryCount();

        for (var i = 0; i < 30; i++)
        {
            using var api = new WebSocketApi(ApiConfig(server.Url));
            await api.ConnectAsync().WaitAsync(Limit);
            await api.SendAsync("""{"method":"time"}""").WaitAsync(Limit);
        }

        Assert.Equal(registry, RegistryCount());
    }

    [Fact]
    public async Task ThousandConcurrentWebSocketApiRequestsAreAnswered()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies("""{"status":200,"result":{"serverTime":1}}"""));
        using var api = new WebSocketApi(ApiConfig(server.Url));
        await api.ConnectAsync().WaitAsync(Limit);

        var tasks = Enumerable.Range(0, 1000).Select(_ => api.SendAsync("""{"method":"time"}""")).ToList();
        var responses = await Task.WhenAll(tasks).WaitAsync(Limit);

        Assert.All(responses, r => Assert.Contains("serverTime", r, StringComparison.Ordinal));
    }

    [Fact]
    public async Task DisposingAWebSocketApiClientDuringARequestStormEndsEveryRequest()
    {
        using var unobserved = new Unobserved();
        using var server = new MiniWsServer(MiniWsServer.ApiReplies("""{"status":200,"result":{"serverTime":1}}"""));
        var api = new WebSocketApi(ApiConfig(server.Url));
        await api.ConnectAsync().WaitAsync(Limit);
        var tasks = Enumerable.Range(0, 1000).Select(_ => api.SendAsync("""{"method":"time"}""")).Cast<Task>().ToList();
        await Task.Delay(5);
        var stopwatch = Stopwatch.StartNew();

        api.Dispose();
        var (ok, ended) = await Outcomes(tasks);

        Assert.Equal(1000, ok + ended);
        Assert.True(stopwatch.Elapsed < Limit);
        unobserved.AssertNone();
    }

    // ---- WebSocket Streams ----

    [Fact]
    public async Task FiveHundredSubscribeAndUnsubscribeCyclesEndEveryReader()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var streams = new WebSocketStreams(StreamsConfig(server.Url));
        await streams.ConnectAsync().WaitAsync(Limit);
        var registry = RegistryCount();

        for (var i = 0; i < 500; i++)
        {
            var subscription = streams.Subscribe($"s{i}@trade");
            subscription.Dispose();
            await subscription.Reader.Completion.WaitAsync(Limit);
            Assert.False(subscription.IsActive);
        }

        Assert.Equal(registry, RegistryCount());
    }

    [Fact]
    public async Task TwoHundredStreamsCanBeSubscribedAtOnce()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var streams = new WebSocketStreams(StreamsConfig(server.Url));
        await streams.ConnectAsync().WaitAsync(Limit);
        var subscriptions = Enumerable.Range(0, 200).Select(i => streams.Subscribe($"s{i}@trade")).ToList();

        // The client may batch several streams into one SUBSCRIBE.
        Assert.True(await MiniWsServer.WaitFor(() => server.SubscribedStreams() >= 200));
        subscriptions.ForEach(s => Assert.True(s.IsActive));
        server.Publish("s150@trade", """{"serverTime":150}""");
        using var timeout = new CancellationTokenSource(Limit);
        Assert.Contains("150", await subscriptions[150].Reader.ReadAsync(timeout.Token), StringComparison.Ordinal);

        subscriptions.ForEach(s => s.Dispose());
        foreach (var s in subscriptions) await s.Reader.Completion.WaitAsync(Limit);
    }

    [Fact]
    public async Task DisposingTheStreamsClientWhileEventsFlowCompletesTheReaders()
    {
        using var unobserved = new Unobserved();
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        var streams = new WebSocketStreams(StreamsConfig(server.Url));
        await streams.ConnectAsync().WaitAsync(Limit);
        using var subscription = streams.Subscribe("a@b");
        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var flowing = true;
        var received = 0;
        var flood = Task.Run(() =>
        {
            try
            {
                while (Volatile.Read(ref flowing)) server.Send(1, """{"stream":"a@b","data":{"serverTime":1}}""");
            }
            catch (Exception e) when (e is IOException or ObjectDisposedException or InvalidOperationException)
            {
            }
        });
        var drain = Task.Run(async () =>
        {
            await foreach (var _ in subscription.Reader.ReadAllAsync()) Interlocked.Increment(ref received);
        });
        Assert.True(await MiniWsServer.WaitFor(() => Volatile.Read(ref received) > 100));

        streams.Dispose();

        await drain.WaitAsync(Limit);
        await subscription.Reader.Completion.WaitAsync(Limit);
        Volatile.Write(ref flowing, false);
        await flood.WaitAsync(Limit);
        unobserved.AssertNone();
    }

    // ---- Disposing from callbacks ----

    [Fact]
    public async Task DisposingTheClientFromAReaderContinuationDoesNotDeadlock()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        var streams = new WebSocketStreams(StreamsConfig(server.Url));
        await streams.ConnectAsync().WaitAsync(Limit);
        using var subscription = streams.Subscribe("a@b");
        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        server.Publish("a@b", """{"serverTime":1}""");

        var disposed = Task.Run(async () =>
        {
            await foreach (var _ in subscription.Reader.ReadAllAsync())
            {
                streams.Dispose();
                streams.Dispose();
            }
        });

        await disposed.WaitAsync(Limit);
        Assert.False(streams.IsConnected);
    }

    [Fact]
    public async Task DisposingTheClientFromTheLifecycleEventReaderDoesNotDeadlock()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies(null));
        var api = new WebSocketApi(ApiConfig(server.Url));
        var reacted = Task.Run(async () =>
        {
            await foreach (var e in api.Events.ReadAllAsync())
            {
                if (e.Type == ConnectionEventType.Open) api.Dispose();
            }
        });

        await api.ConnectAsync().WaitAsync(Limit);

        await reacted.WaitAsync(Limit);
    }

    [Fact]
    public async Task DisposingTheClientFromTheCertificateValidatorDoesNotDeadlock()
    {
        using var tls = new TlsLoopback();
        RestApiClient? client = null;
        var validated = new TaskCompletionSource();
        client = Rest(tls.Url, c =>
        {
            c.CaPem = tls.CaPem;
            c.ServerCertificateValidator = (_, _, preverified) =>
            {
                client!.Dispose();
                validated.TrySetResult();
                return preverified;
            };
        });

        var request = client.SendAsync(Time, TestJson.Default.TimeDto);
        await validated.Task.WaitAsync(Limit);

        try { await request.WaitAsync(Limit); }
        catch (Exception e) when (IsEndOfOperation(e)) { }
    }

    // ---- Logging ----

    [Fact]
    public async Task TheLogCanBeReconfiguredWhileClientsComeAndGo()
    {
        var log = new CapturingLoggerFactory();
        var stop = false;
        var churn = Enumerable.Range(0, 4).Select(_ => Task.Run(() =>
        {
            while (!Volatile.Read(ref stop))
            {
                using var client = Rest("http://127.0.0.1:1");
                try { client.SendAsync(Time, TestJson.Default.TimeDto).Wait(TimeSpan.FromSeconds(5)); }
                catch (AggregateException) { }
            }
        })).ToList();
        var toggler = Task.Run(() =>
        {
            for (var i = 0; i < 300; i++)
            {
                BinanceLogging.Configure(i % 3 == 0 ? null : log);
                BinanceLogging.SetLevel((BinanceLogLevel)(i % 5));
            }
        });

        try
        {
            await toggler.WaitAsync(Limit);
        }
        finally
        {
            Volatile.Write(ref stop, true);
            BinanceLogging.Configure(null);
            BinanceLogging.SetLevel(BinanceLogLevel.Warning);
        }

        await Task.WhenAll(churn).WaitAsync(Limit);
    }
}
