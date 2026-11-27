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

[JsonConverter(typeof(ExtensibleValueConverter<CreateOtcBlocktradeSide>))]
public readonly struct CreateOtcBlocktradeSide : IExtensibleValue<CreateOtcBlocktradeSide>, IEquatable<CreateOtcBlocktradeSide>
{
    private readonly string? _value;

    public CreateOtcBlocktradeSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static CreateOtcBlocktradeSide Buy { get; } = new("BUY");

    public static CreateOtcBlocktradeSide Sell { get; } = new("SELL");

    static CreateOtcBlocktradeSide IExtensibleValue<CreateOtcBlocktradeSide>.Create(string value) => new(value);

    public static bool operator ==(CreateOtcBlocktradeSide left, CreateOtcBlocktradeSide right) => left.Equals(right);

    public static bool operator !=(CreateOtcBlocktradeSide left, CreateOtcBlocktradeSide right) => !left.Equals(right);

    public static implicit operator CreateOtcBlocktradeSide(string value) => new(value);

    public static CreateOtcBlocktradeSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is CreateOtcBlocktradeSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(CreateOtcBlocktradeSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class CreateOtcBlocktradeRequest
{
    /// <summary>PredictFun market id</summary>
    public required string MarketId { get; init; }

    /// <summary>ERC-1155 outcome token id</summary>
    public required string TokenId { get; init; }

    /// <summary>Trade side. Enum: BUY (BID), SELL (ASK)</summary>
    public required CreateOtcBlocktradeSide Side { get; init; }

    /// <summary>Maker amount in wei. BID：USDT; ASK：shares</summary>
    public required string MakerAmount { get; init; }

    /// <summary>Taker amount in wei. BID：shares; ASK：USDT</summary>
    public required string TakerAmount { get; init; }

    /// <summary>Price per share (decimal ether, e.g. 0.65)</summary>
    public required string PricePerShare { get; init; }

    /// <summary>Expiration timestamp in seconds (GTD order)</summary>
    public required long Expiration { get; init; }
}

public sealed class FulfilOtcBlocktradeRequest
{
    /// <summary>Maker order id (returned by maker create)</summary>
    public required string OrderId { get; init; }

    /// <summary>One-time fulfilment token the maker shared out-of-band</summary>
    public required string SecretToken { get; init; }
}

public sealed class GetOtcBlocktradeDetailRequest
{
    /// <summary>Maker order id (returned by create)</summary>
    public required string OrderId { get; init; }
}

public sealed class GetOtcBlocktradeEventsRequest
{
    /// <summary>Page size</summary>
    public long? First { get; init; }

    /// <summary>Pagination cursor</summary>
    public string? After { get; init; }

    /// <summary>Filter by event types (e.g. ["MATCH_SUCCESS","EXPIRE"])</summary>
    public List<string>? EventTypes { get; init; }

    /// <summary>Filter by market id</summary>
    public long? MarketId { get; init; }
}

public sealed class GetOtcReservedBalancesRequest
{
    /// <summary>Assets to query (max 50)</summary>
    public required List<GetOtcReservedBalancesAssetsParameterInner> Assets { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ListOtcBlocktradesStatus>))]
public readonly struct ListOtcBlocktradesStatus : IExtensibleValue<ListOtcBlocktradesStatus>, IEquatable<ListOtcBlocktradesStatus>
{
    private readonly string? _value;

    public ListOtcBlocktradesStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ListOtcBlocktradesStatus Open { get; } = new("OPEN");

    public static ListOtcBlocktradesStatus Fulfilled { get; } = new("FULFILLED");

    public static ListOtcBlocktradesStatus Matched { get; } = new("MATCHED");

    public static ListOtcBlocktradesStatus Cancelled { get; } = new("CANCELLED");

    public static ListOtcBlocktradesStatus Expired { get; } = new("EXPIRED");

    public static ListOtcBlocktradesStatus Failed { get; } = new("FAILED");

    static ListOtcBlocktradesStatus IExtensibleValue<ListOtcBlocktradesStatus>.Create(string value) => new(value);

    public static bool operator ==(ListOtcBlocktradesStatus left, ListOtcBlocktradesStatus right) => left.Equals(right);

    public static bool operator !=(ListOtcBlocktradesStatus left, ListOtcBlocktradesStatus right) => !left.Equals(right);

    public static implicit operator ListOtcBlocktradesStatus(string value) => new(value);

    public static ListOtcBlocktradesStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ListOtcBlocktradesStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ListOtcBlocktradesStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ListOtcBlocktradesRequest
{
    /// <summary>Page size</summary>
    public long? First { get; init; }

    /// <summary>Pagination cursor (from previous response)</summary>
    public string? After { get; init; }

    /// <summary>Filter by status. Enum: OPEN, FULFILLED, MATCHED, CANCELLED, EXPIRED, FAILED</summary>
    public ListOtcBlocktradesStatus? Status { get; init; }
}

public sealed class PreviewOtcBlocktradeRequest
{
    /// <summary>One-time fulfilment token the maker shared out-of-band</summary>
    public required string SecretToken { get; init; }
}

public sealed class RemoveOtcBlocktradesRequest
{
    /// <summary>
    /// Order ids to remove (max 100). Must be the orderId returned by Create OTC Blocktrade
    /// </summary>
    public required List<string> OrderIds { get; init; }
}

public sealed partial class W3WPredictionRestApi
{

    /// <summary>Create OTC Blocktrade (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Create an OTC blocktrade as the maker (BID to buy outcome shares with USDT, or ASK to sell outcome
    /// shares for USDT). The maker wallet is resolved server-side by userId; signing is done server-side
    /// via SAS typedDataSign. Returns orderId and a one-time secretToken to share out-of-band with the
    /// intended taker.
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// <para>- Side &amp; Amount Rules:</para>
    /// <para>| side | makerAmount | takerAmount |</para>
    /// <para>| BUY | USDT (wei) | shares (wei) |</para>
    /// <para>| SELL | shares (wei) | USDT (wei) |</para>
    /// <para>
    /// - "Note on side encoding: this request uses a string enum (BUY/SELL). Responses from Get Blocktrade
    /// Detail / Preview / List return side as an integer and also include a quoteType string — both encode
    /// the same concept."
    /// </para>
    /// <para>| Request side | Response side (Integer) | Response quoteType |</para>
    /// <para>| BUY | 0 | "Bid" |</para>
    /// <para>| SELL | 1 | "Ask" |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateOtcBlocktradeResponse>> CreateOtcBlocktradeAsync(CreateOtcBlocktradeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/create", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateOtcBlocktradeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("marketId", request.MarketId);
        r.Query("tokenId", request.TokenId);
        r.Query("side", request.Side);
        r.Query("makerAmount", request.MakerAmount);
        r.Query("takerAmount", request.TakerAmount);
        r.Query("pricePerShare", request.PricePerShare);
        r.Query("expiration", request.Expiration);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.CreateOtcBlocktradeResponse, cancellationToken);
    }

    /// <summary>Fulfil OTC Blocktrade (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Fulfil an open maker blocktrade as the taker, using the secretToken the maker shared out-of-band.
    /// All-or-nothing fill (no partial fill); the taker order is the server-derived symmetric inverse of
    /// the maker order.
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FulfilOtcBlocktradeResponse>> FulfilOtcBlocktradeAsync(FulfilOtcBlocktradeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/fulfil", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FulfilOtcBlocktradeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        r.Query("secretToken", request.SecretToken);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.FulfilOtcBlocktradeResponse, cancellationToken);
    }

    /// <summary>Get OTC Blocktrade Detail (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Query the maker's own blocktrade by orderId. Returns full order data including status and
    /// secretToken.
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOtcBlocktradeDetailResponse>> GetOtcBlocktradeDetailAsync(GetOtcBlocktradeDetailRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/detail", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetOtcBlocktradeDetailResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetOtcBlocktradeDetailResponse, cancellationToken);
    }

    /// <summary>Get OTC Blocktrade Events (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Paginated feed of blocktrade lifecycle and settlement events (CREATE, FULFIL, MATCH_SUBMIT,
    /// MATCH_SUCCESS, EXPIRE, FAILED, etc.).
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOtcBlocktradeEventsResponse>> GetOtcBlocktradeEventsAsync(GetOtcBlocktradeEventsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/events", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("first", request.First);
        r.Query("after", request.After);
        r.Query("eventTypes", request.EventTypes);
        r.Query("marketId", request.MarketId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetOtcBlocktradeEventsResponse, cancellationToken);
    }

    /// <summary>Get OTC Reserved Balances (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Query PredictFun reserved balances for the caller's bound wallet — these are funds locked by the
    /// caller's open OTC blocktrade orders (maker BID locks USDT, maker ASK locks shares). Not tied to a
    /// specific blocktrade id; the path nesting under otc/blocktrade reflects the cause of the lock, not a
    /// per-order query. Returns one entry per requested asset, aligned with the request order. Pass
    /// {type:"USDT"} for reserved USDT, or {type:"SHARE", tokenId:"..."} for a specific outcome token's
    /// reserved shares.
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// <para>- AssetQuery:</para>
    /// <para>| Name | Type | Mandatory | Description |</para>
    /// <para>| type | STRING | YES | Asset type. Enum: USDT, SHARE |</para>
    /// <para>| tokenId | STRING | NO | Outcome token id (present for SHARE entries only) |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOtcReservedBalancesResponse>> GetOtcReservedBalancesAsync(GetOtcReservedBalancesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/reserved-balances", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetOtcReservedBalancesResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("assets", Wire.Json(request.Assets, W3WPredictionRestApiJson.Default.ListGetOtcReservedBalancesAssetsParameterInner));
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetOtcReservedBalancesResponse, cancellationToken);
    }

    /// <summary>List OTC Blocktrades (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>List the maker's own blocktrades with optional status filter and cursor pagination.</para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ListOtcBlocktradesResponse>> ListOtcBlocktradesAsync(ListOtcBlocktradesRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("first", request.First);
        r.Query("after", request.After);
        r.Query("status", request.Status);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ListOtcBlocktradesResponse, cancellationToken);
    }

    /// <summary>Preview OTC Blocktrade (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Inspect an open blocktrade by secretToken (no orderId needed). Taker uses this to preview the maker
    /// order before fulfilling. Returns the same shape as Get Blocktrade Detail, but orderId is null and
    /// secretToken is never returned from this endpoint.
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PreviewOtcBlocktradeResponse>> PreviewOtcBlocktradeAsync(PreviewOtcBlocktradeRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/preview", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<PreviewOtcBlocktradeResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("secretToken", request.SecretToken);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.PreviewOtcBlocktradeResponse, cancellationToken);
    }

    /// <summary>Remove OTC Blocktrades (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Cancel open or fulfilled-but-unsettled blocktrades. Terminal orders (already
    /// MATCHED/CANCELLED/EXPIRED/FAILED) are returned in noop instead of removed.
    /// </para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RemoveOtcBlocktradesResponse>> RemoveOtcBlocktradesAsync(RemoveOtcBlocktradesRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/otc/blocktrade/remove", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RemoveOtcBlocktradesResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderIds", request.OrderIds);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.RemoveOtcBlocktradesResponse, cancellationToken);
    }
}
