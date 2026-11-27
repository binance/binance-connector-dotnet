//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.Stocks.WebSocketStreams;

public sealed class CalendarStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class KlineStreamRequest
{
    /// <summary>US-equity ticker (UPPERCASE), e.g. AAPL.</summary>
    public required string Symbol { get; init; }

    /// <summary>Kline interval — 5m / 1h / 1d / 1w / 1M.</summary>
    public required string Interval { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class PriceStreamRequest
{
    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class QuoteStreamRequest
{
    /// <summary>US-equity ticker (UPPERCASE), e.g. AAPL.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class TradabilityStreamRequest
{
    /// <summary>US-equity ticker (UPPERCASE), e.g. AAPL.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed class TradingStatusStreamRequest
{
    /// <summary>US-equity ticker (UPPERCASE), e.g. AAPL.</summary>
    public required string Symbol { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed partial class StocksWebSocketStreamsConnection
{

    /// <summary>Calendar Stream</summary>
    /// <remarks>
    /// Single-stream broadcast of market-phase transitions. One message per transition; no periodic
    /// heartbeat payload. Server polls every 5 seconds. Also reachable via the SUBSCRIBE/UNSUBSCRIBE RPC —
    /// see Subscribing via RPC.
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<CalendarStreamResponse> CalendarStream(CalendarStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("calendar", ("id", request.Id)), StocksWebSocketStreamsJson.Default.CalendarStreamResponse, null, id: request.Id);
    }

    /// <summary>Kline Stream</summary>
    /// <remarks>
    /// Per-symbol candlestick updates. One stream per (symbol, interval) combination. Supported intervals:
    /// 5m, 1h, 1d, 1w, 1M. Also reachable via the SUBSCRIBE/UNSUBSCRIBE RPC — see Subscribing via RPC.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<KlineStreamResponse> KlineStream(KlineStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("<symbol>@kline_<interval>", ("symbol", request.Symbol), ("interval", request.Interval), ("id", request.Id)), StocksWebSocketStreamsJson.Default.KlineStreamResponse, null, id: request.Id);
    }

    /// <summary>Price Stream</summary>
    /// <remarks>
    /// Push-all price snapshot, polled every 3 seconds. One message carries the latest price for every
    /// active US-equity symbol. Also reachable via the SUBSCRIBE/UNSUBSCRIBE RPC — see Subscribing via RPC.
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PriceStreamResponse> PriceStream(PriceStreamRequest? request = null)
    {
        request ??= new();
        return _client.Subscribe(StreamName.Build("price", ("id", request.Id)), StocksWebSocketStreamsJson.Default.PriceStreamResponse, null, id: request.Id);
    }

    /// <summary>Quote Stream</summary>
    /// <remarks>
    /// Per-symbol real-time best-bid / best-ask. Each symbol has its own stream. Per-symbol throttle: at
    /// most one push per symbol every 200 ms. Also reachable via the SUBSCRIBE/UNSUBSCRIBE RPC — see
    /// Subscribing via RPC.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<QuoteStreamResponse> QuoteStream(QuoteStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("<symbol>@quote", ("symbol", request.Symbol), ("id", request.Id)), StocksWebSocketStreamsJson.Default.QuoteStreamResponse, null, id: request.Id);
    }

    /// <summary>Tradability Stream</summary>
    /// <remarks>
    /// Per-symbol push whenever the tradable direction of a symbol changes. Pushed only when the value
    /// actually changes (new value ≠ old value). Also reachable via the SUBSCRIBE/UNSUBSCRIBE RPC — see
    /// Subscribing via RPC.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TradabilityStreamResponse> TradabilityStream(TradabilityStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("<symbol>@tradability", ("symbol", request.Symbol), ("id", request.Id)), StocksWebSocketStreamsJson.Default.TradabilityStreamResponse, null, id: request.Id);
    }

    /// <summary>Trading Status Stream</summary>
    /// <remarks>
    /// Per-symbol trading-status transitions (halts, resumes, SSR, LULD pauses, etc.). Events that do not
    /// match a known status/reason rule are not pushed. Also reachable via the SUBSCRIBE/UNSUBSCRIBE RPC —
    /// see Subscribing via RPC.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<TradingStatusStreamResponse> TradingStatusStream(TradingStatusStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("<symbol>@tradingStatus", ("symbol", request.Symbol), ("id", request.Id)), StocksWebSocketStreamsJson.Default.TradingStatusStreamResponse, null, id: request.Id);
    }
}
