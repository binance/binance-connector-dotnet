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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class ClassicPortfolioMarginAccountInformationRequest
{
    public required string Asset { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesRestApi
{

    /// <summary>Classic Portfolio Margin Account Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Classic Portfolio Margin current account information.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- maxWithdrawAmount is for asset transfer out to the spot wallet.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ClassicPortfolioMarginAccountInformationResponse>> ClassicPortfolioMarginAccountInformationAsync(ClassicPortfolioMarginAccountInformationRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/pmAccountInfo", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ClassicPortfolioMarginAccountInformationResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ClassicPortfolioMarginAccountInformationResponse, cancellationToken);
    }
}
