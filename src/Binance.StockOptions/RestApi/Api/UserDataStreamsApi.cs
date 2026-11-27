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

namespace Binance.StockOptions.RestApi;

public sealed class CreateRenewListenKeyRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StockOptionsRestApi
{

    /// <summary>Create / Renew Listen Key (USER_STREAM)</summary>
    /// <remarks>
    /// <para>Create or renew the user data stream listenKey.</para>
    /// <para>
    /// - Valid for 1 hour. Calling again renews it (resets to 1 hour) and returns the same key; renewing
    /// every 30 minutes is recommended. After expiry, a new key is issued and you must resubscribe with it.
    /// </para>
    /// <para>
    /// - Options and stocks share one key. The key is issued per user, not per asset class. This endpoint
    /// and /sapi/v1/equity/listenKey return the same key; calling either is enough.
    /// </para>
    /// <para>- Use the key to subscribe to the Order Report V2 Stream.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateRenewListenKeyResponse>> CreateRenewListenKeyAsync(CreateRenewListenKeyRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/option/listenKey", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.CreateRenewListenKeyResponse, cancellationToken);
    }
}
