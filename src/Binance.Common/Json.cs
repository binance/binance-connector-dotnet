//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Collections;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Binance.Common;

/// <summary>The kind of a rate limit.</summary>
[JsonConverter(typeof(RateLimitEnumConverter<RateLimitType>))]
public enum RateLimitType
{
    /// <summary>A value this version does not know.</summary>
    Unknown = 0,
    /// <summary><c>REQUEST_WEIGHT</c>.</summary>
    RequestWeight,
    /// <summary><c>ORDERS</c>.</summary>
    Orders,
    /// <summary><c>RAW_REQUESTS</c>.</summary>
    RawRequests,
}

/// <summary>The interval of a rate limit.</summary>
[JsonConverter(typeof(RateLimitEnumConverter<RateLimitInterval>))]
public enum RateLimitInterval
{
    /// <summary>A value this version does not know.</summary>
    Unknown = 0,
    /// <summary><c>SECOND</c>.</summary>
    Second,
    /// <summary><c>MINUTE</c>.</summary>
    Minute,
    /// <summary><c>HOUR</c>.</summary>
    Hour,
    /// <summary><c>DAY</c>.</summary>
    Day,
}

/// <summary>A rate limit counter of a REST response, from its <c>X-MBX-USED-WEIGHT-*</c> and <c>X-MBX-ORDER-COUNT-*</c> headers.</summary>
public sealed record RestApiRateLimit
{
    /// <summary>The kind of limit.</summary>
    public RateLimitType RateLimitType { get; init; }

    /// <summary>The interval, e.g. <see cref="RateLimitInterval.Minute"/>.</summary>
    public RateLimitInterval Interval { get; init; }

    /// <summary>Number of intervals.</summary>
    public int IntervalNum { get; init; }

    /// <summary>Current usage.</summary>
    public long Count { get; init; }

    /// <summary>Seconds to wait (<c>Retry-After</c>), when the limit was exceeded.</summary>
    public long? RetryAfter { get; init; }
}

/// <summary>A rate limit counter of a WebSocket API response (its <c>rateLimits</c>).</summary>
public sealed record WebSocketApiRateLimit
{
    /// <summary>The kind of limit.</summary>
    public RateLimitType RateLimitType { get; init; }

    /// <summary>The interval, e.g. <see cref="RateLimitInterval.Minute"/>.</summary>
    public RateLimitInterval Interval { get; init; }

    /// <summary>Number of intervals.</summary>
    public int IntervalNum { get; init; }

    /// <summary>The limit.</summary>
    public long Limit { get; init; }

    /// <summary>Current usage.</summary>
    public long Count { get; init; }
}

// SCREAMING_SNAKE_CASE names (REQUEST_WEIGHT, MINUTE); a value this version does not know is Unknown, so that a new kind of
// limit does not fail the response.
internal sealed class RateLimitEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    private static readonly Dictionary<string, T> ByName =
        Enum.GetValues<T>().ToDictionary(v => Name(v), v => v, StringComparer.OrdinalIgnoreCase);

    private static string Name(T value) =>
        string.Concat(value.ToString().Select((c, i) => i > 0 && char.IsUpper(c) ? "_" + c : c.ToString())).ToUpperInvariant();

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && ByName.TryGetValue(reader.GetString()!, out var value) ? value : default;

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => writer.WriteStringValue(Name(value));
}

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<RestApiRateLimit>))]
[JsonSerializable(typeof(List<WebSocketApiRateLimit>))]
[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(JsonElement))]
internal sealed partial class NativeJson : JsonSerializerContext;

/// <summary>A value that may have one of several types: the raw JSON, decoded on demand with <see cref="TryAs{T}"/> or <see cref="As{T}"/>.</summary>
public abstract class OneOf
{
    /// <summary>The raw JSON value.</summary>
    public JsonElement Json { get; set; }

    /// <summary>The serializer context of the product that holds the alternatives.</summary>
    protected abstract JsonSerializerContext Context { get; }

    /// <summary>The types the value can have.</summary>
    protected virtual IReadOnlyList<Type> Alternatives => [];

