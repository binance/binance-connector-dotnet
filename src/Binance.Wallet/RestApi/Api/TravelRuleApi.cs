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

namespace Binance.Wallet.RestApi;

public sealed class BrokerWithdrawRequest
{
    public required string Address { get; init; }

    public required string Coin { get; init; }

    public required decimal Amount { get; init; }

    /// <summary>withdrawID defined by the client (i.e. client's internal withdrawID)</summary>
    public required string WithdrawOrderId { get; init; }

    /// <summary>JSON format questionnaire answers.</summary>
    public required string Questionnaire { get; init; }

    /// <summary>JSON format originator Pii, see StandardPii section below</summary>
    public required string OriginatorPii { get; init; }

    /// <summary>Secondary address identifier for coins like XRP,XMR etc.</summary>
    public string? AddressTag { get; init; }

    public string? Network { get; init; }

    /// <summary>
    /// Description of the address. Address book cap is 200, space in name should be encoded into %20
    /// </summary>
    public string? AddressName { get; init; }

    /// <summary>
    /// When making internal transfer, true for returning the fee to the destination account; false for
    /// returning the fee back to the departure account. Default false.
    /// </summary>
    public bool? TransactionFeeFlag { get; init; }

    /// <summary>
    /// The wallet type for withdraw，0-spot wallet ，1-funding wallet. Default walletType is the current
    /// "selected wallet" under wallet-&gt;Fiat and Spot/Funding-&gt;Deposit
    /// </summary>
    public long? WalletType { get; init; }
}

public sealed class CheckQuestionnaireRequirementsRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class DepositHistoryTravelRuleRequest
{
    /// <summary>Comma(,) separated list of travel rule record Ids.</summary>
    public string? TrId { get; init; }

    /// <summary>Comma(,) separated list of transaction Ids.</summary>
    public string? TxId { get; init; }

    /// <summary>Comma(,) separated list of wallet tran Ids.</summary>
    public string? TranId { get; init; }

    public string? Network { get; init; }

    public string? Coin { get; init; }

    /// <summary>0: Completed,1: Pending,2: Failed</summary>
    public long? TravelRuleStatus { get; init; }

    /// <summary>
    /// true: Only return records that pending deposit questionnaire. false/not provided: return all
    /// records.
    /// </summary>
    public bool? PendingQuestionnaire { get; init; }

    /// <summary>Default: 90 days from current timestamp</summary>
    public long? StartTime { get; init; }

    /// <summary>Default: present timestamp</summary>
    public long? EndTime { get; init; }

    /// <summary>Default: 0</summary>
    public long? Offset { get; init; }

    public long? Limit { get; init; }
}

public sealed class DepositHistoryV2Request
{
    /// <summary>Comma(,) separated list of wallet tran Ids.</summary>
    public long? DepositId { get; init; }

    /// <summary>Comma(,) separated list of transaction Ids.</summary>
    public string? TxId { get; init; }

    public string? Network { get; init; }

    public string? Coin { get; init; }

    /// <summary>true: return questionnaire within response.</summary>
    public bool? RetrieveQuestionnaire { get; init; }

    /// <summary>Default: 90 days from current timestamp</summary>
    public long? StartTime { get; init; }

    /// <summary>Default: present timestamp</summary>
    public long? EndTime { get; init; }

    public long? Offset { get; init; }

    public long? Limit { get; init; }
}

