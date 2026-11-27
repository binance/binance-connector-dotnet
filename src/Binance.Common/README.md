# Binance Common Types and Utilities for Binance .NET Connectors

![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-blue)
[![NuGet version](https://img.shields.io/nuget/v/Binance.Common)](https://www.nuget.org/packages/Binance.Common)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

`Binance.Common` is the **shared library** of the Binance .NET connectors. It implements what every
connector needs to talk to the Binance REST and WebSocket APIs: configuration, request signing,
connection management, error types, logging and utilities. The connectors under [`src/`](https://github.com/binance/binance-connector-dotnet/tree/master/src)
are built on top of it, and it comes with every one of them.

## Installation

`Binance.Common` is installed with every connector (see the [root README](https://github.com/binance/binance-connector-dotnet/blob/master/README.md#installation)). To add it on its own:

```bash
dotnet add package Binance.Common
```

The optional [`Binance.Common.DependencyInjection`](https://github.com/binance/binance-connector-dotnet/tree/master/src/Binance.Common.DependencyInjection) package registers the clients with
`Microsoft.Extensions.DependencyInjection`.

## Features

- **REST client** with connection reuse, retries with backoff (GET and DELETE), gzip/deflate
  decoding and rate-limit headers (`RestApiResponse<T>`).
- **Request signing** with HMAC-SHA256, RSA or Ed25519 keys.
- **WebSocket API client**: request/response matching, connection pools, session logon that is
  repeated after reconnects, and user-data subscriptions that are restored after reconnects.
- **WebSocket Streams client**: subscriptions over connection pools and URL paths, restored after
  reconnects.
- **Automatic connection management**: reconnects with backoff, renewal every 23 hours and on
  `serverShutdown`, and dead-connection detection.
- **Typed responses and events** decoded on demand, with exact decimals (`decimal`), 64-bit
  integers and extensible enums that keep values the SDK does not know.
- **Asynchronous** calls: every request is a `Task` that accepts a `CancellationToken`, and the events
  of a subscription are a `ChannelReader<T>`.
- **Proxies** (HTTP, HTTPS, SOCKS5 and SOCKS5 with remote name resolution, with authentication, or from the environment).
- **TLS**: private CAs (`CaFile`, `CaPem`, `CaOnly`) and certificate pinning (`ServerCertificateValidator`).
- **Errors** as one exception hierarchy (`BinanceException`) carrying Binance's `Code`.
- **Logging** through `Microsoft.Extensions.Logging`.
- **Trimming and Native AOT** are supported.

## Usage

### REST

The clients of the connectors take a `RestApiConfig`. For example, with `Binance.Spot`:

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

var config = new RestApiConfig
{
    ApiKey = "...",
    ApiSecret = "...", // or PrivateKeyFile = "ed25519.pem"
};
using var client = SpotRestApi.Production(config);

var time = await client.TimeAsync();
Console.WriteLine(time.Data()!.ServerTime); // the body is decoded when Data() is called

// Status, rate limits (RestApiRateLimit: RateLimitType, Interval, IntervalNum, Count) and headers come with every response
foreach (var limit in time.RateLimits)
    Console.WriteLine(limit);
```

### WebSocket API and Streams

`WebSocketApiConfig` configures the clients that send WebSocket API requests and `WebSocketStreamsConfig` the clients that
subscribe to streams. As in the other Binance connectors, a client holds the configuration and `ConnectAsync()` returns an open
connection, which has the methods; every call opens an independent one. Connections reconnect, renew themselves every 23 hours and
survive `serverShutdown` on their own.

```csharp
using Binance.Common;
using Binance.Spot.WebSocketApi;
using WebSocketStreamsNs = Binance.Spot.WebSocketStreams;

var apiConfig = new WebSocketApiConfig
{
    ApiKey = "...",
    PrivateKeyFile = "ed25519.pem",
};
var api = SpotWebSocketApi.Production(apiConfig);
await using var connection = await api.ConnectAsync(); // or ConnectAsync(WebSocketMode.Pool(3))

// Logs the connection on, and again after reconnects (AutoSessionRelogon)
await connection.SessionLogonAsync();
var time = await connection.TimeAsync();
Console.WriteLine(time.Data()!.ServerTime);

var streams = WebSocketStreamsNs.SpotWebSocketStreams.Production();
await using var streamsConnection = await streams.ConnectAsync();
using var trades = streamsConnection.AggTrade(new WebSocketStreamsNs.AggTradeRequest { Symbol = "bnbusdt" });
await trades.WaitSubscribedAsync(); // optional: until the server has acknowledged the SUBSCRIBE
await foreach (var trade in trades.Events.ReadAllAsync())
    Console.WriteLine($"{trade.S} {trade.P}");

// Or callbacks, like stream.on('message', ...) of the other connectors (instead of the reader):
// using var callback = trades.OnMessage(trade => Console.WriteLine(trade.P));
```

- Requests wait for their response up to `Timeout`. A request that was not answered in time fails with a `BinanceException`.
- The WebSocket API repeats `session.logon` after a reconnect (`AutoSessionRelogon`) and restores user-data subscriptions.
- Streams are subscribed again after a reconnect. `WaitSubscribedAsync()` of a subscription completes once the server has
  acknowledged it, and fails with `BinanceWebSocketResponseException` if the server rejects it. `Unsubscribe()` (or `Dispose()`)
  ends it.
- `WebSocketMode.Single` (the default) or `WebSocketMode.Pool(n)`, in `Mode` of the configuration or given to `ConnectAsync`,
  spreads the requests or streams over `n` connections; `session.logon` and `session.logout` go to every connection.
- Reconnects wait `ReconnectDelay`; after a failed attempt, a backoff of 1 s doubling up to 60 s, with random jitter, is added
  to it, and the wait is at least the `Retry-After` of a rejected upgrade. Streams of a connection that closes for good move to
  another connection of the pool.
- A subscription's events go either to its reader (`Events`) or to callbacks (`OnMessage`, which every event reaches in order;
  disposing the result removes one), not both. The reader completes when the connection is disconnected or disposed and faults with
  a `BinanceException` when the server rejects the SUBSCRIBE; a reconnect never ends it. `Completion` and `IsActive` report the
  same. A WebSocket API user-data subscription completes only on dispose.
- Connections and subscriptions hold native resources and registry entries: dispose every one of them.
- `PingServer()` sends a ping frame. The lifecycle events of a connection (open, close, error, ping, pong) go to its `Events` reader
  or to `OnEvent` callbacks.
- `EnableMessages()` of a connection turns on the delivery of every message of its connections as the server sent it (a
  `ConnectionMessage`) and returns their reader; `OnMessage` delivers them to callbacks instead. The library builds them only from
  then on. Unbounded unless `EventBufferCapacity` is set.
- For what has no method yet: `SendRequestAsync(endpoint, method, ...)` / `SendSignedRequestAsync` of a REST client call any
  endpoint, `SendMessageAsync` / `SendSignedMessageAsync` of a WebSocket API connection send any method, and `Subscribe(stream)`
  of a WebSocket Streams connection takes any stream name. They return raw JSON (`JsonElement`), or decode it with the type info
  given to the generic overloads.
- `Subscribe(["a@trade", "b@trade"])` and `Unsubscribe([...])` of a WebSocket Streams connection subscribe and unsubscribe stream
  names without a subscription object (their messages reach `EnableMessages` / `OnMessage`), `IsSubscribed(stream)` tells whether
  a stream is subscribed, and `ConnectAsync(streams)` subscribes streams through the connection URL.

### Errors

Every error derives from `BinanceException`, which carries the Binance `Code` (when there is one) and the
`Kind` of the failure.

- REST errors derive from `BinanceApiException`: `BinanceBadRequestException`, `BinanceUnauthorizedException`,
  `BinanceForbiddenException`, `BinanceNotFoundException`, `BinanceConflictException` (409), `BinanceTooManyRequestsException`,
  `BinanceRateLimitBanException` or `BinanceServerException`. They carry the `HttpStatus`, and the response that caused them:
  `Body`, `Headers` and `RateLimits`. An error answered by the WebSocket API carries the `WebSocketRateLimits` of that answer and its `ErrorData`
  (`error.data`).
- `BinanceTimeoutException` (a `BinanceNetworkException`) means the attempt took longer than `Timeout`.
- `BinanceNetworkException.RequestSent` says whether a failed request may have reached Binance. Check it
  before placing an order again.
- `TransportCode` and `TransportCategory` give the system error behind a network failure (for example `system` and the
  value of `ECONNREFUSED`), or `0` and an empty category when there is none.
- `RetryAfter` is the `Retry-After` delay of a 418 / 429 response; `RetryAt` is the time from the `retryAfter` of a
  WebSocket API error, which Binance sends as an epoch timestamp.
- WebSocket failures carry `WebSocketKind` (`BinanceWebSocketErrorKind`), and the exception type follows the cause:
  - a request without a response in time is a `BinanceTimeoutException`, a lost connection or a refused connect a
    `BinanceNetworkException`, and an operation cancelled by the connector (the client was disposed) a `BinanceCancelledException`;
  - the other failures derive from `BinanceWebSocketException`: `BinanceWebSocketNotConnectedException`,
    `BinanceWebSocketNoResponseException` (the connection closed before the response arrived: check `RequestSent`),
    `BinanceWebSocketResponseException` (an error answered by the WebSocket API, with `HttpStatus`, `Code` and `RetryAt`),
    `BinanceWebSocketHandshakeException` (the upgrade was rejected, with `HttpStatus`), `BinanceWebSocketProtocolException`
    and `BinanceWebSocketServerException`; any other failure is a plain `BinanceWebSocketException`.
- Invalid configurations throw `BinanceConfigException`.
- A cancelled token throws `OperationCanceledException`; an operation cancelled by the connector (the client was disposed)
  throws `BinanceCancelledException`. Cancelling a request (REST or WebSocket API) aborts it; cancelling `ConnectAsync` (the
  connection is then disposed), `DisconnectAsync`, `WaitSubscribedAsync` or a user-data `SubscribeAsync` abandons the wait only: a
  disconnect may still close the connections, and a user-data subscribe may still open the subscription on the server.

```csharp
using var client = SpotRestApi.Production();
try
{
    await client.TimeAsync();
}
catch (BinanceTooManyRequestsException e)
{
    await Task.Delay(e.RetryAfter ?? TimeSpan.FromSeconds(1));
}
catch (BinanceNetworkException e) when (!e.RequestSent)
{
    // The request never reached the server: it is safe to send it again.
}
```

### Configuration

- `Timeout`: how long one attempt of a request may take as a whole (DNS, connect, proxy, TLS,
  writing the request and reading the response), as in the other Binance connectors; a retry starts a new attempt. `Retries` / `Backoff` (GET and DELETE only) and `KeepAlive`.
- `Compression` and `MaxResponseSize`.
- `Proxy`: a `ProxyProtocol` (`Http`, `Https`, `Socks5` or `Socks5h`; `Socks5h` lets the proxy resolve the host name), with a user name and password.
  Without it, `HTTPS_PROXY` / `HTTP_PROXY` / `ALL_PROXY` /
  `NO_PROXY` from the environment are used when `ProxyFromEnv` is set: by default for REST, and not for WebSockets, as in the other
  Binance connectors.
- TLS: `CaFile` / `CaPem` add trusted CAs to the system store (a private CA), `CaOnly` trusts only them, and
  `ServerCertificateValidator` is called with each certificate of the chain (`X509Certificate2`, depth, whether the built-in checks
  passed) to pin a certificate or take over the decision. An exception it throws rejects the certificate.
- `CustomHeaders` and `TimeUnit`. The `User-Agent` names the product and its version; the clients set it.
- `TimeOffset`: a fixed offset (`TimeSpan`, may be negative, at most one day) added to the host clock for the `timestamp` of signed
  REST requests, signed WebSocket API requests and signed streams, including retries, re-logons, reconnects and renewals. Set it to
  `serverTime - local time` when requests fail with `-1021`. `TimestampProvider` (a `Func<DateTimeOffset>`) replaces the clock
  altogether, for example with one synchronised with Binance; set one of the two.
- `ClientCertificatePem` / `ClientCertificateFile` with `ClientKeyPem` / `ClientKeyFile` (and `ClientKeyPassphrase`) present a client
  certificate (mutual TLS).
- The `Id` of a WebSocket API request is used only if it is a string of 32 lower-case hexadecimal characters; any other value is
  replaced by a generated id.
- `ApiKey` with `ApiSecret` (HMAC-SHA256), or `PrivateKeyPem` / `PrivateKeyFile` (RSA or Ed25519) with `PrivateKeyPassphrase`.
- WebSocket: `ReconnectDelay`, `ConnectTimeout`, `Mode`, `MaxMessageSize`, `AutoSessionRelogon` (WebSocket API) and
  `EventBufferCapacity`, which bounds the buffer of each subscription (the oldest event is dropped when a slow reader lets it fill up;
  unbounded by default).

`config.ToString()` redacts every secret. A client copies its configuration when it is created; changing it afterwards has no
effect.

Pinning a certificate and trusting a private CA:

```csharp
using Binance.Common;
using System.Security.Cryptography;

var config = new RestApiConfig
{
    CaFile = "/path/to/private-ca.pem",
    ServerCertificateValidator = (certificate, depth, preverified) =>
        depth != 0 ? preverified : certificate.GetCertHashString(HashAlgorithmName.SHA256) == "<SHA-256 of the server certificate>",
};
```

### Models and decoding

- Responses and events are typed models. Amounts the API sends as numbers are `decimal`, ids are `long`, and a field
  that the API documents as a closed set of strings is an extensible enum: a struct with a static member for each known
  value (`NewOrderSide.Buy`) that also carries a value the SDK does not know, so a new value from the server never fails
  a call (`new NewOrderSide("SOMETHING_NEW")`, `Value`).
- A response body that does not decode into the model fails with a `BinanceClientException` whose message names the model and
  starts with the payload. A stream message that does not decode is skipped, logged as a warning and counted in
  `DecodeFailureCount` of the subscription; the stream goes on.
- Values with several possible shapes are `OneOf` types: `TryAs<T>(out var value)` decodes the raw `Json` as one of the
  `AlternativeTypes` (false when it is not one), and `As<T>()` does the same for models and lists, returning null.

### Logging

The log is process-wide. `BinanceLogging.Configure(loggerFactory)` sends it to `ILogger` (the level is the lowest one the
logger enables), `BinanceLogging.SetLevel(BinanceLogLevel.Debug)` sets the level, and `Configure(null)` writes to stderr again.
Without configuration, warnings and errors go to stderr; the `LOG_LEVEL` environment variable (`debug`, `info`, `warn`,
`error` or `none`) changes that. The [`Binance.Common.DependencyInjection`](https://github.com/binance/binance-connector-dotnet/tree/master/src/Binance.Common.DependencyInjection) package configures it for
you.

```csharp
using Binance.Common;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(b => b.AddConsole().SetMinimumLevel(LogLevel.Debug));
BinanceLogging.Configure(loggerFactory);
```


## Supported platforms

The package ships a platform library in `runtimes/<rid>/native/` for each of these runtime identifiers:

| Platform | RID | Oldest version |
| --- | --- | --- |
| Windows x64 / x86 / ARM64 | `win-x64`, `win-x86`, `win-arm64` | Windows 10, Windows Server 2016 |
| Linux (glibc) x64 / ARM64 | `linux-x64`, `linux-arm64` | glibc 2.28: RHEL / AlmaLinux / Rocky 8, Debian 10, Ubuntu 20.04, Amazon Linux 2023 |
| Linux (glibc) 32-bit ARM (for example Raspberry Pi OS) | `linux-arm` | glibc 2.36: Debian 12, Raspberry Pi OS 12 (Bookworm) |
| Linux (musl, for example Alpine) x64 / ARM64 | `linux-musl-x64`, `linux-musl-arm64` | built and tested on Alpine 3.20 |
| macOS Intel / Apple silicon | `osx-x64`, `osx-arm64` | macOS 12 |

The release build checks the oldest glibc and macOS versions that each library needs. On glibc Linux x64 / ARM64 the library
also uses the system's `libstdc++.so.6` (any version since GCC 8), which .NET itself needs.

.NET picks the right one for your system; nothing has to be installed besides the package. A `BinanceLibraryException` at the
first call means that the library for your platform is missing or does not match the package; its message lists the supported
identifiers and the one of the running process.

For diagnostics, the `BINANCE_C_LIB` environment variable can name the path of a platform library to load instead of the shipped one.

## Contributing

Contributions are welcome. See the [root README](https://github.com/binance/binance-connector-dotnet/blob/master/README.md#contributing): open a GitHub issue before making changes and
discuss them with the maintainers. This folder (`src/Binance.Common/`) and its tests (`tests/Binance.Common.Tests/`) are maintained by hand; follow the existing C# structure.

## Disclaimer

This SDK is provided by Binance on an "as is" and "as available" basis for use at your own risk. Binance makes no representations or warranties of any kind, whether express or implied, as to the operation of the SDK, its accuracy, reliability, completeness, or fitness for any particular purpose.

To the fullest extent permitted by law, Binance shall not be liable for any losses, damages, or expenses of any kind arising from or in connection with your use of, or inability to use, this SDK, including but not limited to any financial losses resulting from errors, bugs, interruptions, or inaccuracies in the SDK.

Your use of this SDK to access the Binance Platform is subject to the Binance API Key Terms and the Binance Terms of Use, which shall prevail in the event of any conflict with this disclaimer. You are solely responsible for any orders or transactions executed through the Binance Platform using this SDK.

This SDK is not intended to constitute investment advice or a recommendation to buy, sell, or hold any digital asset. You should independently evaluate and verify all information before acting.

- [Binance Terms of Use](https://www.binance.com/en/terms)
- [Binance API Key Terms](https://www.binance.com/en/about-legal/terms-binance-api)

## License

This project is licensed under the MIT License - see the [LICENCE](https://github.com/binance/binance-connector-dotnet/blob/master/LICENCE) file for details.
