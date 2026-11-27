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

namespace Binance.Convert.RestApi;

public sealed class AcceptQuoteRequest
{
    public required string QuoteId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelLimitOrderRequest
{
    /// <summary>The orderId from placeOrder api</summary>
    public required long OrderId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetConvertTradeHistoryRequest
{
    public required long StartTime { get; init; }

    public required long EndTime { get; init; }

    /// <summary>Number of records to return</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OrderStatusRequest
{
    /// <summary>Either orderId or quoteId is required</summary>
    public string? OrderId { get; init; }

    /// <summary>Either orderId or quoteId is required</summary>
    public string? QuoteId { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceLimitOrderSide>))]
public readonly struct PlaceLimitOrderSide : IExtensibleValue<PlaceLimitOrderSide>, IEquatable<PlaceLimitOrderSide>
{
    private readonly string? _value;

    public PlaceLimitOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceLimitOrderSide Buy { get; } = new("BUY");

    public static PlaceLimitOrderSide Sell { get; } = new("SELL");

    static PlaceLimitOrderSide IExtensibleValue<PlaceLimitOrderSide>.Create(string value) => new(value);

    public static bool operator ==(PlaceLimitOrderSide left, PlaceLimitOrderSide right) => left.Equals(right);

    public static bool operator !=(PlaceLimitOrderSide left, PlaceLimitOrderSide right) => !left.Equals(right);

    public static implicit operator PlaceLimitOrderSide(string value) => new(value);

    public static PlaceLimitOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceLimitOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceLimitOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceLimitOrderExpiredType>))]
public readonly struct PlaceLimitOrderExpiredType : IExtensibleValue<PlaceLimitOrderExpiredType>, IEquatable<PlaceLimitOrderExpiredType>
{
    private readonly string? _value;

    public PlaceLimitOrderExpiredType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceLimitOrderExpiredType ExpiredType1D { get; } = new("1_D");

    public static PlaceLimitOrderExpiredType ExpiredType3D { get; } = new("3_D");

    public static PlaceLimitOrderExpiredType ExpiredType7D { get; } = new("7_D");

    public static PlaceLimitOrderExpiredType ExpiredType30D { get; } = new("30_D");

    static PlaceLimitOrderExpiredType IExtensibleValue<PlaceLimitOrderExpiredType>.Create(string value) => new(value);

    public static bool operator ==(PlaceLimitOrderExpiredType left, PlaceLimitOrderExpiredType right) => left.Equals(right);

    public static bool operator !=(PlaceLimitOrderExpiredType left, PlaceLimitOrderExpiredType right) => !left.Equals(right);

    public static implicit operator PlaceLimitOrderExpiredType(string value) => new(value);

    public static PlaceLimitOrderExpiredType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceLimitOrderExpiredType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceLimitOrderExpiredType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceLimitOrderWalletType>))]
