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

namespace Binance.SubAccount.RestApi;

public sealed class CreateAVirtualSubAccountRequest
{
    /// <summary>
    /// Please input a string. We will create a virtual email using that string for you to register
    /// </summary>
    public required string SubAccountString { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class EnableFuturesForSubAccountRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class EnableOptionsForSubAccountRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetFuturesPositionRiskOfSubAccountRequest
{
    public required string Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetFuturesPositionRiskOfSubAccountV2Request
{
    public required string Email { get; init; }

    /// <summary>1: USDT-margined Futures，2: Coin-margined Futures</summary>
    public required long FuturesType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetSubAccountsStatusOnMarginOrFuturesRequest
{
    public string? Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountListRequest
{
    public string? Email { get; init; }

    public string? IsFreeze { get; init; }

    public long? Page { get; init; }

    public long? Limit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountTransactionStatisticsRequest
{
    /// <summary>Managed sub-account email</summary>
    public string? Email { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class SubAccountRestApi
{

    /// <summary>Create a Virtual Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Create a Virtual Sub-account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- This request generates a virtual sub-account under your master account.</para>
    /// <para>- The API key used to call this endpoint must have the trade option enabled.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateAVirtualSubAccountResponse>> CreateAVirtualSubAccountAsync(CreateAVirtualSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/virtualSubAccount", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateAVirtualSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("subAccountString", request.SubAccountString);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.CreateAVirtualSubAccountResponse, cancellationToken);
    }

    /// <summary>Enable Futures for Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Enable Futures for Sub-account for Master Account</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EnableFuturesForSubAccountResponse>> EnableFuturesForSubAccountAsync(EnableFuturesForSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/futures/enable", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<EnableFuturesForSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.EnableFuturesForSubAccountResponse, cancellationToken);
    }

    /// <summary>Enable Options for Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Enable Options for Sub-account (For Master Account).</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<EnableOptionsForSubAccountResponse>> EnableOptionsForSubAccountAsync(EnableOptionsForSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/eoptions/enable", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<EnableOptionsForSubAccountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.EnableOptionsForSubAccountResponse, cancellationToken);
    }

    /// <summary>Get Futures Position-Risk of Sub-account (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Futures Position-Risk of Sub-account</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetFuturesPositionRiskOfSubAccountResponseInner>>> GetFuturesPositionRiskOfSubAccountAsync(GetFuturesPositionRiskOfSubAccountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/futures/positionRisk", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<GetFuturesPositionRiskOfSubAccountResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ListGetFuturesPositionRiskOfSubAccountResponseInner, cancellationToken);
    }

    /// <summary>Get Futures Position-Risk of Sub-account V2 (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Futures Position-Risk of Sub-account V2</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFuturesPositionRiskOfSubAccountV2Response>> GetFuturesPositionRiskOfSubAccountV2Async(GetFuturesPositionRiskOfSubAccountV2Request request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/sub-account/futures/positionRisk", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFuturesPositionRiskOfSubAccountV2Response>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("futuresType", request.FuturesType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetFuturesPositionRiskOfSubAccountV2Response, cancellationToken);
    }

    /// <summary>Get Sub-account's Status on Margin Or Futures (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Sub-account's Status on Margin Or Futures</para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If no email sent, all sub-accounts' information will be returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<GetSubAccountsStatusOnMarginOrFuturesResponseInner>>> GetSubAccountsStatusOnMarginOrFuturesAsync(GetSubAccountsStatusOnMarginOrFuturesRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/status", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ListGetSubAccountsStatusOnMarginOrFuturesResponseInner, cancellationToken);
    }

    /// <summary>Query Sub-account List (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Sub-account List</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountListResponse>> QuerySubAccountListAsync(QuerySubAccountListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("email", request.Email);
        r.Query("isFreeze", request.IsFreeze);
        r.Query("page", request.Page);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountListResponse, cancellationToken);
    }

    /// <summary>Query Sub-account Transaction Statistics (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Sub-account Transaction statistics (For Master Account).</para>
    /// <para>Weight(IP): 60</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountTransactionStatisticsResponse>> QuerySubAccountTransactionStatisticsAsync(QuerySubAccountTransactionStatisticsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/transaction-statistics", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("email", request.Email);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountTransactionStatisticsResponse, cancellationToken);
    }
}
