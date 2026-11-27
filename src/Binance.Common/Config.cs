//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json.Nodes;

namespace Binance.Common;

/// <summary>The unit of the timestamps in requests and responses.</summary>
public enum TimeUnit
{
    /// <summary>Milliseconds (the default).</summary>
    Millisecond,
    /// <summary>Microseconds.</summary>
    Microsecond,
}

/// <summary>The protocol of a proxy.</summary>
public enum ProxyProtocol
{
    /// <summary>HTTP proxy (<c>http</c>).</summary>
    Http,
    /// <summary>HTTP proxy reached over TLS (<c>https</c>).</summary>
    Https,
    /// <summary>SOCKS5; the client resolves the host name of the target (<c>socks5</c>).</summary>
    Socks5,
    /// <summary>SOCKS5; the proxy resolves the host name of the target (<c>socks5h</c>).</summary>
    Socks5h,
}

/// <summary>An HTTP or HTTPS proxy, with optional Basic authentication.</summary>
/// <param name="Host">Proxy host.</param>
/// <param name="Port">Proxy port.</param>
/// <param name="Protocol"><see cref="ProxyProtocol.Http"/>, <see cref="ProxyProtocol.Https"/> (TLS to the proxy itself), <see cref="ProxyProtocol.Socks5"/> (the client resolves the host name of the target) or
/// <see cref="ProxyProtocol.Socks5h"/> (the proxy resolves it). The SOCKS5 protocols run over plain TCP and use <paramref name="Username"/> and <paramref name="Password"/>
/// (at most 255 bytes each) when given.</param>
/// <param name="Username">User name for Basic authentication.</param>
/// <param name="Password">Password for Basic authentication.</param>
public sealed record ProxyConfig(string Host, int Port, ProxyProtocol Protocol = ProxyProtocol.Http, string? Username = null, string? Password = null)
{
    /// <inheritdoc/>
    public override string ToString() => $"ProxyConfig {{ Host = {Host}, Port = {Port}, Protocol = {Protocol}, Username = {Username}, Password = {(Password is null ? "" : "***")} }}";
}

/// <summary>
/// Settings shared by the three clients. A client copies its configuration when it is created; changing it
/// afterwards has no effect. Secrets are never printed.
/// </summary>
public abstract record ConnectorConfig
{
    private static readonly string[] ProxyNames = ["http", "https", "socks5", "socks5h"];

    // Durations are TimeSpan in the API and whole milliseconds on the wire.
    private protected static int? Ms(TimeSpan? value) => value is { } v ? (int)Math.Min(Math.Round(v.TotalMilliseconds), int.MaxValue) : null;

    /// <summary>API key (<c>X-MBX-APIKEY</c>).</summary>
    public string? ApiKey { get; set; }

    /// <summary>HMAC secret.</summary>
    public string? ApiSecret { get; set; }

    /// <summary>RSA or Ed25519 private key in PEM, instead of <see cref="ApiSecret"/>.</summary>
    public string? PrivateKeyPem { get; set; }

    /// <summary>Path of a PEM private key file, instead of <see cref="PrivateKeyPem"/>.</summary>
    public string? PrivateKeyFile { get; set; }

    /// <summary>Passphrase of an encrypted private key.</summary>
    public string? PrivateKeyPassphrase { get; set; }

    /// <summary>Unit of the timestamps (products without time unit support ignore it).</summary>
    public TimeUnit? TimeUnit { get; set; }

    /// <summary>
    /// A fixed offset added to the host clock for the <c>timestamp</c> of signed requests (REST, WebSocket API and signed streams, including
    /// retries, re-logons, reconnects and renewals); rounded to whole milliseconds, may be negative, at most one day either way. Use it to
    /// compensate a clock that is off against Binance (error <c>-1021</c>): set it to <c>serverTime - local time</c>. Default: none.
    /// </summary>
    public TimeSpan? TimeOffset { get; set; }

    /// <summary>
    /// Returns the <c>timestamp</c> of signed requests (REST, WebSocket API and signed streams, including retries, re-logons, reconnects
    /// and renewals), instead of the host clock: for example a clock synchronised with Binance's <c>serverTime</c>. It runs on background
    /// threads, possibly several at a time, and must return quickly; if it throws, the host clock is used and a warning logged. Set
    /// either it or <see cref="TimeOffset"/>. The client keeps the delegate until it is disposed.
    /// </summary>
    public Func<DateTimeOffset>? TimestampProvider { get; set; }

