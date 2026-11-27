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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed partial class DerivativesTradingCoinFuturesRestApi
{

    /// <summary>Close User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Close out a user data stream.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> CloseUserDataStreamAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/dapi/v1/listenKey", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Keepalive User Data Stream (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<KeepaliveUserDataStreamResponse>> KeepaliveUserDataStreamAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/dapi/v1/listenKey", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.KeepaliveUserDataStreamResponse, cancellationToken);
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
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<StartUserDataStreamResponse>> StartUserDataStreamAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/dapi/v1/listenKey", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, DerivativesTradingCoinFuturesRestApiJson.Default.StartUserDataStreamResponse, cancellationToken);
    }
}
