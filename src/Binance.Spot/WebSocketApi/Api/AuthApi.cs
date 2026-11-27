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

namespace Binance.Spot.WebSocketApi;

public sealed class SessionLogonRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// The value cannot be greater than 60000. Supports up to three decimal places of precision (e.g.,
    /// 6000.346) so that microseconds may be specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }
}

public sealed class SessionLogoutRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }
}

public sealed class SessionStatusRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }
}

public sealed partial class SpotWebSocketApiConnection
{

    /// <summary>Log in with API key (USER_DATA)</summary>
    /// <remarks>
    /// <para>Authenticate WebSocket connection using the provided API key.</para>
    /// <para>
    /// After calling session.logon, you can omit apiKey and signature parameters for future requests that
    /// require them.
    /// </para>
    /// <para>Note that only one API key can be authenticated.</para>
    /// <para>Calling session.logon multiple times changes the current authenticated API key.</para>
    /// <para>Note: Only Ed25519 keys are supported for this feature.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>One response for each connection that answered, each with its rate limit counters.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<IReadOnlyList<WebSocketApiResponse<SessionLogonResponseResult>>> SessionLogonAsync(SessionLogonRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("session.logon", WebSocketAuth.SessionLogon);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        return _client.SendAllAsync(r, SpotWebSocketApiJson.Default.SessionLogonResponseResult, cancellationToken);
    }

    /// <summary>Log out of the session</summary>
    /// <remarks>
    /// <para>
    /// Forget the API key previously authenticated. If the connection is not authenticated, this request
    /// does nothing.
    /// </para>
    /// <para>
    /// Note that the WebSocket connection stays open after session.logout request. You can continue using
    /// the connection, but now you will have to explicitly provide the apiKey and signature parameters
    /// where needed.
    /// </para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>One response for each connection that answered, each with its rate limit counters.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<IReadOnlyList<WebSocketApiResponse<SessionLogoutResponseResult>>> SessionLogoutAsync(SessionLogoutRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("session.logout", WebSocketAuth.SessionLogout);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAllAsync(r, SpotWebSocketApiJson.Default.SessionLogoutResponseResult, cancellationToken);
    }

    /// <summary>Query session status</summary>
    /// <remarks>
    /// <para>
    /// Query the status of the WebSocket connection, inspecting which API key (if any) is used to authorize
    /// requests.
    /// </para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<SessionStatusResponseResult>> SessionStatusAsync(SessionStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("session.status", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.SessionStatusResponseResult, cancellationToken);
    }
}
