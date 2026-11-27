//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Runtime.InteropServices;
using System.Text;

namespace Binance.Common;

/// <summary>The WebSocket failure behind a <see cref="BinanceException"/>.</summary>
public enum BinanceWebSocketErrorKind
{
    /// <summary>Not a WebSocket failure.</summary>
    None = 0,
    /// <summary>A request got no response in time.</summary>
    Timeout,
    /// <summary>The client is not connected.</summary>
    NotConnected,
    /// <summary>The connection closed before the response arrived.</summary>
    NoResponse,
    /// <summary>The server answered with an error status.</summary>
    ResponseError,
    /// <summary>The upgrade was rejected or failed.</summary>
    Handshake,
    /// <summary>A violation of the WebSocket protocol.</summary>
    Protocol,
    /// <summary>The server closed the connection with an error.</summary>
    Server,
    /// <summary>The connection was lost.</summary>
    Network,
    /// <summary>The operation was cancelled.</summary>
    Cancelled,
    /// <summary>Any other WebSocket failure.</summary>
    Other,
}

/// <summary>The kind of failure.</summary>
public enum BinanceErrorKind
{
    /// <summary>Invalid configuration or request, or an unusable key.</summary>
    Config = 1,
    /// <summary>HTTP 400.</summary>
    BadRequest,
    /// <summary>HTTP 401.</summary>
    Unauthorized,
    /// <summary>HTTP 403.</summary>
    Forbidden,
    /// <summary>HTTP 404.</summary>
    NotFound,
    /// <summary>HTTP 418: the IP is banned for exceeding the rate limits.</summary>
    RateLimitBan,
    /// <summary>HTTP 429.</summary>
    TooManyRequests,
    /// <summary>HTTP 5xx.</summary>
    Server,
    /// <summary>DNS, connect, TLS or I/O failure.</summary>
    Network,
    /// <summary>The attempt took longer than the timeout.</summary>
    Timeout,
    /// <summary>The operation was cancelled (e.g. the client was disposed).</summary>
    Cancelled,
    /// <summary>Unexpected status, malformed response, ...</summary>
    Client,
    /// <summary>Any WebSocket failure, including errors answered by the WebSocket API.</summary>
    WebSocket,
    /// <summary>An unexpected internal error of the connector.</summary>
    Internal,
    /// <summary>HTTP 409: the request conflicts with the current state of the resource.</summary>
    Conflict = 15,
}

/// <summary>
/// Base of every error raised by the connector. It carries the details of the failure; the
/// derived types let callers <c>catch</c> one kind of failure.
/// </summary>
public class BinanceException : Exception
{
    /// <summary>Creates an exception that carries only a kind and a message.</summary>
    public BinanceException(BinanceErrorKind kind, string message, Exception? innerException = null) : base(message, innerException)
    {
        Kind = kind;
        TransportCategory = "";
    }