    // Set by the clients from the product and its package (see BinanceUserAgent), not by users.
    internal string? UserAgent { get; init; }

    /// <summary>Read the proxy from the <c>HTTPS_PROXY</c>, <c>HTTP_PROXY</c>, <c>ALL_PROXY</c> and <c>NO_PROXY</c> environment variables when <see cref="Proxy"/> is not set. Default: true for REST, false for WebSockets (as in the other Binance connectors).</summary>
    public bool? ProxyFromEnv { get; set; }

    /// <summary>Explicit proxy, which wins over the environment.</summary>
    public ProxyConfig? Proxy { get; set; }

    /// <summary>Compress with gzip or deflate (default true).</summary>
    public bool? Compression { get; set; }

    /// <summary>
    /// Path of a PEM file whose CAs are trusted in addition to the system store (for example a private CA). With <see cref="CaPem"/>
    /// both are added. It applies to the server and to an <c>https</c> proxy.
    /// </summary>
    public string? CaFile { get; set; }

    /// <summary>PEM text whose CAs are trusted in addition to the system store; see <see cref="CaFile"/>.</summary>
    public string? CaPem { get; set; }

    /// <summary>Trust only the CAs of <see cref="CaFile"/> and <see cref="CaPem"/>, not the system store (needs one of them).</summary>
    public bool? CaOnly { get; set; }

    /// <summary>
    /// Called with every certificate of the chain the client verifies, to pin a certificate or to take over the decision; see
    /// <see cref="ServerCertificateValidator"/>. Verification cannot be switched off by a setting: only a validator that returns true for
    /// a certificate that was not preverified accepts it anyway. The client keeps the delegate until it is disposed.
    /// </summary>
    public ServerCertificateValidator? ServerCertificateValidator { get; set; }

    /// <summary>A client certificate (mutual TLS), in PEM: the certificate and then its chain. It needs <see cref="ClientKeyPem"/> or <see cref="ClientKeyFile"/>.</summary>
    public string? ClientCertificatePem { get; set; }

    /// <summary>Path of a PEM file with the client certificate and its chain, instead of <see cref="ClientCertificatePem"/>.</summary>
    public string? ClientCertificateFile { get; set; }

    /// <summary>The private key of the client certificate, in PEM.</summary>
    public string? ClientKeyPem { get; set; }

    /// <summary>Path of a PEM file with the private key of the client certificate, instead of <see cref="ClientKeyPem"/>.</summary>
    public string? ClientKeyFile { get; set; }

    /// <summary>Passphrase of an encrypted <see cref="ClientKeyPem"/> or <see cref="ClientKeyFile"/>.</summary>
    public string? ClientKeyPassphrase { get; set; }

    internal JsonObject ToJsonObject()
    {
        var o = new JsonObject
        {
            ["api_key"] = ApiKey,
            ["api_secret"] = ApiSecret,
            ["private_key_pem"] = PrivateKeyPem,
            ["private_key_file"] = PrivateKeyFile,
            ["private_key_passphrase"] = PrivateKeyPassphrase,
            ["time_unit"] = TimeUnit?.ToString().ToUpperInvariant(),
            ["time_offset_ms"] = TimeOffset is { } offset ? (long)Math.Round(offset.TotalMilliseconds) : null,
            ["user_agent"] = UserAgent,
            ["proxy_from_env"] = ProxyFromEnv,
            ["compression"] = Compression,
            ["ca_file"] = CaFile,
            ["ca_pem"] = CaPem,
            ["ca_only"] = CaOnly,
            ["client_cert_pem"] = ClientCertificatePem,
            ["client_cert_file"] = ClientCertificateFile,
            ["client_key_pem"] = ClientKeyPem,
            ["client_key_file"] = ClientKeyFile,
            ["client_key_passphrase"] = ClientKeyPassphrase,
        };
        if (Proxy is { } p)
            o["proxy"] = new JsonObject { ["host"] = p.Host, ["port"] = p.Port, ["protocol"] = Enum.IsDefined(p.Protocol) ? ProxyNames[(int)p.Protocol] : null, ["username"] = p.Username, ["password"] = p.Password };
        Write(o);
        return o;
    }

    internal string ToJson()
    {
        Validate();
        return ToJsonObject().ToJsonString();
    }

