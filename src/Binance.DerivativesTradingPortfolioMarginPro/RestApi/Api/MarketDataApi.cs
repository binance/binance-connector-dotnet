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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

public sealed class PortfolioMarginProTieredCollateralRateRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryPortfolioMarginAssetIndexPriceRequest
{
    public string? Asset { get; init; }
}

public sealed partial class DerivativesTradingPortfolioMarginProRestApi
{

    /// <summary>Get Portfolio Margin Asset Leverage (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Portfolio Margin Asset Leverage</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetPortfolioMarginAssetLeverageResponseInner>>> GetPortfolioMarginAssetLeverageAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/margin-asset-leverage", signed: true, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListGetPortfolioMarginAssetLeverageResponseInner, cancellationToken);
    }

    /// <summary>Get Portfolio Margin Tiered Collateral Rates (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Query the tiered collateral rate configurations for Portfolio Margin assets.</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetPortfolioMarginTieredCollateralRatesResponseInner>>> GetPortfolioMarginTieredCollateralRatesAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/portfolio/retail/collateralRate", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListGetPortfolioMarginTieredCollateralRatesResponseInner, cancellationToken);
    }

    /// <summary>Portfolio Margin Collateral Rate (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Portfolio Margin Collateral Rate</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PortfolioMarginCollateralRateResponseInner>>> PortfolioMarginCollateralRateAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/collateralRate", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListPortfolioMarginCollateralRateResponseInner, cancellationToken);
    }

    /// <summary>Portfolio Margin Pro Tiered Collateral Rate (USER_DATA)</summary>
    /// <remarks>
    /// <para>Portfolio Margin PRO Tiered Collateral Rate</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<PortfolioMarginProTieredCollateralRateResponseInner>>> PortfolioMarginProTieredCollateralRateAsync(PortfolioMarginProTieredCollateralRateRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/portfolio/collateralRate", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListPortfolioMarginProTieredCollateralRateResponseInner, cancellationToken);
    }

    /// <summary>Query Portfolio Margin Asset Index Price (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Query Portfolio Margin Asset Index Price</para>
    /// <para>Weight: - 1 if asset is sent</para>
    /// <para>- 50 if asset is not sent</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryPortfolioMarginAssetIndexPriceResponseInner>>> QueryPortfolioMarginAssetIndexPriceAsync(QueryPortfolioMarginAssetIndexPriceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/portfolio/asset-index-price", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginProRestApiJson.Default.ListQueryPortfolioMarginAssetIndexPriceResponseInner, cancellationToken);
    }
}
