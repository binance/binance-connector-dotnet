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

namespace Binance.MarginTrading.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<GetCrossMarginTransferHistoryType>))]
public readonly struct GetCrossMarginTransferHistoryType : IExtensibleValue<GetCrossMarginTransferHistoryType>, IEquatable<GetCrossMarginTransferHistoryType>
{
    private readonly string? _value;

    public GetCrossMarginTransferHistoryType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetCrossMarginTransferHistoryType RollIn { get; } = new("ROLL_IN");

    public static GetCrossMarginTransferHistoryType RollOut { get; } = new("ROLL_OUT");

    static GetCrossMarginTransferHistoryType IExtensibleValue<GetCrossMarginTransferHistoryType>.Create(string value) => new(value);

    public static bool operator ==(GetCrossMarginTransferHistoryType left, GetCrossMarginTransferHistoryType right) => left.Equals(right);

    public static bool operator !=(GetCrossMarginTransferHistoryType left, GetCrossMarginTransferHistoryType right) => !left.Equals(right);

    public static implicit operator GetCrossMarginTransferHistoryType(string value) => new(value);

    public static GetCrossMarginTransferHistoryType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetCrossMarginTransferHistoryType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetCrossMarginTransferHistoryType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetCrossMarginTransferHistoryRequest
{
    public string? Asset { get; init; }

    public GetCrossMarginTransferHistoryType? Type { get; init; }

    public long? StartTime { get; init; }

    public long? EndTime { get; init; }

    public long? Current { get; init; }

    public long? Size { get; init; }

    public string? IsolatedSymbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class QueryMaxTransferOutAmountRequest
{
    public required string Asset { get; init; }

    public string? IsolatedSymbol { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class MarginTradingRestApi
{

    /// <summary>Get Cross Margin Transfer History (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Cross Margin Transfer History</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Response in descending order</para>
    /// <para>- The max interval between startTime and endTime is 30 days.</para>
    /// <para>- Returns data for last 7 days by default</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetCrossMarginTransferHistoryResponse>> GetCrossMarginTransferHistoryAsync(GetCrossMarginTransferHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/transfer", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("asset", request.Asset);
        r.Query("type", request.Type);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("current", request.Current);
        r.Query("size", request.Size);
        r.Query("isolatedSymbol", request.IsolatedSymbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.GetCrossMarginTransferHistoryResponse, cancellationToken);
    }

    /// <summary>Query Max Transfer-Out Amount (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query Max Transfer-Out Amount</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- If isolatedSymbol is not sent, crossed margin data will be sent.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<QueryMaxTransferOutAmountResponse>> QueryMaxTransferOutAmountAsync(QueryMaxTransferOutAmountRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/margin/maxTransferable", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<QueryMaxTransferOutAmountResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("asset", request.Asset);
        r.Query("isolatedSymbol", request.IsolatedSymbol);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, MarginTradingRestApiJson.Default.QueryMaxTransferOutAmountResponse, cancellationToken);
    }
}
