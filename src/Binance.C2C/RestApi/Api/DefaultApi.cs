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

namespace Binance.C2C.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<GetC2CTradeHistoryTradeType>))]
public readonly struct GetC2CTradeHistoryTradeType : IExtensibleValue<GetC2CTradeHistoryTradeType>, IEquatable<GetC2CTradeHistoryTradeType>
{
    private readonly string? _value;

    public GetC2CTradeHistoryTradeType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetC2CTradeHistoryTradeType Buy { get; } = new("BUY");

    public static GetC2CTradeHistoryTradeType Sell { get; } = new("SELL");

    static GetC2CTradeHistoryTradeType IExtensibleValue<GetC2CTradeHistoryTradeType>.Create(string value) => new(value);

    public static bool operator ==(GetC2CTradeHistoryTradeType left, GetC2CTradeHistoryTradeType right) => left.Equals(right);

    public static bool operator !=(GetC2CTradeHistoryTradeType left, GetC2CTradeHistoryTradeType right) => !left.Equals(right);

    public static implicit operator GetC2CTradeHistoryTradeType(string value) => new(value);

    public static GetC2CTradeHistoryTradeType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetC2CTradeHistoryTradeType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetC2CTradeHistoryTradeType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetC2CTradeHistoryRequest
{
    /// <summary>Trade side filter</summary>
    public GetC2CTradeHistoryTradeType? TradeType { get; init; }

    public long? StartTimestamp { get; init; }

    public long? EndTimestamp { get; init; }

    /// <summary>Page number</summary>
    public long? Page { get; init; }

    /// <summary>Number of records per page</summary>
    public long? Rows { get; init; }
}

public sealed partial class C2CRestApi
{

    /// <summary>Get C2C Trade History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get C2C (also known as P2P) trade history, including both buy and sell orders.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- The max interval between startTimestamp and endTimestamp is 30 days.</para>
    /// <para>- If startTimestamp and endTimestamp are not sent, the recent 30 days' data is returned.</para>
    /// <para>
    /// - You can only view data from the past 6 months. For all C2C orders, check
    /// https://c2c.binance.com/en/fiatOrder.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetC2CTradeHistoryResponse>> GetC2CTradeHistoryAsync(GetC2CTradeHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/c2c/orderMatch/listUserOrderHistory", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("tradeType", request.TradeType);
        r.Query("startTimestamp", request.StartTimestamp);
        r.Query("endTimestamp", request.EndTimestamp);
        r.Query("page", request.Page);
        r.Query("rows", request.Rows);
        return _client.SendAsync(r, C2CRestApiJson.Default.GetC2CTradeHistoryResponse, cancellationToken);
    }
}
