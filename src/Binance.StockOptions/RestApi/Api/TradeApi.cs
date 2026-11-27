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

namespace Binance.StockOptions.RestApi;

public sealed class CancelAllOptionOrdersRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelOptionOrderRequest
{
    /// <summary>Option order ID.</summary>
    public required string OrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOptionOrderSide>))]
public readonly struct PlaceOptionOrderSide : IExtensibleValue<PlaceOptionOrderSide>, IEquatable<PlaceOptionOrderSide>
{
    private readonly string? _value;

    public PlaceOptionOrderSide(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOptionOrderSide Buy { get; } = new("BUY");

    public static PlaceOptionOrderSide Sell { get; } = new("SELL");

    static PlaceOptionOrderSide IExtensibleValue<PlaceOptionOrderSide>.Create(string value) => new(value);

    public static bool operator ==(PlaceOptionOrderSide left, PlaceOptionOrderSide right) => left.Equals(right);

    public static bool operator !=(PlaceOptionOrderSide left, PlaceOptionOrderSide right) => !left.Equals(right);

    public static implicit operator PlaceOptionOrderSide(string value) => new(value);

    public static PlaceOptionOrderSide FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOptionOrderSide other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOptionOrderSide other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOptionOrderPositionIntent>))]
public readonly struct PlaceOptionOrderPositionIntent : IExtensibleValue<PlaceOptionOrderPositionIntent>, IEquatable<PlaceOptionOrderPositionIntent>
{
    private readonly string? _value;

    public PlaceOptionOrderPositionIntent(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOptionOrderPositionIntent BuyToOpen { get; } = new("BUY_TO_OPEN");

    public static PlaceOptionOrderPositionIntent SellToClose { get; } = new("SELL_TO_CLOSE");

    public static PlaceOptionOrderPositionIntent SellToOpen { get; } = new("SELL_TO_OPEN");

    public static PlaceOptionOrderPositionIntent BuyToClose { get; } = new("BUY_TO_CLOSE");

    static PlaceOptionOrderPositionIntent IExtensibleValue<PlaceOptionOrderPositionIntent>.Create(string value) => new(value);

    public static bool operator ==(PlaceOptionOrderPositionIntent left, PlaceOptionOrderPositionIntent right) => left.Equals(right);

    public static bool operator !=(PlaceOptionOrderPositionIntent left, PlaceOptionOrderPositionIntent right) => !left.Equals(right);

    public static implicit operator PlaceOptionOrderPositionIntent(string value) => new(value);

    public static PlaceOptionOrderPositionIntent FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOptionOrderPositionIntent other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOptionOrderPositionIntent other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOptionOrderTimeInForce>))]
