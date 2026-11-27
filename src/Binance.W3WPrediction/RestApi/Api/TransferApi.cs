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

namespace Binance.W3WPrediction.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<ApplyMmDepositAccountType>))]
public readonly struct ApplyMmDepositAccountType : IExtensibleValue<ApplyMmDepositAccountType>, IEquatable<ApplyMmDepositAccountType>
{
    private readonly string? _value;

    public ApplyMmDepositAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ApplyMmDepositAccountType Spot { get; } = new("SPOT");

    public static ApplyMmDepositAccountType Funding { get; } = new("FUNDING");

    static ApplyMmDepositAccountType IExtensibleValue<ApplyMmDepositAccountType>.Create(string value) => new(value);

    public static bool operator ==(ApplyMmDepositAccountType left, ApplyMmDepositAccountType right) => left.Equals(right);

    public static bool operator !=(ApplyMmDepositAccountType left, ApplyMmDepositAccountType right) => !left.Equals(right);

    public static implicit operator ApplyMmDepositAccountType(string value) => new(value);

    public static ApplyMmDepositAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ApplyMmDepositAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ApplyMmDepositAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ApplyMmDepositRequest
{
    /// <summary>Source token symbol (e.g. USDT)</summary>
    public required string FromToken { get; init; }

    /// <summary>Source token amount in WEI (18 decimals). Example: 1000000000000000000 = 1 USDT</summary>
    public required string FromTokenAmount { get; init; }

    /// <summary>Target token symbol (e.g. USDT)</summary>
    public required string ToToken { get; init; }

    /// <summary>Target CEX account type. Enum: SPOT, FUNDING</summary>
    public required ApplyMmDepositAccountType AccountType { get; init; }

    /// <summary>Chain ID. Default 56 (BSC)</summary>
    public string? ChainId { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ApplyMmWithdrawWalletType>))]
public readonly struct ApplyMmWithdrawWalletType : IExtensibleValue<ApplyMmWithdrawWalletType>, IEquatable<ApplyMmWithdrawWalletType>
{
    private readonly string? _value;

    public ApplyMmWithdrawWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ApplyMmWithdrawWalletType WalletType0 { get; } = new("0");

    public static ApplyMmWithdrawWalletType WalletType1 { get; } = new("1");

    static ApplyMmWithdrawWalletType IExtensibleValue<ApplyMmWithdrawWalletType>.Create(string value) => new(value);

    public static bool operator ==(ApplyMmWithdrawWalletType left, ApplyMmWithdrawWalletType right) => left.Equals(right);

    public static bool operator !=(ApplyMmWithdrawWalletType left, ApplyMmWithdrawWalletType right) => !left.Equals(right);

    public static implicit operator ApplyMmWithdrawWalletType(string value) => new(value);

    public static ApplyMmWithdrawWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ApplyMmWithdrawWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ApplyMmWithdrawWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ApplyMmWithdrawRequest
{
    /// <summary>Coin to withdraw (e.g. USDT)</summary>
    public required string Coin { get; init; }

    /// <summary>Network (e.g. BEP20)</summary>
    public required string Network { get; init; }

    /// <summary>Amount to withdraw (must be &gt; 0)</summary>
    public required string Amount { get; init; }

    /// <summary>Client withdraw order id (idempotency key)</summary>
    public string? WithdrawOrderId { get; init; }

    /// <summary>
    /// Source CEX account type. Enum: 0 (SPOT), 1 (FUNDING). Default 0. Must be 0 or 1; any other value is
    /// rejected
    /// </summary>
    public ApplyMmWithdrawWalletType? WalletType { get; init; }

    /// <summary>Remark for the withdraw</summary>
    public string? Name { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<CreateInboundTransferAccountType>))]
