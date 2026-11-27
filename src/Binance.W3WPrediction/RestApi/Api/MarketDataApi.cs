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

public sealed class GetMarketDetailRequest
{
    /// <summary>Market topic ID. Must be &gt; 0</summary>
    public required long MarketTopicId { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ListPredictionMarketsSortBy>))]
public readonly struct ListPredictionMarketsSortBy : IExtensibleValue<ListPredictionMarketsSortBy>, IEquatable<ListPredictionMarketsSortBy>
{
    private readonly string? _value;

    public ListPredictionMarketsSortBy(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ListPredictionMarketsSortBy Recommended { get; } = new("RECOMMENDED");

    public static ListPredictionMarketsSortBy Volume { get; } = new("VOLUME");

    public static ListPredictionMarketsSortBy Participants { get; } = new("PARTICIPANTS");

    public static ListPredictionMarketsSortBy CreatedTime { get; } = new("CREATED_TIME");

    public static ListPredictionMarketsSortBy EndDate { get; } = new("END_DATE");

    static ListPredictionMarketsSortBy IExtensibleValue<ListPredictionMarketsSortBy>.Create(string value) => new(value);

    public static bool operator ==(ListPredictionMarketsSortBy left, ListPredictionMarketsSortBy right) => left.Equals(right);

    public static bool operator !=(ListPredictionMarketsSortBy left, ListPredictionMarketsSortBy right) => !left.Equals(right);

    public static implicit operator ListPredictionMarketsSortBy(string value) => new(value);

    public static ListPredictionMarketsSortBy FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ListPredictionMarketsSortBy other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ListPredictionMarketsSortBy other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<ListPredictionMarketsOrderBy>))]