public readonly struct PlaceLimitOrderWalletType : IExtensibleValue<PlaceLimitOrderWalletType>, IEquatable<PlaceLimitOrderWalletType>
{
    private readonly string? _value;

    public PlaceLimitOrderWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceLimitOrderWalletType Spot { get; } = new("SPOT");

    public static PlaceLimitOrderWalletType Funding { get; } = new("FUNDING");

    public static PlaceLimitOrderWalletType Earn { get; } = new("EARN");

    public static PlaceLimitOrderWalletType SpotFunding { get; } = new("SPOT_FUNDING");

    public static PlaceLimitOrderWalletType FundingEarn { get; } = new("FUNDING_EARN");

    public static PlaceLimitOrderWalletType SpotFundingEarn { get; } = new("SPOT_FUNDING_EARN");

    public static PlaceLimitOrderWalletType SpotEarn { get; } = new("SPOT_EARN");

    static PlaceLimitOrderWalletType IExtensibleValue<PlaceLimitOrderWalletType>.Create(string value) => new(value);

    public static bool operator ==(PlaceLimitOrderWalletType left, PlaceLimitOrderWalletType right) => left.Equals(right);

    public static bool operator !=(PlaceLimitOrderWalletType left, PlaceLimitOrderWalletType right) => !left.Equals(right);

    public static implicit operator PlaceLimitOrderWalletType(string value) => new(value);

    public static PlaceLimitOrderWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceLimitOrderWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceLimitOrderWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PlaceLimitOrderRequest
{
    /// <summary>
    /// base asset (use the response fromIsBase from GET /sapi/v1/convert/exchangeInfo api to check which
    /// one is baseAsset )
    /// </summary>
    public required string BaseAsset { get; init; }

    /// <summary>quote asset</summary>
    public required string QuoteAsset { get; init; }

    /// <summary>Symbol limit price (from baseAsset to quoteAsset)</summary>
    public required decimal LimitPrice { get; init; }

    /// <summary>BUY or SELL</summary>
    public required PlaceLimitOrderSide Side { get; init; }

    /// <summary>Order expiry duration. 1_D, 3_D, 7_D, 30_D (D means day)</summary>
    public required PlaceLimitOrderExpiredType ExpiredType { get; init; }

    /// <summary>Base asset amount. (One of baseAmount or quoteAmount is required)</summary>
    public decimal? BaseAmount { get; init; }

    /// <summary>Quote asset amount. (One of baseAmount or quoteAmount is required)</summary>
    public decimal? QuoteAmount { get; init; }

    /// <summary>
    /// Wallet to use for payment. Supported values: SPOT, FUNDING, EARN. Combined wallets also supported:
    /// SPOT_FUNDING, FUNDING_EARN, SPOT_FUNDING_EARN, SPOT_EARN. Default is SPOT.
    /// </summary>
    public PlaceLimitOrderWalletType? WalletType { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryLimitOpenOrdersRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<SendQuoteRequestWalletType>))]
public readonly struct SendQuoteRequestWalletType : IExtensibleValue<SendQuoteRequestWalletType>, IEquatable<SendQuoteRequestWalletType>
{
    private readonly string? _value;

    public SendQuoteRequestWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SendQuoteRequestWalletType Spot { get; } = new("SPOT");

    public static SendQuoteRequestWalletType Funding { get; } = new("FUNDING");

    public static SendQuoteRequestWalletType Earn { get; } = new("EARN");

    public static SendQuoteRequestWalletType SpotFunding { get; } = new("SPOT_FUNDING");

    public static SendQuoteRequestWalletType FundingEarn { get; } = new("FUNDING_EARN");

    public static SendQuoteRequestWalletType SpotFundingEarn { get; } = new("SPOT_FUNDING_EARN");

    public static SendQuoteRequestWalletType SpotEarn { get; } = new("SPOT_EARN");

    static SendQuoteRequestWalletType IExtensibleValue<SendQuoteRequestWalletType>.Create(string value) => new(value);

    public static bool operator ==(SendQuoteRequestWalletType left, SendQuoteRequestWalletType right) => left.Equals(right);

    public static bool operator !=(SendQuoteRequestWalletType left, SendQuoteRequestWalletType right) => !left.Equals(right);

    public static implicit operator SendQuoteRequestWalletType(string value) => new(value);

    public static SendQuoteRequestWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SendQuoteRequestWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SendQuoteRequestWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<SendQuoteRequestValidTime>))]