public readonly struct CreateInboundTransferAccountType : IExtensibleValue<CreateInboundTransferAccountType>, IEquatable<CreateInboundTransferAccountType>
{
    private readonly string? _value;

    public CreateInboundTransferAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static CreateInboundTransferAccountType Spot { get; } = new("SPOT");

    public static CreateInboundTransferAccountType Funding { get; } = new("FUNDING");

    static CreateInboundTransferAccountType IExtensibleValue<CreateInboundTransferAccountType>.Create(string value) => new(value);

    public static bool operator ==(CreateInboundTransferAccountType left, CreateInboundTransferAccountType right) => left.Equals(right);

    public static bool operator !=(CreateInboundTransferAccountType left, CreateInboundTransferAccountType right) => !left.Equals(right);

    public static implicit operator CreateInboundTransferAccountType(string value) => new(value);

    public static CreateInboundTransferAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is CreateInboundTransferAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(CreateInboundTransferAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class CreateInboundTransferRequest
{
    /// <summary>Wallet ID</summary>
    public required string WalletId { get; init; }

    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>
    /// Transfer amount in wei (18 decimals). Must be &gt; 0. Example: 1000000000000000000 = 1 USDT
    /// </summary>
    public required string FromTokenAmount { get; init; }

    /// <summary>Destination CEX account. Enum: SPOT, FUNDING</summary>
    public required CreateInboundTransferAccountType AccountType { get; init; }

    /// <summary>Source token symbol. Default USDT</summary>
    public string? FromToken { get; init; }

    /// <summary>Destination token symbol. Default USDT</summary>
    public string? ToToken { get; init; }

    /// <summary>Chain ID. Default 56 (BSC)</summary>
    public string? ChainId { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<CreateOutboundTransferAccountType>))]
public readonly struct CreateOutboundTransferAccountType : IExtensibleValue<CreateOutboundTransferAccountType>, IEquatable<CreateOutboundTransferAccountType>
{
    private readonly string? _value;

    public CreateOutboundTransferAccountType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static CreateOutboundTransferAccountType Spot { get; } = new("SPOT");

    public static CreateOutboundTransferAccountType Funding { get; } = new("FUNDING");

    static CreateOutboundTransferAccountType IExtensibleValue<CreateOutboundTransferAccountType>.Create(string value) => new(value);

    public static bool operator ==(CreateOutboundTransferAccountType left, CreateOutboundTransferAccountType right) => left.Equals(right);

    public static bool operator !=(CreateOutboundTransferAccountType left, CreateOutboundTransferAccountType right) => !left.Equals(right);

    public static implicit operator CreateOutboundTransferAccountType(string value) => new(value);

    public static CreateOutboundTransferAccountType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is CreateOutboundTransferAccountType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(CreateOutboundTransferAccountType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<CreateOutboundTransferSourceBiz>))]