public readonly struct PlaceOptionOrderTimeInForce : IExtensibleValue<PlaceOptionOrderTimeInForce>, IEquatable<PlaceOptionOrderTimeInForce>
{
    private readonly string? _value;

    public PlaceOptionOrderTimeInForce(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOptionOrderTimeInForce Day { get; } = new("DAY");

    static PlaceOptionOrderTimeInForce IExtensibleValue<PlaceOptionOrderTimeInForce>.Create(string value) => new(value);

    public static bool operator ==(PlaceOptionOrderTimeInForce left, PlaceOptionOrderTimeInForce right) => left.Equals(right);

    public static bool operator !=(PlaceOptionOrderTimeInForce left, PlaceOptionOrderTimeInForce right) => !left.Equals(right);

    public static implicit operator PlaceOptionOrderTimeInForce(string value) => new(value);

    public static PlaceOptionOrderTimeInForce FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOptionOrderTimeInForce other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOptionOrderTimeInForce other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

[JsonConverter(typeof(ExtensibleValueConverter<PlaceOptionOrderWalletType>))]
public readonly struct PlaceOptionOrderWalletType : IExtensibleValue<PlaceOptionOrderWalletType>, IEquatable<PlaceOptionOrderWalletType>
{
    private readonly string? _value;

    public PlaceOptionOrderWalletType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static PlaceOptionOrderWalletType Card { get; } = new("CARD");

    public static PlaceOptionOrderWalletType Main { get; } = new("MAIN");

    static PlaceOptionOrderWalletType IExtensibleValue<PlaceOptionOrderWalletType>.Create(string value) => new(value);

    public static bool operator ==(PlaceOptionOrderWalletType left, PlaceOptionOrderWalletType right) => left.Equals(right);

    public static bool operator !=(PlaceOptionOrderWalletType left, PlaceOptionOrderWalletType right) => !left.Equals(right);

    public static implicit operator PlaceOptionOrderWalletType(string value) => new(value);

    public static PlaceOptionOrderWalletType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is PlaceOptionOrderWalletType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(PlaceOptionOrderWalletType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class PlaceOptionOrderRequest
{
    /// <summary>OCC contract symbol.</summary>
    public required string Symbol { get; init; }

    /// <summary>BUY / SELL.</summary>
    public required PlaceOptionOrderSide Side { get; init; }

    /// <summary>Number of contracts. Must be a whole number, minimum 1.</summary>
    public required string Quantity { get; init; }

    /// <summary>
    /// Limit price (premium) per share, minimum 0.01, must be a multiple of tickSize. For a put SELL order
    /// it cannot exceed the strike price (497438).
    /// </summary>
    public required string Price { get; init; }

    /// <summary>Quote asset. Only USDC (default) is supported; other values return 497104.</summary>
    public string? QuoteAsset { get; init; }

    /// <summary>
    /// May be omitted and derived from side (BUY → BUY_TO_OPEN, SELL → SELL_TO_CLOSE); always pass it for
    /// the short side (SELL_TO_OPEN / BUY_TO_CLOSE). Must match side when passed.
    /// </summary>
    public PlaceOptionOrderPositionIntent? PositionIntent { get; init; }

    /// <summary>Only DAY (default) is supported. Other values return a parameter error.</summary>
    public PlaceOptionOrderTimeInForce? TimeInForce { get; init; }

    /// <summary>Payment wallet: CARD (default) / MAIN.</summary>
    public PlaceOptionOrderWalletType? WalletType { get; init; }

    /// <summary>
    /// Client order ID. Format ^[a-zA-Z0-9-_]{32,36}$. Generated by the server when omitted.
    /// </summary>
    public string? ClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SubmitOptionExerciseRequest
{
    /// <summary>OCC contract symbol to exercise.</summary>
    public required string Symbol { get; init; }

    /// <summary>Number of contracts to exercise. Whole number, minimum 1, up to availableQty.</summary>
    public required string Quantity { get; init; }

    /// <summary>Quote asset. Only USDC (default) is supported; other values return 497104.</summary>
    public string? QuoteAsset { get; init; }

    /// <summary>Client ID. Format ^[a-zA-Z0-9-_]{32,36}$. Generated by the server when omitted.</summary>
    public string? ClientOrderId { get; init; }

    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StockOptionsRestApi
{

    /// <summary>Cancel All Option Orders (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel all of the caller's open orders.</para>
    /// <para>
    /// This also cancels open stock orders. Cancel-all is account-level at the broker and does not
    /// distinguish asset classes; it is the same operation as /sapi/v1/equity/order/cancel-all.
    /// </para>
    /// <para>
    /// To cancel option orders only, fetch them with Current Open Option Orders and cancel each one with
    /// Cancel Option Order.
    /// </para>
    /// <para>Errors on this endpoint use the Stocks Trading error codes (486xxx). See Stocks Trading Error Code.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelAllOptionOrdersResponse>> CancelAllOptionOrdersAsync(CancelAllOptionOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/option/order/cancel-all", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.CancelAllOptionOrdersResponse, cancellationToken);
    }

    /// <summary>Cancel Option Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel an open order by orderId.</para>
    /// <para>
    /// Cancellation applies to the caller's own brokerage account and is not restricted by asset class:
    /// passing the orderId of a stock order also cancels it, and /sapi/v1/equity/order/cancel can likewise
    /// cancel option orders. Only the caller's own orders can be canceled.
    /// </para>
    /// <para>Errors on this endpoint use the Stocks Trading error codes (486xxx). See Stocks Trading Error Code.</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CancelOptionOrderResponse>> CancelOptionOrderAsync(CancelOptionOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/option/order/cancel", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CancelOptionOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("orderId", request.OrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.CancelOptionOrderResponse, cancellationToken);
    }

    /// <summary>Place Option Order (TRADE)</summary>
    /// <remarks>
    /// <para>Place an option limit order.</para>
    /// <para>
    /// The server calculates the amount to lock based on positionIntent and the contract type: buy to open
    /// locks the premium plus fees; sell to open locks the underlying shares for a covered call, or the
    /// strike-equivalent cash for a cash-secured put. Fees are calculated by the server; callers do not
    /// pass payment details.
    /// </para>
    /// <para>
    /// positionIntent: may be omitted, in which case it is derived from side: BUY → BUY_TO_OPEN, SELL →
    /// SELL_TO_CLOSE. The derivation is unreliable in two cases, and an order without positionIntent is
    /// rejected (parameter error): a BUY while you hold a short position in the contract (it may be meant
    /// as BUY_TO_CLOSE), and a SELL while you hold no long position in the contract (it can only be
    /// SELL_TO_OPEN). Therefore always pass it for the short side (SELL_TO_OPEN / BUY_TO_CLOSE). When
    /// passed, it must match side (BUY_* with BUY, SELL_* with SELL), otherwise the order is rejected.
    /// </para>
    /// <para>
    /// Only LIMIT orders with timeInForce = DAY are supported, and quantity must be a whole number of
    /// contracts.
    /// </para>
    /// <para>
    /// Resubmitting with the same clientOrderId is idempotent: if the original order was accepted or is
    /// still processing, the original order is returned (S / P); if the original order failed, 497401 is
    /// returned.
    /// </para>
    /// <para>
    /// If the request returns 497001, 497301 or a broker-rejection error code after the order has already
    /// been submitted to the broker, the order may still be processing. Retry with the same clientOrderId
    /// (a replay then returns P) or query Option Order Detail by clientOrderId for the final status. Do not
    /// retry with a new clientOrderId.
    /// </para>
    /// <para>Rate limit: 200 requests / min (UID).</para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<PlaceOptionOrderResponse>> PlaceOptionOrderAsync(PlaceOptionOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/option/order/place", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<PlaceOptionOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("side", request.Side);
        r.Query("quantity", request.Quantity);
        r.Query("price", request.Price);
        r.Query("quoteAsset", request.QuoteAsset);
        r.Query("positionIntent", request.PositionIntent);
        r.Query("timeInForce", request.TimeInForce);
        r.Query("walletType", request.WalletType);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.PlaceOptionOrderResponse, cancellationToken);
    }

    /// <summary>Submit Option Exercise (TRADE)</summary>
    /// <remarks>
    /// <para>Submit an exercise request for a long option position.</para>
    /// <para>Requires the TRADE permission, because exercising changes positions and balances.</para>
    /// <para>
    /// Exercise is asynchronous. The request returns PROCESSING; delivery is handled by the broker. Poll
    /// Option Exercise Detail for the final status.
    /// </para>
    /// <para>quantity cannot exceed availableQty from Exercisable Options.</para>
    /// <para>
    /// Resubmitting with the same clientOrderId is idempotent: if the original exercise was accepted or is
    /// still processing, it is returned with its current status; if it failed, 497401 is returned. If the
    /// request returns 497001, 497301 or a broker-rejection error code, the exercise may still be
    /// processing: retry with the same clientOrderId or query Option Exercise Detail by clientOrderId. Do
    /// not resubmit with a new clientOrderId.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubmitOptionExerciseResponse>> SubmitOptionExerciseAsync(SubmitOptionExerciseRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/option/exercise/submit", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubmitOptionExerciseResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("symbol", request.Symbol);
        r.Query("quantity", request.Quantity);
        r.Query("quoteAsset", request.QuoteAsset);
        r.Query("clientOrderId", request.ClientOrderId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StockOptionsRestApiJson.Default.SubmitOptionExerciseResponse, cancellationToken);
    }
}
