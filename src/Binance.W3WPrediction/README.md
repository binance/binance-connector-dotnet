# Binance .NET W3W Prediction Connector

[![Open Issues](https://img.shields.io/github/issues/binance/binance-connector-dotnet)](https://github.com/binance/binance-connector-dotnet/issues)
[![NuGet version](https://img.shields.io/nuget/v/Binance.W3WPrediction)](https://www.nuget.org/packages/Binance.W3WPrediction)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Binance.W3WPrediction)](https://www.nuget.org/packages/Binance.W3WPrediction)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-blue)
[![Docs](https://img.shields.io/badge/docs-online-blue?style=flat-square)](https://binance.github.io/binance-connector-dotnet/api/Binance.W3WPrediction.RestApi.html)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This is a client library for the Binance W3W Prediction API. Place and manage prediction market orders, query positions, and transfer funds via the Prediction Trading REST API.

It provides typed REST API and WebSocket Streams clients:

- [REST API](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/RestApi/W3WPredictionRestApi.cs)
- [WebSocket Streams](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/WebSocketStreams/W3WPredictionWebSocketStreams.cs)

## Table of Contents

- [Supported Features](#supported-features)
- [Installation](#installation)
- [Documentation](#documentation)
- [REST APIs](#rest-apis)
- [WebSocket Streams](#websocket-streams)
- [Logging](#logging)
- [Testing](#testing)
- [Migration Guide](#migration-guide)
- [Contributing](#contributing)
- [Licence](#licence)

## Supported Features

- REST API Endpoints:
  - `/sapi/*`
- WebSocket Endpoints: Real-time data streaming.
- Inclusion of test cases and examples for quick onboarding.

## Installation

To use this library, ensure your environment targets **.NET 8** or later (net8.0 and net10.0 are supported; trimming and Native AOT work). Supported platforms: `win-x64`, `win-x86`, `win-arm64`, `linux-x64`, `linux-arm64`, `linux-arm`, `linux-musl-x64`, `linux-musl-arm64`, `osx-x64` and `osx-arm64`.

Then install the library using `dotnet`:

```bash
dotnet add package Binance.W3WPrediction
```

The platform library (`libbinance_c`) ships inside the package. On a platform it does not support, the first client you create throws a `BinanceLibraryException`. The examples in this repository target **net10.0** and need the .NET 10 SDK; the library itself runs on net8.0 and later.

## Documentation

For detailed information, refer to the [Binance API Documentation](https://developers.binance.com/en/docs/products/w3w-prediction/change-log).

### REST APIs

All REST API endpoints are available through the [`W3WPredictionRestApi`](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/RestApi/W3WPredictionRestApi.cs) class. Some endpoints require authentication with your Binance API credentials.

```csharp
using Binance.Common;
using Binance.W3WPrediction.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
using var client = W3WPredictionRestApi.Production(config);

var response = await client.ListPredictionCategoriesAsync();

Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
```

Every endpoint is a method named after it (`<Operation>Async`) that takes an `<Operation>Request` when it has parameters. The response (`RestApiResponse<T>`) has `Data()`, which decodes the body, `Status`, `RateLimits` and `Headers`. Every client has a factory for each of its environments (`Production`, and `Testnet` / `Demo` where they exist) and `FromConfig(config)` for the endpoint of the configuration.

More examples can be found in the [`examples/Binance.W3WPrediction.Examples`](https://github.com/binance/binance-connector-dotnet/tree/master/examples/Binance.W3WPrediction.Examples) folder.

#### Configuration Options

The REST API supports the following advanced configuration options through `RestApiConfig`:

- `Timeout`: How long a request attempt may take as a whole (connecting, writing the request and reading the response), a `TimeSpan` (default: 1 s).
- `Proxy`: Proxy configuration (`ProxyConfig`):
  - `Host`: Proxy server hostname.
  - `Port`: Proxy server port.
  - `Protocol`: Proxy protocol, a `ProxyProtocol` (`Http`, `Https`, `Socks5` or `Socks5h`; the SOCKS5 protocols run over plain TCP, `Socks5h` lets the proxy resolve the host name).
  - `Username` / `Password`: Proxy authentication credentials (Basic).
- `ProxyFromEnv`: Read `HTTPS_PROXY`, `HTTP_PROXY`, `ALL_PROXY` and `NO_PROXY` from the environment (default: true). `Proxy` wins over the environment.
- `KeepAlive`: Enable HTTP keep-alive (default: true).
- `Compression`: Enable response compression (default: true).
- `Retries`: Total attempts for failed requests (default: 3).
- `Backoff`: Delay between retries, a `TimeSpan`; attempt `n` waits `n * Backoff` (default: 1 s).
- `CustomHeaders`: Headers added to every request.
- `MaxResponseSize`: Largest response body accepted, in bytes (default: 128 MiB).
- `ApiKey` / `ApiSecret`: API key and HMAC secret.
- `PrivateKeyPem` / `PrivateKeyFile`: RSA or Ed25519 private key for authentication, as PEM text or as the path of a PEM file.
- `PrivateKeyPassphrase`: Passphrase for the private key, if encrypted.
- `CaFile` / `CaPem`: PEM bundle (path or text) whose CAs are trusted in addition to the system store, for example a private CA.
- `CaOnly`: Trust only `CaFile` / `CaPem`, not the system store.
- `ServerCertificateValidator`: Called with each certificate of the chain, to pin a certificate or to take over the decision.
- `ClientCertificatePem` / `ClientCertificateFile` with `ClientKeyPem` / `ClientKeyFile` and `ClientKeyPassphrase`: A client certificate for mutual TLS.
- `TimeOffset` / `TimestampProvider`: A fixed offset added to the host clock, or a function returning the time, for the `timestamp` of signed requests.

##### Timeout

You can configure a timeout for requests (a `TimeSpan`). If an attempt takes longer than the timeout (connecting, writing the request and reading the whole response), it is aborted with a `BinanceTimeoutException`.

See the [Timeout example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/timeout.md) for a complete program.

##### Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

See the [Proxy example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/proxy.md) for a complete program.

##### Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

See the [Custom CA Certificates and Certificate Pinning example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/certificate-pinning.md) for a complete program.

##### Client Certificates and Timestamps

A client certificate (mutual TLS) is set with the certificate and its private key, as PEM text or files. `TimestampProvider` returns the time for the `timestamp` of signed requests instead of the host clock (or set `TimeOffset`, a fixed offset added to it).

See the [Client Certificates and Timestamps example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/client-certificates-and-timestamps.md) for a complete program.

##### Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

See the [Keep-Alive example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/keep-alive.md) for a complete program.

##### Compression

Enable or disable response compression (enabled by default).

See the [Compression example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/compression.md) for a complete program.

##### Retries

Configure the number of attempts and the delay between them (`Backoff`, a `TimeSpan`). `GET` and `DELETE` requests are retried after a network error or an HTTP 500, 502, 503 or 504. Every retry of a signed request is signed again.

See the [Retries example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/retries.md) for a complete program.

##### Custom Headers

Add headers to every request.

See the [Custom Headers example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/custom-headers.md) for a complete program.

##### Key Pair Based Authentication

The REST API supports key pair-based authentication for secure communication. You can use `RSA` or `Ed25519` keys for signing requests, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`). Without a private key, `ApiSecret` signs with HMAC-SHA256.

See the [Key Pair Based Authentication example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/key-pair-authentication.md) for a complete program.

`config.ToString()` never prints the key, the secret, the private key or the passphrase.

##### Rate Limits

Every response carries the rate limit counters Binance reports, and the response headers.

```csharp
using var client = W3WPredictionRestApi.Production();
var response = await client.ListPredictionCategoriesAsync();
foreach (var limit in response.RateLimits)
    Console.WriteLine(limit);
```

##### Endpoints Without a Method

`SendRequestAsync` and `SendSignedRequestAsync` call any endpoint, for example one added to the API after this release. The parameters are encoded, and the request signed, as for the other methods; the body comes back as raw JSON.

```csharp
var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
using var client = W3WPredictionRestApi.Production(config);
var response = await client.SendSignedRequestAsync("/path/of/the/endpoint", HttpMethod.Get,
    new Dictionary<string, object?> { ["name"] = "value", ["limit"] = 10 });
Console.WriteLine(response.Data());
```

#### Error Handling

The REST API provides detailed error types to help you handle issues effectively. Every error derives from `BinanceException`:

- `BinanceBadRequestException`: Invalid request (HTTP 400).
- `BinanceUnauthorizedException`: Missing or invalid authentication credentials (HTTP 401).
- `BinanceForbiddenException`: Access to the requested resource is forbidden (HTTP 403).
- `BinanceNotFoundException`: Resource not found (HTTP 404).
- `BinanceConflictException`: The request conflicts with the current state of the resource (HTTP 409).
- `BinanceRateLimitBanException`: IP address banned for exceeding rate limits (HTTP 418).
- `BinanceTooManyRequestsException`: Rate limit exceeded (HTTP 429).
- `BinanceServerException`: Internal server error (HTTP 5xx).
- `BinanceNetworkException`: Issues with network connectivity; `BinanceTimeoutException` is an attempt that took longer than `Timeout`.
- `BinanceClientException`: General client error (unexpected status, malformed response).
- `BinanceConfigException`: Invalid configuration or request.
- `BinanceCancelledException`: The operation was cancelled (for example the client was disposed).

See the [Error Handling example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/rest-api/error-handling.md) for a complete program.

`BinanceException` carries `Kind`, `HttpStatus`, `Code` (the Binance error code), `RetryAfter` (REST 418 and 429), `RetryAt` (WebSocket API), `TransportCode`, `TransportCategory` and `RequestSent`, for a REST error the response that caused it (`Body`, `Headers` and `RateLimits`), and for a WebSocket API error its `WebSocketRateLimits` and `ErrorData` (the `error.data` of the answer). Cancelling a `CancellationToken` cancels the request in flight and throws `OperationCanceledException`.

If you need another endpoint, create the client from a configuration: `new W3WPredictionRestApi(new RestApiConfig { BasePath = "https://..." })`. The default is `W3WPredictionRestApi.ProductionUrl`.

### WebSocket Streams

WebSocket Streams provide real-time data feeds. Use the [`W3WPredictionWebSocketStreams`](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/WebSocketStreams/W3WPredictionWebSocketStreams.cs) client: its `ConnectAsync` opens a connection and returns it once it is open, a `W3WPredictionWebSocketStreamsConnection` with one method per stream. `ConnectAsync(streams)` subscribes to streams by name on open, and `ConnectAsync(poolSize: n)` opens a pool of `n`. Dispose the connection when done.

```csharp
using Binance.Common;
using Binance.W3WPrediction.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
var client = W3WPredictionWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.BatchClaimPartiallySucceeded();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(W3WPredictionWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```

`Events` of a subscription is a `ChannelReader<T>`. It completes when the subscription ends (the client is disconnected or disposed, or the subscription is disposed) and faults with a `BinanceException` when the server rejects the SUBSCRIBE, so `await foreach` throws it; a connection the client re-establishes does not end it. `subscription.Completion` and `IsActive` report the same. `subscription.OnMessage(callback)` delivers the events to callbacks instead (every callback gets every event, in order), and `subscription.RunAsync(handler, ct)` runs one handler over the reader.

A message that does not decode as the event type is skipped, not fatal: it is logged as a warning and counted in `subscription.DecodeFailureCount`; the stream goes on.

More examples are available in the [`examples/Binance.W3WPrediction.Examples`](https://github.com/binance/binance-connector-dotnet/tree/master/examples/Binance.W3WPrediction.Examples) folder.

The streams of this product are signed: set `ApiKey` and `ApiSecret` (or `PrivateKeyPem` / `PrivateKeyFile`) in the `WebSocketStreamsConfig`.

#### Configuration Options

The WebSocket Streams client supports the following advanced configuration options through `WebSocketStreamsConfig`:

- `ReconnectDelay`: The delay between reconnection attempts, a `TimeSpan` (default: 5 s); after a failed attempt, a backoff of 1 s doubling up to 60 s, with random jitter, is added to it.
- `ConnectTimeout`: How long connecting may take, a `TimeSpan` (default: 10 s).
- `Compression`: Enable or disable compression for WebSocket messages (default: true).
- `Mode`: `WebSocketMode.Single` (the default) or `WebSocketMode.Pool(n)`, a pool of `n` connections.
- `MaxMessageSize`: Largest message accepted, in bytes (default: 64 MiB).
- `EventBufferCapacity`: Capacity of the buffer of each subscription; when it is full the oldest event is dropped. Unbounded by default.
- `Proxy` / `ProxyFromEnv`: As for the REST API, but `ProxyFromEnv` is false by default, as in the other Binance connectors.
- `CaFile` / `CaPem` / `CaOnly` / `ServerCertificateValidator`, the client certificate and `TimeOffset` / `TimestampProvider`: As for the REST API.

##### Reconnect Delay

Specify the delay between WebSocket reconnection attempts for streams (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it. After a reconnect the client subscribes again to every stream.

See the [Reconnect Delay example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/websocket-streams/reconnect-delay.md) for a complete program.

##### Compression

Enable or disable compression for WebSocket Streams messages.

See the [Compression example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/websocket-streams/compression.md) for a complete program.

##### Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

See the [Connection Mode example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/websocket-streams/connection-mode.md) for a complete program.

##### Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

See the [Custom CA Certificates and Certificate Pinning example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/websocket-streams/certificate-pinning.md) for a complete program.

##### Key Pair Based Authentication

The streams of this product are signed. You can sign the connections with an `RSA` or `Ed25519` key instead of `ApiSecret`, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`).

See the [Key Pair Based Authentication example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.W3WPrediction/docs/websocket-streams/key-pair-authentication.md) for a complete program.

#### Unsubscribing from Streams

You can unsubscribe from a stream with `Unsubscribe()` (or by disposing its subscription). This is useful for managing active subscriptions without closing the connection.

```csharp
using Binance.Common;
using Binance.W3WPrediction.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
var client = W3WPredictionWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

var subscription = connection.BatchClaimPartiallySucceeded();

await Task.Delay(TimeSpan.FromSeconds(10));
subscription.Unsubscribe();
Console.WriteLine("Unsubscribed");
```

`PingServer()` sends a WebSocket ping frame on every open connection, and `connection.Events` (or `connection.OnEvent(callback)`) carries the lifecycle events (open, close, error, ping, pong).

A subscription delivers its events either to its `Events` reader or to callbacks, like `on('message', ...)` of the other connectors: every callback added with `OnMessage` gets every event, in order. `WaitSubscribedAsync()` completes once the server has acknowledged the subscription, and fails with `BinanceWebSocketResponseException` if the server rejects it.

```csharp
using var callback = subscription.OnMessage(e => Console.WriteLine(e));
await subscription.WaitSubscribedAsync();
```

#### Streams by Name

`Subscribe("name-of-the-stream")` takes any stream name and returns a subscription with its events as raw JSON. `Subscribe([...])` and `Unsubscribe([...])` subscribe and unsubscribe stream names without a subscription object, like `subscribe` and `unsubscribe` of the other connectors; their messages reach `connection.EnableMessages()` (a reader of every message as the server sent it) or `connection.OnMessage(callback)`. `IsSubscribed` tells whether a stream is subscribed, and `ConnectAsync(streams)` subscribes streams through the connection URL.

```csharp
var client = W3WPredictionWebSocketStreams.Production();
await using var connection = await client.ConnectAsync();
using var subscription = connection.Subscribe("name-of-the-stream");
await subscription.WaitSubscribedAsync();
Console.WriteLine(connection.IsSubscribed("name-of-the-stream"));
await foreach (var e in subscription.Events.ReadAllAsync())
    Console.WriteLine(e);
```

If you need another endpoint, set `Url` of the configuration: `new W3WPredictionWebSocketStreams(new WebSocketStreamsConfig { Url = "wss://..." })`. The default is `W3WPredictionWebSocketStreams.ProductionUrl`.

### Automatic Connection Renewal

The WebSocket connection is automatically renewed for both WebSocket API and WebSocket Streams connections, before the 24 hours expiration of the connection, and when the server announces its shutdown. The subscriptions and the session logon are restored. This ensures continuous connectivity.

## Logging

`BinanceLogging.Configure(loggerFactory)` sends the log of the connectors, which is process-wide, to `Microsoft.Extensions.Logging`, and `BinanceLogging.SetLevel(BinanceLogLevel.Debug)` sets the level. The optional `Binance.Common.DependencyInjection` package does it for you.

```csharp
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(b => b.AddConsole().SetMinimumLevel(LogLevel.Debug));
BinanceLogging.Configure(loggerFactory);
```

## Testing

To run the tests of this connector:

```bash
dotnet test tests/Binance.W3WPrediction.Tests
```

The tests run the connector against a loopback server with the example responses documented for the API. They cover every operation, WebSocket API request and stream, and the decoding of the models. They need the platform support described in [`Binance.Common/README.md`](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Common/README.md).

## Migration Guide

If you are moving from the 4.x connector (the single `Binance.Spot` 4.x package), refer to the [Migration Guide](https://github.com/binance/binance-connector-dotnet/blob/master/MIGRATION.md) for detailed steps.

## Contributing

Contributions are welcome. Please open a GitHub issue to discuss your idea or report a bug before sending a pull request. The code of this connector (and its examples and tests) is maintained from the Binance API definitions, so changes to it are made there; edits made by hand in this folder would be overwritten. Make sure all tests pass if you contribute a change.

## Disclaimer

This SDK is provided by Binance on an "as is" and "as available" basis for use at your own risk. Binance makes no representations or warranties of any kind, whether express or implied, as to the operation of the SDK, its accuracy, reliability, completeness, or fitness for any particular purpose.

To the fullest extent permitted by law, Binance shall not be liable for any losses, damages, or expenses of any kind arising from or in connection with your use of, or inability to use, this SDK, including but not limited to any financial losses resulting from errors, bugs, interruptions, or inaccuracies in the SDK.

Your use of this SDK to access the Binance Platform is subject to the Binance API Key Terms and the Binance Terms of Use, which shall prevail in the event of any conflict with this disclaimer. You are solely responsible for any orders or transactions executed through the Binance Platform using this SDK.

This SDK is not intended to constitute investment advice or a recommendation to buy, sell, or hold any digital asset. You should independently evaluate and verify all information before acting.

- [Binance Terms of Use](https://www.binance.com/en/terms)
- [Binance API Key Terms](https://www.binance.com/en/about-legal/terms-binance-api)

## Licence

This project is licensed under the MIT License. See the [LICENCE](https://github.com/binance/binance-connector-dotnet/blob/master/LICENCE) file for details.