public readonly struct CreateOutboundTransferSourceBiz : IExtensibleValue<CreateOutboundTransferSourceBiz>, IEquatable<CreateOutboundTransferSourceBiz>
{
    private readonly string? _value;

    public CreateOutboundTransferSourceBiz(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static CreateOutboundTransferSourceBiz UserTransfer { get; } = new("USER_TRANSFER");

    public static CreateOutboundTransferSourceBiz PredictionBuy { get; } = new("PREDICTION_BUY");

    static CreateOutboundTransferSourceBiz IExtensibleValue<CreateOutboundTransferSourceBiz>.Create(string value) => new(value);

    public static bool operator ==(CreateOutboundTransferSourceBiz left, CreateOutboundTransferSourceBiz right) => left.Equals(right);

    public static bool operator !=(CreateOutboundTransferSourceBiz left, CreateOutboundTransferSourceBiz right) => !left.Equals(right);

    public static implicit operator CreateOutboundTransferSourceBiz(string value) => new(value);

    public static CreateOutboundTransferSourceBiz FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is CreateOutboundTransferSourceBiz other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(CreateOutboundTransferSourceBiz other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class CreateOutboundTransferRequest
{
    /// <summary>Wallet ID</summary>
    public required string WalletId { get; init; }

    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>
    /// Transfer amount in wei (18 decimals). Must be &gt; 0. Example: 1000000000000000000 = 1 USDT
    /// </summary>
    public required string FromTokenAmount { get; init; }

    /// <summary>Source CEX account. Enum: SPOT, FUNDING</summary>
    public required CreateOutboundTransferAccountType AccountType { get; init; }

    /// <summary>Business source. Enum: USER_TRANSFER, PREDICTION_BUY</summary>
    public required CreateOutboundTransferSourceBiz SourceBiz { get; init; }

    /// <summary>Source token symbol. Default USDT</summary>
    public string? FromToken { get; init; }

    /// <summary>Destination token symbol. Default USDT</summary>
    public string? ToToken { get; init; }

    /// <summary>Chain ID. Default 56 (BSC)</summary>
    public string? ChainId { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<QueryTransferListDirection>))]
public readonly struct QueryTransferListDirection : IExtensibleValue<QueryTransferListDirection>, IEquatable<QueryTransferListDirection>
{
    private readonly string? _value;

    public QueryTransferListDirection(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static QueryTransferListDirection Inbound { get; } = new("INBOUND");

    public static QueryTransferListDirection Outbound { get; } = new("OUTBOUND");

    static QueryTransferListDirection IExtensibleValue<QueryTransferListDirection>.Create(string value) => new(value);

    public static bool operator ==(QueryTransferListDirection left, QueryTransferListDirection right) => left.Equals(right);

    public static bool operator !=(QueryTransferListDirection left, QueryTransferListDirection right) => !left.Equals(right);

    public static implicit operator QueryTransferListDirection(string value) => new(value);

    public static QueryTransferListDirection FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is QueryTransferListDirection other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(QueryTransferListDirection other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class QueryTransferListRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Start date. Format: yyyy-MM-dd. Must be ≤ endDate</summary>
    public required string StartDate { get; init; }

    /// <summary>End date. Format: yyyy-MM-dd. Must be ≥ startDate</summary>
    public required string EndDate { get; init; }

    /// <summary>Filter by token symbol (e.g. USDT)</summary>
    public string? TokenSymbol { get; init; }

    /// <summary>Filter by direction. Enum: INBOUND, OUTBOUND</summary>
    public QueryTransferListDirection? Direction { get; init; }

    /// <summary>Pagination offset. Default 0</summary>
    public long? Offset { get; init; }

    /// <summary>Page size. Default 20, range 1–100</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryTransferStatusRequest
{
    /// <summary>Transfer ID returned from outbound/inbound transfer</summary>
    public required string TransferId { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class W3WPredictionRestApi
{

    /// <summary>Apply MM Deposit (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Move funds from the user's bound CeDeFi MPC wallet to their CEX account (SPOT/FUNDING) via a
    /// contract escrow + credit flow. The maker wallet is resolved server-side by userId; the caller does
    /// not pass wallet or signature.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// <para>
    /// - "Note on fromToken / toToken: typically the same symbol (e.g. both USDT). When they differ, the
    /// backend may attempt a swap, but cross-symbol conversion is not guaranteed for all pairs — prefer
    /// using the same symbol."
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ApplyMmDepositResponse>> ApplyMmDepositAsync(ApplyMmDepositRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/deposit/apply", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ApplyMmDepositResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromToken", request.FromToken);
        r.Query("fromTokenAmount", request.FromTokenAmount);
        r.Query("toToken", request.ToToken);
        r.Query("accountType", request.AccountType);
        r.Query("chainId", request.ChainId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ApplyMmDepositResponse, cancellationToken);
    }

    /// <summary>Apply MM Withdraw (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Withdraw funds from the user's CEX account (SPOT/FUNDING) to their bound CeDeFi MPC wallet address.
    /// Unlike v1/capital/withdraw/apply, the caller does NOT pass address; the backend resolves the user's
    /// bound CeDeFi MPC wallet address by userId and reuses the existing capital withdraw flow with that
    /// address as the target.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - Restricted to authorized market makers. Requests from unauthorized accounts are rejected — contact
    /// BD to request access.
    /// </para>
    /// <para>- walletType Validation:</para>
    /// <para>| Value | Behavior |</para>
    /// <para>| null | Allowed — defaults to SPOT |</para>
    /// <para>| 0 | Allowed — source = SPOT |</para>
    /// <para>| 1 | Allowed — source = FUNDING |</para>
    /// <para>| Other (e.g. 99) | Rejected — returns validation error |</para>
    /// <para>
    /// - "Note on field naming: this endpoint uses walletType (INT 0/1) for the source CEX account, while
    /// Apply MM Deposit uses accountType (STRING SPOT/FUNDING) for the target. The difference is
    /// intentional: withdraw reuses the existing v1/capital/withdraw/apply flow, which inherits that flow's
    /// integer walletType field."
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ApplyMmWithdrawResponse>> ApplyMmWithdrawAsync(ApplyMmWithdrawRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/withdraw/apply", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ApplyMmWithdrawResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("coin", request.Coin);
        r.Query("network", request.Network);
        r.Query("amount", request.Amount);
        r.Query("withdrawOrderId", request.WithdrawOrderId);
        r.Query("walletType", request.WalletType);
        r.Query("name", request.Name);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.ApplyMmWithdrawResponse, cancellationToken);
    }

    /// <summary>Create Inbound Transfer (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Transfer funds from the prediction wallet back to the user's CEX account (SPOT or FUNDING). Requires
    /// SAS authorization.
    /// </para>
    /// <para>
    /// ⚠️ SAS Authorization Required: This endpoint enforces SAS (Self-Authorization Service)
    /// authorization. If SAS is not enabled for the wallet, the request will be rejected with -31003 SAS
    /// authorization required. Enable SAS for your wallet before calling this endpoint.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateInboundTransferResponse>> CreateInboundTransferAsync(CreateInboundTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/transfer/inbound", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateInboundTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletId", request.WalletId);
        r.Query("walletAddress", request.WalletAddress);
        r.Query("fromTokenAmount", request.FromTokenAmount);
        r.Query("accountType", request.AccountType);
        r.Query("fromToken", request.FromToken);
        r.Query("toToken", request.ToToken);
        r.Query("chainId", request.ChainId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.CreateInboundTransferResponse, cancellationToken);
    }

    /// <summary>Create Outbound Transfer (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Transfer funds from the user's CEX account (SPOT or FUNDING) into the prediction wallet. Requires
    /// SAS authorization.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateOutboundTransferResponse>> CreateOutboundTransferAsync(CreateOutboundTransferRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/transfer/outbound", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateOutboundTransferResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletId", request.WalletId);
        r.Query("walletAddress", request.WalletAddress);
        r.Query("fromTokenAmount", request.FromTokenAmount);
        r.Query("accountType", request.AccountType);
        r.Query("sourceBiz", request.SourceBiz);
        r.Query("fromToken", request.FromToken);
        r.Query("toToken", request.ToToken);
        r.Query("chainId", request.ChainId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.CreateOutboundTransferResponse, cancellationToken);
    }

    /// <summary>Query Transfer List (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Get the authenticated user's prediction wallet transfer history within a date range.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryTransferListResponse>> QueryTransferListAsync(QueryTransferListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/transfer/list", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryTransferListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("startDate", request.StartDate);
        r.Query("endDate", request.EndDate);
        r.Query("tokenSymbol", request.TokenSymbol);
        r.Query("direction", request.Direction);
        r.Query("offset", request.Offset);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryTransferListResponse, cancellationToken);
    }

    /// <summary>Query Transfer Status (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Query the current status of a prediction wallet transfer by transfer ID.</para>
    /// <para>
    /// status values: Terminal states are COMPLETED and FAILED. Intermediate states are PROCESSING and
    /// PENDING. Do not poll for SUCCESS — it is not a valid terminal state.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryTransferStatusResponse>> QueryTransferStatusAsync(QueryTransferStatusRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/transfer/status", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryTransferStatusResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("transferId", request.TransferId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.QueryTransferStatusResponse, cancellationToken);
    }
}
