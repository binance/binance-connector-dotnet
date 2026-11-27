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

namespace Binance.CopyTrading.RestApi;

public sealed class GetFuturesLeadTraderStatusRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetFuturesLeadTradingSymbolWhitelistRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class CopyTradingRestApi
{

    /// <summary>Get Futures Lead Trader Status (TRADE)</summary>
    /// <remarks>
    /// <para>Get Futures Lead Trader Status</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFuturesLeadTraderStatusResponse>> GetFuturesLeadTraderStatusAsync(GetFuturesLeadTraderStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/copyTrading/futures/userStatus", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CopyTradingRestApiJson.Default.GetFuturesLeadTraderStatusResponse, cancellationToken);
    }

    /// <summary>Get Futures Lead Trading Symbol Whitelist (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Futures Lead Trading Symbol Whitelist</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFuturesLeadTradingSymbolWhitelistResponse>> GetFuturesLeadTradingSymbolWhitelistAsync(GetFuturesLeadTradingSymbolWhitelistRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/copyTrading/futures/leadSymbol", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, CopyTradingRestApiJson.Default.GetFuturesLeadTradingSymbolWhitelistResponse, cancellationToken);
    }
}
