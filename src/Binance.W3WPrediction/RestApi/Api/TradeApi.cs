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

namespace Binance.W3WPrediction.RestApi;

public sealed class BatchCancelOrdersRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Wallet ID</summary>
    public required string WalletId { get; init; }

    /// <summary>List of orders to cancel (index i starts from 0)</summary>
    public List<BatchCancelOrdersCancelInfoListParameterInner>? CancelInfoList { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetQuoteSide>))]
public readonly struct GetQuoteSide : IExtensibleValue<GetQuoteSide>, IEquatable<GetQuoteSide>
{
    private readonly string? _value;

    public GetQuoteSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetQuoteSide Buy { get; } = new("BUY");

    public static GetQuoteSide Sell { get; } = new("SELL");

    static GetQuoteSide IExtensibleValue<GetQuoteSide>.Create(string value) => new(value);

    public static bool operator ==(GetQuoteSide left, GetQuoteSide right) => left.Equals(right);

    public static bool operator !=(GetQuoteSide left, GetQuoteSide right) => !left.Equals(right);

    public static implicit operator GetQuoteSide(string value) => new(value);

    public static GetQuoteSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetQuoteSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetQuoteSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<GetQuoteOrderType>))]
public readonly struct GetQuoteOrderType : IExtensibleValue<GetQuoteOrderType>, IEquatable<GetQuoteOrderType>
{
    private readonly string? _value;

    public GetQuoteOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetQuoteOrderType Market { get; } = new("MARKET");

    public static GetQuoteOrderType Limit { get; } = new("LIMIT");

    static GetQuoteOrderType IExtensibleValue<GetQuoteOrderType>.Create(string value) => new(value);

    public static bool operator ==(GetQuoteOrderType left, GetQuoteOrderType right) => left.Equals(right);

    public static bool operator !=(GetQuoteOrderType left, GetQuoteOrderType right) => !left.Equals(right);

    public static implicit operator GetQuoteOrderType(string value) => new(value);

    public static GetQuoteOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetQuoteOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetQuoteOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<GetQuoteFundingSource>))]
public readonly struct GetQuoteFundingSource : IExtensibleValue<GetQuoteFundingSource>, IEquatable<GetQuoteFundingSource>
{
    private readonly string? _value;

    public GetQuoteFundingSource(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetQuoteFundingSource Mpc { get; } = new("MPC");

    public static GetQuoteFundingSource Cex { get; } = new("CEX");

    static GetQuoteFundingSource IExtensibleValue<GetQuoteFundingSource>.Create(string value) => new(value);

    public static bool operator ==(GetQuoteFundingSource left, GetQuoteFundingSource right) => left.Equals(right);

    public static bool operator !=(GetQuoteFundingSource left, GetQuoteFundingSource right) => !left.Equals(right);

    public static implicit operator GetQuoteFundingSource(string value) => new(value);

    public static GetQuoteFundingSource FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetQuoteFundingSource other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetQuoteFundingSource other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetQuoteRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Prediction outcome token ID</summary>
    public required string TokenId { get; init; }

    /// <summary>Trade direction. Enum: BUY, SELL</summary>
    public required GetQuoteSide Side { get; init; }

    /// <summary>
    /// Input amount in wei (18 decimals). Must be &gt; 0. The minimum is set by the server and may change,
    /// see the response notes. Example: 1000000000000000000 = 1 USDT
    /// </summary>
    public required string AmountIn { get; init; }

    /// <summary>Order type. Enum: MARKET, LIMIT</summary>
    public required GetQuoteOrderType OrderType { get; init; }

    /// <summary>Slippage tolerance in basis points. Range 1–10000</summary>
    public required long SlippageBps { get; init; }

    /// <summary>
    /// Limit price. Required when orderType=LIMIT. Must be &gt; 0. A price that is not on the price tick of
    /// the market (see decimalPrecision in Get Market Detail) is truncated down instead of being rejected,
    /// unless the result is 0
    /// </summary>
    public string? PriceLimit { get; init; }

    /// <summary>Chain ID. Default 56 (BSC)</summary>
    public string? ChainId { get; init; }

    /// <summary>Fee rate in basis points. Default 200, range 1–10000</summary>
    public long? FeeRateBps { get; init; }

    /// <summary>Funding source. Enum: MPC, CEX. Default MPC</summary>
    public GetQuoteFundingSource? FundingSource { get; init; }

    /// <summary>Auto-transfer amount before order (wei). Must be &gt; 0 if provided</summary>
    public string? FundTransferAmount { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOrderAccountType>))]
