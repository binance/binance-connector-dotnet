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

namespace Binance.Fiat.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<DepositApiPaymentMethod>))]
public readonly struct DepositApiPaymentMethod : IExtensibleValue<DepositApiPaymentMethod>, IEquatable<DepositApiPaymentMethod>
{
    private readonly string? _value;

    public DepositApiPaymentMethod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static DepositApiPaymentMethod Pix { get; } = new("pix");

    static DepositApiPaymentMethod IExtensibleValue<DepositApiPaymentMethod>.Create(string value) => new(value);

    public static bool operator ==(DepositApiPaymentMethod left, DepositApiPaymentMethod right) => left.Equals(right);

    public static bool operator !=(DepositApiPaymentMethod left, DepositApiPaymentMethod right) => !left.Equals(right);

    public static implicit operator DepositApiPaymentMethod(string value) => new(value);

    public static DepositApiPaymentMethod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DepositApiPaymentMethod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(DepositApiPaymentMethod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class DepositRequest
{
    public required string Currency { get; init; }

    /// <summary>payment method; current supported: pix</summary>
    public required DepositApiPaymentMethod ApiPaymentMethod { get; init; }

    /// <summary>deposit amount</summary>
    public required string Amount { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }

    public JsonElement? Ext { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<FiatWithdrawApiPaymentMethod>))]
public readonly struct FiatWithdrawApiPaymentMethod : IExtensibleValue<FiatWithdrawApiPaymentMethod>, IEquatable<FiatWithdrawApiPaymentMethod>
{
    private readonly string? _value;

    public FiatWithdrawApiPaymentMethod(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static FiatWithdrawApiPaymentMethod BankTransfer { get; } = new("bank_transfer");

    static FiatWithdrawApiPaymentMethod IExtensibleValue<FiatWithdrawApiPaymentMethod>.Create(string value) => new(value);

    public static bool operator ==(FiatWithdrawApiPaymentMethod left, FiatWithdrawApiPaymentMethod right) => left.Equals(right);

    public static bool operator !=(FiatWithdrawApiPaymentMethod left, FiatWithdrawApiPaymentMethod right) => !left.Equals(right);

    public static implicit operator FiatWithdrawApiPaymentMethod(string value) => new(value);

    public static FiatWithdrawApiPaymentMethod FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is FiatWithdrawApiPaymentMethod other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(FiatWithdrawApiPaymentMethod other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class FiatWithdrawRequest
{
    /// <summary>Fiat currency, such as BRL, ARS, MXN</summary>
    public required string Currency { get; init; }

    /// <summary>payment method; current supported: bank_transfer</summary>
    public required FiatWithdrawApiPaymentMethod ApiPaymentMethod { get; init; }

    /// <summary>withdraw amount</summary>
    public required long Amount { get; init; }

    public required FiatWithdrawRequestAccountInfo AccountInfo { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }

    public JsonElement? Ext { get; init; }
}

public sealed class GetFiatDepositWithdrawHistoryRequest
{
    /// <summary>0: deposit, 1: withdraw</summary>
    public required string TransactionType { get; init; }

    public long? BeginTime { get; init; }

    public long? EndTime { get; init; }

    public long? Page { get; init; }

    public long? Rows { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetFiatPaymentsHistoryRequest
{
    /// <summary>0: buy, 1: sell</summary>
    public required string TransactionType { get; init; }

    public long? BeginTime { get; init; }

    public long? EndTime { get; init; }

    public long? Page { get; init; }

    public long? Rows { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetOrderDetailRequest
{
    /// <summary>Order ID retrieved from the withdrawal API</summary>
    public required string OrderNo { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class FiatRestApi
{

    /// <summary>Deposit (TRADE)</summary>
    /// <remarks>
    /// <para>Submit deposit request, in this version, we only support BRL deposit via pix.</para>
    /// <para>For BRL deposit via pix, you need to place an order before making a transfer from your bank.</para>
    /// <para>
    /// Before calling this api, please make sure you have already completed your KYC or KYB, and already
    /// activated your fiat service on our website.
    /// </para>
    /// <para>Weight(UID): 45000</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - timestamp, signature and recvWindow are sent as query-string parameters, while the business fields
    /// (currency, apiPaymentMethod, amount, ext) are sent in the JSON request body with Content-Type:
    /// application/json.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<DepositResponse>> DepositAsync(DepositRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/fiat/deposit", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<DepositResponse>>(new ArgumentNullException(nameof(request)));
        r.Body("currency", request.Currency);
        r.Body("apiPaymentMethod", request.ApiPaymentMethod);
        r.Body("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        r.Body("ext", request.Ext);
        return _client.SendAsync(r, FiatRestApiJson.Default.DepositResponse, cancellationToken);
    }

    /// <summary>Fiat Withdraw (TRADE)</summary>
    /// <remarks>
    /// <para>Submit withdraw request, in this version, we support BRL,ARS,MXN withdrawal via bank_transfer.</para>
    /// <para>
    /// You need to call this api first, and call query order detail api in a loop to get the status of the
    /// order until this order is successful.
    /// </para>
    /// <para>
    /// Before calling this api, please make sure you have already completed your KYC or KYB, and already
    /// activated your fiat service on our website.
    /// </para>
    /// <para>Weight(UID): 45000</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FiatWithdrawResponse>> FiatWithdrawAsync(FiatWithdrawRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v2/fiat/withdraw", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FiatWithdrawResponse>>(new ArgumentNullException(nameof(request)));
        r.Body("currency", request.Currency);
        r.Body("apiPaymentMethod", request.ApiPaymentMethod);
        r.Body("amount", request.Amount);
        r.Body("accountInfo", Wire.Json(request.AccountInfo, FiatRestApiJson.Default.FiatWithdrawRequestAccountInfo));
        r.Query("recvWindow", request.RecvWindow);
        r.Body("ext", request.Ext);
        return _client.SendAsync(r, FiatRestApiJson.Default.FiatWithdrawResponse, cancellationToken);
    }

    /// <summary>Get Fiat Deposit/Withdraw History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Fiat Deposit/Withdraw History</para>
    /// <para>Weight(UID): 45000</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If beginTime and endTime are not sent, recent 30-day data is returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFiatDepositWithdrawHistoryResponse>> GetFiatDepositWithdrawHistoryAsync(GetFiatDepositWithdrawHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/fiat/orders", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFiatDepositWithdrawHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("transactionType", request.TransactionType);
        r.Query("beginTime", request.BeginTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("rows", request.Rows);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, FiatRestApiJson.Default.GetFiatDepositWithdrawHistoryResponse, cancellationToken);
    }

    /// <summary>Get Fiat Payments History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Fiat Payments History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If beginTime and endTime are not sent, recent 30-day data is returned.</para>
    /// <para>- paymentMethod is returned only when querying buy history (transactionType=0).</para>
    /// <para>- Supported payment methods: Cash Balance, Credit Card, Online Banking, Bank Transfer.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetFiatPaymentsHistoryResponse>> GetFiatPaymentsHistoryAsync(GetFiatPaymentsHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/fiat/payments", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetFiatPaymentsHistoryResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("transactionType", request.TransactionType);
        r.Query("beginTime", request.BeginTime);
        r.Query("endTime", request.EndTime);
        r.Query("page", request.Page);
        r.Query("rows", request.Rows);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, FiatRestApiJson.Default.GetFiatPaymentsHistoryResponse, cancellationToken);
    }

    /// <summary>Get Order Detail (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Order Detail</para>
    /// <para>
    /// Before calling this api, please make sure you have already completed your KYC or KYB, and already
    /// activated your fiat service on our website.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetOrderDetailResponse>> GetOrderDetailAsync(GetOrderDetailRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/fiat/get-order-detail", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetOrderDetailResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderNo", request.OrderNo);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, FiatRestApiJson.Default.GetOrderDetailResponse, cancellationToken);
    }
}
