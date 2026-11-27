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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

public sealed class CloseUserDataStreamRequest
{
    public string? Id { get; init; }
}

public sealed class KeepaliveUserDataStreamRequest
{
    public string? Id { get; init; }
}

public sealed class StartUserDataStreamRequest
{
    public string? Id { get; init; }
}

public sealed partial class DerivativesTradingCoinFuturesWebSocketApiConnection
{

    /// <summary>Close User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Close out a user data stream.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<JsonElement>> CloseUserDataStreamAsync(CloseUserDataStreamRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("userDataStream.stop", WebSocketAuth.ApiKey);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Keepalive User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>
    /// Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes.
    /// It's recommended to send a ping about every 60 minutes.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<KeepaliveUserDataStreamResponseResult>> KeepaliveUserDataStreamAsync(KeepaliveUserDataStreamRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("userDataStream.ping", WebSocketAuth.ApiKey);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.KeepaliveUserDataStreamResponseResult, cancellationToken);
    }

    /// <summary>Start User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>
    /// Start a new user data stream. The stream will close after 60 minutes unless a keepalive is sent. If
    /// the account has an active listenKey, that listenKey will be returned and its validity will be
    /// extended for 60 minutes.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<StartUserDataStreamResponseResult>> StartUserDataStreamAsync(StartUserDataStreamRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("userDataStream.start", WebSocketAuth.ApiKey);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesWebSocketApiJson.Default.StartUserDataStreamResponseResult, cancellationToken);
    }
}