public readonly struct ListPredictionMarketsOrderBy : IExtensibleValue<ListPredictionMarketsOrderBy>, IEquatable<ListPredictionMarketsOrderBy>
{
    private readonly string? _value;

    public ListPredictionMarketsOrderBy(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ListPredictionMarketsOrderBy Asc { get; } = new("ASC");

    public static ListPredictionMarketsOrderBy Desc { get; } = new("DESC");

    static ListPredictionMarketsOrderBy IExtensibleValue<ListPredictionMarketsOrderBy>.Create(string value) => new(value);

    public static bool operator ==(ListPredictionMarketsOrderBy left, ListPredictionMarketsOrderBy right) => left.Equals(right);

    public static bool operator !=(ListPredictionMarketsOrderBy left, ListPredictionMarketsOrderBy right) => !left.Equals(right);

    public static implicit operator ListPredictionMarketsOrderBy(string value) => new(value);

    public static ListPredictionMarketsOrderBy FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ListPredictionMarketsOrderBy other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ListPredictionMarketsOrderBy other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ListPredictionMarketsRequest
{
    /// <summary>Level-1 category filter</summary>
    public string? L1Category { get; init; }

    /// <summary>Level-2 category filter</summary>
    public string? L2Category { get; init; }

    /// <summary>Sort field. Enum: RECOMMENDED, VOLUME, PARTICIPANTS, CREATED_TIME, END_DATE</summary>
    public ListPredictionMarketsSortBy? SortBy { get; init; }

    /// <summary>Sort direction. Enum: ASC, DESC</summary>
    public ListPredictionMarketsOrderBy? OrderBy { get; init; }

    /// <summary>Pagination offset. Default 0</summary>
    public long? Offset { get; init; }

    /// <summary>Page size. Default 20, range 1–100</summary>
    public long? Limit { get; init; }
}

public sealed class MarketSearchRequest
{
    /// <summary>Search keyword. Not blank</summary>
    public required string Query { get; init; }

    /// <summary>Max number of results to return. Default 20, range 1–50</summary>
    public long? TopK { get; init; }
}

public sealed class QueryLastTradePriceRequest
{
    /// <summary>Market ID. Must be &gt; 0</summary>
    public required long MarketId { get; init; }
}

public sealed class QueryOrderBookRequest
{
    /// <summary>Vendor identifier (e.g. predict_fun)</summary>
    public required string Vendor { get; init; }

    /// <summary>Market ID. Must be &gt; 0</summary>
    public required long MarketId { get; init; }

    /// <summary>Prediction outcome token ID</summary>
    public required string TokenId { get; init; }
}

public sealed partial class W3WPredictionRestApi
{

    /// <summary>Get Market Detail</summary>
    /// <remarks>
    /// <para>Get full details for a specific prediction market topic, including variant data and timeline.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Response Notes:</para>
    /// <para>
    /// - status is a case-sensitive string. REGISTERED: registered and not yet resolved, this value alone
    /// does not guarantee that trading is available. RESOLVED: the outcome has been determined, it does not
    /// mean that the user has already claimed the payout. PAUSED: trading is temporarily suspended and may
    /// resume. CLOSED: closed for display, for example the end time has passed or the market was removed,
    /// it does not guarantee that trading is closed.
    /// </para>
    /// <para>
    /// - markets[].tradingStatus shows whether new orders may be attempted. OPEN: new orders may be
    /// attempted, this is the only value that allows new orders. MATCHING_NOT_ENABLED: order matching is
    /// not enabled. CANCEL_ONLY: only cancellation is allowed. CLOSED: trading has stopped. Use
    /// markets[].tradingStatus, not status, to decide whether to place an order, because a market whose
    /// status is CLOSED can still have tradingStatus OPEN. A topic can contain several markets and an order
    /// is placed on one market, so only the tradingStatus of that market matters. A successful quote does
    /// not guarantee that an order is accepted or filled.
    /// </para>
    /// <para>
    /// - outcomes[].winner is returned only after the market is resolved. There is no separate cancelled,
    /// invalid or refunded status. A resolved market can pay more than one outcome, in that case several
    /// outcomes have winner set to true and price is the settled value per share, for example 0.5 for each
    /// of two outcomes.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetMarketDetailResponse>> GetMarketDetailAsync(GetMarketDetailRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/market/detail", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetMarketDetailResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("marketTopicId", request.MarketTopicId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetMarketDetailResponse, cancellationToken);
    }

    /// <summary>List Prediction Categories</summary>
    /// <remarks>
    /// <para>Get all available prediction market categories (L1 and L2).</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ListPredictionCategoriesResponse>> ListPredictionCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/category/list", signed: true, hasTimeUnit: false);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ListPredictionCategoriesResponse, cancellationToken);
    }

    /// <summary>List Prediction Markets</summary>
    /// <remarks>
    /// <para>Get a paginated list of prediction market topics, with optional category and sort filters.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Response Notes:</para>
    /// <para>- For the values of status and markets[].tradingStatus, see Get Market Detail.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ListPredictionMarketsResponse>> ListPredictionMarketsAsync(ListPredictionMarketsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/market/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("l1Category", request.L1Category);
        r.Query("l2Category", request.L2Category);
        r.Query("sortBy", request.SortBy);
        r.Query("orderBy", request.OrderBy);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ListPredictionMarketsResponse, cancellationToken);
    }

    /// <summary>Market Search</summary>
    /// <remarks>
    /// <para>Semantic search for prediction market topics by keyword.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<MarketSearchResponseInner>>> MarketSearchAsync(MarketSearchRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/market/search", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<MarketSearchResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("query", request.Query);
        r.Query("topK", request.TopK);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ListMarketSearchResponseInner, cancellationToken);
    }

    /// <summary>Query Last Trade Price</summary>
    /// <remarks>
    /// <para>Get the most recent trade price for a prediction market.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryLastTradePriceResponse>> QueryLastTradePriceAsync(QueryLastTradePriceRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/order-book/last-trade-price", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryLastTradePriceResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("marketId", request.MarketId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryLastTradePriceResponse, cancellationToken);
    }

    /// <summary>Query Order Book</summary>
    /// <remarks>
    /// <para>Get the current order book (bids and asks) for a specific prediction market outcome token.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryOrderBookResponse>> QueryOrderBookAsync(QueryOrderBookRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/order-book", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryOrderBookResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("vendor", request.Vendor);
        r.Query("marketId", request.MarketId);
        r.Query("tokenId", request.TokenId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryOrderBookResponse, cancellationToken);
    }
}
