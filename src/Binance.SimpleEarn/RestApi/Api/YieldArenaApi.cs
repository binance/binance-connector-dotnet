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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetYieldArenaActivitiesRequest
{
    /// <summary>
    /// Locale tag for title and description (e.g. en, zh-CN, pt-BR). Default: en. If the value is missing,
    /// malformed, or has no translation configured, content is returned in en.
    /// </summary>
    public string? Lang { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class SimpleEarnRestApi
{

    /// <summary>Get Yield Arena Activities (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get the list of Earn Yield Arena giveaway activities currently available to the user.</para>
    /// <para>Weight(IP): 150</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetYieldArenaActivitiesResponse>> GetYieldArenaActivitiesAsync(GetYieldArenaActivitiesRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/earn/arena/activities", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Header("lang", request.Lang);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SimpleEarnRestApiJson.Default.GetYieldArenaActivitiesResponse, cancellationToken);
    }
}