public readonly struct SendQuoteRequestValidTime : IExtensibleValue<SendQuoteRequestValidTime>, IEquatable<SendQuoteRequestValidTime>
{
    private readonly string? _value;

    public SendQuoteRequestValidTime(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static SendQuoteRequestValidTime ValidTime10s { get; } = new("10s");

    public static SendQuoteRequestValidTime ValidTime30s { get; } = new("30s");

    public static SendQuoteRequestValidTime ValidTime1m { get; } = new("1m");

    static SendQuoteRequestValidTime IExtensibleValue<SendQuoteRequestValidTime>.Create(string value) => new(value);

    public static bool operator ==(SendQuoteRequestValidTime left, SendQuoteRequestValidTime right) => left.Equals(right);

    public static bool operator !=(SendQuoteRequestValidTime left, SendQuoteRequestValidTime right) => !left.Equals(right);

    public static implicit operator SendQuoteRequestValidTime(string value) => new(value);

    public static SendQuoteRequestValidTime FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SendQuoteRequestValidTime other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SendQuoteRequestValidTime other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class SendQuoteRequestRequest
{
    public required string FromAsset { get; init; }

    public required string ToAsset { get; init; }

    /// <summary>When specified, it is the amount you will be debited after the conversion</summary>
    public decimal? FromAmount { get; init; }

    /// <summary>When specified, it is the amount you will be credited after the conversion</summary>
    public decimal? ToAmount { get; init; }

    /// <summary>
    /// Wallet to use for payment. Supported values: SPOT, FUNDING, EARN. Combined wallets also supported:
    /// SPOT_FUNDING, FUNDING_EARN, SPOT_FUNDING_EARN, SPOT_EARN. Default is SPOT.
    /// </summary>
    public SendQuoteRequestWalletType? WalletType { get; init; }

    /// <summary>Quote valid duration. Supported values: 10s, 30s, 1m. Default is 10s.</summary>
    public SendQuoteRequestValidTime? ValidTime { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class ConvertRestApi
{

    /// <summary>Accept Quote (TRADE)</summary>
    /// <remarks>
    /// <para>Accept the offered quote by quote ID.</para>
    /// <para>Weight(UID): 500</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AcceptQuoteResponse>> AcceptQuoteAsync(AcceptQuoteRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/convert/acceptQuote", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AcceptQuoteResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("quoteId", request.QuoteId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.AcceptQuoteResponse, cancellationToken);
    }

    /// <summary>Cancel limit order (TRADE)</summary>
    /// <remarks>
    /// <para>Enable users to cancel a limit order</para>
    /// <para>Weight(UID): 200</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelLimitOrderResponse>> CancelLimitOrderAsync(CancelLimitOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/convert/limit/cancelOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelLimitOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.CancelLimitOrderResponse, cancellationToken);
    }

    /// <summary>Get Convert Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Convert Trade History</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The max interval between startTime and endTime is 30 days.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetConvertTradeHistoryResponse>> GetConvertTradeHistoryAsync(GetConvertTradeHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/convert/tradeFlow", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetConvertTradeHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.GetConvertTradeHistoryResponse, cancellationToken);
    }

    /// <summary>Order status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query order status by order ID.</para>
    /// <para>Weight(UID): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OrderStatusResponse>> OrderStatusAsync(OrderStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/convert/orderStatus", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("quoteId", request.QuoteId);
        return _client.SendAsync(r, ConvertRestApiJson.Default.OrderStatusResponse, cancellationToken);
    }

    /// <summary>Place limit order (TRADE)</summary>
    /// <remarks>
    /// <para>Enable users to place a limit order</para>
    /// <para>Weight(UID): 500</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- baseAsset and quoteAsset can be determined via the exchangeInfo endpoint.</para>
    /// <para>- Limit price is defined from baseAsset to quoteAsset.</para>
    /// <para>- Exactly one of baseAmount or quoteAmount should be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PlaceLimitOrderResponse>> PlaceLimitOrderAsync(PlaceLimitOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/convert/limit/placeOrder", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<PlaceLimitOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("baseAsset", request.BaseAsset);
        r.Query("quoteAsset", request.QuoteAsset);
        r.Query("limitPrice", request.LimitPrice);
        r.Query("side", request.Side);
        r.Query("expiredType", request.ExpiredType);
        r.Query("baseAmount", request.BaseAmount);
        r.Query("quoteAmount", request.QuoteAmount);
        r.Query("walletType", request.WalletType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.PlaceLimitOrderResponse, cancellationToken);
    }

    /// <summary>Query limit open orders (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query current open limit orders</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryLimitOpenOrdersResponse>> QueryLimitOpenOrdersAsync(QueryLimitOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/convert/limit/queryOpenOrders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.QueryLimitOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Send Quote Request (TRADE)</summary>
    /// <remarks>
    /// <para>Request a quote for the requested token pairs</para>
    /// <para>Weight(UID): 200</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Either fromAmount or toAmount should be sent.</para>
    /// <para>- quoteId is returned only if you have enough funds to convert.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SendQuoteRequestResponse>> SendQuoteRequestAsync(SendQuoteRequestRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/convert/getQuote", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SendQuoteRequestResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromAsset", request.FromAsset);
        r.Query("toAsset", request.ToAsset);
        r.Query("fromAmount", request.FromAmount);
        r.Query("toAmount", request.ToAmount);
        r.Query("walletType", request.WalletType);
        r.Query("validTime", request.ValidTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.SendQuoteRequestResponse, cancellationToken);
    }
}