    /// <summary>The configuration without its secrets (key, secret, private key and passphrase).</summary>
    public sealed override string ToString()
    {
        var o = ToJsonObject();
        foreach (var key in new[] { "api_key", "api_secret", "private_key_pem", "private_key_passphrase", "client_key_pem", "client_key_passphrase" })
            if (o[key] is not null) o[key] = "***";
        foreach (var key in new[] { "user_agent", "signed_streams", "stream_id_is_strictly_number" }) o.Remove(key); // set by the clients
        if (o["proxy"] is JsonObject { } proxy && proxy["password"] is not null) proxy["password"] = "***";
        if (o["custom_headers"] is JsonObject headers) // names only: the values are often credentials
            o["custom_headers"] = new JsonArray([.. headers.Select(kv => (JsonNode?)JsonValue.Create(kv.Key))]);
        foreach (var key in o.Where(kv => kv.Value is null).Select(kv => kv.Key).ToList()) o.Remove(key);
        return $"{GetType().Name} {o.ToJsonString()}";
    }

    private protected abstract void Write(JsonObject o);

    private protected abstract void ValidateEndpoint();

    /// <summary>Checks the configuration; the clients do it when they are created.</summary>
    /// <exception cref="BinanceConfigException">A value is missing or out of range.</exception>
    public void Validate()
    {
        ValidateEndpoint();
        if (PrivateKeyPem is not null && PrivateKeyFile is not null)
            throw new BinanceConfigException("Set only one of PrivateKeyPem and PrivateKeyFile.");
        if (CaOnly == true && string.IsNullOrEmpty(CaFile) && string.IsNullOrEmpty(CaPem))
            throw new BinanceConfigException("CaOnly needs CaFile or CaPem.");
        if (TimeOffset is { } offset && TimeSpan.FromDays(1) < offset.Duration())
            throw new BinanceConfigException("TimeOffset must be within one day of the host clock.");
        if (TimeOffset is { } shift && shift != TimeSpan.Zero && TimestampProvider is not null)
            throw new BinanceConfigException("Set only one of TimeOffset and TimestampProvider.");
        if (ClientCertificatePem is not null && ClientCertificateFile is not null)
            throw new BinanceConfigException("Set only one of ClientCertificatePem and ClientCertificateFile.");
        if (ClientKeyPem is not null && ClientKeyFile is not null)
            throw new BinanceConfigException("Set only one of ClientKeyPem and ClientKeyFile.");
        if ((ClientCertificatePem ?? ClientCertificateFile) is null != (ClientKeyPem ?? ClientKeyFile) is null)
            throw new BinanceConfigException("A client certificate needs both the certificate and its private key.");
        if (Proxy is { } p && (string.IsNullOrWhiteSpace(p.Host) || p.Port is <= 0 or > 65535 || !Enum.IsDefined(p.Protocol)))
            throw new BinanceConfigException("Proxy needs a host, a port in 1..65535 and the protocol Http, Https, Socks5 or Socks5h.");
    }

    private protected static void Require(string value, string name, params string[] schemes)
    {
        if (string.IsNullOrWhiteSpace(value) || !schemes.Any(s => value.StartsWith(s + "://", StringComparison.OrdinalIgnoreCase)))
            throw new BinanceConfigException($"{name} must be a URL starting with {string.Join(" or ", schemes.Select(s => s + "://"))}, but is '{value}'.");
    }

    private protected static void NonNegative(TimeSpan? value, string name)
    {
        if (value < TimeSpan.Zero) throw new BinanceConfigException($"{name} must not be negative.");
    }

    private protected static void NonNegative(int? value, string name)
    {
        if (value < 0) throw new BinanceConfigException($"{name} must not be negative.");
    }
}

/// <summary>
/// How a WebSocket client connects: one connection, or a pool that spreads the requests or streams over several. In a bound
/// configuration section (appsettings), it is written <c>Single</c> or <c>Pool(4)</c>.
/// </summary>
[System.ComponentModel.TypeConverter(typeof(WebSocketModeConverter))]
public sealed record WebSocketMode
{
    private WebSocketMode(int poolSize, bool isPool)
    {
        PoolSize = poolSize;
        IsPool = isPool;
    }

    /// <summary>One connection (the default).</summary>
    public static WebSocketMode Single { get; } = new(1, false);

