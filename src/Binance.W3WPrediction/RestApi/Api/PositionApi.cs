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

public sealed class GetPositionByTokenRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Prediction outcome token ID</summary>
    public required string TokenId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryPnLRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Filter by prediction token ID</summary>
    public string? TokenId { get; init; }

    /// <summary>Filter by market ID. Must be &gt; 0</summary>
    public long? MarketId { get; init; }

    /// <summary>Filter by market topic ID. Must be &gt; 0</summary>
    public long? MarketTopicId { get; init; }

    /// <summary>If true, return only active (unresolved) positions</summary>
    public bool? ActiveOnly { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryPositionsRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Position status tab. Values from PositionQueryType. Default ONGOING</summary>
    public string? Tab { get; init; }

    /// <summary>Pagination offset. Default 0</summary>
    public long? Offset { get; init; }

    /// <summary>Page size. Default 20, range 1–100</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryPositionsByFilterRequest
{
    /// <summary>User's prediction wallet address</summary>
    public string? WalletAddress { get; init; }

    /// <summary>Filter by market topic ID</summary>
    public long? MarketTopicId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QuerySettledPositionHistoryRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Filter by level-1 category</summary>
    public string? L1Category { get; init; }

    /// <summary>Settlement result filter</summary>
    public long? Result { get; init; }

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

    /// <summary>Get Position by Token (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get the authenticated user's position detail for a specific prediction token.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetPositionByTokenResponse>> GetPositionByTokenAsync(GetPositionByTokenRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/position/token", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetPositionByTokenResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("tokenId", request.TokenId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetPositionByTokenResponse, cancellationToken);
    }

    /// <summary>Query PnL (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Query profit and loss records for the authenticated user's prediction positions. When tokenId is
    /// provided, returns a single record in pnl; otherwise returns a list in pnlList.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryPnLResponse>> QueryPnLAsync(QueryPnLRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/pnl/query", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryPnLResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("tokenId", request.TokenId);
        r.Query("marketId", request.MarketId);
        r.Query("marketTopicId", request.MarketTopicId);
        r.Query("activeOnly", request.ActiveOnly);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryPnLResponse, cancellationToken);
    }

    /// <summary>Query Positions (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Get the authenticated user's prediction token positions with portfolio summary and tab-based
    /// filtering.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryPositionsResponse>> QueryPositionsAsync(QueryPositionsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/position/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryPositionsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("tab", request.Tab);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryPositionsResponse, cancellationToken);
    }

    /// <summary>Query Positions by Filter (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Get prediction positions filtered by wallet address and/or market topic ID. Both parameters are
    /// optional.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryPositionsByFilterResponse>> QueryPositionsByFilterAsync(QueryPositionsByFilterRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/position/filter", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("walletAddress", request.WalletAddress);
        r.Query("marketTopicId", request.MarketTopicId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryPositionsByFilterResponse, cancellationToken);
    }

    /// <summary>Query Settled Position History (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get the authenticated user's settled (resolved) prediction position history with optional filters.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Response Notes:</para>
    /// <para>
    /// - There is no separate cancelled, invalid or refunded status. A resolved market pays each outcome by
    /// its payout ratio, which can be fractional, for example 0.5 for each of two outcomes. This is not a
    /// refund of the purchase cost. Use finalOutcome, isWinner, claimAmount and redeemStatus together with
    /// your own claim records, and Get Market Detail for outcomes[].winner.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySettledPositionHistoryResponse>> QuerySettledPositionHistoryAsync(QuerySettledPositionHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/position/settled-history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySettledPositionHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("l1Category", request.L1Category);
        r.Query("result", request.Result);
        r.Query("startDate", request.StartDate);
        r.Query("endDate", request.EndDate);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QuerySettledPositionHistoryResponse, cancellationToken);
    }
}
