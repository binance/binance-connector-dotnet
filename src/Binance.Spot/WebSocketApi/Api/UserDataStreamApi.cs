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

public sealed class SessionSubscriptionsRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }
}

public sealed class UserDataStreamSubscribeRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Optional filter that controls which events are delivered on this subscription. See User Data Stream
    /// Subscription Filters. When omitted, all events for the subscribed account are delivered.
    /// </summary>
    public JsonElement? Filter { get; init; }
}

public sealed class UserDataStreamSubscribeSignatureRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// Supports up to three decimal places of precision (e.g., 6000.346) so that microseconds may be
    /// specified.
    /// </summary>
    public decimal? RecvWindow { get; init; }

    /// <summary>
    /// Optional event filter. See User Data Stream Subscription Filters. When included, filter must be in
    /// the signed string with sorted keys and no whitespace between JSON elements.
    /// </summary>
    public JsonElement? Filter { get; init; }
}

public sealed class UserDataStreamUnsubscribeRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>
    /// When called with no parameter, this will close all subscriptions. When called with the
    /// subscriptionId parameter, this will attempt to close the subscription with that subscription id, if
    /// it exists.
    /// </summary>
    public long? SubscriptionId { get; init; }
}

public sealed partial class SpotWebSocketApiConnection
{

    /// <summary>Listing all subscriptions</summary>
    /// <remarks>
    /// <para>Note:</para>
    /// <para>- Users should track the corresponding subscription status of related accounts as needed.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<List<SessionSubscriptionsResponseResultInner>>> SessionSubscriptionsAsync(SessionSubscriptionsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("session.subscriptions", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ListSessionSubscriptionsResponseResultInner, cancellationToken);
    }

    /// <summary>Subscribe to User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Subscribe to the User Data Stream in the current WebSocket connection.</para>
    /// <para>Notes:</para>
    /// <para>
    /// - This method requires an authenticated WebSocket connection using Ed25519 keys. Please refer to
    /// session.logon.
    /// </para>
    /// <para>
    /// - To check the subscription status, use session.status, see the userDataStream flag indicating you
    /// have an active subscription.
    /// </para>
    /// <para>- User Data Stream events are available in both JSON and SBE sessions.</para>
    /// <para>- Please refer to User Data Streams for the event format details.</para>
    /// <para>- For SBE, only SBE schema 2:1 or later is supported.</para>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The response and the subscription whose events follow; dispose the subscription to unsubscribe.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiSubscription<UserDataStreamSubscribeResponseResult, UserDataStreamEventsResponse>> UserDataStreamSubscribeAsync(UserDataStreamSubscribeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("userDataStream.subscribe", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("filter", request.Filter);
        return _client.SubscribeAsync(r, SpotWebSocketApiJson.Default.UserDataStreamSubscribeResponseResult, SpotWebSocketApiJson.Default.UserDataStreamEventsResponse, cancellationToken);
    }

    /// <summary>Subscribe to User Data Stream through signature subscription (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Weight(IP): 2</para>
    /// <para>Security Type: USER_STREAM</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The response and the subscription whose events follow; dispose the subscription to unsubscribe.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiSubscription<UserDataStreamSubscribeResponseResult, UserDataStreamEventsResponse>> UserDataStreamSubscribeSignatureAsync(UserDataStreamSubscribeSignatureRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("userDataStream.subscribe.signature", WebSocketAuth.Signed);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("recvWindow", request.RecvWindow);
        r.Param("filter", request.Filter);
        return _client.SubscribeAsync(r, SpotWebSocketApiJson.Default.UserDataStreamSubscribeResponseResult, SpotWebSocketApiJson.Default.UserDataStreamEventsResponse, cancellationToken);
    }

    /// <summary>Unsubscribe from User Data Stream</summary>
    /// <remarks>
    /// <para>Stop listening to the User Data Stream in the current WebSocket connection.</para>
    /// <para>
    /// Note that session.logout will only close the subscription created with userDataStream.subscribe but
    /// not subscriptions opened with userDataStream.subscribe.signature.
    /// </para>
    /// <para>Weight(IP): 2</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<JsonElement>> UserDataStreamUnsubscribeAsync(UserDataStreamUnsubscribeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("userDataStream.unsubscribe", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("subscriptionId", request.SubscriptionId);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.JsonElement, cancellationToken);
    }
}
