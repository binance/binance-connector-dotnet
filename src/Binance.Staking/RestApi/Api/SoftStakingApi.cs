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

namespace Binance.Staking.RestApi;

public sealed class GetSoftStakingProductListRequest
{
    public string? Asset { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetSoftStakingRewardsHistoryRequest
{
    public string? Asset { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    /// <summary>Currently querying page</summary>
    public long? Current { get; init; }

    public long? Size { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SetSoftStakingRequest
{
    public required bool SoftStaking { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StakingRestApi
{

    /// <summary>Get Soft Staking Product List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get the available Soft Staking product list.</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSoftStakingProductListResponse>> GetSoftStakingProductListAsync(GetSoftStakingProductListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/soft-staking/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetSoftStakingProductListResponse, cancellationToken);
    }

    /// <summary>Get Soft Staking Rewards History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Soft Staking Rewards History</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The time between startTime and endTime cannot be longer than 3 months.</para>
    /// <para>- If startTime and endTime</para>
    /// <para>are both not sent, then the last 30 days' data will be returned.</para>
    /// <para>- If startTime is sent but endTime is not</para>
    /// <para>sent, the next 30 days' data beginning from startTime will be returned.</para>
    /// <para>- If endTime is sent but</para>
    /// <para>startTime is not sent, the 30 days' data before endTime will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetSoftStakingRewardsHistoryResponse>> GetSoftStakingRewardsHistoryAsync(GetSoftStakingRewardsHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/soft-staking/history/rewardsRecord", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.GetSoftStakingRewardsHistoryResponse, cancellationToken);
    }

    /// <summary>Set Soft Staking (USER_DATA)</summary>
    /// <remarks>
    /// <para>Enable or disable Soft Staking.</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetSoftStakingResponse>> SetSoftStakingAsync(SetSoftStakingRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/soft-staking/set", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetSoftStakingResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("softStaking", request.SoftStaking);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StakingRestApiJson.Default.SetSoftStakingResponse, cancellationToken);
    }
}
