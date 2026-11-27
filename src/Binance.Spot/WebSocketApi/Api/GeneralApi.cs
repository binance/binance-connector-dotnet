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

namespace Binance.Spot.WebSocketApi;

[JsonConverter(typeof(ExtensibleValueConverter<ExchangeInfoSymbolStatus>))]
public readonly struct ExchangeInfoSymbolStatus : IExtensibleValue<ExchangeInfoSymbolStatus>, IEquatable<ExchangeInfoSymbolStatus>
{
    private readonly string? _value;

    public ExchangeInfoSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ExchangeInfoSymbolStatus Trading { get; } = new("TRADING");

    public static ExchangeInfoSymbolStatus Halt { get; } = new("HALT");

    public static ExchangeInfoSymbolStatus Break { get; } = new("BREAK");

    public static ExchangeInfoSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static ExchangeInfoSymbolStatus IExtensibleValue<ExchangeInfoSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(ExchangeInfoSymbolStatus left, ExchangeInfoSymbolStatus right) => left.Equals(right);

    public static bool operator !=(ExchangeInfoSymbolStatus left, ExchangeInfoSymbolStatus right) => !left.Equals(right);

    public static implicit operator ExchangeInfoSymbolStatus(string value) => new(value);

    public static ExchangeInfoSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ExchangeInfoSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ExchangeInfoSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ExchangeInfoRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Describe a single symbol</summary>
    public string? Symbol { get; init; }

    /// <summary>Describe multiple symbols</summary>
    public List<string>? Symbols { get; init; }

    /// <summary>Filter symbols by permissions</summary>
    public List<string>? Permissions { get; init; }

    /// <summary>
    /// Controls whether the content of the permissionSets field is populated or not. Defaults to true.
    /// </summary>
    public bool? ShowPermissionSets { get; init; }

    /// <summary>
    /// Filters for symbols that have this tradingStatus. Valid values: TRADING, HALT, BREAK, CANCEL_ONLY.
    /// Cannot be used in combination with symbol or symbols.
    /// </summary>
    public ExchangeInfoSymbolStatus? SymbolStatus { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<ExecutionRulesSymbolStatus>))]
public readonly struct ExecutionRulesSymbolStatus : IExtensibleValue<ExecutionRulesSymbolStatus>, IEquatable<ExecutionRulesSymbolStatus>
{
    private readonly string? _value;

    public ExecutionRulesSymbolStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ExecutionRulesSymbolStatus Trading { get; } = new("TRADING");

    public static ExecutionRulesSymbolStatus Halt { get; } = new("HALT");

    public static ExecutionRulesSymbolStatus Break { get; } = new("BREAK");

    public static ExecutionRulesSymbolStatus CancelOnly { get; } = new("CANCEL_ONLY");

    static ExecutionRulesSymbolStatus IExtensibleValue<ExecutionRulesSymbolStatus>.Create(string value) => new(value);

    public static bool operator ==(ExecutionRulesSymbolStatus left, ExecutionRulesSymbolStatus right) => left.Equals(right);

    public static bool operator !=(ExecutionRulesSymbolStatus left, ExecutionRulesSymbolStatus right) => !left.Equals(right);

    public static implicit operator ExecutionRulesSymbolStatus(string value) => new(value);

    public static ExecutionRulesSymbolStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ExecutionRulesSymbolStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ExecutionRulesSymbolStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class ExecutionRulesRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }

    /// <summary>Query for specified symbol.</summary>
    public string? Symbol { get; init; }

    /// <summary>Query for multiple symbols.</summary>
    public List<string>? Symbols { get; init; }

    /// <summary>
    /// Query for all symbols with the specified status. Supported values: TRADING, HALT, BREAK, CANCEL_ONLY
    /// </summary>
    public ExecutionRulesSymbolStatus? SymbolStatus { get; init; }
}

public sealed class PingRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }
}

public sealed class TimeRequest
{
    /// <summary>Client-generated request identifier.</summary>
    public string? Id { get; init; }
}

public sealed partial class SpotWebSocketApiConnection
{

    /// <summary>Exchange information</summary>
    /// <remarks>
    /// <para>Query current exchange trading rules, rate limits, and symbol information.</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If the value provided to symbol or symbols do not exist, the endpoint will throw an error saying
    /// the symbol is invalid.
    /// </para>
    /// <para>- All parameters are optional.</para>
    /// <para>- Only one of symbol, symbols, permissions parameters can be specified.</para>
    /// <para>
    /// - Without parameters, exchangeInfo displays all symbols with ["SPOT", "MARGIN", "LEVERAGED"]
    /// permissions.
    /// </para>
    /// <para>
    /// - In order to list all active symbols on the exchange, you need to explicitly request all
    /// permissions.
    /// </para>
    /// <para>- permissions accepts either a list of permissions, or a single permission name. E.g. "SPOT".</para>
    /// <para>Examples of Symbol Permissions Interpretation from the Response:</para>
    /// <para>
    /// - [["A","B"]] means you may place an order if your account has either permission "A" or permission
    /// "B".
    /// </para>
    /// <para>- [["A"],["B"]] means you can place an order if your account has permission "A" and permission "B".</para>
    /// <para>
    /// - [["A"],["B","C"]] means you can place an order if your account has permission "A" and permission
    /// "B" or permission "C". (Inclusive or is applied here, not exclusive or, so your account may have
    /// both permission "B" and permission "C".)
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<ExchangeInfoResponse>> ExchangeInfoAsync(ExchangeInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("exchangeInfo", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("symbol", request.Symbol);
        r.Param("symbols", request.Symbols);
        r.Param("permissions", request.Permissions);
        r.Param("showPermissionSets", request.ShowPermissionSets);
        r.Param("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ExchangeInfoResponse, cancellationToken);
    }

    /// <summary>Query Execution Rules</summary>
    /// <remarks>
    /// <para>Query execution rules for symbols.</para>
    /// <para>Weight: Parameter | Weight</para>
    /// <para>symbol | 2</para>
    /// <para>symbols | 2 for each symbol, capped at a max of 40</para>
    /// <para>symbolStatus | 40</para>
    /// <para>None | 40</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// <para>Note: No combination of multiple parameters is allowed.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<ExecutionRulesResponseResult>> ExecutionRulesAsync(ExecutionRulesRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("executionRules", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("symbol", request.Symbol);
        r.Param("symbols", request.Symbols);
        r.Param("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.ExecutionRulesResponseResult, cancellationToken);
    }

    /// <summary>Test connectivity</summary>
    /// <remarks>
    /// <para>Test connectivity to the WebSocket API.</para>
    /// <para>
    /// Note: You can use regular WebSocket ping frames to test connectivity as well, WebSocket API will
    /// respond with pong frames as soon as possible. ping request along with time is a safe way to test
    /// request-response handling in your application.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<JsonElement>> PingAsync(PingRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("ping", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Check server time</summary>
    /// <remarks>
    /// <para>Test connectivity to the WebSocket API and get the current server time.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<TimeResponseResult>> TimeAsync(TimeRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("time", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        return _client.SendAsync(r, SpotWebSocketApiJson.Default.TimeResponseResult, cancellationToken);
    }
}
