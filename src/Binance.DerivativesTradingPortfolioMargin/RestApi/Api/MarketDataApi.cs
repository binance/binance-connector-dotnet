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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed partial class DerivativesTradingPortfolioMarginRestApi
{

    /// <summary>Test Connectivity</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API.</para>
    /// <para>Weight(IP): 1</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> TestConnectivityAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/papi/v1/ping", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingPortfolioMarginRestApiJson.Default.JsonElement, cancellationToken);
    }
}