    /// <summary>The types the value can have.</summary>
    public IReadOnlyList<Type> AlternativeTypes => Alternatives;

    /// <summary>Decodes the value as <paramref name="type"/>, one of <see cref="AlternativeTypes"/>; null when it does not decode.</summary>
    /// <param name="type">The type.</param>
    public object? As(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        if (Context.GetTypeInfo(type) is not { } info) throw new InvalidOperationException($"{type} is not part of the serializer context");
        try { return JsonSerializer.Deserialize(Json, info); }
        catch (JsonException) { return null; }
    }

    /// <summary>
    /// Decodes the value as the alternative that holds all of it: among the alternatives that decode and have every field of the JSON, the
    /// one with the fewest fields. False when there is none.
    /// </summary>
    /// <param name="value">The decoded value.</param>
    public bool TryGetValue(out object? value)
    {
        value = null;
        var bestSize = int.MaxValue;
        foreach (var type in Alternatives)
        {
            if (Context.GetTypeInfo(type) is not { } info) continue;
            object? candidate;
            JsonElement back;
            try
            {
                candidate = JsonSerializer.Deserialize(Json, info);
                if (candidate is null) continue;
                back = JsonSerializer.SerializeToElement(candidate, info);
            }
            catch (JsonException)
            {
                continue;
            }
            if (!Holds(Json, back)) continue;
            var size = back.ValueKind == JsonValueKind.Object ? back.EnumerateObject().Count() : 0;
            if (size >= bestSize) continue;
            value = candidate;
            bestSize = size;
        }
        return value is not null;
    }

    private static bool Holds(JsonElement json, JsonElement decoded)
    {
        switch (json.ValueKind)
        {
            case JsonValueKind.Object:
                return decoded.ValueKind == JsonValueKind.Object && json.EnumerateObject().All(p => decoded.TryGetProperty(p.Name, out _));
            case JsonValueKind.Array:
                return decoded.ValueKind == JsonValueKind.Array && decoded.GetArrayLength() == json.GetArrayLength();
            default:
                return decoded.ValueKind != JsonValueKind.Object && decoded.ValueKind != JsonValueKind.Array;
        }
    }

    /// <summary>
    /// Decodes the value as <typeparamref name="T"/>, a model or a list; null when it is not a <typeparamref name="T"/>. For an alternative
    /// that is a number, a string or another value type, use <see cref="TryAs{T}"/>, which tells a failure from a decoded <c>0</c>.
    /// </summary>
    /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an alternative of this value.</exception>
    public T? As<T>() where T : class => TryAs<T>(out var value) ? value : null;

