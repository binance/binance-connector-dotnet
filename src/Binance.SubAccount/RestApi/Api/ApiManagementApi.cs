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

public sealed class AddIpRestrictionForSubAccountApiKeyRequest
{
    public required string Email { get; init; }

    public required string SubAccountApiKey { get; init; }

    /// <summary>
    /// IP Restriction status. 1 = IP Unrestricted. 2 = Restrict access to trusted IPs only.
    /// </summary>
    public required long Status { get; init; }

    /// <summary>Insert static IP in batch, separated by commas.</summary>
    public string? IpAddress { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CreateSubAccountApiKeyRequest
{
    /// <summary>Sub-account email</summary>
    public required string Email { get; init; }

    /// <summary>API Key name</summary>
    public required string ApiName { get; init; }

    /// <summary>
    /// IP restriction status. 1 = unrestricted, 2 = restricted to trusted IPs, 3 = third-party IP
    /// restriction
    /// </summary>
    public required long Status { get; init; }

    /// <summary>Spot &amp; Margin trading permission, default false</summary>
    public bool? CanTrade { get; init; }

    /// <summary>Margin borrow/repay permission, default false</summary>
    public bool? CanMarginLoanRepay { get; init; }

    /// <summary>Futures trading permission, default false</summary>
    public bool? CanFuturesTrade { get; init; }

    /// <summary>Universal transfer permission, default false</summary>
    public bool? CanUniversalTransfer { get; init; }

    /// <summary>Vanilla options permission, default false</summary>
    public bool? CanVanillaOptions { get; init; }

    /// <summary>
    /// FIX API Trading permission. Only supported for API Keys using an Ed25519 public key. Setting it to
    /// true for any other key type returns -9000 Unsupported operation
    /// </summary>
    public bool? CanFixApiTrading { get; init; }

    /// <summary>
    /// FIX API Reading permission. Only supported for API Keys using an Ed25519 public key. Setting it to
    /// true for any other key type returns -9000 Unsupported operation
    /// </summary>
    public bool? CanFixApiReading { get; init; }

    /// <summary>Required when status=2. IP address list, max 500 chars</summary>
    public string? IpAddress { get; init; }

    /// <summary>Required when status=3. Third-party name</summary>
    public string? ThirdPartyName { get; init; }

    /// <summary>Ed25519 public key (optional, for Ed25519 type API Key)</summary>
    public string? PublicKey { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CreateSubAccountApiKeyV2Request
{
    /// <summary>Sub-account email</summary>
    public required string Email { get; init; }

    /// <summary>API Key name</summary>
    public required string ApiName { get; init; }

    /// <summary>
    /// IP restriction status. 1 = unrestricted, 2 = restricted to trusted IPs, 3 = third-party IP
    /// restriction
    /// </summary>
    public required long Status { get; init; }

    /// <summary>Spot &amp; Margin trading permission, default false</summary>
    public bool? CanTrade { get; init; }

    /// <summary>Margin borrow/repay permission, default false</summary>
    public bool? CanMarginLoanRepay { get; init; }

    /// <summary>Futures trading permission, default false</summary>
    public bool? CanFuturesTrade { get; init; }

    /// <summary>Universal transfer permission, default false</summary>
    public bool? CanUniversalTransfer { get; init; }

    /// <summary>Vanilla options permission, default false</summary>
    public bool? CanVanillaOptions { get; init; }

    /// <summary>
    /// FIX API Trading permission. Only supported for API Keys using an Ed25519 public key. Setting it to
    /// true for any other key type returns -9000 Unsupported operation
    /// </summary>
    public bool? CanFixApiTrading { get; init; }

    /// <summary>
    /// FIX API Reading permission. Only supported for API Keys using an Ed25519 public key. Setting it to
    /// true for any other key type returns -9000 Unsupported operation
    /// </summary>
    public bool? CanFixApiReading { get; init; }

    /// <summary>Required when status=2. IP address list, max 500 chars</summary>
    public string? IpAddress { get; init; }

    /// <summary>Required when status=3. Third-party name</summary>
    public string? ThirdPartyName { get; init; }

    /// <summary>
    /// RSA or Ed25519 public key (optional). Must be sent in the request body; it is rejected if passed in
    /// the URL query string
    /// </summary>
    public string? PublicKey { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class DeleteIpListForASubAccountApiKeyRequest
{
    public required string Email { get; init; }

    public required string SubAccountApiKey { get; init; }

    /// <summary>IPs to be deleted. Can be added in batches, separated by commas</summary>
    public required string IpAddress { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class DeleteSubAccountApiKeyRequest
{
    /// <summary>Sub-account email</summary>
    public required string Email { get; init; }

    /// <summary>The sub-account API Key to be deleted</summary>
    public required string SubAccountApiKey { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetIpRestrictionForASubAccountApiKeyRequest
{
    public required string Email { get; init; }

    public required string SubAccountApiKey { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ModifySubAccountApiKeyPermissionRequest
{
    /// <summary>Sub-account email</summary>
    public required string Email { get; init; }

    /// <summary>Sub-account API Key</summary>
    public required string SubAccountApiKey { get; init; }

    /// <summary>Spot &amp; Margin trading permission</summary>
    public bool? CanTrade { get; init; }

    /// <summary>Margin borrow/repay permission</summary>
    public bool? CanMarginLoanRepay { get; init; }

    /// <summary>Futures trading permission</summary>
    public bool? CanFuturesTrade { get; init; }

    /// <summary>Universal transfer permission</summary>
    public bool? CanUniversalTransfer { get; init; }

    /// <summary>Vanilla options permission</summary>
    public bool? CanVanillaOptions { get; init; }

    /// <summary>
    /// FIX API Trading permission. If omitted, the existing value is unchanged. Only supported for API Keys
    /// using an Ed25519 public key. Setting it to true for any other key type returns -9000 Unsupported
    /// operation
    /// </summary>
    public bool? CanFixApiTrading { get; init; }

    /// <summary>
    /// FIX API Reading permission. If omitted, the existing value is unchanged. Only supported for API Keys
    /// using an Ed25519 public key. Setting it to true for any other key type returns -9000 Unsupported
    /// operation
    /// </summary>
    public bool? CanFixApiReading { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QuerySubAccountApiKeyRequest
{
    /// <summary>Sub-account email</summary>
    public required string Email { get; init; }

    /// <summary>Specify an API Key for exact match</summary>
    public string? SubAccountApiKey { get; init; }

    /// <summary>Page number, default 1, minimum 1</summary>
    public long? Page { get; init; }

    /// <summary>Page size, default 30, maximum 100</summary>
    public long? Size { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class SubAccountRestApi
{

    /// <summary>Add IP Restriction for Sub-Account API key (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Add IP Restriction for Sub-Account API key</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to enable Enable Spot &amp; Margin Trading option for the api key which requests this
    /// endpoint
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AddIpRestrictionForSubAccountApiKeyResponse>> AddIpRestrictionForSubAccountApiKeyAsync(AddIpRestrictionForSubAccountApiKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/sub-account/subAccountApi/ipRestriction", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AddIpRestrictionForSubAccountApiKeyResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("subAccountApiKey", request.SubAccountApiKey);
        r.Query("status", request.Status);
        r.Query("ipAddress", request.IpAddress);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.AddIpRestrictionForSubAccountApiKeyResponse, cancellationToken);
    }

    /// <summary>Create Sub-account API Key (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Create a new API Key for a sub-account.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- status=2 requires ipAddress</para>
    /// <para>- status=3 requires thirdPartyName</para>
    /// <para>- Asset Sub Account is not supported</para>
    /// <para>- The caller must pass the KYC IP restriction check</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateSubAccountApiKeyResponse>> CreateSubAccountApiKeyAsync(CreateSubAccountApiKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/subAccountApi", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateSubAccountApiKeyResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("apiName", request.ApiName);
        r.Query("status", request.Status);
        r.Query("canTrade", request.CanTrade);
        r.Query("canMarginLoanRepay", request.CanMarginLoanRepay);
        r.Query("canFuturesTrade", request.CanFuturesTrade);
        r.Query("canUniversalTransfer", request.CanUniversalTransfer);
        r.Query("canVanillaOptions", request.CanVanillaOptions);
        r.Query("canFixApiTrading", request.CanFixApiTrading);
        r.Query("canFixApiReading", request.CanFixApiReading);
        r.Query("ipAddress", request.IpAddress);
        r.Query("thirdPartyName", request.ThirdPartyName);
        r.Query("publicKey", request.PublicKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.CreateSubAccountApiKeyResponse, cancellationToken);
    }

    /// <summary>Create Sub-account API Key V2 (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Create a new API Key for a sub-account.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- status=2 requires ipAddress</para>
    /// <para>- status=3 requires thirdPartyName</para>
    /// <para>- Asset Sub Account is not supported</para>
    /// <para>- The caller must pass the KYC IP restriction check</para>
    /// <para>
    /// - publicKey is rejected if passed in the URL query string. The example sends it in the request body
    /// with --data-urlencode
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateSubAccountApiKeyV2Response>> CreateSubAccountApiKeyV2Async(CreateSubAccountApiKeyV2Request request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/sub-account/subAccountApi", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateSubAccountApiKeyV2Response>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("apiName", request.ApiName);
        r.Query("status", request.Status);
        r.Query("canTrade", request.CanTrade);
        r.Query("canMarginLoanRepay", request.CanMarginLoanRepay);
        r.Query("canFuturesTrade", request.CanFuturesTrade);
        r.Query("canUniversalTransfer", request.CanUniversalTransfer);
        r.Query("canVanillaOptions", request.CanVanillaOptions);
        r.Query("canFixApiTrading", request.CanFixApiTrading);
        r.Query("canFixApiReading", request.CanFixApiReading);
        r.Query("ipAddress", request.IpAddress);
        r.Query("thirdPartyName", request.ThirdPartyName);
        r.Query("publicKey", request.PublicKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.CreateSubAccountApiKeyV2Response, cancellationToken);
    }

    /// <summary>Delete IP List For a Sub-account API Key (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Delete IP List For a Sub-account API Key</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - You need to enable Enable Spot &amp; Margin Trading option for the api key which requests this
    /// endpoint
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DeleteIpListForASubAccountApiKeyResponse>> DeleteIpListForASubAccountApiKeyAsync(DeleteIpListForASubAccountApiKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DeleteIpListForASubAccountApiKeyResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("subAccountApiKey", request.SubAccountApiKey);
        r.Query("ipAddress", request.IpAddress);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.DeleteIpListForASubAccountApiKeyResponse, cancellationToken);
    }

    /// <summary>Delete Sub-account API Key (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Delete an API Key of a sub-account.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Asset Sub Account is not supported</para>
    /// <para>- The caller must pass the KYC IP restriction check</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> DeleteSubAccountApiKeyAsync(DeleteSubAccountApiKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/sapi/v1/sub-account/subAccountApi", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<JsonElement>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("subAccountApiKey", request.SubAccountApiKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Get IP Restriction for a Sub-account API Key (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get IP Restriction for a Sub-account API Key</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetIpRestrictionForASubAccountApiKeyResponse>> GetIpRestrictionForASubAccountApiKeyAsync(GetIpRestrictionForASubAccountApiKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/subAccountApi/ipRestriction", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetIpRestrictionForASubAccountApiKeyResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("subAccountApiKey", request.SubAccountApiKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.GetIpRestrictionForASubAccountApiKeyResponse, cancellationToken);
    }

    /// <summary>Modify Sub-account API Key Permission (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Modify the trading permissions of a sub-account API Key.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Portfolio Margin Retail User is not supported</para>
    /// <para>- Asset Sub Account is not supported</para>
    /// <para>- The caller must pass the KYC IP restriction check</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ModifySubAccountApiKeyPermissionResponse>> ModifySubAccountApiKeyPermissionAsync(ModifySubAccountApiKeyPermissionRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/sub-account/subAccountApiPermission", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ModifySubAccountApiKeyPermissionResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("subAccountApiKey", request.SubAccountApiKey);
        r.Query("canTrade", request.CanTrade);
        r.Query("canMarginLoanRepay", request.CanMarginLoanRepay);
        r.Query("canFuturesTrade", request.CanFuturesTrade);
        r.Query("canUniversalTransfer", request.CanUniversalTransfer);
        r.Query("canVanillaOptions", request.CanVanillaOptions);
        r.Query("canFixApiTrading", request.CanFixApiTrading);
        r.Query("canFixApiReading", request.CanFixApiReading);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.ModifySubAccountApiKeyPermissionResponse, cancellationToken);
    }

    /// <summary>Query Sub-account API Key (For Master Account) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query the API Key list of a sub-account.</para>
    /// <para>Weight(UID): 3000</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QuerySubAccountApiKeyResponse>> QuerySubAccountApiKeyAsync(QuerySubAccountApiKeyRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/sub-account/subAccountApi", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QuerySubAccountApiKeyResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("email", request.Email);
        r.Query("subAccountApiKey", request.SubAccountApiKey);
        r.Query("page", request.Page);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, SubAccountRestApiJson.Default.QuerySubAccountApiKeyResponse, cancellationToken);
    }
}