    internal BinanceException(in BncError e, string message) : base(message)
    {
        Kind = (BinanceErrorKind)e.Kind;
        HttpStatus = e.HttpStatus;
        Code = e.HasCode != 0 ? e.Code : null;
        RetryAfter = e.RetryAfterSeconds >= 0 ? TimeSpan.FromSeconds(e.RetryAfterSeconds) : null;
        RetryAt = e.RetryAtMs >= 0 ? DateTimeOffset.FromUnixTimeMilliseconds(e.RetryAtMs) : null;
        TransportCode = e.TransportCode;
        var copy = e;
        unsafe { TransportCategory = Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(copy.TransportCategory)); }
        RequestSent = e.RequestSent != 0;
        WebSocketKind = (BinanceWebSocketErrorKind)e.WsKind;
    }

    /// <summary>The kind of failure.</summary>
    public BinanceErrorKind Kind { get; }

    /// <summary>HTTP status of the failing response, or 0.</summary>
    public int HttpStatus { get; }

    /// <summary>Binance error code from the response body, if there was one.</summary>
    public long? Code { get; }

    /// <summary><c>Retry-After</c> of a REST 418 or 429 response.</summary>
    public TimeSpan? RetryAfter { get; }

    /// <summary>Time from the <c>retryAfter</c> of a WebSocket API error (Binance sends an epoch timestamp).</summary>
    public DateTimeOffset? RetryAt { get; }

    /// <summary>The underlying system error value, or 0.</summary>
    public int TransportCode { get; }

    /// <summary>Category of <see cref="TransportCode"/> (for example <c>system</c>), or empty.</summary>
    public string TransportCategory { get; }

    /// <summary>
    /// The WebSocket failure behind this error, or <see cref="BinanceWebSocketErrorKind.None"/> when it is not a WebSocket failure. The type
    /// of the exception follows <see cref="Kind"/> (a timeout is a <see cref="BinanceTimeoutException"/>, a lost connection a
    /// <see cref="BinanceNetworkException"/>, a cancellation a <see cref="BinanceCancelledException"/>); the other WebSocket failures are
    /// subclasses of <see cref="BinanceWebSocketException"/>.
    /// </summary>
    public BinanceWebSocketErrorKind WebSocketKind { get; }

    /// <summary>Whether the request may have reached the server. Check it before sending an order again.</summary>
    public bool RequestSent { get; }

    /// <summary>The body of the REST response that caused the error (often <c>{"code": ..., "msg": ...}</c>), or null when there was none.</summary>
    public string? Body { get; private set; }

    /// <summary>The headers of the REST response that caused the error, with lower-case names; empty when there was none.</summary>
    public IReadOnlyDictionary<string, string> Headers { get; private set; } = EmptyHeaders;

    /// <summary>The rate limit counters of the REST response that caused the error; empty when there was none.</summary>
    public IReadOnlyList<RestApiRateLimit> RateLimits { get; private set; } = [];

    /// <summary>The rate limit counters of the WebSocket API error response (<c>rateLimits</c>); empty for other errors.</summary>
    public IReadOnlyList<WebSocketApiRateLimit> WebSocketRateLimits { get; private set; } = [];

    /// <summary>
    /// The <c>error.data</c> of a WebSocket API error response, as Binance sent it, or null when it has none. For a REST error, the whole response body is <see cref="Body"/>.
    /// </summary>
    public System.Text.Json.JsonElement? ErrorData { get; private set; }

    private static readonly IReadOnlyDictionary<string, string> EmptyHeaders = new Dictionary<string, string>();

    internal void SetWebSocketRateLimits(IReadOnlyList<WebSocketApiRateLimit> rateLimits) => WebSocketRateLimits = rateLimits;

    internal void SetErrorData(System.Text.Json.JsonElement data) => ErrorData = data;

    internal void SetResponse(string body, IReadOnlyDictionary<string, string> headers, IReadOnlyList<RestApiRateLimit> rateLimits)
    {
        Body = body;
        Headers = headers;
        RateLimits = rateLimits;
    }

    internal static unsafe BinanceException Create(BncError* e)
    {
        var message = Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(e->Message));
        return (BinanceErrorKind)e->Kind switch
        {
            BinanceErrorKind.Config => new BinanceConfigException(*e, message),
            BinanceErrorKind.BadRequest => new BinanceBadRequestException(*e, message),
            BinanceErrorKind.Unauthorized => new BinanceUnauthorizedException(*e, message),
            BinanceErrorKind.Forbidden => new BinanceForbiddenException(*e, message),
            BinanceErrorKind.NotFound => new BinanceNotFoundException(*e, message),
            BinanceErrorKind.Conflict => new BinanceConflictException(*e, message),
            BinanceErrorKind.RateLimitBan => new BinanceRateLimitBanException(*e, message),
            BinanceErrorKind.TooManyRequests => new BinanceTooManyRequestsException(*e, message),
            BinanceErrorKind.Server => new BinanceServerException(*e, message),
            BinanceErrorKind.Network => new BinanceNetworkException(*e, message),
            BinanceErrorKind.Timeout => new BinanceTimeoutException(*e, message),
            BinanceErrorKind.Cancelled => new BinanceCancelledException(*e, message),
            BinanceErrorKind.WebSocket => (BinanceWebSocketErrorKind)e->WsKind switch
            {
                BinanceWebSocketErrorKind.NotConnected => new BinanceWebSocketNotConnectedException(*e, message),
                BinanceWebSocketErrorKind.NoResponse => new BinanceWebSocketNoResponseException(*e, message),
                BinanceWebSocketErrorKind.ResponseError => new BinanceWebSocketResponseException(*e, message),
                BinanceWebSocketErrorKind.Handshake => new BinanceWebSocketHandshakeException(*e, message),
                BinanceWebSocketErrorKind.Protocol => new BinanceWebSocketProtocolException(*e, message),
                BinanceWebSocketErrorKind.Server => new BinanceWebSocketServerException(*e, message),
                _ => new BinanceWebSocketException(*e, message),
            },
            BinanceErrorKind.Client => new BinanceClientException(*e, message),
            _ => new BinanceException(*e, message),
        };
    }
}

/// <summary>Invalid configuration or request, or an unusable key.</summary>
public class BinanceConfigException : BinanceException
{
    /// <summary>Creates the exception.</summary>
    public BinanceConfigException(string message, Exception? innerException = null) : base(BinanceErrorKind.Config, message, innerException) { }