public readonly struct PlaceOrderAccountType : IExtensibleValue<PlaceOrderAccountType>, IEquatable<PlaceOrderAccountType>
{
    private readonly string? _value;

    public PlaceOrderAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOrderAccountType Spot { get; } = new("SPOT");

    public static PlaceOrderAccountType Funding { get; } = new("FUNDING");

    static PlaceOrderAccountType IExtensibleValue<PlaceOrderAccountType>.Create(string value) => new(value);

    public static bool operator ==(PlaceOrderAccountType left, PlaceOrderAccountType right) => left.Equals(right);

    public static bool operator !=(PlaceOrderAccountType left, PlaceOrderAccountType right) => !left.Equals(right);

    public static implicit operator PlaceOrderAccountType(string value) => new(value);

    public static PlaceOrderAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOrderAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOrderAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOrderOrderType>))]
public readonly struct PlaceOrderOrderType : IExtensibleValue<PlaceOrderOrderType>, IEquatable<PlaceOrderOrderType>
{
    private readonly string? _value;

    public PlaceOrderOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOrderOrderType Market { get; } = new("MARKET");

    public static PlaceOrderOrderType Limit { get; } = new("LIMIT");

    static PlaceOrderOrderType IExtensibleValue<PlaceOrderOrderType>.Create(string value) => new(value);

    public static bool operator ==(PlaceOrderOrderType left, PlaceOrderOrderType right) => left.Equals(right);

    public static bool operator !=(PlaceOrderOrderType left, PlaceOrderOrderType right) => !left.Equals(right);

    public static implicit operator PlaceOrderOrderType(string value) => new(value);

    public static PlaceOrderOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOrderOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOrderOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOrderFundingSource>))]
