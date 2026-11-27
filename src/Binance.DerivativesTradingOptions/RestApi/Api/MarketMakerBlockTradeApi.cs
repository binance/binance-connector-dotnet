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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class AcceptBlockTradeOrderRequest
{
    public required string BlockOrderMatchingKey { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class AccountBlockTradeListRequest
{
    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>Underlying asset.</summary>
    public string? Underlying { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class CancelBlockTradeOrderRequest
{
    /// <summary>Block trade matching key.</summary>
    public required string BlockOrderMatchingKey { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class ExtendBlockTradeOrderRequest
{
    public required string BlockOrderMatchingKey { get; init; }

    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<NewBlockTradeOrderLiquidity>))]
public readonly struct NewBlockTradeOrderLiquidity : IExtensibleValue<NewBlockTradeOrderLiquidity>, IEquatable<NewBlockTradeOrderLiquidity>
{
    private readonly string? _value;

    public NewBlockTradeOrderLiquidity(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static NewBlockTradeOrderLiquidity Maker { get; } = new("MAKER");

    public static NewBlockTradeOrderLiquidity Taker { get; } = new("TAKER");

    static NewBlockTradeOrderLiquidity IExtensibleValue<NewBlockTradeOrderLiquidity>.Create(string value) => new(value);

    public static bool operator ==(NewBlockTradeOrderLiquidity left, NewBlockTradeOrderLiquidity right) => left.Equals(right);

    public static bool operator !=(NewBlockTradeOrderLiquidity left, NewBlockTradeOrderLiquidity right) => !left.Equals(right);

    public static implicit operator NewBlockTradeOrderLiquidity(string value) => new(value);

    public static NewBlockTradeOrderLiquidity FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NewBlockTradeOrderLiquidity other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(NewBlockTradeOrderLiquidity other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class NewBlockTradeOrderRequest
{
    public required NewBlockTradeOrderLiquidity Liquidity { get; init; }

    /// <summary>
    /// Max 1 (only single leg supported), list of legs parameters in JSON; example:
    /// eapi/v1/block/order/create?orders=[{"symbol":"BTC-210115-35000-C",
    /// "price":"100","quantity":"0.0002","side":"BUY","type":"LIMIT"}]
    /// </summary>
    public required List<NewBlockTradeOrderLegsParameterInner> Legs { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryBlockTradeDetailsRequest
{
    /// <summary>Block trade matching key.</summary>
    public required string BlockOrderMatchingKey { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class QueryBlockTradeOrderRequest
{
    /// <summary>
    /// If specified, returns the specific block trade associated with the blockOrderMatchingKey
    /// </summary>
    public string? BlockOrderMatchingKey { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>Underlying asset.</summary>
    public string? Underlying { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingOptionsRestApi
{

    /// <summary>Accept Block Trade Order (TRADE)</summary>
    /// <remarks>
    /// <para>Accept a block trade order</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AcceptBlockTradeOrderResponse>> AcceptBlockTradeOrderAsync(AcceptBlockTradeOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/block/order/execute", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AcceptBlockTradeOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("blockOrderMatchingKey", request.BlockOrderMatchingKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.AcceptBlockTradeOrderResponse, cancellationToken);
    }

    /// <summary>Account Block Trade List (USER_DATA)</summary>
    /// <remarks>
    /// <para>Gets block trades for a specific account.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AccountBlockTradeListResponseInner>>> AccountBlockTradeListAsync(AccountBlockTradeListRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/block/user-trades", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("endTime", request.EndTime);
        r.Query("startTime", request.StartTime);
        r.Query("underlying", request.Underlying);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListAccountBlockTradeListResponseInner, cancellationToken);
    }

    /// <summary>Cancel Block Trade Order (TRADE)</summary>
    /// <remarks>
    /// <para>Cancel a block trade order.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> CancelBlockTradeOrderAsync(CancelBlockTradeOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("DELETE", "/eapi/v1/block/order/create", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<JsonElement>>(new ArgumentNullException(nameof(request)));
        r.Query("blockOrderMatchingKey", request.BlockOrderMatchingKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Extend Block Trade Order (TRADE)</summary>
    /// <remarks>
    /// <para>Extends a block trade expire time by 30 mins from the current time.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExtendBlockTradeOrderResponse>> ExtendBlockTradeOrderAsync(ExtendBlockTradeOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("PUT", "/eapi/v1/block/order/create", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ExtendBlockTradeOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("blockOrderMatchingKey", request.BlockOrderMatchingKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ExtendBlockTradeOrderResponse, cancellationToken);
    }

    /// <summary>New Block Trade Order (TRADE)</summary>
    /// <remarks>
    /// <para>Send in a new block trade order.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<NewBlockTradeOrderResponse>> NewBlockTradeOrderAsync(NewBlockTradeOrderRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/block/order/create", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<NewBlockTradeOrderResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("liquidity", request.Liquidity);
        r.Query("legs", Wire.Json(request.Legs, DerivativesTradingOptionsRestApiJson.Default.ListNewBlockTradeOrderLegsParameterInner));
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.NewBlockTradeOrderResponse, cancellationToken);
    }

    /// <summary>Query Block Trade Details (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query block trade details; returns block trade details from counterparty's perspective.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryBlockTradeDetailsResponse>> QueryBlockTradeDetailsAsync(QueryBlockTradeDetailsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/block/order/execute", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryBlockTradeDetailsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("blockOrderMatchingKey", request.BlockOrderMatchingKey);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.QueryBlockTradeDetailsResponse, cancellationToken);
    }

    /// <summary>Query Block Trade Order (TRADE)</summary>
    /// <remarks>
    /// <para>Check block trade order status.</para>
    /// <para>Weight(IP): 5</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryBlockTradeOrderResponseInner>>> QueryBlockTradeOrderAsync(QueryBlockTradeOrderRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/block/order/orders", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("blockOrderMatchingKey", request.BlockOrderMatchingKey);
        r.Query("endTime", request.EndTime);
        r.Query("startTime", request.StartTime);
        r.Query("underlying", request.Underlying);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListQueryBlockTradeOrderResponseInner, cancellationToken);
    }
}