public sealed class FetchAddressVerificationListRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetCountryListRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class GetRegionListRequest
{
    /// <summary>ISO 2-digit country code (from Country List API).</summary>
    public required string CountryCode { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class SubmitDepositQuestionnaireRequest
{
    /// <summary>External user ID.</summary>
    public required string SubAccountId { get; init; }

    /// <summary>Wallet deposit ID.</summary>
    public required long DepositId { get; init; }

    /// <summary>JSON format questionnaire answers.</summary>
    public required string Questionnaire { get; init; }

    /// <summary>JSON format beneficiary Pii, see StandardPii section below</summary>
    public required string BeneficiaryPii { get; init; }

    public string? Network { get; init; }

    public string? Coin { get; init; }

    public decimal? Amount { get; init; }

    public string? Address { get; init; }

    public string? AddressTag { get; init; }
}

public sealed class SubmitDepositQuestionnaireTravelRuleRequest
{
    /// <summary>Wallet tran ID</summary>
    public required long TranId { get; init; }

    /// <summary>JSON format questionnaire answers.</summary>
    public required string Questionnaire { get; init; }
}

public sealed class SubmitDepositQuestionnaireV2Request
{
    /// <summary>Wallet deposit ID</summary>
    public required long DepositId { get; init; }

    /// <summary>JSON format questionnaire answers.</summary>
    public required string Questionnaire { get; init; }
}

public sealed class VaspListRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class WithdrawHistoryV1Request
{
    /// <summary>Comma(,) separated list of travel rule record Ids.</summary>
    public string? TrId { get; init; }

    /// <summary>Comma(,) separated list of transaction Ids.</summary>
    public string? TxId { get; init; }

    /// <summary>
    /// client side id for withdrawal, if provided in POST /sapi/v1/capital/withdraw/apply, can be used here
    /// for query.
    /// </summary>
    public string? WithdrawOrderId { get; init; }

    public string? Network { get; init; }

    public string? Coin { get; init; }

    /// <summary>0: Completed,1: Pending,2: Failed</summary>
    public long? TravelRuleStatus { get; init; }

    public long? Offset { get; init; }

    public long? Limit { get; init; }

    /// <summary>Default: 90 days from current timestamp</summary>
    public long? StartTime { get; init; }

    /// <summary>Default: present timestamp</summary>
    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class WithdrawHistoryV2Request
{
    /// <summary>Comma(,) separated list of travel rule record Ids.</summary>
    public string? TrId { get; init; }

    /// <summary>Comma(,) separated list of transaction Ids.</summary>
    public string? TxId { get; init; }

    /// <summary>
    /// client side id for withdrawal, if provided in POST /sapi/v1/capital/withdraw/apply, can be used here
    /// for query.
    /// </summary>
    public string? WithdrawOrderId { get; init; }

    public string? Network { get; init; }

    public string? Coin { get; init; }

    /// <summary>0: Completed,1: Pending,2: Failed</summary>
    public long? TravelRuleStatus { get; init; }

    public long? Offset { get; init; }

    public long? Limit { get; init; }

    /// <summary>Default: 90 days from current timestamp</summary>
    public long? StartTime { get; init; }

    /// <summary>Default: present timestamp</summary>
    public long? EndTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class WithdrawTravelRuleRequest
{
    public required string Coin { get; init; }

    /// <summary>Withdrawal address</summary>
    public required string Address { get; init; }

    /// <summary>Amount</summary>
    public required decimal Amount { get; init; }

    /// <summary>JSON format questionnaire answers.</summary>
    public required string Questionnaire { get; init; }

    /// <summary>withdrawID defined by the client (i.e. client's internal withdrawID)</summary>
    public string? WithdrawOrderId { get; init; }

    /// <summary>Withdrawal network</summary>
    public string? Network { get; init; }

    /// <summary>Secondary address identifier for coins like XRP,XMR etc.</summary>
    public string? AddressTag { get; init; }

    /// <summary>
    /// When making internal transfer, true for returning the fee to the destination account; false for
    /// returning the fee back to the departure account. Default false.
    /// </summary>
    public bool? TransactionFeeFlag { get; init; }

    public string? Name { get; init; }

    /// <summary>
    /// The wallet type for withdraw，0-spot wallet ，1-funding wallet. Default walletType is the current
    /// "selected wallet" under wallet-&gt;Fiat and Spot/Funding-&gt;Deposit
    /// </summary>
    public long? WalletType { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class WalletRestApi
{

    /// <summary>
    /// Broker Withdraw (for brokers of local entities that require travel rule) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Submit a withdrawal request for brokers of local entities that required travel rule.</para>
    /// <para>Weight(UID): 600</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If network not send, return with default network of the coin, but if the address could not match
    /// default network, the withdraw will be rejected.
    /// </para>
    /// <para>
    /// - You can get network in networkList of a coin in the response of Get /sapi/v1/capital/config/getall
    /// (HMAC SHA256).
    /// </para>
    /// <para>
    /// - Questionnaire is different for each local entity, please refer to the Withdraw Questionnaire
    /// Contents page.
    /// </para>
    /// <para>
    /// - If getting error like Questionnaire format not valid. or Questionnaire must not be blank, please
    /// try to verify the format of the questionnaire and use URL-encoded format.
    /// </para>
    /// <para>StandardPii</para>
    /// <para>For Natural Person</para>
    /// <para>- piiType (INTEGER, Mandatory): Fix to 0: Natural Person</para>
    /// <para>
    /// - latinNames (List&lt;PiiName&gt;, Mandatory): In case a person have complicated names or multiple
    /// names, this parameter is a list
    /// </para>
    /// <para>
    /// - localNames (List&lt;PiiName&gt;, Optional): In case a person have complicated names or multiple
    /// names, this parameter is a list
    /// </para>
    /// <para>- nationality (STRING, Optional)</para>
    /// <para>- residenceCountry (STRING, Mandatory)</para>
    /// <para>- nationalIdentifier (STRING, Optional)</para>
    /// <para>- nationalIdentifierType (STRING, Optional)</para>
    /// <para>- nationalIdentifierIssueCountry (STRING, Optional)</para>
    /// <para>
    /// - dateOfBirth (STRING, Optional): yyyy-mm-dd. Not required but strongly recommended. Providing DOB
    /// could greatly reduce false positive rate during risk checking process.
    /// </para>
    /// <para>- placeOfBirth (STRING, Optional)</para>
    /// <para>- address (STRING, Optional)</para>
    /// <para>For Legal Person</para>
    /// <para>- piiType (INTEGER, Mandatory): Fix to 1: Legal Person</para>
    /// <para>- latinName (STRING, Mandatory): It's company name for Legal Person</para>
    /// <para>- localName (STRING, Optional)</para>
    /// <para>- registrationCountry (STRING, Mandatory)</para>
    /// <para>- nationalIdentifier (STRING, Optional)</para>
    /// <para>- nationalIdentifierType (STRING, Optional)</para>
    /// <para>- nationalIdentifierIssueCountry (STRING, Optional)</para>
    /// <para>- registrationDate (STRING, Optional): yyyy-mm-dd. Not required but strongly recommended.</para>
    /// <para>- address (STRING, Optional)</para>
    /// <para>- walletAddress (STRING, Optional)</para>
    /// <para>- walletTag (STRING, Optional)</para>
    /// <para>PiiName</para>
    /// <para>- firstName (STRING, Mandatory): Mandatory for Natural person</para>
    /// <para>- middleName (STRING, Optional)</para>
    /// <para>- lastName (STRING, Optional)</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<BrokerWithdrawResponse>> BrokerWithdrawAsync(BrokerWithdrawRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/localentity/broker/withdraw/apply", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<BrokerWithdrawResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("address", request.Address);
        r.Query("coin", request.Coin);
        r.Query("amount", request.Amount);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("questionnaire", request.Questionnaire);
        r.Query("originatorPii", request.OriginatorPii);
        r.Query("addressTag", request.AddressTag);
        r.Query("network", request.Network);
        r.Query("addressName", request.AddressName);
        r.Query("transactionFeeFlag", request.TransactionFeeFlag);
        r.Query("walletType", request.WalletType);
        return _client.SendAsync(r, WalletRestApiJson.Default.BrokerWithdrawResponse, cancellationToken);
    }

    /// <summary>
    /// Check Questionnaire Requirements (for local entities that require travel rule) (supporting network)
    /// (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>
    /// This API will return user-specific Travel Rule questionnaire requirement information in reference to
    /// the current API key.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CheckQuestionnaireRequirementsResponse>> CheckQuestionnaireRequirementsAsync(CheckQuestionnaireRequirementsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/localentity/questionnaire-requirements", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.CheckQuestionnaireRequirementsResponse, cancellationToken);
    }

    /// <summary>
    /// Deposit History Travel Rule (for local entities that required travel rule) (supporting network)
    /// (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Fetch deposit history for local entities that required travel rule.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Please notice the default startTime and endTime to make sure that time interval is within 0-90
    /// days.
    /// </para>
    /// <para>
    /// - If both startTime and endTime are sent, time between startTime and endTime must be less than 90
    /// days.
    /// </para>
    /// <para>
    /// - Please, note that due to network-specific characteristics, the returned source address may be
    /// inaccurate. If multiple source addresses are found, only the first one will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<DepositHistoryTravelRuleResponseInner>>> DepositHistoryTravelRuleAsync(DepositHistoryTravelRuleRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/localentity/deposit/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("trId", request.TrId);
        r.Query("txId", request.TxId);
        r.Query("tranId", request.TranId);
        r.Query("network", request.Network);
        r.Query("coin", request.Coin);
        r.Query("travelRuleStatus", request.TravelRuleStatus);
        r.Query("pendingQuestionnaire", request.PendingQuestionnaire);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListDepositHistoryTravelRuleResponseInner, cancellationToken);
    }

    /// <summary>
    /// Deposit History V2 (for local entities that required travel rule) (supporting network) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Fetch deposit history for local entities that with required travel rule information.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Please notice the default startTime and endTime to make sure that time interval is within 0-90
    /// days.
    /// </para>
    /// <para>
    /// - If both startTime and endTime are sent, time between startTime and endTime must be less than 90
    /// days.
    /// </para>
    /// <para>
    /// - Please, note that due to network-specific characteristics, the returned source address may be
    /// inaccurate. If multiple source addresses are found, only the first one will be returned.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<DepositHistoryV2ResponseInner>>> DepositHistoryV2Async(DepositHistoryV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/localentity/deposit/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("depositId", request.DepositId);
        r.Query("txId", request.TxId);
        r.Query("network", request.Network);
        r.Query("coin", request.Coin);
        r.Query("retrieveQuestionnaire", request.RetrieveQuestionnaire);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListDepositHistoryV2ResponseInner, cancellationToken);
    }