    /// <summary>A pool of <paramref name="size"/> connections. <c>session.logon</c> and <c>session.logout</c> go to every connection.</summary>
    /// <param name="size">The number of connections, at least 1.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> is less than 1.</exception>
    public static WebSocketMode Pool(int size)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 1);
        return new(size, true);
    }

    /// <summary>The number of connections.</summary>
    public int PoolSize { get; }

    /// <summary>Whether this is a pool.</summary>
    public bool IsPool { get; }

    /// <inheritdoc/>
    public override string ToString() => IsPool ? $"Pool({PoolSize})" : "Single";

    internal int? Json => IsPool ? PoolSize : null;

    /// <summary>Parses <c>Single</c> or <c>Pool(n)</c> (case-insensitive), as <see cref="ToString"/> writes them.</summary>
    /// <param name="text">The text.</param>
    /// <exception cref="FormatException">The text is neither.</exception>
    public static WebSocketMode Parse(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        var t = text.Trim();
        if (t.Equals("Single", StringComparison.OrdinalIgnoreCase)) return Single;
        if (t.StartsWith("Pool(", StringComparison.OrdinalIgnoreCase) && t.EndsWith(')')
            && int.TryParse(t.AsSpan(5, t.Length - 6), System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out var n) && n >= 1)
            return Pool(n);
        throw new FormatException($"'{text}' is not a WebSocket mode: expected Single or Pool(n) with n at least 1.");
    }
}

internal sealed class WebSocketModeConverter : System.ComponentModel.TypeConverter
{
    public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, Type sourceType) =>
        sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object? ConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value) =>
        value is string s ? WebSocketMode.Parse(s) : base.ConvertFrom(context, culture, value);
}

/// <summary>Configuration of the REST client.</summary>
public sealed record RestApiConfig : ConnectorConfig
{
    /// <summary>Base URL, e.g. <c>https://api.binance.com</c>. The product factories (<c>Production()</c>, ...) set it.</summary>
    public string BasePath { get; set; } = "";

    /// <summary>How long one attempt of a request may take as a whole: DNS, connect, proxy, TLS, writing the request and reading the response (default 1 second). A retry starts a new attempt.</summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>Total attempts for retriable failures of GET and DELETE (default 3; 0 and 1 both mean a single attempt). Each retry of a signed request is signed again.</summary>
    public int? Retries { get; set; }

    /// <summary>Linear backoff: attempt <c>n</c> waits <c>n * Backoff</c> before retrying (default 1 second).</summary>
    public TimeSpan? Backoff { get; set; }

    /// <summary>Reuse connections (default true).</summary>
    public bool? KeepAlive { get; set; }

    /// <summary>Largest response body accepted, in bytes (default 128 MiB).</summary>
    public long? MaxResponseSize { get; set; }

    /// <summary>Headers added to every request.</summary>
    public Dictionary<string, string>? CustomHeaders { get; set; }

    private protected override void Write(JsonObject o)
    {
        o["base_path"] = BasePath; o["timeout_ms"] = Ms(Timeout); o["retries"] = Retries; o["backoff_ms"] = Ms(Backoff);
        o["keep_alive"] = KeepAlive; o["max_response_size"] = MaxResponseSize;
        if (CustomHeaders is not null)
        {
            var h = new JsonObject();
            foreach (var (k, v) in CustomHeaders) h[k] = v;
            o["custom_headers"] = h;
        }
    }

    private protected override void ValidateEndpoint()
    {
        Require(BasePath, nameof(BasePath), "http", "https");
        NonNegative(Timeout, nameof(Timeout));
        NonNegative(Retries, nameof(Retries));
        NonNegative(Backoff, nameof(Backoff));
        if (MaxResponseSize < 0) throw new BinanceConfigException("MaxResponseSize must not be negative.");
    }
}

/// <summary>Configuration of the WebSocket API client.</summary>
public sealed record WebSocketApiConfig : ConnectorConfig
{
    /// <summary>WebSocket URL, e.g. <c>wss://ws-api.binance.com:443/ws-api/v3</c>. The product factories set it.</summary>
    public string Url { get; set; } = "";

    /// <summary>How long a request may wait for its response (default 5 seconds).</summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>Delay before reconnecting a connection that dropped (default 5 seconds). After a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it.</summary>
    public TimeSpan? ReconnectDelay { get; set; }

