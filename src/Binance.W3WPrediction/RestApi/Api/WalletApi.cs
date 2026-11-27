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

public sealed class GetPortfolioRequest
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

public sealed class GetQuotaStatusRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class ListPredictionWalletsRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryPaymentOptionBalancesRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class W3WPredictionRestApi
{

    /// <summary>Get Portfolio (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Get the authenticated user's prediction portfolio overview including active positions count,
    /// aggregated PnL, and full position list.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetPortfolioResponse>> GetPortfolioAsync(GetPortfolioRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/pnl/portfolio", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetPortfolioResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("tokenId", request.TokenId);
        r.Query("marketId", request.MarketId);
        r.Query("marketTopicId", request.MarketTopicId);
        r.Query("activeOnly", request.ActiveOnly);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetPortfolioResponse, cancellationToken);
    }

    /// <summary>Get Quota Status (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Query the current user's daily trading quota limit and remaining allowance for prediction markets.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetQuotaStatusResponse>> GetQuotaStatusAsync(GetQuotaStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/quota/limit/status", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetQuotaStatusResponse, cancellationToken);
    }

    /// <summary>List Prediction Wallets (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get all prediction wallets registered for the authenticated user.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ListPredictionWalletsResponse>> ListPredictionWalletsAsync(ListPredictionWalletsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/wallet/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ListPredictionWalletsResponse, cancellationToken);
    }

    /// <summary>Query Payment Option Balances (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get available balances for each payment option that can be used for prediction trading.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryPaymentOptionBalancesResponse>> QueryPaymentOptionBalancesAsync(QueryPaymentOptionBalancesRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/balance/payment-options", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryPaymentOptionBalancesResponse, cancellationToken);
    }
}