public readonly struct PlaceOrderFundingSource : IExtensibleValue<PlaceOrderFundingSource>, IEquatable<PlaceOrderFundingSource>
{
    private readonly string? _value;

    public PlaceOrderFundingSource(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOrderFundingSource Mpc { get; } = new("MPC");

    public static PlaceOrderFundingSource Cex { get; } = new("CEX");

    static PlaceOrderFundingSource IExtensibleValue<PlaceOrderFundingSource>.Create(string value) => new(value);

    public static bool operator ==(PlaceOrderFundingSource left, PlaceOrderFundingSource right) => left.Equals(right);

    public static bool operator !=(PlaceOrderFundingSource left, PlaceOrderFundingSource right) => !left.Equals(right);

    public static implicit operator PlaceOrderFundingSource(string value) => new(value);

    public static PlaceOrderFundingSource FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOrderFundingSource other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOrderFundingSource other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PlaceOrderRequest
{
    /// <summary>
    /// User's prediction wallet address. Must be a valid address owned by the calling UID — a well-formed
    /// address not owned by the UID and a malformed (non-address) value both return the same generic -3026.
    /// An empty string instead returns -1102 naming the field.
    /// </summary>
    public required string WalletAddress { get; init; }

    /// <summary>Wallet ID</summary>
    public required string WalletId { get; init; }

    /// <summary>Quote ID obtained from Get Quote</summary>
    public required string QuoteId { get; init; }

    /// <summary>Must match orderType: FOK for MARKET, GTC for LIMIT</summary>
    public required string TimeInForce { get; init; }

    /// <summary>
    /// Payment account type. Enum: SPOT, FUNDING. This only determines the settlement/reference account —
    /// it does not control which balance is debited. See fundingSource below for that.
    /// </summary>
    public required PlaceOrderAccountType AccountType { get; init; }

    /// <summary>
    /// Order type. Enum: MARKET, LIMIT only. Do not combine with timeInForce (e.g. LIMIT_GTC is not a valid
    /// value) — set timeInForce separately per the Validation Rules table below.
    /// </summary>
    public required PlaceOrderOrderType OrderType { get; init; }

    /// <summary>Slippage tolerance in basis points. Range 1–10000</summary>
    public required long SlippageBps { get; init; }

    /// <summary>
    /// Limit price. Required when orderType=LIMIT, must be &gt; 0. Omitting it when orderType=LIMIT returns
    /// a generic -3026 (no field name in the message).
    /// </summary>
    public string? PriceLimit { get; init; }

    /// <summary>
    /// Funding source. Enum: MPC, CEX. Default MPC. This determines which balance is actually debited,
    /// independent of accountType.
    /// </summary>
    public PlaceOrderFundingSource? FundingSource { get; init; }

    /// <summary>Auto-transfer amount before order (wei). Must be &gt; 0 if provided</summary>
    public string? FundTransferAmount { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryActiveOrdersTradeSide>))]
public readonly struct QueryActiveOrdersTradeSide : IExtensibleValue<QueryActiveOrdersTradeSide>, IEquatable<QueryActiveOrdersTradeSide>
{
    private readonly string? _value;

    public QueryActiveOrdersTradeSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryActiveOrdersTradeSide Buy { get; } = new("BUY");

    public static QueryActiveOrdersTradeSide Sell { get; } = new("SELL");

    static QueryActiveOrdersTradeSide IExtensibleValue<QueryActiveOrdersTradeSide>.Create(string value) => new(value);

    public static bool operator ==(QueryActiveOrdersTradeSide left, QueryActiveOrdersTradeSide right) => left.Equals(right);

    public static bool operator !=(QueryActiveOrdersTradeSide left, QueryActiveOrdersTradeSide right) => !left.Equals(right);

    public static implicit operator QueryActiveOrdersTradeSide(string value) => new(value);

    public static QueryActiveOrdersTradeSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryActiveOrdersTradeSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryActiveOrdersTradeSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryActiveOrdersRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Filter by trade side. Enum: BUY, SELL</summary>
    public QueryActiveOrdersTradeSide? TradeSide { get; init; }

    /// <summary>Filter by level-1 category</summary>
    public string? L1Category { get; init; }

    /// <summary>Filter by market ID</summary>
    public long? MarketId { get; init; }

    /// <summary>Pagination offset. Default 0</summary>
    public long? Offset { get; init; }

    /// <summary>Page size. Default 20, range 1–100</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryOrderHistoryOrderType>))]
public readonly struct QueryOrderHistoryOrderType : IExtensibleValue<QueryOrderHistoryOrderType>, IEquatable<QueryOrderHistoryOrderType>
{
    private readonly string? _value;

    public QueryOrderHistoryOrderType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryOrderHistoryOrderType Market { get; } = new("MARKET");

    public static QueryOrderHistoryOrderType Limit { get; } = new("LIMIT");

    static QueryOrderHistoryOrderType IExtensibleValue<QueryOrderHistoryOrderType>.Create(string value) => new(value);

    public static bool operator ==(QueryOrderHistoryOrderType left, QueryOrderHistoryOrderType right) => left.Equals(right);

    public static bool operator !=(QueryOrderHistoryOrderType left, QueryOrderHistoryOrderType right) => !left.Equals(right);

    public static implicit operator QueryOrderHistoryOrderType(string value) => new(value);

    public static QueryOrderHistoryOrderType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryOrderHistoryOrderType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryOrderHistoryOrderType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryOrderHistoryRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Filter by level-1 category</summary>
    public string? L1Category { get; init; }

    /// <summary>Filter by order type. Enum: MARKET, LIMIT</summary>
    public QueryOrderHistoryOrderType? OrderType { get; init; }

    /// <summary>Filter by order status</summary>
    public string? Status { get; init; }

    /// <summary>Start date. Format: yyyy-MM-dd. Must be ≤ endDate</summary>
    public string? StartDate { get; init; }

    /// <summary>End date. Format: yyyy-MM-dd. Must be ≥ startDate</summary>
    public string? EndDate { get; init; }

    /// <summary>Pagination offset. Default 0</summary>
    public long? Offset { get; init; }

    /// <summary>Page size. Default 20, range 1–100</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class W3WPredictionRestApi
{

    /// <summary>Batch Cancel Orders (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Cancel one or more active prediction orders in a single request. Requires SAS authorization.</para>
    /// <para>
    /// Known Issue — Bracket Encoding Incompatibility: This endpoint uses indexed bracket notation
    /// (cancelInfoList[0].orderId). Binance SAPI signature verification runs over the raw, unencoded
    /// canonical string. However, mainstream HTTP libraries (Python requests, Java HttpURLConnection/URI,
    /// Go net/url, Node.js url) automatically percent-encode [ → %5B and ] → %5D, producing a signature
    /// mismatch with error -1022 Signature for this request is not valid. Postman is unaffected because it
    /// does not encode keys.
    /// </para>
    /// <para>Workarounds (use low-level HTTP APIs that do not normalize URLs):</para>
    /// <para>- Python: use http.client (stdlib) and hand-build the body string.</para>
    /// <para>- Java: use HttpURLConnection and write the raw body bytes directly.</para>
    /// <para>- Go: use strings.NewReader with a hand-built body instead of url.Values.Encode().</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Use dot notation for nested list fields: cancelInfoList[0].orderId, cancelInfoList[1].orderId,
    /// etc.
    /// </para>
    /// <para>
    /// - vendor does not need to be supplied. The server automatically sets the correct vendor
    /// (predict_fun) for every item in the batch.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<BatchCancelOrdersResponse>> BatchCancelOrdersAsync(BatchCancelOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/trade/batch-cancel", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<BatchCancelOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("walletId", request.WalletId);
        r.Query("cancelInfoList", Wire.Json(request.CancelInfoList, W3WPredictionRestApiJson.Default.ListBatchCancelOrdersCancelInfoListParameterInner));
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.BatchCancelOrdersResponse, cancellationToken);
    }

    /// <summary>Get Quote (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Get a price quote for a prediction order. The returned quoteId must be used in the subsequent Place
    /// Order request.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Response Notes:</para>
    /// <para>
    /// - feeAmount is a string because it is denominated in wei (18 decimals) and may exceed JavaScript's
    /// safe integer range. feeDiscountBps is also a string to allow fractional basis-point values in the
    /// future. feeRateBps and slippageBps are integers and will never exceed safe integer bounds.
    /// </para>
    /// <para>
    /// - Minimum order amount: The minimum order amount is set by the server and the upstream market rules
    /// and may change, so no fixed value is documented. BUY orders are checked by amount (amountIn) and
    /// SELL orders by share quantity, for both MARKET and LIMIT orders. If the amountIn of a BUY order is
    /// below the minimum, the server returns -9000 with the message Your order amount is too small. A
    /// successful quote does not guarantee that the order is accepted or filled, so check the error message
    /// and the final order status.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetQuoteResponse>> GetQuoteAsync(GetQuoteRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/trade/get-quote", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetQuoteResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("tokenId", request.TokenId);
        r.Query("side", request.Side);
        r.Query("amountIn", request.AmountIn);
        r.Query("orderType", request.OrderType);
        r.Query("slippageBps", request.SlippageBps);
        r.Query("priceLimit", request.PriceLimit);
        r.Query("chainId", request.ChainId);
        r.Query("feeRateBps", request.FeeRateBps);
        r.Query("fundingSource", request.FundingSource);
        r.Query("fundTransferAmount", request.FundTransferAmount);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetQuoteResponse, cancellationToken);
    }

    /// <summary>Place Order (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Place a prediction order using a previously obtained quote. Requires SAS authorization.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>- Validation rules:</para>
    /// <para>| orderType | timeInForce | priceLimit |</para>
    /// <para>| MARKET | Must be FOK | Not required |</para>
    /// <para>| LIMIT | Must be GTC | Required, must be &gt; 0 |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PlaceOrderResponse>> PlaceOrderAsync(PlaceOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/trade/place-order-bundle", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<PlaceOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("walletId", request.WalletId);
        r.Query("quoteId", request.QuoteId);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("accountType", request.AccountType);
        r.Query("orderType", request.OrderType);
        r.Query("slippageBps", request.SlippageBps);
        r.Query("priceLimit", request.PriceLimit);
        r.Query("fundingSource", request.FundingSource);
        r.Query("fundTransferAmount", request.FundTransferAmount);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.PlaceOrderResponse, cancellationToken);
    }

    /// <summary>Query Active Orders (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get active (open) prediction orders for the authenticated user.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryActiveOrdersResponse>> QueryActiveOrdersAsync(QueryActiveOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/order/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryActiveOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("tradeSide", request.TradeSide);
        r.Query("l1Category", request.L1Category);
        r.Query("marketId", request.MarketId);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryActiveOrdersResponse, cancellationToken);
    }

    /// <summary>Query Order History (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get historical prediction orders (all statuses) for the authenticated user, with optional filters.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryOrderHistoryResponse>> QueryOrderHistoryAsync(QueryOrderHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/order/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryOrderHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("l1Category", request.L1Category);
        r.Query("orderType", request.OrderType);
        r.Query("status", request.Status);
        r.Query("startDate", request.StartDate);
        r.Query("endDate", request.EndDate);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryOrderHistoryResponse, cancellationToken);
    }
}