    /// <summary>How long opening one connection may take (DNS, TCP, proxy, TLS and the WebSocket upgrade), (default 10 seconds).</summary>
    public TimeSpan? ConnectTimeout { get; set; }

    /// <summary><see cref="WebSocketMode.Single"/> (the default) or <see cref="WebSocketMode.Pool"/>; <c>ConnectAsync(mode)</c> overrides it.</summary>
    public WebSocketMode? Mode { get; set; }

    /// <summary>Largest message accepted, in bytes (default 64 MiB); a larger message closes the connection.</summary>
    public long? MaxMessageSize { get; set; }

    /// <summary>Repeat <c>session.logon</c> after a reconnect (default true).</summary>
    public bool? AutoSessionRelogon { get; set; }

    /// <summary>
    /// Capacity of the buffer of each user-data subscription, and of <c>EnableMessages()</c>; when it is full the oldest event is
    /// dropped. Unbounded by default: a slow reader then costs memory, but loses nothing. Used by the client only.
    /// </summary>
    public int? EventBufferCapacity { get; set; }

    private protected override void Write(JsonObject o)
    {
        o["url"] = Url; o["timeout_ms"] = Ms(Timeout); o["reconnect_delay_ms"] = Ms(ReconnectDelay);
        o["connect_timeout_ms"] = Ms(ConnectTimeout); o["pool_size"] = Mode?.Json; o["max_message_size"] = MaxMessageSize;
        o["auto_session_relogon"] = AutoSessionRelogon;
    }

    private protected override void ValidateEndpoint()
    {
        Require(Url, nameof(Url), "ws", "wss");
        NonNegative(Timeout, nameof(Timeout));
        NonNegative(ReconnectDelay, nameof(ReconnectDelay));
        NonNegative(ConnectTimeout, nameof(ConnectTimeout));
        if (EventBufferCapacity is <= 0) throw new BinanceConfigException("EventBufferCapacity must be positive.");
    }
}

/// <summary>Configuration of the WebSocket Streams client.</summary>
public sealed record WebSocketStreamsConfig : ConnectorConfig
{
    /// <summary>WebSocket URL, e.g. <c>wss://stream.binance.com:9443</c>. The product factories set it.</summary>
    public string Url { get; set; } = "";

    /// <summary>Delay before reconnecting a connection that dropped (default 5 seconds). After a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it.</summary>
    public TimeSpan? ReconnectDelay { get; set; }

    /// <summary>How long opening one connection may take (DNS, TCP, proxy, TLS and the WebSocket upgrade), (default 10 seconds).</summary>
    public TimeSpan? ConnectTimeout { get; set; }

    /// <summary><see cref="WebSocketMode.Single"/> (the default) or <see cref="WebSocketMode.Pool"/>; <c>ConnectAsync(mode)</c> overrides it.</summary>
    public WebSocketMode? Mode { get; set; }

    /// <summary>Largest message accepted, in bytes (default 64 MiB); a larger message closes the connection.</summary>
    public long? MaxMessageSize { get; set; }

    // Set by the product clients (WebSocketStreamsClient), not by users: the connection is authenticated with the credentials,
    // and subscription ids are always numbers.
    internal bool? SignedStreams { get; init; }

    internal bool? StreamIdIsStrictlyNumber { get; init; }

    /// <summary>
    /// Capacity of the buffer of each subscription, and of <c>EnableMessages()</c>; when it is full the oldest event is dropped.
    /// Unbounded by default: a slow reader then costs memory, but loses nothing. Used by the client only.
    /// </summary>
    public int? EventBufferCapacity { get; set; }

    private protected override void Write(JsonObject o)
    {
        o["url"] = Url; o["reconnect_delay_ms"] = Ms(ReconnectDelay); o["connect_timeout_ms"] = Ms(ConnectTimeout);
        o["pool_size"] = Mode?.Json; o["max_message_size"] = MaxMessageSize; o["signed_streams"] = SignedStreams;
        o["stream_id_is_strictly_number"] = StreamIdIsStrictlyNumber;
    }

    private protected override void ValidateEndpoint()
    {
        Require(Url, nameof(Url), "ws", "wss");
        NonNegative(ReconnectDelay, nameof(ReconnectDelay));
        NonNegative(ConnectTimeout, nameof(ConnectTimeout));
        if (EventBufferCapacity is <= 0) throw new BinanceConfigException("EventBufferCapacity must be positive.");
    }
}