    internal BinanceConfigException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The platform library is missing or does not match this package.</summary>
public sealed class BinanceLibraryException : BinanceConfigException
{
    internal BinanceLibraryException(string message, Exception? innerException = null) : base(message, innerException) { }
}

/// <summary>An HTTP error answered by the REST API.</summary>
public abstract class BinanceApiException : BinanceException
{
    internal BinanceApiException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 400.</summary>
public sealed class BinanceBadRequestException : BinanceApiException
{
    internal BinanceBadRequestException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 401.</summary>
public sealed class BinanceUnauthorizedException : BinanceApiException
{
    internal BinanceUnauthorizedException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 403.</summary>
public sealed class BinanceForbiddenException : BinanceApiException
{
    internal BinanceForbiddenException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 404.</summary>
public sealed class BinanceNotFoundException : BinanceApiException
{
    internal BinanceNotFoundException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 409: the request conflicts with the current state of the resource.</summary>
public sealed class BinanceConflictException : BinanceApiException
{
    internal BinanceConflictException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 418: the IP is banned; see <see cref="BinanceException.RetryAfter"/>.</summary>
public sealed class BinanceRateLimitBanException : BinanceApiException
{
    internal BinanceRateLimitBanException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 429; see <see cref="BinanceException.RetryAfter"/>.</summary>
public sealed class BinanceTooManyRequestsException : BinanceApiException
{
    internal BinanceTooManyRequestsException(in BncError e, string message) : base(e, message) { }
}

/// <summary>HTTP 5xx.</summary>
public sealed class BinanceServerException : BinanceApiException
{
    internal BinanceServerException(in BncError e, string message) : base(e, message) { }
}

/// <summary>Unexpected status or malformed response.</summary>
public sealed class BinanceClientException : BinanceException
{
    internal BinanceClientException(string message, Exception? innerException = null) : base(BinanceErrorKind.Client, message, innerException) { }

    internal BinanceClientException(in BncError e, string message) : base(e, message) { }
}

/// <summary>DNS, connect, TLS or I/O failure; see <see cref="BinanceException.TransportCode"/> and <see cref="BinanceException.RequestSent"/>.</summary>
public class BinanceNetworkException : BinanceException
{
    internal BinanceNetworkException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The attempt took longer than the configured timeout.</summary>
public sealed class BinanceTimeoutException : BinanceNetworkException
{
    internal BinanceTimeoutException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The operation was cancelled by the connector (for example the client was disposed).</summary>
public sealed class BinanceCancelledException : BinanceException
{
    internal BinanceCancelledException(in BncError e, string message) : base(e, message) { }
}

/// <summary>
/// A WebSocket failure that is not a timeout, a lost connection or a cancellation (those are <see cref="BinanceTimeoutException"/>,
/// <see cref="BinanceNetworkException"/> and <see cref="BinanceCancelledException"/>, with <see cref="BinanceException.WebSocketKind"/> set). It
/// is also the base of the more specific WebSocket exceptions, and the type of an error answered by the WebSocket API without a
/// more specific kind (<see cref="BinanceException.HttpStatus"/>, <see cref="BinanceException.Code"/>, <see cref="BinanceException.RetryAt"/>).
/// </summary>
public class BinanceWebSocketException : BinanceException
{
    internal BinanceWebSocketException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The request needs a connection and the client is not connected.</summary>
public sealed class BinanceWebSocketNotConnectedException : BinanceWebSocketException
{
    internal BinanceWebSocketNotConnectedException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The connection closed before the response arrived; check <see cref="BinanceException.RequestSent"/> before sending again.</summary>
public sealed class BinanceWebSocketNoResponseException : BinanceWebSocketException
{
    internal BinanceWebSocketNoResponseException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The WebSocket API answered with an error (<see cref="BinanceException.HttpStatus"/>, <see cref="BinanceException.Code"/>).</summary>
public sealed class BinanceWebSocketResponseException : BinanceWebSocketException
{
    internal BinanceWebSocketResponseException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The WebSocket upgrade was rejected or failed (<see cref="BinanceException.HttpStatus"/>).</summary>
public sealed class BinanceWebSocketHandshakeException : BinanceWebSocketException
{
    internal BinanceWebSocketHandshakeException(in BncError e, string message) : base(e, message) { }
}

/// <summary>A violation of the WebSocket protocol.</summary>
public sealed class BinanceWebSocketProtocolException : BinanceWebSocketException
{
    internal BinanceWebSocketProtocolException(in BncError e, string message) : base(e, message) { }
}

/// <summary>The server closed the connection with an error.</summary>
public sealed class BinanceWebSocketServerException : BinanceWebSocketException
{
    internal BinanceWebSocketServerException(in BncError e, string message) : base(e, message) { }
}
