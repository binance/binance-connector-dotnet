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

namespace Binance.StockOptions.RestApi;

public sealed class OptionContractsRequest
{
    /// <summary>Underlying US-equity ticker, e.g. NVDA.</summary>
    public required string UnderlyingSymbol { get; init; }

    /// <summary>
    /// Expiration date in YYYY-MM-DD, taken from Option Expirations. Other formats (e.g. 2026-9-30,
    /// 2026/09/30) are rejected.
    /// </summary>
    public required string ExpirationDate { get; init; }

    /// <summary>
    /// OCC root. If omitted, only standard contracts are returned. To list corporate-action-adjusted
    /// contracts (e.g. GOOG1), pass the rootSymbol from Option Expirations.
    /// </summary>
    public string? RootSymbol { get; init; }
}

public sealed class OptionExchangeInfoRequest
{
    /// <summary>OCC contract symbol, e.g. NVDA260930C00100000.</summary>
    public required string Symbol { get; init; }
}

public sealed class OptionExpirationsRequest
{
    /// <summary>Underlying US-equity ticker, e.g. NVDA.</summary>
    public required string UnderlyingSymbol { get; init; }
}

public sealed partial class StockOptionsRestApi
{

    /// <summary>Option Contracts (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns every option contract (calls and puts) of an underlying for one expiration date. Reference
    /// data only — no market data.
    /// </para>
    /// <para>Sorted by strikePrice ascending; for the same strike, CALL comes before PUT. Not paginated.</para>
    /// <para>
    /// If there is no contract for the (underlying, root, expiration) combination, an empty array is
    /// returned.
    /// </para>
    /// <para>
    /// Only the X-MBX-APIKEY header is required; this endpoint is not signed and takes no timestamp /
    /// recvWindow.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OptionContractsResponseInner>>> OptionContractsAsync(OptionContractsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/market/contracts", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<OptionContractsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("underlyingSymbol", request.UnderlyingSymbol);
        r.Query("expirationDate", request.ExpirationDate);
        r.Query("rootSymbol", request.RootSymbol);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.ListOptionContractsResponseInner, cancellationToken);
    }

    /// <summary>Option Exchange Info (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns the trading rules of a single option contract, combining contract-level data (type, strike,
    /// expiration, multiplier, deliverables) with underlying-level configuration (price / quantity
    /// increments and limits).
    /// </para>
    /// <para>
    /// symbol is required. Unlike the stock exchangeInfo, listing all contracts is not supported. To browse
    /// contracts, use Option Expirations and Option Contracts.
    /// </para>
    /// <para>
    /// Price constraints: a limit price must be a multiple of tickSize, and the order notional (price ×
    /// quantity × multiplier, excluding fees) must fall within the closed interval [minNotional,
    /// maxNotional]. For a put SELL order, the limit price cannot exceed the strike price. All of these
    /// values are returned by this endpoint, so you can validate an order before placing it.
    /// </para>
    /// <para>
    /// multiplier vs contractSize: multiplier is used to calculate cost, contractSize is the number of
    /// shares delivered. Both are 100 for standard contracts and may differ for contracts adjusted by a
    /// corporate action (split, merger, special dividend). Always estimate cost with multiplier.
    /// </para>
    /// <para>
    /// Only the X-MBX-APIKEY header is required; this endpoint is not signed and takes no timestamp /
    /// recvWindow.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionExchangeInfoResponse>> OptionExchangeInfoAsync(OptionExchangeInfoRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/market/exchangeInfo", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<OptionExchangeInfoResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.OptionExchangeInfoResponse, cancellationToken);
    }

    /// <summary>Option Expirations (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Returns every expiration date currently tradable for an underlying, in ascending expirationDate
    /// order.
    /// </para>
    /// <para>
    /// When standard and corporate-action-adjusted contracts share an expiration date, multiple rows are
    /// returned with the same expirationDate and different rootSymbol. To list the adjusted set, pass that
    /// rootSymbol to Option Contracts.
    /// </para>
    /// <para>Reference data only — no market data.</para>
    /// <para>
    /// An unknown underlying, or one without listed options, returns -1121 Invalid symbol. An empty array
    /// is never returned.
    /// </para>
    /// <para>
    /// Only the X-MBX-APIKEY header is required; this endpoint is not signed and takes no timestamp /
    /// recvWindow.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<OptionExpirationsResponseInner>>> OptionExpirationsAsync(OptionExpirationsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/option/market/expirations", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<OptionExpirationsResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("underlyingSymbol", request.UnderlyingSymbol);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.ListOptionExpirationsResponseInner, cancellationToken);
    }
}
