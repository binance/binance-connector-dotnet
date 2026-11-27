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

namespace Binance.Wallet.RestApi;

public sealed class GetSymbolsDelistScheduleForSpotRequest
{
    public long? RecvWindow { get; init; }
}

public sealed partial class WalletRestApi
{

    /// <summary>Get Spot Delist Schedule (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Get symbols delist schedule for spot</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetSymbolsDelistScheduleForSpotResponseInner>>> GetSymbolsDelistScheduleForSpotAsync(GetSymbolsDelistScheduleForSpotRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/spot/delist-schedule", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListGetSymbolsDelistScheduleForSpotResponseInner, cancellationToken);
    }

    /// <summary>System Status</summary>
    /// <remarks>
    /// <para>Fetch system status.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: System</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SystemStatusResponse>> SystemStatusAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/system/status", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, WalletRestApiJson.Default.SystemStatusResponse, cancellationToken);
    }
}
