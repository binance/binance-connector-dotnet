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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class HistoricalExerciseRecordsRequest
{
    /// <summary>Underlying asset.</summary>
    public string? Underlying { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of result sets returned</summary>
    public long? Limit { get; init; }
}

public sealed class IndexPriceRequest
{
    /// <summary>Underlying asset.</summary>
    public required string Underlying { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<KlineCandlestickDataInterval>))]
public readonly struct KlineCandlestickDataInterval : IExtensibleValue<KlineCandlestickDataInterval>, IEquatable<KlineCandlestickDataInterval>
{
    private readonly string? _value;

    public KlineCandlestickDataInterval(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static KlineCandlestickDataInterval Interval1m { get; } = new("1m");

    public static KlineCandlestickDataInterval Interval3m { get; } = new("3m");

    public static KlineCandlestickDataInterval Interval5m { get; } = new("5m");

    public static KlineCandlestickDataInterval Interval15m { get; } = new("15m");

    public static KlineCandlestickDataInterval Interval30m { get; } = new("30m");

    public static KlineCandlestickDataInterval Interval1h { get; } = new("1h");

    public static KlineCandlestickDataInterval Interval2h { get; } = new("2h");

    public static KlineCandlestickDataInterval Interval4h { get; } = new("4h");

    public static KlineCandlestickDataInterval Interval6h { get; } = new("6h");

    public static KlineCandlestickDataInterval Interval8h { get; } = new("8h");

    public static KlineCandlestickDataInterval Interval12h { get; } = new("12h");

    public static KlineCandlestickDataInterval Interval1d { get; } = new("1d");

    public static KlineCandlestickDataInterval Interval3d { get; } = new("3d");

    public static KlineCandlestickDataInterval Interval1w { get; } = new("1w");

    public static KlineCandlestickDataInterval Interval1Month { get; } = new("1M");

    static KlineCandlestickDataInterval IExtensibleValue<KlineCandlestickDataInterval>.Create(string value) => new(value);

    public static bool operator ==(KlineCandlestickDataInterval left, KlineCandlestickDataInterval right) => left.Equals(right);

    public static bool operator !=(KlineCandlestickDataInterval left, KlineCandlestickDataInterval right) => !left.Equals(right);

    public static implicit operator KlineCandlestickDataInterval(string value) => new(value);

    public static KlineCandlestickDataInterval FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is KlineCandlestickDataInterval other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(KlineCandlestickDataInterval other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class KlineCandlestickDataRequest
{
    /// <summary>Option trading pair</summary>
    public required string Symbol { get; init; }

    /// <summary>Time interval</summary>
    public required KlineCandlestickDataInterval Interval { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of result sets returned</summary>
    public long? Limit { get; init; }
}

public sealed class OpenInterestRequest
{
    /// <summary>Underlying asset.</summary>
    public required string UnderlyingAsset { get; init; }

    /// <summary>expiration date</summary>
    public required string Expiration { get; init; }
}

public sealed class OptionMarkPriceRequest
{
    /// <summary>Option trading pair</summary>
    public string? Symbol { get; init; }
}

public sealed class OrderBookRequest
{
    /// <summary>Option trading pair</summary>
    public required string Symbol { get; init; }

    /// <summary>Default:100 Max:1000.Optional value:[10, 20, 50, 100, 500, 1000]</summary>
    public long? Limit { get; init; }
}

public sealed class RecentBlockTradesListRequest
{
    /// <summary>Option trading pair</summary>
    public string? Symbol { get; init; }

    /// <summary>Number of records</summary>
    public long? Limit { get; init; }
}

public sealed class RecentTradesListRequest
{
    /// <summary>Option trading pair</summary>
    public required string Symbol { get; init; }

    /// <summary>Number of result sets returned</summary>
    public long? Limit { get; init; }
}

public sealed class Ticker24hrPriceChangeStatisticsRequest
{
    /// <summary>Option trading pair</summary>
    public string? Symbol { get; init; }
}

public sealed partial class DerivativesTradingOptionsRestApi
{

    /// <summary>Check Server Time</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API and get the current server time.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CheckServerTimeResponse>> CheckServerTimeAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/time", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.CheckServerTimeResponse, cancellationToken);
    }

    /// <summary>Exchange Information</summary>
    /// <remarks>
    /// <para>Current exchange trading rules and symbol information</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExchangeInformationResponse>> ExchangeInformationAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/exchangeInfo", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ExchangeInformationResponse, cancellationToken);
    }

    /// <summary>Historical Exercise Records</summary>
    /// <remarks>
    /// <para>Get historical exercise records.</para>
    /// <para>- REALISTIC_VALUE_STRICKEN -&gt; Exercised</para>
    /// <para>- EXTRINSIC_VALUE_EXPIRED -&gt; Expired OTM</para>
    /// <para>Weight(IP): 3</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<HistoricalExerciseRecordsResponseInner>>> HistoricalExerciseRecordsAsync(HistoricalExerciseRecordsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/exerciseHistory", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("underlying", request.Underlying);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListHistoricalExerciseRecordsResponseInner, cancellationToken);
    }

    /// <summary>Index Price</summary>
    /// <remarks>
    /// <para>Get spot index price for option underlying.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<IndexPriceResponse>> IndexPriceAsync(IndexPriceRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/index", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<IndexPriceResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlying", request.Underlying);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.IndexPriceResponse, cancellationToken);
    }

    /// <summary>Kline/Candlestick Data</summary>
    /// <remarks>
    /// <para>Kline/candlestick bars for an option symbol. Klines are uniquely identified by their open time.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the most recent klines are returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<List<KlineCandlestickDataItemInner>>>> KlineCandlestickDataAsync(KlineCandlestickDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/klines", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<List<KlineCandlestickDataItemInner>>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("interval", request.Interval);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListListKlineCandlestickDataItemInner, cancellationToken);
    }

    /// <summary>Open Interest</summary>
    /// <remarks>
    /// <para>Get open interest for specific underlying asset on specific expiration date.</para>
    /// <para>Weight(IP): 0</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OpenInterestResponseInner>>> OpenInterestAsync(OpenInterestRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/openInterest", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<OpenInterestResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("underlyingAsset", request.UnderlyingAsset);
        r.Query("expiration", request.Expiration);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListOpenInterestResponseInner, cancellationToken);
    }

    /// <summary>Option Mark Price</summary>
    /// <remarks>
    /// <para>Option mark price and greek info.</para>
    /// <para>Weight(IP): 5</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OptionMarkPriceResponseInner>>> OptionMarkPriceAsync(OptionMarkPriceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/mark", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListOptionMarkPriceResponseInner, cancellationToken);
    }

    /// <summary>Order Book</summary>
    /// <remarks>
    /// <para>Check orderbook depth on specific symbol</para>
    /// <para>Weight: limit | weight</para>
    /// <para>5, 10, 20, 50 | 1</para>
    /// <para>100 | 5</para>
    /// <para>500 | 10</para>
    /// <para>1000 | 20</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OrderBookResponse>> OrderBookAsync(OrderBookRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/depth", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OrderBookResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.OrderBookResponse, cancellationToken);
    }

    /// <summary>Recent Block Trades List</summary>
    /// <remarks>
    /// <para>Get recent block trades</para>
    /// <para>Weight(IP): 5</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<RecentBlockTradesListResponseInner>>> RecentBlockTradesListAsync(RecentBlockTradesListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/blockTrades", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListRecentBlockTradesListResponseInner, cancellationToken);
    }

    /// <summary>Recent Trades List</summary>
    /// <remarks>
    /// <para>Get recent market trades</para>
    /// <para>Weight(IP): 5</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<RecentTradesListResponseInner>>> RecentTradesListAsync(RecentTradesListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/trades", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<RecentTradesListResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListRecentTradesListResponseInner, cancellationToken);
    }

    /// <summary>Test Connectivity</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> TestConnectivityAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/ping", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>24hr Ticker Price Change Statistics</summary>
    /// <remarks>
    /// <para>24 hour rolling window price change statistics.</para>
    /// <para>Weight: 1 for a single symbol; 40 when the symbol parameter is omitted</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<Ticker24hrPriceChangeStatisticsResponseInner>>> Ticker24hrPriceChangeStatisticsAsync(Ticker24hrPriceChangeStatisticsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/ticker", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListTicker24hrPriceChangeStatisticsResponseInner, cancellationToken);
    }
}
