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

namespace Binance.Rebate.RestApi;

public sealed class GetSpotRebateHistoryRecordsRequest
{
    /// <summary>Start time in milliseconds.</summary>
    public long? StartTime { get; init; }

    /// <summary>End time in milliseconds.</summary>
    public long? EndTime { get; init; }

    /// <summary>Page number.</summary>
    public long? Page { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class RebateRestApi
{

    /// <summary>Get Spot Rebate History Records (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Spot Rebate History Records</para>
    /// <para>Weight(UID): 12000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The max interval between startTime and endTime is 30 days.</para>
    /// <para>- If startTime and endTime are not sent, the recent 7 days' data will be returned.</para>
    /// <para>- The earliest supported startTime is June 10, 2020.</para>
    /// <para>- Return up to 200 records per request.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSpotRebateHistoryRecordsResponse>> GetSpotRebateHistoryRecordsAsync(GetSpotRebateHistoryRecordsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/rebate/taxQuery", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, RebateRestApiJson.Default.GetSpotRebateHistoryRecordsResponse, cancellationToken);
    }
}