    /// <summary>Decodes the value as <typeparamref name="T"/>, any of the alternatives; false when it is not a <typeparamref name="T"/>.</summary>
    /// <param name="value">The decoded value; <c>default</c> when it is not a <typeparamref name="T"/>.</param>
    /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an alternative of this value.</exception>
    public bool TryAs<T>([System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out T value)
    {
        if (Context.GetTypeInfo(typeof(T)) is not JsonTypeInfo<T> info) throw new InvalidOperationException($"{typeof(T)} is not part of the serializer context");
        value = default;
        if (Json.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null) return false;
        try { value = Json.Deserialize(info); }
        catch (JsonException) { return false; }
        catch (InvalidOperationException) { return false; } // a JSON value of another kind for a primitive (e.g. an array for a long)
        return value is not null;
    }
}

/// <summary>Reads and writes a <see cref="OneOf"/> value as its raw JSON.</summary>
/// <typeparam name="T">The oneOf type.</typeparam>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public sealed class OneOfConverter<T> : JsonConverter<T> where T : OneOf, new()
{
    /// <inheritdoc/>
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        new() { Json = JsonElement.ParseValue(ref reader) };

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => value.Json.WriteTo(writer);
}

/// <summary>Builds the JSON of requests. Decimals are written as strings, so they stay exact.</summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public static class Wire
{
    /// <summary>Converts a parameter value to JSON.</summary>
    /// <exception cref="ArgumentException">The type is not supported.</exception>
    public static JsonNode? Node(object? v) => v switch
    {
        null => null,
        string s => s,
        decimal d => d.ToString(CultureInfo.InvariantCulture),
        long l => l,
        int i => i,
        bool b => b,
        IWireValue w => w.Value,
        JsonNode n => n.DeepClone(),
        JsonElement { ValueKind: JsonValueKind.Undefined } => null, // default(JsonElement) is "no value"
        JsonElement e => JsonNode.Parse(e.GetRawText()),
        IEnumerable items => new JsonArray(items.Cast<object?>().Select(Node).ToArray()),
        _ => throw new ArgumentException($"unsupported parameter type {v.GetType()}"),
    };

    /// <summary>Converts a model (or a list of models) to JSON, using the serializer context of the product.</summary>
    public static JsonNode? Json<T>(T? value, JsonTypeInfo<T> info) => value is null ? null : JsonSerializer.SerializeToNode(value, info);

    internal static void Set(JsonObject o, string name, object? v)
    {
        if (Node(v) is { } node) o[name] = node;
    }

    // A body that does not decode into the model is a client error that names the model and shows the start of the payload.
    internal static T? Decode<T>(string json, JsonTypeInfo<T> info)
    {
        if (string.IsNullOrWhiteSpace(json)) return default;
        try { return JsonSerializer.Deserialize(json, info); }
        catch (JsonException e) { throw DecodeFailure(typeof(T), json, e); }
    }

    internal static T? Decode<T>(JsonElement json, JsonTypeInfo<T> info)
    {
        if (json.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null) return default;
        try { return json.Deserialize(info); }
        catch (JsonException e) { throw DecodeFailure(typeof(T), json.GetRawText(), e); }
    }

    private static BinanceClientException DecodeFailure(Type type, string json, JsonException e) =>
        new($"Failed to decode the response as {type.Name}: {e.Message} Payload: {(json.Length > 512 ? json[..512] + "..." : json)}", e);

    internal static IReadOnlyDictionary<string, string> Headers(string json) =>
        string.IsNullOrEmpty(json) ? new Dictionary<string, string>() : JsonSerializer.Deserialize(json, NativeJson.Default.DictionaryStringString) ?? [];

    internal static IReadOnlyList<RestApiRateLimit> RestLimits(string json) =>
        string.IsNullOrEmpty(json) ? [] : JsonSerializer.Deserialize(json, NativeJson.Default.ListRestApiRateLimit) ?? [];

    internal static IReadOnlyList<WebSocketApiRateLimit> WebSocketLimits(JsonElement json) =>
        json.ValueKind == JsonValueKind.Array ? json.Deserialize(NativeJson.Default.ListWebSocketApiRateLimit) ?? [] : [];
}

/// <summary>A REST request. <c>{name}</c> in the endpoint is replaced by <see cref="Path"/>.</summary>
/// <param name="method">HTTP method.</param>
/// <param name="endpoint">Endpoint path.</param>
/// <param name="signed">Whether the request is signed.</param>
/// <param name="hasTimeUnit">Whether the product honours the configured time unit.</param>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public sealed class RestRequest(string method, string endpoint, bool signed = false, bool hasTimeUnit = false)
{
    private readonly JsonObject _query = new(), _body = new(), _headers = new();
    private string _endpoint = endpoint;

    /// <summary>Replaces <c>{name}</c> in the endpoint.</summary>
    public RestRequest Path(string name, object? v)
    {
        _endpoint = _endpoint.Replace("{" + name + "}", Uri.EscapeDataString(Wire.Node(v)?.ToString() ?? ""), StringComparison.Ordinal);
        return this;
    }

    /// <summary>Adds a query parameter (null is skipped).</summary>
    public RestRequest Query(string name, object? v) { Wire.Set(_query, name, v); return this; }

    /// <summary>Adds a body parameter (null is skipped).</summary>
    public RestRequest Body(string name, object? v) { Wire.Set(_body, name, v); return this; }

    /// <summary>Adds a header (null is skipped).</summary>
    public RestRequest Header(string name, object? v) { Wire.Set(_headers, name, v); return this; }

    internal string ToJson(TimeUnit? timeUnit)
    {
        var o = new JsonObject { ["method"] = method, ["endpoint"] = _endpoint, ["signed"] = signed };
        if (_query.Count > 0) o["query"] = _query;
        if (_body.Count > 0) o["body"] = _body;
        if (_headers.Count > 0) o["headers"] = _headers;
        if (hasTimeUnit && timeUnit is { } t) o["time_unit"] = t.ToString().ToUpperInvariant();
        return o.ToJsonString();
    }
}

/// <summary>How a WebSocket API request is authenticated.</summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public enum WebSocketAuth
{
    /// <summary>Not authenticated.</summary>
    None,
    /// <summary>Sends the API key.</summary>
    ApiKey,
    /// <summary>Signed with the credentials.</summary>
    Signed,
    /// <summary><c>session.logon</c>.</summary>
    SessionLogon,
    /// <summary><c>session.logout</c>.</summary>
    SessionLogout,
}

/// <summary>A WebSocket API request.</summary>
/// <param name="method">The method, e.g. <c>account.status</c>.</param>
/// <param name="auth">How the request is authenticated.</param>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public sealed class WebSocketApiRequest(string method, WebSocketAuth auth = WebSocketAuth.None)
{
    private readonly JsonObject _params = new();

    /// <summary>
    /// Adds a parameter (null is skipped). The parameter <c>id</c> is the id of the request, which is kept only if it is a string of
    /// 32 lower-case hexadecimal characters; any other value is replaced by a generated id.
    /// </summary>
    public WebSocketApiRequest Param(string name, object? v) { Wire.Set(_params, name, v); return this; }

    internal string ToJson()
    {
        // The request id is the `id` of the frame, not a parameter.
        var parameters = (JsonObject)_params.DeepClone();
        parameters.Remove("id", out var id);
        var request = ToObject(parameters);
        if (id is not null) request["id"] = id;
        return request.ToJsonString();
    }

    private JsonObject ToObject(JsonObject parameters) => new()
    {
        ["method"] = method,
        ["params"] = parameters,
        ["auth"] = auth switch
        {
            WebSocketAuth.ApiKey => "api_key",
            WebSocketAuth.Signed => "signed",
            WebSocketAuth.SessionLogon => "session_logon",
            WebSocketAuth.SessionLogout => "session_logout",
            _ => "none",
        },
    };
}

/// <summary>
/// Builds a stream name from a template such as <c>/&lt;symbol&gt;@depth&lt;levels&gt;@&lt;updateSpeed&gt;</c>: names match
/// case-insensitively ignoring <c>_</c> and <c>-</c>, a missing value is empty and a trailing <c>@</c> is dropped.
/// With a leading <c>/</c>, a placeholder at the very start is lower-cased (symbols), except <c>&lt;listenKey&gt;</c>: listen keys are case-sensitive.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public static class StreamName
{
    /// <summary>Fills the template.</summary>
    public static string Build(string template, params (string Name, object? Value)[] values)
    {
        static string Norm(string s) => s.Replace("_", "", StringComparison.Ordinal).Replace("-", "", StringComparison.Ordinal).ToLowerInvariant();
        var lookup = values.ToDictionary(v => Norm(v.Name), v => Wire.Node(v.Value)?.ToString() ?? "");
        var lower = template.StartsWith('/');
        var body = lower ? template[1..] : template;
        string? head = null;
        var sb = new System.Text.StringBuilder();
        for (var i = 0; i < body.Length;)
        {
            var open = body.IndexOf('<', i);
            var close = open < 0 ? -1 : body.IndexOf('>', open + 1);
            if (close < 0 || close == open + 1) { sb.Append(body, i, body.Length - i); break; }
            sb.Append(body, i, open - i);
            var key = Norm(body[(open + 1)..close]);
            var value = lookup.GetValueOrDefault(key, "");
            if (open == 0 && key != "listenkey") head = value;
            sb.Append(value);
            i = close + 1;
        }
        var name = sb.ToString().TrimEnd('@');
        return lower && head is not null && name.StartsWith(head, StringComparison.Ordinal) ? head.ToLowerInvariant() + name[head.Length..] : name;
    }
}
