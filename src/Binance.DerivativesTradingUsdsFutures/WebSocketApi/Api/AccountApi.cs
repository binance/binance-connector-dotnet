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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class AccountInformationRequest
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class AccountInformationV2Request
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class FuturesAccountBalanceRequest
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class FuturesAccountBalanceV2Request
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesWebSocketApiConnection
{

    /// <summary>Account Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get current account information. User in single-asset/ multi-assets mode will see different value,
    /// see comments in response section for detail.
    /// </para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<AccountInformationResponseResult>> AccountInformationAsync(AccountInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("account.status", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.AccountInformationResponseResult, cancellationToken);
    }

    /// <summary>Account Information V2 (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Get current account information. User in single-asset/ multi-assets mode will see different value,
    /// see comments in response section for detail.
    /// </para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<AccountInformationV2ResponseResult>> AccountInformationV2Async(AccountInformationV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("v2/account.status", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.AccountInformationV2ResponseResult, cancellationToken);
    }

    /// <summary>Futures Account Balance (USER_DATA)</summary>
    /// <remarks>
    /// <para>Futures Account Balance</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<FuturesAccountBalanceResponseResultInner>>> FuturesAccountBalanceAsync(FuturesAccountBalanceRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("account.balance", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.ListFuturesAccountBalanceResponseResultInner, cancellationToken);
    }

    /// <summary>Futures Account Balance V2 (USER_DATA)</summary>
    /// <remarks>
    /// <para>Futures Account Balance V2</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<FuturesAccountBalanceResponseResultInner>>> FuturesAccountBalanceV2Async(FuturesAccountBalanceV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("v2/account.balance", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.ListFuturesAccountBalanceResponseResultInner, cancellationToken);
    }
}
