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

public sealed class ExchangeInfoRequest
{
    /// <summary>
    /// Filter to a single US-equity ticker, e.g. AAPL. When omitted, returns all active symbols. An unknown
    /// ticker returns an empty symbols array (HTTP 200), not an error.
    /// </summary>
    public string? Symbol { get; init; }
}

public sealed class LatestQuoteRequest
{
    /// <summary>US-equity ticker, e.g. AAPL, TSLA. Case-insensitive; uppercased server-side.</summary>
    public required string Symbol { get; init; }
}

public sealed partial class StocksRestApi
{

    /// <summary>Exchange Info (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns current exchange trading rules and the list of tradable US-equity symbols. MARKET_DATA
    /// endpoint — requires an API key (X-MBX-APIKEY) but no signature. Response is served from a
    /// server-side cache.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExchangeInfoResponse>> ExchangeInfoAsync(ExchangeInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/market/exchangeInfo", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, StocksRestApiJson.Default.ExchangeInfoResponse, cancellationToken);
    }

    /// <summary>Latest Quote (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns the latest best bid / best ask for a single US-equity ticker. The returned value is at most
    /// ~5 seconds stale. Returns an empty response body (not the literal null) when no quote is available
    /// for the supplied ticker (e.g. the ticker is unknown, halted, or de-listed).
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<LatestQuoteResponse>> LatestQuoteAsync(LatestQuoteRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/market/quote", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<LatestQuoteResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, StocksRestApiJson.Default.LatestQuoteResponse, cancellationToken);
    }

    /// <summary>Tokenized Assets (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns the list of all tokenized assets currently available for mint / redeem, together with each
    /// asset's underlying equity symbol and conversion multiplier. MARKET_DATA endpoint — requires an API
    /// key (X-MBX-APIKEY) but no signature. Response is served from a server-side cache.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<TokenizedAssetsResponseInner>>> TokenizedAssetsAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/market/tokenized-assets", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, StocksRestApiJson.Default.ListTokenizedAssetsResponseInner, cancellationToken);
    }
}
