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

namespace Binance.Mining.RestApi;

public sealed class AccountListRequest
{
    /// <summary>Algorithm name.</summary>
    public required string Algo { get; init; }

    /// <summary>Mining account</summary>
    public required string UserName { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelHashrateResaleConfigurationRequest
{
    /// <summary>Mining ID</summary>
    public required long ConfigId { get; init; }

    /// <summary>Mining Account</summary>
    public required string UserName { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class EarningsListRequest
{
    /// <summary>Algorithm name.</summary>
    public required string Algo { get; init; }

    /// <summary>Mining account.</summary>
    public required string UserName { get; init; }

    /// <summary>Coin name</summary>
    public string? Coin { get; init; }

    /// <summary>Search start time in milliseconds.</summary>
    public long? StartDate { get; init; }

    /// <summary>Search end time in milliseconds.</summary>
    public long? EndDate { get; init; }

    /// <summary>Page number, starting from 1.</summary>
    public long? PageIndex { get; init; }

    /// <summary>Number of rows per page.</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class ExtraBonusListRequest
{
    /// <summary>Transfer algorithm</summary>
    public required string Algo { get; init; }

    /// <summary>Mining account</summary>
    public required string UserName { get; init; }

    /// <summary>Coin name</summary>
    public string? Coin { get; init; }

    /// <summary>Search start time in milliseconds.</summary>
    public long? StartDate { get; init; }

    /// <summary>Search end time in milliseconds.</summary>
    public long? EndDate { get; init; }

    /// <summary>Page number, starting from 1.</summary>
    public long? PageIndex { get; init; }

    /// <summary>Number of rows per page.</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class HashrateResaleDetailRequest
{
    /// <summary>Configuration ID.</summary>
    public required long ConfigId { get; init; }

    /// <summary>Page number, starting from 1.</summary>
    public long? PageIndex { get; init; }

    /// <summary>Number of rows per page.</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class HashrateResaleListRequest
{
    /// <summary>Page number, starting from 1.</summary>
    public long? PageIndex { get; init; }

    /// <summary>Number of rows per page.</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class HashrateResaleRequestRequest
{
    /// <summary>Mining Account</summary>
    public required string UserName { get; init; }

    /// <summary>Transfer algorithm</summary>
    public required string Algo { get; init; }

    /// <summary>Resale End Time (Millisecond timestamp)</summary>
    public required long EndDate { get; init; }

    /// <summary>Resale Start Time(Millisecond timestamp)</summary>
    public required long StartDate { get; init; }

    /// <summary>Mining Account</summary>
    public required string ToPoolUser { get; init; }

    /// <summary>
    /// Resale hashrate h/s must be transferred (BTC is greater than 500000000000 ETH is greater than
    /// 500000)
    /// </summary>
    public required long HashRate { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class MiningAccountEarningRequest
{
    /// <summary>Algorithm</summary>
    public required string Algo { get; init; }

    /// <summary>Millisecond timestamp</summary>
    public long? StartDate { get; init; }

    /// <summary>Millisecond timestamp</summary>
    public long? EndDate { get; init; }

    /// <summary>Page number, starting from 1.</summary>
    public long? PageIndex { get; init; }

    /// <summary>Number of rows per page.</summary>
    public long? PageSize { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class RequestForDetailMinerListRequest
{
    /// <summary>Algorithm</summary>
    public required string Algo { get; init; }

    /// <summary>Mining account</summary>
    public required string UserName { get; init; }

    /// <summary>Miner name.</summary>
    public required string WorkerName { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class RequestForMinerListRequest
{
    /// <summary>Algorithm</summary>
    public required string Algo { get; init; }

    /// <summary>Mining account</summary>
    public required string UserName { get; init; }

    /// <summary>Page number, starting from 1.</summary>
    public long? PageIndex { get; init; }

    /// <summary>Sort order. 0 for ascending, 1 for descending.</summary>
    public long? Sort { get; init; }

    /// <summary>
    /// Sort by: 1 miner name, 2 real-time hashrate, 3 daily average hashrate, 4 real-time rejection rate, 5
    /// last submission time
    /// </summary>
    public long? SortColumn { get; init; }

    /// <summary>Miner status. 0 all, 1 valid, 2 invalid, 3 failure.</summary>
    public long? WorkerStatus { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class StatisticListRequest
{
    /// <summary>Algorithm</summary>
    public required string Algo { get; init; }

    /// <summary>Mining account</summary>
    public required string UserName { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class MiningRestApi
{

    /// <summary>Account List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Account List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AccountListResponse>> AccountListAsync(AccountListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/statistics/user/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AccountListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("userName", request.UserName);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.AccountListResponse, cancellationToken);
    }

    /// <summary>Acquiring Algorithm (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Acquiring Algorithm</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AcquiringAlgorithmResponse>> AcquiringAlgorithmAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/pub/algoList", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MiningRestApiJson.Default.AcquiringAlgorithmResponse, cancellationToken);
    }

    /// <summary>Acquiring CoinName (MARKET_DATA)</summary>
    /// <remarks>
    /// <para>Acquiring CoinName</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: MARKET_DATA</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AcquiringCoinnameResponse>> AcquiringCoinnameAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/pub/coinList", signed: false, hasTimeUnit: false);
        return _client.SendAsync(r, MiningRestApiJson.Default.AcquiringCoinnameResponse, cancellationToken);
    }

    /// <summary>Cancel hashrate resale configuration (USER_DATA)</summary>
    /// <remarks>
    /// <para>Cancel hashrate resale configuration</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelHashrateResaleConfigurationResponse>> CancelHashrateResaleConfigurationAsync(CancelHashrateResaleConfigurationRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/mining/hash-transfer/config/cancel", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelHashrateResaleConfigurationResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("configId", request.ConfigId);
        r.Query("userName", request.UserName);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.CancelHashrateResaleConfigurationResponse, cancellationToken);
    }

    /// <summary>Earnings List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Earnings List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EarningsListResponse>> EarningsListAsync(EarningsListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/payment/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<EarningsListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("userName", request.UserName);
        r.Query("coin", request.Coin);
        r.Query("startDate", request.StartDate);
        r.Query("endDate", request.EndDate);
        r.Query("pageIndex", request.PageIndex);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.EarningsListResponse, cancellationToken);
    }

    /// <summary>Extra Bonus List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Extra Bonus List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExtraBonusListResponse>> ExtraBonusListAsync(ExtraBonusListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/payment/other", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ExtraBonusListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("userName", request.UserName);
        r.Query("coin", request.Coin);
        r.Query("startDate", request.StartDate);
        r.Query("endDate", request.EndDate);
        r.Query("pageIndex", request.PageIndex);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.ExtraBonusListResponse, cancellationToken);
    }

    /// <summary>Hashrate Resale Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>Hashrate Resale Detail(USER_DATA)</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<HashrateResaleDetailResponse>> HashrateResaleDetailAsync(HashrateResaleDetailRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/hash-transfer/profit/details", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<HashrateResaleDetailResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("configId", request.ConfigId);
        r.Query("pageIndex", request.PageIndex);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.HashrateResaleDetailResponse, cancellationToken);
    }

    /// <summary>Hashrate Resale List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Hashrate Resale List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<HashrateResaleListResponse>> HashrateResaleListAsync(HashrateResaleListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/hash-transfer/config/details/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("pageIndex", request.PageIndex);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.HashrateResaleListResponse, cancellationToken);
    }

    /// <summary>Hashrate Resale Request (USER_DATA)</summary>
    /// <remarks>
    /// <para>Hashrate Resale Request</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<HashrateResaleRequestResponse>> HashrateResaleRequestAsync(HashrateResaleRequestRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/mining/hash-transfer/config", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<HashrateResaleRequestResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("userName", request.UserName);
        r.Query("algo", request.Algo);
        r.Query("endDate", request.EndDate);
        r.Query("startDate", request.StartDate);
        r.Query("toPoolUser", request.ToPoolUser);
        r.Query("hashRate", request.HashRate);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.HashrateResaleRequestResponse, cancellationToken);
    }

    /// <summary>Mining Account Earning (USER_DATA)</summary>
    /// <remarks>
    /// <para>Mining Account Earning</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<MiningAccountEarningResponse>> MiningAccountEarningAsync(MiningAccountEarningRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/payment/uid", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<MiningAccountEarningResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("startDate", request.StartDate);
        r.Query("endDate", request.EndDate);
        r.Query("pageIndex", request.PageIndex);
        r.Query("pageSize", request.PageSize);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.MiningAccountEarningResponse, cancellationToken);
    }

    /// <summary>Request for Detail Miner List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Request for Detail Miner List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RequestForDetailMinerListResponse>> RequestForDetailMinerListAsync(RequestForDetailMinerListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/worker/detail", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RequestForDetailMinerListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("userName", request.UserName);
        r.Query("workerName", request.WorkerName);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.RequestForDetailMinerListResponse, cancellationToken);
    }

    /// <summary>Request for Miner List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Request for Miner List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RequestForMinerListResponse>> RequestForMinerListAsync(RequestForMinerListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/worker/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RequestForMinerListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("userName", request.UserName);
        r.Query("pageIndex", request.PageIndex);
        r.Query("sort", request.Sort);
        r.Query("sortColumn", request.SortColumn);
        r.Query("workerStatus", request.WorkerStatus);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.RequestForMinerListResponse, cancellationToken);
    }

    /// <summary>Statistic List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Statistic List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<StatisticListResponse>> StatisticListAsync(StatisticListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/mining/statistics/user/status", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<StatisticListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("algo", request.Algo);
        r.Query("userName", request.UserName);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MiningRestApiJson.Default.StatisticListResponse, cancellationToken);
    }
}
