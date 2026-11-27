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

namespace Binance.Alpha.RestApi;

public sealed class AggregatedTradesRequest
{
    /// <summary>Trading pair symbol, e.g. ALPHA_118USDC (use token ID from Token List).</summary>
    public required string Symbol { get; init; }

    /// <summary>Starting aggregate trade ID to fetch from.</summary>
    public long? FromId { get; init; }

    /// <summary>Start timestamp in milliseconds.</summary>
    public long? StartTime { get; init; }

    /// <summary>End timestamp in milliseconds.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of results to return.</summary>
    public long? Limit { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<FullDepthLimit>))]
public readonly struct FullDepthLimit : IExtensibleValue<FullDepthLimit>, IEquatable<FullDepthLimit>
{
    private readonly string? _value;

    public FullDepthLimit(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static FullDepthLimit Limit5 { get; } = new("5");

    public static FullDepthLimit Limit10 { get; } = new("10");

    public static FullDepthLimit Limit20 { get; } = new("20");

    public static FullDepthLimit Limit50 { get; } = new("50");

    public static FullDepthLimit Limit100 { get; } = new("100");

    public static FullDepthLimit Limit500 { get; } = new("500");

    public static FullDepthLimit Limit1000 { get; } = new("1000");

    static FullDepthLimit IExtensibleValue<FullDepthLimit>.Create(string value) => new(value);

    public static bool operator ==(FullDepthLimit left, FullDepthLimit right) => left.Equals(right);

    public static bool operator !=(FullDepthLimit left, FullDepthLimit right) => !left.Equals(right);

    public static implicit operator FullDepthLimit(string value) => new(value);

    public static FullDepthLimit FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is FullDepthLimit other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(FullDepthLimit other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class FullDepthRequest
{
    /// <summary>Trading pair symbol, e.g. ALPHA_175USDT (use token ID from Token List).</summary>
    public required string Symbol { get; init; }

    /// <summary>Number of price levels to return. Valid values: 5, 10, 20, 50, 100, 500, 1000.</summary>
    public FullDepthLimit? Limit { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlinesInterval>))]
public readonly struct KlinesInterval : IExtensibleValue<KlinesInterval>, IEquatable<KlinesInterval>
{
    private readonly string? _value;

    public KlinesInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlinesInterval Interval1s { get; } = new("1s");

    public static KlinesInterval Interval15s { get; } = new("15s");

    public static KlinesInterval Interval1m { get; } = new("1m");

    public static KlinesInterval Interval3m { get; } = new("3m");

    public static KlinesInterval Interval5m { get; } = new("5m");

    public static KlinesInterval Interval15m { get; } = new("15m");

    public static KlinesInterval Interval30m { get; } = new("30m");

    public static KlinesInterval Interval1h { get; } = new("1h");

    public static KlinesInterval Interval2h { get; } = new("2h");

    public static KlinesInterval Interval4h { get; } = new("4h");

    public static KlinesInterval Interval6h { get; } = new("6h");

    public static KlinesInterval Interval8h { get; } = new("8h");

    public static KlinesInterval Interval12h { get; } = new("12h");

    public static KlinesInterval Interval1d { get; } = new("1d");

    public static KlinesInterval Interval3d { get; } = new("3d");

    public static KlinesInterval Interval1w { get; } = new("1w");

    public static KlinesInterval Interval1Month { get; } = new("1M");

    static KlinesInterval IExtensibleValue<KlinesInterval>.Create(string value) => new(value);

    public static bool operator ==(KlinesInterval left, KlinesInterval right) => left.Equals(right);

    public static bool operator !=(KlinesInterval left, KlinesInterval right) => !left.Equals(right);

    public static implicit operator KlinesInterval(string value) => new(value);

    public static KlinesInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlinesInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlinesInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlinesRequest
{
    /// <summary>Trading pair symbol, e.g. ALPHA_175USDT (use token ID from Token List).</summary>
    public required string Symbol { get; init; }

    /// <summary>Kline interval.</summary>
    public required KlinesInterval Interval { get; init; }

    /// <summary>Number of klines to return.</summary>
    public long? Limit { get; init; }

    /// <summary>Start timestamp in milliseconds.</summary>
    public long? StartTime { get; init; }

    /// <summary>End timestamp in milliseconds.</summary>
    public long? EndTime { get; init; }
}

public sealed class TickerRequest
{
    /// <summary>Trading pair symbol, e.g. ALPHA_175USDT (use token ID from Token List).</summary>
    public required string Symbol { get; init; }
}

public sealed partial class AlphaRestApi
{

    /// <summary>Aggregated Trades</summary>
    /// <remarks>
    /// Retrieves compressed, aggregated historical trades for a specific symbol. Useful for recent trade
    /// history.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AggregatedTradesResponse>> AggregatedTradesAsync(AggregatedTradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/bapi/defi/v1/public/alpha-trade/agg-trades", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AggregatedTradesResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("fromId", request.FromId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, AlphaRestApiJson.Default.AggregatedTradesResponse, cancellationToken);
    }

    /// <summary>Full Depth</summary>
    /// <remarks>
    /// Fetches the full order book depth (UI &amp; API orders) for a symbol, including bid and ask orders
    /// with their prices and quantities.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FullDepthResponse>> FullDepthAsync(FullDepthRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/bapi/defi/v1/public/alpha-trade/fullDepth", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FullDepthResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, AlphaRestApiJson.Default.FullDepthResponse, cancellationToken);
    }

    /// <summary>Get Exchange Info</summary>
    /// <remarks>
    /// Fetches general exchange information, such as supported symbols, rate limits, and server time.
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetExchangeInfoResponse>> GetExchangeInfoAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/bapi/defi/v1/public/alpha-trade/get-exchange-info", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, AlphaRestApiJson.Default.GetExchangeInfoResponse, cancellationToken);
    }

    /// <summary>Klines</summary>
    /// <remarks>
    /// Fetches Kline/candlestick bars for a symbol, which include open/high/low/close prices and volume
    /// over intervals. Useful for charting and analysis.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<KlinesResponse>> KlinesAsync(KlinesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/bapi/defi/v1/public/alpha-trade/klines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<KlinesResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        return _client.SendAsync(r, AlphaRestApiJson.Default.KlinesResponse, cancellationToken);
    }

    /// <summary>Ticker</summary>
    /// <remarks>
    /// Gets the 24-hour rolling window price change statistics for a symbol, including volume and price
    /// changes.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TickerResponse>> TickerAsync(TickerRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/bapi/defi/v1/public/alpha-trade/ticker", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TickerResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, AlphaRestApiJson.Default.TickerResponse, cancellationToken);
    }

    /// <summary>Token List</summary>
    /// <remarks>
    /// Retrieves a list of all available ALPHA tokens, including their IDs and symbols. Use this to find
    /// the token ID for constructing symbols in other endpoints.
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TokenListResponse>> TokenListAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/bapi/defi/v1/public/wallet-direct/buw/wallet/cex/alpha/all/token/list", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, AlphaRestApiJson.Default.TokenListResponse, cancellationToken);
    }
}
