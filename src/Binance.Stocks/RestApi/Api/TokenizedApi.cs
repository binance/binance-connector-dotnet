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

public sealed class BstocksCorporateActionRecordsRequest
{
    /// <summary>Number of records to return. Default 20, range 1 to 100.</summary>
    public required long Limit { get; init; }

    /// <summary>
    /// The nextTime returned by the previous page, in milliseconds. Must be sent together with lastId.
    /// </summary>
    public long? LastTime { get; init; }

    /// <summary>The nextId returned by the previous page. Must be sent together with lastTime.</summary>
    public long? LastId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CorporateActionRecordsRequest
{
    /// <summary>Number of records to return. Default 20, range 1 to 100.</summary>
    public required long Limit { get; init; }

    /// <summary>
    /// The nextTime returned by the previous page, in milliseconds. Must be sent together with lastId.
    /// </summary>
    public long? LastTime { get; init; }

    /// <summary>The nextId returned by the previous page. Must be sent together with lastTime.</summary>
    public long? LastId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class TokenizedConvertHistoryRequest
{
    /// <summary>Start time (ms epoch).</summary>
    public long? StartTime { get; init; }

    /// <summary>End time (ms epoch).</summary>
    public long? EndTime { get; init; }

    /// <summary>
    /// Last record id from the previous page. Omit (or leave unset) to fetch the first page.
    /// </summary>
    public long? LastId { get; init; }

    /// <summary>Page size. Default 20, max 100.</summary>
    public long? Size { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TokenizedConvertStatusConvertType>))]
public readonly struct TokenizedConvertStatusConvertType : IExtensibleValue<TokenizedConvertStatusConvertType>, IEquatable<TokenizedConvertStatusConvertType>
{
    private readonly string? _value;

    public TokenizedConvertStatusConvertType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TokenizedConvertStatusConvertType Mint { get; } = new("MINT");

    public static TokenizedConvertStatusConvertType Redeem { get; } = new("REDEEM");

    static TokenizedConvertStatusConvertType IExtensibleValue<TokenizedConvertStatusConvertType>.Create(string value) => new(value);

    public static bool operator ==(TokenizedConvertStatusConvertType left, TokenizedConvertStatusConvertType right) => left.Equals(right);

    public static bool operator !=(TokenizedConvertStatusConvertType left, TokenizedConvertStatusConvertType right) => !left.Equals(right);

    public static implicit operator TokenizedConvertStatusConvertType(string value) => new(value);

    public static TokenizedConvertStatusConvertType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TokenizedConvertStatusConvertType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TokenizedConvertStatusConvertType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TokenizedConvertStatusRequest
{
    /// <summary>Convert request id returned by /tokenized/mint or /redeem.</summary>
    public required string IssuerRequestId { get; init; }

    /// <summary>MINT or REDEEM.</summary>
    public required TokenizedConvertStatusConvertType ConvertType { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TokenizedMintTokenizedAssetSettleWalletType>))]
public readonly struct TokenizedMintTokenizedAssetSettleWalletType : IExtensibleValue<TokenizedMintTokenizedAssetSettleWalletType>, IEquatable<TokenizedMintTokenizedAssetSettleWalletType>
{
    private readonly string? _value;

    public TokenizedMintTokenizedAssetSettleWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TokenizedMintTokenizedAssetSettleWalletType Main { get; } = new("MAIN");

    public static TokenizedMintTokenizedAssetSettleWalletType Card { get; } = new("CARD");

    static TokenizedMintTokenizedAssetSettleWalletType IExtensibleValue<TokenizedMintTokenizedAssetSettleWalletType>.Create(string value) => new(value);

    public static bool operator ==(TokenizedMintTokenizedAssetSettleWalletType left, TokenizedMintTokenizedAssetSettleWalletType right) => left.Equals(right);

    public static bool operator !=(TokenizedMintTokenizedAssetSettleWalletType left, TokenizedMintTokenizedAssetSettleWalletType right) => !left.Equals(right);

    public static implicit operator TokenizedMintTokenizedAssetSettleWalletType(string value) => new(value);

    public static TokenizedMintTokenizedAssetSettleWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TokenizedMintTokenizedAssetSettleWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TokenizedMintTokenizedAssetSettleWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TokenizedMintRequest
{
    /// <summary>
    /// Underlying US-equity ticker, e.g. AAPL, TSLA. Resolved against the active-symbol list; unknown
    /// tickers return -26004. The target tokenized asset is looked up from this field via
    /// /market/tokenized-assets.
    /// </summary>
    public required string UnderlyingAsset { get; init; }

    /// <summary>Quantity of the underlying asset to mint from. Must be &gt; 0.</summary>
    public required string UnderlyingAssetAmount { get; init; }

    /// <summary>
    /// Client order id for idempotency. Format ^[a-zA-Z0-9-_]{32,36}$. Auto-generated when omitted.
    /// </summary>
    public string? ClientOrderId { get; init; }

    /// <summary>
    /// Wallet that receives the minted tokenized asset. MAIN = Spot wallet, CARD = Funding wallet. Default
    /// CARD. If MAIN is sent while Spot wallet settlement is not enabled, the request is rejected as an
    /// illegal parameter.
    /// </summary>
    public TokenizedMintTokenizedAssetSettleWalletType? TokenizedAssetSettleWalletType { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<TokenizedRedeemTokenizedAssetSettleWalletType>))]
public readonly struct TokenizedRedeemTokenizedAssetSettleWalletType : IExtensibleValue<TokenizedRedeemTokenizedAssetSettleWalletType>, IEquatable<TokenizedRedeemTokenizedAssetSettleWalletType>
{
    private readonly string? _value;

    public TokenizedRedeemTokenizedAssetSettleWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static TokenizedRedeemTokenizedAssetSettleWalletType Main { get; } = new("MAIN");

    public static TokenizedRedeemTokenizedAssetSettleWalletType Card { get; } = new("CARD");

    static TokenizedRedeemTokenizedAssetSettleWalletType IExtensibleValue<TokenizedRedeemTokenizedAssetSettleWalletType>.Create(string value) => new(value);

    public static bool operator ==(TokenizedRedeemTokenizedAssetSettleWalletType left, TokenizedRedeemTokenizedAssetSettleWalletType right) => left.Equals(right);

    public static bool operator !=(TokenizedRedeemTokenizedAssetSettleWalletType left, TokenizedRedeemTokenizedAssetSettleWalletType right) => !left.Equals(right);

    public static implicit operator TokenizedRedeemTokenizedAssetSettleWalletType(string value) => new(value);

    public static TokenizedRedeemTokenizedAssetSettleWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TokenizedRedeemTokenizedAssetSettleWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(TokenizedRedeemTokenizedAssetSettleWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class TokenizedRedeemRequest
{
    /// <summary>
    /// Tokenized asset to redeem, e.g. AAPLB. Not a US-equity ticker — this is the on-chain tokenized asset
    /// identifier. Unknown asset returns -1102 (the message currently says the parameter was
    /// empty/malformed, but it was in fact sent — it is simply unknown). The target underlying ticker is
    /// looked up from this field via /market/tokenized-assets.
    /// </summary>
    public required string TokenizedAsset { get; init; }

    /// <summary>Quantity of the tokenized asset to redeem. Must be &gt; 0.</summary>
    public required string TokenizedAssetAmount { get; init; }

    /// <summary>
    /// Client order id for idempotency. Format ^[a-zA-Z0-9-_]{32,36}$. Auto-generated when omitted.
    /// </summary>
    public string? ClientOrderId { get; init; }

    /// <summary>
    /// Wallet the tokenized asset is deducted from on redeem. MAIN = Spot wallet, CARD = Funding wallet.
    /// Default CARD. If MAIN is sent while Spot wallet settlement is not enabled, the request is rejected
    /// as an illegal parameter.
    /// </summary>
    public TokenizedRedeemTokenizedAssetSettleWalletType? TokenizedAssetSettleWalletType { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StocksRestApi
{

    /// <summary>Bstocks Corporate Action Records (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query the asset balance changes caused by corporate actions (for example stock splits and cash
    /// dividends) on the caller's account. Cursor-style pagination — supply the nextTime and nextId from
    /// the previous page's response as lastTime and lastId to fetch the next page. Records are returned in
    /// descending order of modification time. This endpoint is equivalent to
    /// /sapi/v1/equity/corp-action/history.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<BstocksCorporateActionRecordsResponse>> BstocksCorporateActionRecordsAsync(BstocksCorporateActionRecordsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/bstocks/corp-action/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<BstocksCorporateActionRecordsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("limit", request.Limit);
        r.Query("lastTime", request.LastTime);
        r.Query("lastId", request.LastId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.BstocksCorporateActionRecordsResponse, cancellationToken);
    }

    /// <summary>Corporate Action Records (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query the asset balance changes caused by corporate actions (for example stock splits and cash
    /// dividends) on the caller's account. Cursor-style pagination — supply the nextTime and nextId from
    /// the previous page's response as lastTime and lastId to fetch the next page. Records are returned in
    /// descending order of modification time. This endpoint is equivalent to
    /// /sapi/v1/bstocks/corp-action/history.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CorporateActionRecordsResponse>> CorporateActionRecordsAsync(CorporateActionRecordsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/corp-action/history", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CorporateActionRecordsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("limit", request.Limit);
        r.Query("lastTime", request.LastTime);
        r.Query("lastId", request.LastId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.CorporateActionRecordsResponse, cancellationToken);
    }

    /// <summary>Tokenized Convert History (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Paged history of mint / redeem conversions for the caller. Cursor-style pagination — supply the
    /// nextLastId from the previous page's response to fetch the next page.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TokenizedConvertHistoryResponse>> TokenizedConvertHistoryAsync(TokenizedConvertHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/tokenized/history", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("lastId", request.LastId);
        r.Query("size", request.Size);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.TokenizedConvertHistoryResponse, cancellationToken);
    }

    /// <summary>Tokenized Convert Status (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// Query the current status of a single mint / redeem request by its issuerRequestId. Returns an empty
    /// object when no record matches (caller's ID scope only).
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TokenizedConvertStatusResponse>> TokenizedConvertStatusAsync(TokenizedConvertStatusRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/equity/tokenized/convert-status", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TokenizedConvertStatusResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("issuerRequestId", request.IssuerRequestId);
        r.Query("convertType", request.ConvertType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.TokenizedConvertStatusResponse, cancellationToken);
    }

    /// <summary>Tokenized Mint (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Mint a tokenized asset from an underlying equity holding. The caller's underlying equity (e.g. AAPL)
    /// is burned (or locked), and the corresponding tokenized asset (e.g. AAPLB) is credited. The tokenized
    /// asset is resolved server-side from underlyingAsset; callers only provide the underlying ticker and
    /// quantity. Mint is asynchronous: the endpoint returns an issuerRequestId immediately with a transient
    /// status; poll /tokenized/convert-status to observe the terminal state, or inspect /tokenized/history
    /// for the full record. Rate limit: 50 requests / min (UID).
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TokenizedMintResponse>> TokenizedMintAsync(TokenizedMintRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/tokenized/mint", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TokenizedMintResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlyingAsset", request.UnderlyingAsset);
        r.Query("underlyingAssetAmount", request.UnderlyingAssetAmount);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("tokenizedAssetSettleWalletType", request.TokenizedAssetSettleWalletType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.TokenizedMintResponse, cancellationToken);
    }

    /// <summary>Tokenized Redeem (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Redeem a tokenized asset back into the underlying equity. The caller's tokenized asset (e.g. AAPLB)
    /// is burned, and the corresponding underlying equity (e.g. AAPL) is released. The underlying asset is
    /// resolved server-side from tokenizedAsset; callers only provide the tokenized asset and quantity.
    /// Redeem is asynchronous: the endpoint returns an issuerRequestId immediately with a transient status;
    /// poll /tokenized/convert-status to observe the terminal state, or inspect /tokenized/history for the
    /// full record. Rate limit: 200 requests / min (UID).
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TokenizedRedeemResponse>> TokenizedRedeemAsync(TokenizedRedeemRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/tokenized/redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<TokenizedRedeemResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("tokenizedAsset", request.TokenizedAsset);
        r.Query("tokenizedAssetAmount", request.TokenizedAssetAmount);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("tokenizedAssetSettleWalletType", request.TokenizedAssetSettleWalletType);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.TokenizedRedeemResponse, cancellationToken);
    }
}
