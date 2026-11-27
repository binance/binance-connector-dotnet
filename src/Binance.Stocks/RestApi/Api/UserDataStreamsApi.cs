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

namespace Binance.Stocks.RestApi;

public sealed class CreateRenewListenKeyRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StocksRestApi
{

    /// <summary>Create / Renew Listen Key (USER_STREAM)</summary>
    /// <remarks>
    /// <para>
    /// Create a new stock user-data-stream listenKey, or renew an existing one. Calling this endpoint for
    /// the same user with an active listenKey extends its validity; if there is no active key, a new one is
    /// issued. Use the returned listenKey to subscribe to the stock user data stream.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_STREAM</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateRenewListenKeyResponse>> CreateRenewListenKeyAsync(CreateRenewListenKeyRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/listenKey", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.CreateRenewListenKeyResponse, cancellationToken);
    }
}
