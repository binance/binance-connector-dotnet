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

namespace Binance.Stocks.RestApi;

public sealed class CancelAllEquityOrdersRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelEquityOrderRequest
{
    /// <summary>Equity order id returned by /order/place or a query endpoint.</summary>
    public required string OrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CurrentOpenOrdersRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class EquityOrderDetailRequest
{
    /// <summary>Equity order id. Either orderId or clientOrderId must be provided.</summary>
    public string? OrderId { get; init; }

    /// <summary>Client-supplied order id. Either orderId or clientOrderId must be provided.</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<EquityOrderHistoryOrderType>))]
public readonly struct EquityOrderHistoryOrderType : IExtensibleValue<EquityOrderHistoryOrderType>, IEquatable<EquityOrderHistoryOrderType>
{
    private readonly string? _value;

    public EquityOrderHistoryOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static EquityOrderHistoryOrderType Market { get; } = new("MARKET");

    public static EquityOrderHistoryOrderType Limit { get; } = new("LIMIT");

    static EquityOrderHistoryOrderType IExtensibleValue<EquityOrderHistoryOrderType>.Create(string value) => new(value);

    public static bool operator ==(EquityOrderHistoryOrderType left, EquityOrderHistoryOrderType right) => left.Equals(right);

    public static bool operator !=(EquityOrderHistoryOrderType left, EquityOrderHistoryOrderType right) => !left.Equals(right);

    public static implicit operator EquityOrderHistoryOrderType(string value) => new(value);

    public static EquityOrderHistoryOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is EquityOrderHistoryOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(EquityOrderHistoryOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<EquityOrderHistorySide>))]
public readonly struct EquityOrderHistorySide : IExtensibleValue<EquityOrderHistorySide>, IEquatable<EquityOrderHistorySide>
{
    private readonly string? _value;

    public EquityOrderHistorySide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static EquityOrderHistorySide Buy { get; } = new("BUY");

    public static EquityOrderHistorySide Sell { get; } = new("SELL");

    static EquityOrderHistorySide IExtensibleValue<EquityOrderHistorySide>.Create(string value) => new(value);

    public static bool operator ==(EquityOrderHistorySide left, EquityOrderHistorySide right) => left.Equals(right);

    public static bool operator !=(EquityOrderHistorySide left, EquityOrderHistorySide right) => !left.Equals(right);

    public static implicit operator EquityOrderHistorySide(string value) => new(value);

    public static EquityOrderHistorySide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is EquityOrderHistorySide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(EquityOrderHistorySide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class EquityOrderHistoryRequest
{
    /// <summary>Start time (ms epoch).</summary>
    public required long StartTime { get; init; }

    /// <summary>End time (ms epoch).</summary>
    public required long EndTime { get; init; }

    /// <summary>US-equity ticker filter, e.g. NVDA.</summary>
    public string? Symbol { get; init; }

    /// <summary>Order type filter: MARKET / LIMIT.</summary>
    public EquityOrderHistoryOrderType? OrderType { get; init; }

    /// <summary>Side filter: BUY / SELL.</summary>
    public EquityOrderHistorySide? Side { get; init; }

    /// <summary>
    /// Comma-separated status filter. Allowed values: FILLED, PARTIALLY_FILLED, CANCELED, EXPIRED,
    /// REJECTED.
    /// </summary>
    public string? OrderStatus { get; init; }

    /// <summary>Page number, 1-based. Default 1.</summary>
    public long? Current { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<EquityTradeHistorySide>))]
public readonly struct EquityTradeHistorySide : IExtensibleValue<EquityTradeHistorySide>, IEquatable<EquityTradeHistorySide>
{
    private readonly string? _value;

    public EquityTradeHistorySide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static EquityTradeHistorySide Buy { get; } = new("BUY");

    public static EquityTradeHistorySide Sell { get; } = new("SELL");

    static EquityTradeHistorySide IExtensibleValue<EquityTradeHistorySide>.Create(string value) => new(value);

    public static bool operator ==(EquityTradeHistorySide left, EquityTradeHistorySide right) => left.Equals(right);

    public static bool operator !=(EquityTradeHistorySide left, EquityTradeHistorySide right) => !left.Equals(right);

    public static implicit operator EquityTradeHistorySide(string value) => new(value);

    public static EquityTradeHistorySide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is EquityTradeHistorySide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(EquityTradeHistorySide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class EquityTradeHistoryRequest
{
    /// <summary>Start time (ms epoch).</summary>
    public required long StartTime { get; init; }

    /// <summary>End time (ms epoch).</summary>
    public required long EndTime { get; init; }

    /// <summary>US-equity ticker filter, e.g. NVDA.</summary>
    public string? Symbol { get; init; }

    /// <summary>Side filter: BUY / SELL.</summary>
    public EquityTradeHistorySide? Side { get; init; }

    /// <summary>Narrow the result to executions of a single order.</summary>
    public string? OrderId { get; init; }

    /// <summary>Page number, 1-based. Default 1.</summary>
    public long? Current { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceEquityOrderSide>))]
public readonly struct PlaceEquityOrderSide : IExtensibleValue<PlaceEquityOrderSide>, IEquatable<PlaceEquityOrderSide>
{
    private readonly string? _value;

    public PlaceEquityOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceEquityOrderSide Buy { get; } = new("BUY");

    public static PlaceEquityOrderSide Sell { get; } = new("SELL");

    static PlaceEquityOrderSide IExtensibleValue<PlaceEquityOrderSide>.Create(string value) => new(value);

    public static bool operator ==(PlaceEquityOrderSide left, PlaceEquityOrderSide right) => left.Equals(right);

    public static bool operator !=(PlaceEquityOrderSide left, PlaceEquityOrderSide right) => !left.Equals(right);

    public static implicit operator PlaceEquityOrderSide(string value) => new(value);

    public static PlaceEquityOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceEquityOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceEquityOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceEquityOrderOrderType>))]
public readonly struct PlaceEquityOrderOrderType : IExtensibleValue<PlaceEquityOrderOrderType>, IEquatable<PlaceEquityOrderOrderType>
{
    private readonly string? _value;

    public PlaceEquityOrderOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceEquityOrderOrderType Market { get; } = new("MARKET");

    public static PlaceEquityOrderOrderType Limit { get; } = new("LIMIT");

    static PlaceEquityOrderOrderType IExtensibleValue<PlaceEquityOrderOrderType>.Create(string value) => new(value);

    public static bool operator ==(PlaceEquityOrderOrderType left, PlaceEquityOrderOrderType right) => left.Equals(right);

    public static bool operator !=(PlaceEquityOrderOrderType left, PlaceEquityOrderOrderType right) => !left.Equals(right);

    public static implicit operator PlaceEquityOrderOrderType(string value) => new(value);

    public static PlaceEquityOrderOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceEquityOrderOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceEquityOrderOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceEquityOrderTimeInForce>))]
public readonly struct PlaceEquityOrderTimeInForce : IExtensibleValue<PlaceEquityOrderTimeInForce>, IEquatable<PlaceEquityOrderTimeInForce>
{
    private readonly string? _value;

    public PlaceEquityOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceEquityOrderTimeInForce Day { get; } = new("DAY");

    public static PlaceEquityOrderTimeInForce Gtc { get; } = new("GTC");

    static PlaceEquityOrderTimeInForce IExtensibleValue<PlaceEquityOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(PlaceEquityOrderTimeInForce left, PlaceEquityOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(PlaceEquityOrderTimeInForce left, PlaceEquityOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator PlaceEquityOrderTimeInForce(string value) => new(value);

    public static PlaceEquityOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceEquityOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceEquityOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceEquityOrderTradingSession>))]
public readonly struct PlaceEquityOrderTradingSession : IExtensibleValue<PlaceEquityOrderTradingSession>, IEquatable<PlaceEquityOrderTradingSession>
{
    private readonly string? _value;

    public PlaceEquityOrderTradingSession(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceEquityOrderTradingSession Rth { get; } = new("RTH");

    public static PlaceEquityOrderTradingSession Extended { get; } = new("EXTENDED");

    public static PlaceEquityOrderTradingSession TradingSession24H { get; } = new("24H");

    static PlaceEquityOrderTradingSession IExtensibleValue<PlaceEquityOrderTradingSession>.Create(string value) => new(value);

    public static bool operator ==(PlaceEquityOrderTradingSession left, PlaceEquityOrderTradingSession right) => left.Equals(right);

    public static bool operator !=(PlaceEquityOrderTradingSession left, PlaceEquityOrderTradingSession right) => !left.Equals(right);

    public static implicit operator PlaceEquityOrderTradingSession(string value) => new(value);

    public static PlaceEquityOrderTradingSession FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceEquityOrderTradingSession other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceEquityOrderTradingSession other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceEquityOrderWalletType>))]
