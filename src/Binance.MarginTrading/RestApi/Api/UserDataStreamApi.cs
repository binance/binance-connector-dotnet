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

public sealed class KeepaliveUserDataStreamRequest
{
    public required string ListenKey { get; init; }
}

public sealed class KeepaliveUserDataStreamV2Request
{
    public required string ListenKey { get; init; }
}

public sealed partial class MarginTradingRestApi
{

    /// <summary>Close User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Close out a user data stream.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> CloseUserDataStreamAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/margin/listen-key", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Close User Data Stream V2 (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Close out a user data stream.</para>
    /// <para>Note: After this request, you will receive another WebSocket message:</para>
    /// <para>{ "e": "eventStreamTerminated", "E": 1793646860552 }</para>
    /// <para>- e (string): event type. Example: eventStreamTerminated</para>
    /// <para>- E (integer): current timestamp. Example: 1793646860552</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> CloseUserDataStreamV2Async(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v2/margin/listen-key", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Keepalive User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Keepalive a user data stream to prevent a time out.</para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> KeepaliveUserDataStreamAsync(KeepaliveUserDataStreamRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/sapi/v1/margin/listen-key", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<JsonElement>>(new ArgumentNullException(nameof(request)));
        r.Query("listenKey", request.ListenKey);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Keepalive User Data Stream V2 (USER_STREAM)</summary>
    /// <remarks>
    /// <para>
    /// Keep alive a user data stream to prevent a timeout. Each successful request extends the listen key
    /// validity for 1 hour.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> KeepaliveUserDataStreamV2Async(KeepaliveUserDataStreamV2Request request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/sapi/v2/margin/listen-key", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<JsonElement>>(new ArgumentNullException(nameof(request)));
        r.Query("listenKey", request.ListenKey);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Start User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Start a new user data stream.</para>
    /// <para>Weight(UID): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<StartUserDataStreamResponse>> StartUserDataStreamAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/margin/listen-key", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.StartUserDataStreamResponse, cancellationToken);
    }

    /// <summary>Start User Data Stream V2 (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Start a new user data stream.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<StartUserDataStreamV2Response>> StartUserDataStreamV2Async(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/margin/listen-key", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.StartUserDataStreamV2Response, cancellationToken);
    }
}
