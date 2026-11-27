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

namespace Binance.MarginTrading.RestApi;

public sealed class GetAllCrossMarginPairsRequest
{
    public string? Symbol { get; init; }
}

public sealed class GetAllIsolatedMarginSymbolRequest
{
    public string? Symbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetAllMarginAssetsRequest
{
    public string? Asset { get; init; }
}

public sealed class GetDelistScheduleRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetListScheduleRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class QueryIsolatedMarginTierDataRequest
{
    public required string Symbol { get; init; }

    public long? Tier { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryMarginAvailableInventoryType>))]
public readonly struct QueryMarginAvailableInventoryType : IExtensibleValue<QueryMarginAvailableInventoryType>, IEquatable<QueryMarginAvailableInventoryType>
{
    private readonly string? _value;

    public QueryMarginAvailableInventoryType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryMarginAvailableInventoryType Margin { get; } = new("MARGIN");

    public static QueryMarginAvailableInventoryType Isolated { get; } = new("ISOLATED");

    static QueryMarginAvailableInventoryType IExtensibleValue<QueryMarginAvailableInventoryType>.Create(string value) => new(value);

    public static bool operator ==(QueryMarginAvailableInventoryType left, QueryMarginAvailableInventoryType right) => left.Equals(right);

    public static bool operator !=(QueryMarginAvailableInventoryType left, QueryMarginAvailableInventoryType right) => !left.Equals(right);

    public static implicit operator QueryMarginAvailableInventoryType(string value) => new(value);

    public static QueryMarginAvailableInventoryType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryMarginAvailableInventoryType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryMarginAvailableInventoryType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryMarginAvailableInventoryRequest
{
    public required QueryMarginAvailableInventoryType Type { get; init; }
}

public sealed class QueryMarginPriceindexRequest
{
    public required string Symbol { get; init; }
}

public sealed partial class MarginTradingRestApi
{

    /// <summary>Cross margin collateral ratio (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Cross margin collateral ratio</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<CrossMarginCollateralRatioResponseInner>>> CrossMarginCollateralRatioAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/crossMarginCollateralRatio", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListCrossMarginCollateralRatioResponseInner, cancellationToken);
    }

    /// <summary>Get All Cross Margin Pairs (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get All Cross Margin Pairs</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetAllCrossMarginPairsResponseInner>>> GetAllCrossMarginPairsAsync(GetAllCrossMarginPairsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/allPairs", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetAllCrossMarginPairsResponseInner, cancellationToken);
    }

    /// <summary>Get All Isolated Margin Symbol (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get All Isolated Margin Symbol</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetAllIsolatedMarginSymbolResponseInner>>> GetAllIsolatedMarginSymbolAsync(GetAllIsolatedMarginSymbolRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/isolated/allPairs", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetAllIsolatedMarginSymbolResponseInner, cancellationToken);
    }

    /// <summary>Get All Margin Assets (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get All Margin Assets.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetAllMarginAssetsResponseInner>>> GetAllMarginAssetsAsync(GetAllMarginAssetsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/allAssets", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetAllMarginAssetsResponseInner, cancellationToken);
    }

    /// <summary>Get Delist Schedule (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get tokens or symbols delist schedule for cross margin and isolated margin</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetDelistScheduleResponseInner>>> GetDelistScheduleAsync(GetDelistScheduleRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/delist-schedule", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetDelistScheduleResponseInner, cancellationToken);
    }

    /// <summary>Get Limit Price Pairs (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Query trading pairs with restriction on limit price range.</para>
    /// <para>
    /// In margin trading, you can place orders with limit price. Limit price should be within (-15%, 15%)
    /// of current index price for a list of margin trading pairs. This rule only impacts limit sell orders
    /// with limit price that is lower than current index price and limit buy orders with limit price that
    /// is higher than current index price.
    /// </para>
    /// <para>- Buy order: Your order will be rejected with an error message</para>
    /// <para>notification if the limit price is 15% above the index price.</para>
    /// <para>- Sell order: Your order will be rejected with an error message</para>
    /// <para>notification if the limit price is 15% below the index price.</para>
    /// <para>
    /// Please review the limit price order placing strategy, backtest and calibrate the planned order size
    /// with the trading volume and order book depth to prevent trading loss.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetLimitPricePairsResponse>> GetLimitPricePairsAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/limit-price-pairs", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetLimitPricePairsResponse, cancellationToken);
    }

    /// <summary>Get list Schedule (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get the upcoming tokens or symbols listing schedule for Cross Margin and Isolated Margin.</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetListScheduleResponseInner>>> GetListScheduleAsync(GetListScheduleRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/list-schedule", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetListScheduleResponseInner, cancellationToken);
    }

    /// <summary>Get Margin Asset Risk-Based Liquidation Ratio (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get Margin Asset Risk-Based Liquidation Ratio</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetMarginAssetRiskBasedLiquidationRatioResponseInner>>> GetMarginAssetRiskBasedLiquidationRatioAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/risk-based-liquidation-ratio", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListGetMarginAssetRiskBasedLiquidationRatioResponseInner, cancellationToken);
    }

    /// <summary>Get Margin Restricted Assets (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get the list of margin-restricted assets.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetMarginRestrictedAssetsResponse>> GetMarginRestrictedAssetsAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/restricted-asset", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetMarginRestrictedAssetsResponse, cancellationToken);
    }

    /// <summary>Query Isolated Margin Tier Data (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get isolated margin tier data collection with any tier as https://www.binance.com/en/margin-data</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryIsolatedMarginTierDataResponseInner>>> QueryIsolatedMarginTierDataAsync(QueryIsolatedMarginTierDataRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/isolatedMarginTier", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<QueryIsolatedMarginTierDataResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("tier", request.Tier);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryIsolatedMarginTierDataResponseInner, cancellationToken);
    }

    /// <summary>Query Liability Coin Leverage Bracket in Cross Margin Pro Mode (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Liability Coin Leverage Bracket in Cross Margin Pro Mode</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInner>>> QueryLiabilityCoinLeverageBracketInCrossMarginProModeAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/leverageBracket", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.ListQueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInner, cancellationToken);
    }

    /// <summary>Query Margin Available Inventory (USER_DATA)</summary>
    /// <remarks>
    /// <para>Margin available Inventory query</para>
    /// <para>Weight(UID): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginAvailableInventoryResponse>> QueryMarginAvailableInventoryAsync(QueryMarginAvailableInventoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/available-inventory", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginAvailableInventoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("type", request.Type);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryMarginAvailableInventoryResponse, cancellationToken);
    }

    /// <summary>Query Margin PriceIndex (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Query Margin PriceIndex</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMarginPriceindexResponse>> QueryMarginPriceindexAsync(QueryMarginPriceindexRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/priceIndex", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMarginPriceindexResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryMarginPriceindexResponse, cancellationToken);
    }
}