public readonly struct PlaceEquityOrderWalletType : IExtensibleValue<PlaceEquityOrderWalletType>, IEquatable<PlaceEquityOrderWalletType>
{
    private readonly string? _value;

    public PlaceEquityOrderWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceEquityOrderWalletType Card { get; } = new("CARD");

    public static PlaceEquityOrderWalletType Main { get; } = new("MAIN");

    static PlaceEquityOrderWalletType IExtensibleValue<PlaceEquityOrderWalletType>.Create(string value) => new(value);

    public static bool operator ==(PlaceEquityOrderWalletType left, PlaceEquityOrderWalletType right) => left.Equals(right);

    public static bool operator !=(PlaceEquityOrderWalletType left, PlaceEquityOrderWalletType right) => !left.Equals(right);

    public static implicit operator PlaceEquityOrderWalletType(string value) => new(value);

    public static PlaceEquityOrderWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceEquityOrderWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceEquityOrderWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceEquityOrderTokenizedAssetSettleWalletType>))]
public readonly struct PlaceEquityOrderTokenizedAssetSettleWalletType : IExtensibleValue<PlaceEquityOrderTokenizedAssetSettleWalletType>, IEquatable<PlaceEquityOrderTokenizedAssetSettleWalletType>
{
    private readonly string? _value;

    public PlaceEquityOrderTokenizedAssetSettleWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceEquityOrderTokenizedAssetSettleWalletType Main { get; } = new("MAIN");

    public static PlaceEquityOrderTokenizedAssetSettleWalletType Card { get; } = new("CARD");

    static PlaceEquityOrderTokenizedAssetSettleWalletType IExtensibleValue<PlaceEquityOrderTokenizedAssetSettleWalletType>.Create(string value) => new(value);

    public static bool operator ==(PlaceEquityOrderTokenizedAssetSettleWalletType left, PlaceEquityOrderTokenizedAssetSettleWalletType right) => left.Equals(right);

    public static bool operator !=(PlaceEquityOrderTokenizedAssetSettleWalletType left, PlaceEquityOrderTokenizedAssetSettleWalletType right) => !left.Equals(right);

    public static implicit operator PlaceEquityOrderTokenizedAssetSettleWalletType(string value) => new(value);

    public static PlaceEquityOrderTokenizedAssetSettleWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceEquityOrderTokenizedAssetSettleWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceEquityOrderTokenizedAssetSettleWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PlaceEquityOrderRequest
{
    /// <summary>
    /// US stock ticker, e.g. AAPL, TSLA. Must be a tradable US-equity symbol — verify via
    /// /sapi/v1/equity/market/exchangeInfo. Tokenization enablement (verifiable via
    /// /sapi/v1/equity/market/tokenized-assets) is not required; non-tokenized symbols are accepted and
    /// settle as traditional underlying-equity trades. The tokenize parameter only takes effect on
    /// tokenization-enabled symbols and is silently ignored otherwise.
    /// </summary>
    public required string Symbol { get; init; }

    /// <summary>BUY / SELL.</summary>
    public required PlaceEquityOrderSide Side { get; init; }

    /// <summary>MARKET / LIMIT.</summary>
    public required PlaceEquityOrderOrderType OrderType { get; init; }

    /// <summary>Quote asset. Defaults to USDC; must be within the server's allowed set.</summary>
    public string? QuoteAsset { get; init; }

    /// <summary>Required for LIMIT; forbidden for MARKET. Maximum 2 decimal places.</summary>
    public string? Price { get; init; }

    /// <summary>Required for LIMIT (both sides) and SELL MARKET; forbidden for BUY MARKET.</summary>
    public string? Quantity { get; init; }

    /// <summary>Required for BUY MARKET; forbidden for LIMIT and SELL MARKET.</summary>
    public string? Notional { get; init; }

    /// <summary>
    /// DAY (default) / GTC. GTC is only supported for LIMIT orders; a fractional-share GTC order must be
    /// paired with tradingSession = EXTENDED or 24H.
    /// </summary>
    public PlaceEquityOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>RTH / EXTENDED / 24H. Required for LIMIT; forbidden for MARKET.</summary>
    public PlaceEquityOrderTradingSession? TradingSession { get; init; }

    /// <summary>
    /// Payment wallet for BUY orders: CARD (default) / MAIN. SELL orders always settle to CARD.
    /// </summary>
    public PlaceEquityOrderWalletType? WalletType { get; init; }

    /// <summary>
    /// Client-supplied order id. Format ^[a-zA-Z0-9-_]{32,36}$. Auto-generated when omitted.
    /// </summary>
    public string? ClientOrderId { get; init; }

    /// <summary>
    /// Whether to tokenize the purchased stock asset upon settlement. Default true. Only takes effect when
    /// the symbol is tokenization-enabled (check via /market/tokenized-assets); silently ignored for
    /// non-tokenized symbols, which always settle as traditional underlying-equity trades.
    /// </summary>
    public bool? Tokenize { get; init; }

    /// <summary>
    /// Wallet that receives the tokenized asset minted after the order fills. MAIN = Spot wallet, CARD =
    /// Funding wallet. Default CARD. Only applies when side = BUY and tokenize = true; ignored for SELL or
    /// tokenize = false. If MAIN is sent while Spot wallet settlement is not enabled, the request is
    /// rejected as an illegal parameter.
    /// </summary>
    public PlaceEquityOrderTokenizedAssetSettleWalletType? TokenizedAssetSettleWalletType { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StocksRestApi
{

    /// <summary>Cancel All Equity Orders (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel all open orders for the caller. No request body is required — the scope is all of the
    /// caller's open orders. The downstream service handles idempotency; to inspect per-order outcomes,
    /// query /order/history after the call.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllEquityOrdersResponse>> CancelAllEquityOrdersAsync(CancelAllEquityOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/order/cancel-all", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.CancelAllEquityOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel Equity Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel a single open order by its orderId.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelEquityOrderResponse>> CancelEquityOrderAsync(CancelEquityOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/order/cancel", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelEquityOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.CancelEquityOrderResponse, cancellationToken);
    }

    /// <summary>Current Open Orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query all unfinished (open) orders for the caller. No business parameters are needed — user identity
    /// is derived from the signature.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CurrentOpenOrdersResponseInner>>> CurrentOpenOrdersAsync(CurrentOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/order/open-orders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.ListCurrentOpenOrdersResponseInner, cancellationToken);
    }

    /// <summary>Equity Order Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns a single order along with its trade execution list. Callers can only read their own orders —
    /// the user identity is derived from the signed request.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EquityOrderDetailResponse>> EquityOrderDetailAsync(EquityOrderDetailRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/order/detail", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.EquityOrderDetailResponse, cancellationToken);
    }

    /// <summary>Equity Order History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Paged order history for the caller. Filters by symbol, order type, side, status, and time range.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EquityOrderHistoryResponse>> EquityOrderHistoryAsync(EquityOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/order/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<EquityOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("symbol", request.Symbol);
        r.Query("orderType", request.OrderType);
        r.Query("side", request.Side);
        r.Query("orderStatus", request.OrderStatus);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.EquityOrderHistoryResponse, cancellationToken);
    }

    /// <summary>Equity Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Paged equity trade (per-fill) history for the caller. Each row is one execution, not one order — a
    /// partially filled order produces multiple rows. Filters by symbol, side, specific orderId, and time
    /// range.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EquityTradeHistoryResponse>> EquityTradeHistoryAsync(EquityTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/trade/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<EquityTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("orderId", request.OrderId);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.EquityTradeHistoryResponse, cancellationToken);
    }

    /// <summary>Place Equity Order (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Place a new equity order. Supports all combinations of LIMIT / MARKET × BUY / SELL. For LIMIT BUY
    /// orders the commission fee is automatically computed and reserved by the server at placement time —
    /// callers submit price and quantity only, no fee field is required.
    /// </para>
    /// <para>Field combination matrix</para>
    /// <para>| Side | OrderType | Required | Forbidden |</para>
    /// <para>| BUY | LIMIT | price, quantity, tradingSession | notional |</para>
    /// <para>| BUY | MARKET | notional | price, quantity, tradingSession |</para>
    /// <para>| SELL | LIMIT | price, quantity, tradingSession | notional |</para>
    /// <para>| SELL | MARKET | quantity | price, notional, tradingSession |</para>
    /// <para>
    /// Fractional shares: when quantity has a decimal component, or an order is placed by notional, it is
    /// treated as a fractional-share order. A fractional-share GTC order must be paired with tradingSession
    /// = EXTENDED or 24H.
    /// </para>
    /// <para>Rate limit: 200 requests / min (UID).</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PlaceEquityOrderResponse>> PlaceEquityOrderAsync(PlaceEquityOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/order/place", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<PlaceEquityOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("orderType", request.OrderType);
        r.Query("quoteAsset", request.QuoteAsset);
        r.Query("price", request.Price);
        r.Query("quantity", request.Quantity);
        r.Query("notional", request.Notional);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("tradingSession", request.TradingSession);
        r.Query("walletType", request.WalletType);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("tokenize", request.Tokenize);
        r.Query("tokenizedAssetSettleWalletType", request.TokenizedAssetSettleWalletType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.PlaceEquityOrderResponse, cancellationToken);
    }
}