    /// <summary>Fetch address verification list (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Fetch address verification list for user to check on status and other details for the addresses
    /// stored in Address Book.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<FetchAddressVerificationListResponseInner>>> FetchAddressVerificationListAsync(FetchAddressVerificationListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/addressVerify/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListFetchAddressVerificationListResponseInner, cancellationToken);
    }

    /// <summary>Get Country List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query the active country list for travel rule questionnaires. Currently supports AU and BR entities.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCountryListResponse>> GetCountryListAsync(GetCountryListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/localentity/country/list", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.GetCountryListResponse, cancellationToken);
    }

    /// <summary>Get Region List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query the active region/city list for a given country. Currently, only supports AU entity.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRegionListResponse>> GetRegionListAsync(GetRegionListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/localentity/region/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetRegionListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("countryCode", request.CountryCode);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.GetRegionListResponse, cancellationToken);
    }

    /// <summary>
    /// Submit Deposit Questionnaire Broker (For local entities that require travel rule) (supporting
    /// network) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>
    /// Submit questionnaire for brokers of local entities that require travel rule. The questionnaire is
    /// only applies to transactions from un-hosted wallets or VASPs that are not yet onboarded with GTR.
    /// </para>
    /// <para>Weight(UID): 600</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Questionnaire is different for each local entity, please refer to Deposit Questionnaire Content
    /// page.
    /// </para>
    /// <para>
    /// - If getting error like Questionnaire format not valid. or Questionnaire must not be blank, please
    /// try to verify the format of the questionnaire and use URL-encoded format.
    /// </para>
    /// <para>StandardPii</para>
    /// <para>For Natural Person</para>
    /// <para>- piiType (INTEGER, Mandatory): Fix to 0: Natural Person</para>
    /// <para>
    /// - latinNames (List&lt;PiiName&gt;, Mandatory): In case a person have complicated names or multiple
    /// names, this parameter is a list
    /// </para>
    /// <para>
    /// - localNames (List&lt;PiiName&gt;, Optional): In case a person have complicated names or multiple
    /// names, this parameter is a list
    /// </para>
    /// <para>- nationality (STRING, Optional)</para>
    /// <para>- residenceCountry (STRING, Mandatory)</para>
    /// <para>- nationalIdentifier (STRING, Optional)</para>
    /// <para>- nationalIdentifierType (STRING, Optional)</para>
    /// <para>- nationalIdentifierIssueCountry (STRING, Optional)</para>
    /// <para>
    /// - dateOfBirth (STRING, Optional): yyyy-mm-dd. Not required but strongly recommended. Providing DOB
    /// could greatly reduce false positive rate during risk checking process.
    /// </para>
    /// <para>- placeOfBirth (STRING, Optional)</para>
    /// <para>- address (STRING, Optional)</para>
    /// <para>For Legal Person</para>
    /// <para>- piiType (INTEGER, Mandatory): Fix to 1: Legal Person</para>
    /// <para>- latinName (STRING, Mandatory): It's company name for Legal Person</para>
    /// <para>- localName (STRING, Optional)</para>
    /// <para>- registrationCountry (STRING, Mandatory)</para>
    /// <para>- nationalIdentifier (STRING, Optional)</para>
    /// <para>- nationalIdentifierType (STRING, Optional)</para>
    /// <para>- nationalIdentifierIssueCountry (STRING, Optional)</para>
    /// <para>- registrationDate (STRING, Optional): yyyy-mm-dd. Not required but strongly recommended.</para>
    /// <para>- address (STRING, Optional)</para>
    /// <para>- walletAddress (STRING, Optional)</para>
    /// <para>- walletTag (STRING, Optional)</para>
    /// <para>PiiName</para>
    /// <para>- firstName (STRING, Mandatory): Mandatory for Natural person</para>
    /// <para>- middleName (STRING, Optional)</para>
    /// <para>- lastName (STRING, Optional)</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubmitDepositQuestionnaireResponse>> SubmitDepositQuestionnaireAsync(SubmitDepositQuestionnaireRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/sapi/v1/localentity/broker/deposit/provide-info", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubmitDepositQuestionnaireResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("subAccountId", request.SubAccountId);
        r.Query("depositId", request.DepositId);
        r.Query("questionnaire", request.Questionnaire);
        r.Query("beneficiaryPii", request.BeneficiaryPii);
        r.Query("network", request.Network);
        r.Query("coin", request.Coin);
        r.Query("amount", request.Amount);
        r.Query("address", request.Address);
        r.Query("addressTag", request.AddressTag);
        return _client.SendAsync(r, WalletRestApiJson.Default.SubmitDepositQuestionnaireResponse, cancellationToken);
    }

    /// <summary>
    /// Submit Deposit Questionnaire (For local entities that require travel rule) (supporting network)
    /// (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>
    /// Submit questionnaire for local entities that require travel rule. The questionnaire is only applies
    /// to transactions from unhosted wallets or VASPs that are not yet onboarded with GTR.
    /// </para>
    /// <para>Weight(UID): 600</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Questionnaire is different for each local entity, please refer to Deposit Questionnaire Content
    /// page.
    /// </para>
    /// <para>
    /// - If getting error like Questionnaire format not valid. or Questionnaire must not be blank, please
    /// try to verify the format of the questionnaire and use URL-encoded format.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubmitDepositQuestionnaireTravelRuleResponse>> SubmitDepositQuestionnaireTravelRuleAsync(SubmitDepositQuestionnaireTravelRuleRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/sapi/v1/localentity/deposit/provide-info", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubmitDepositQuestionnaireTravelRuleResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("tranId", request.TranId);
        r.Query("questionnaire", request.Questionnaire);
        return _client.SendAsync(r, WalletRestApiJson.Default.SubmitDepositQuestionnaireTravelRuleResponse, cancellationToken);
    }

    /// <summary>
    /// Submit Deposit Questionnaire V2 (For local entities that require travel rule) (supporting network)
    /// (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>
    /// Submit questionnaire for local entities that require travel rule. The questionnaire is only applies
    /// to transactions from unhosted wallets or VASPs that are not yet onboarded with GTR.
    /// </para>
    /// <para>Weight(UID): 600</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Questionnaire is different for each local entity, please refer to Deposit Questionnaire Content
    /// page.
    /// </para>
    /// <para>
    /// - If getting error like Questionnaire format not valid. or Questionnaire must not be blank, please
    /// try to verify the format of the questionnaire and use URL-encoded format.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubmitDepositQuestionnaireV2Response>> SubmitDepositQuestionnaireV2Async(SubmitDepositQuestionnaireV2Request request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/sapi/v2/localentity/deposit/provide-info", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubmitDepositQuestionnaireV2Response>>(new ArgumentNullException(nameof(request)));
        r.Query("depositId", request.DepositId);
        r.Query("questionnaire", request.Questionnaire);
        return _client.SendAsync(r, WalletRestApiJson.Default.SubmitDepositQuestionnaireV2Response, cancellationToken);
    }

    /// <summary>
    /// VASP list (for local entities that require travel rule) (supporting network) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Fetch the VASP list for local entities.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<VaspListResponseInner>>> VaspListAsync(VaspListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/localentity/vasp", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListVaspListResponseInner, cancellationToken);
    }

    /// <summary>Withdraw History Travel Rule (supporting network) (USER_DATA)</summary>
    /// <remarks>
    /// <para>Fetch withdraw history for local entities that required travel rule.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- network may not be in the response for old withdraw.</para>
    /// <para>
    /// - Please notice the default startTime and endTime to make sure that time interval is within 0-90
    /// days.
    /// </para>
    /// <para>- If both startTime and endTimeare sent, time between startTimeand endTimemust be less than 90 days.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<WithdrawHistoryV1ResponseInner>>> WithdrawHistoryV1Async(WithdrawHistoryV1Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/localentity/withdraw/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("trId", request.TrId);
        r.Query("txId", request.TxId);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("network", request.Network);
        r.Query("coin", request.Coin);
        r.Query("travelRuleStatus", request.TravelRuleStatus);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListWithdrawHistoryV1ResponseInner, cancellationToken);
    }

    /// <summary>
    /// Withdraw History V2 (for local entities that require travel rule) (supporting network) (USER_DATA)
    /// </summary>
    /// <remarks>
    /// <para>Fetch withdraw history for local entities that required travel rule.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- network may not be in the response for old withdraw.</para>
    /// <para>- Withdrawal made through /sapi/v1/capital/withdraw/apply may not be in the response.</para>
    /// <para>
    /// - Please notice the default startTime and endTime to make sure that time interval is within 0-90
    /// days.
    /// </para>
    /// <para>- If both startTime and endTimeare sent, time between startTimeand endTimemust be less than 90 days.</para>
    /// <para>- If withdrawOrderId is sent, time between startTime and endTime must be less than 7 days.</para>
    /// <para>
    /// - If withdrawOrderId is sent, startTime and endTime are not sent, will return last 7 days records by
    /// default.
    /// </para>
    /// <para>- Maximum support trId,txId number is 45.</para>
    /// <para>- WithdrawOrderId only support 1.</para>
    /// <para>- If responsible does not include withdrawalStatus, please input trId or txId retrieve the data.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<WithdrawHistoryV1ResponseInner>>> WithdrawHistoryV2Async(WithdrawHistoryV2Request? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v2/localentity/withdraw/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("trId", request.TrId);
        r.Query("txId", request.TxId);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("network", request.Network);
        r.Query("coin", request.Coin);
        r.Query("travelRuleStatus", request.TravelRuleStatus);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.ListWithdrawHistoryV1ResponseInner, cancellationToken);
    }

    /// <summary>Withdraw Travel Rule (USER_DATA)</summary>
    /// <remarks>
    /// <para>Submit a withdrawal request for local entities that required travel rule.</para>
    /// <para>Weight(UID): 600</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If network not send, return with default network of the coin, but if the address could not match
    /// default network, the withdraw will be rejected.
    /// </para>
    /// <para>
    /// - You can get network and isDefault in networkList of a coin in the response of Get
    /// /sapi/v1/capital/config/getall (HMAC SHA256).
    /// </para>
    /// <para>
    /// - Questionnaire is different for each local entity, please refer to the Withdraw Questionnaire
    /// Contents page.
    /// </para>
    /// <para>
    /// - If getting error like Questionnaire format not valid. or Questionnaire must not be blank, please
    /// try to verify the format of the questionnaire and use URL-encoded format.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<WithdrawTravelRuleResponse>> WithdrawTravelRuleAsync(WithdrawTravelRuleRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/localentity/withdraw/apply", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<WithdrawTravelRuleResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("address", request.Address);
        r.Query("amount", request.Amount);
        r.Query("questionnaire", request.Questionnaire);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("network", request.Network);
        r.Query("addressTag", request.AddressTag);
        r.Query("transactionFeeFlag", request.TransactionFeeFlag);
        r.Query("name", request.Name);
        r.Query("walletType", request.WalletType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, WalletRestApiJson.Default.WithdrawTravelRuleResponse, cancellationToken);
    }
}
