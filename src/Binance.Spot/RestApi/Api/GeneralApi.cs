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

namespace Binance.Spot.RestApi;

[JsonConverter(typeof(ExtensibleValueConverter<ExchangeInfoPermissions>))]
public readonly struct ExchangeInfoPermissions : IExtensibleValue<ExchangeInfoPermissions>, IEquatable<ExchangeInfoPermissions>
{
    private readonly string? _value;

    public ExchangeInfoPermissions(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static ExchangeInfoPermissions Spot { get; } = new("SPOT");

    public static ExchangeInfoPermissions Margin { get; } = new("MARGIN");

    public static ExchangeInfoPermissions Leveraged { get; } = new("LEVERAGED");

    public static ExchangeInfoPermissions TrdGrp002 { get; } = new("TRD_GRP_002");

    public static ExchangeInfoPermissions TrdGrp003 { get; } = new("TRD_GRP_003");

    public static ExchangeInfoPermissions TrdGrp004 { get; } = new("TRD_GRP_004");

    public static ExchangeInfoPermissions TrdGrp005 { get; } = new("TRD_GRP_005");

    public static ExchangeInfoPermissions TrdGrp006 { get; } = new("TRD_GRP_006");

    public static ExchangeInfoPermissions TrdGrp007 { get; } = new("TRD_GRP_007");

    public static ExchangeInfoPermissions TrdGrp008 { get; } = new("TRD_GRP_008");

    public static ExchangeInfoPermissions TrdGrp009 { get; } = new("TRD_GRP_009");

    public static ExchangeInfoPermissions TrdGrp010 { get; } = new("TRD_GRP_010");

    public static ExchangeInfoPermissions TrdGrp011 { get; } = new("TRD_GRP_011");

    public static ExchangeInfoPermissions TrdGrp012 { get; } = new("TRD_GRP_012");

    public static ExchangeInfoPermissions TrdGrp013 { get; } = new("TRD_GRP_013");

    public static ExchangeInfoPermissions TrdGrp014 { get; } = new("TRD_GRP_014");

    public static ExchangeInfoPermissions TrdGrp015 { get; } = new("TRD_GRP_015");

    public static ExchangeInfoPermissions TrdGrp016 { get; } = new("TRD_GRP_016");

    public static ExchangeInfoPermissions TrdGrp017 { get; } = new("TRD_GRP_017");

    public static ExchangeInfoPermissions TrdGrp018 { get; } = new("TRD_GRP_018");

    public static ExchangeInfoPermissions TrdGrp019 { get; } = new("TRD_GRP_019");

    public static ExchangeInfoPermissions TrdGrp020 { get; } = new("TRD_GRP_020");

    public static ExchangeInfoPermissions TrdGrp021 { get; } = new("TRD_GRP_021");

    public static ExchangeInfoPermissions TrdGrp022 { get; } = new("TRD_GRP_022");

    public static ExchangeInfoPermissions TrdGrp023 { get; } = new("TRD_GRP_023");

    public static ExchangeInfoPermissions TrdGrp024 { get; } = new("TRD_GRP_024");

    public static ExchangeInfoPermissions TrdGrp025 { get; } = new("TRD_GRP_025");

    static ExchangeInfoPermissions IExtensibleValue<ExchangeInfoPermissions>.Create(string value) => new(value);

    public static bool operator ==(ExchangeInfoPermissions left, ExchangeInfoPermissions right) => left.Equals(right);

    public static bool operator !=(ExchangeInfoPermissions left, ExchangeInfoPermissions right) => !left.Equals(right);

    public static implicit operator ExchangeInfoPermissions(string value) => new(value);

    public static ExchangeInfoPermissions FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ExchangeInfoPermissions other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ExchangeInfoPermissions other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

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
    /// <summary>Example: curl -X GET "https://api.binance.com/api/v3/exchangeInfo?symbol=BNBBTC"</summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Examples: curl -X GET
    /// "https://api.binance.com/api/v3/exchangeInfo?symbols=%5B%22BNBBTC%22,%22BTCUSDT%22%5D" or curl -g -X
    /// GET 'https://api.binance.com/api/v3/exchangeInfo?symbols=["BTCUSDT","BNBBTC"]'
    /// </summary>
    public List<string>? Symbols { get; init; }

    /// <summary>
    /// Examples: curl -X GET "https://api.binance.com/api/v3/exchangeInfo?permissions=SPOT" curl -X GET
    /// "https://api.binance.com/api/v3/exchangeInfo?permissions=%5B%22MARGIN%22%2C%22LEVERAGED%22%5D" or
    /// curl -g -X GET 'https://api.binance.com/api/v3/exchangeInfo?permissions=["MARGIN","LEVERAGED"]'
    /// </summary>
    public List<ExchangeInfoPermissions>? Permissions { get; init; }

    /// <summary>Controls whether the content of the permissionSets field is populated or not.</summary>
    public bool? ShowPermissionSets { get; init; }

    /// <summary>
    /// Filters for symbols that have this tradingStatus. Cannot be used in combination with symbols or
    /// symbol.
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
    /// <summary>Query for specified symbol.</summary>
    public string? Symbol { get; init; }

    /// <summary>Query for multiple symbols.</summary>
    public List<string>? Symbols { get; init; }

    /// <summary>Query for all symbols with the specified status.</summary>
    public ExecutionRulesSymbolStatus? SymbolStatus { get; init; }
}

public sealed partial class SpotRestApi
{

    /// <summary>Exchange information</summary>
    /// <remarks>
    /// <para>Current exchange trading rules and symbol information</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// <para>Notes:</para>
    /// <para>
    /// - If the value provided to symbol or symbols do not exist, the endpoint will throw an error saying
    /// the symbol is invalid.
    /// </para>
    /// <para>- All parameters are optional.</para>
    /// <para>
    /// - permissions can support single or multiple values (e.g. SPOT, ["MARGIN","LEVERAGED"]). This cannot
    /// be used in combination with symbol or symbols.
    /// </para>
    /// <para>
    /// - If permissions parameter not provided, all symbols that have either SPOT, MARGIN, or LEVERAGED
    /// permission will be exposed.
    /// </para>
    /// <para>
    /// - To display symbols with any permission you need to specify them explicitly in permissions: (e.g.
    /// ["SPOT","MARGIN",...].). See Account and Symbol Permissions for the full list.
    /// </para>
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
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExchangeInfoResponse>> ExchangeInfoAsync(ExchangeInfoRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/exchangeInfo", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("permissions", request.Permissions);
        r.Query("showPermissionSets", request.ShowPermissionSets);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.ExchangeInfoResponse, cancellationToken);
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
    /// <para>Note:: No combination of multiple parameters is allowed.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ExecutionRulesResponse>> ExecutionRulesAsync(ExecutionRulesRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/executionRules", signed: false, hasTimeUnit: true);
        request ??= new();
        r.Query("symbol", request.Symbol);
        r.Query("symbols", request.Symbols);
        r.Query("symbolStatus", request.SymbolStatus);
        return _client.SendAsync(r, SpotRestApiJson.Default.ExecutionRulesResponse, cancellationToken);
    }

    /// <summary>Test connectivity</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<JsonElement>> PingAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/ping", signed: false, hasTimeUnit: true);
        return _client.SendAsync(r, SpotRestApiJson.Default.JsonElement, cancellationToken);
    }

    /// <summary>Check server time</summary>
    /// <remarks>
    /// <para>Test connectivity to the Rest API and get the current server time.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: NONE</para>
    /// <para>Notes: Data Source: Memory</para>
    /// </remarks>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<TimeResponse>> TimeAsync(CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/api/v3/time", signed: false, hasTimeUnit: true);
        return _client.SendAsync(r, SpotRestApiJson.Default.TimeResponse, cancellationToken);
    }
}
