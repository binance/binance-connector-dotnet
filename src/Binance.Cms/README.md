# Binance .NET CMS Connector

[![Open Issues](https://img.shields.io/github/issues/binance/binance-connector-dotnet)](https://github.com/binance/binance-connector-dotnet/issues)
[![NuGet version](https://img.shields.io/nuget/v/Binance.Cms)](https://www.nuget.org/packages/Binance.Cms)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Binance.Cms)](https://www.nuget.org/packages/Binance.Cms)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-blue)
[![Docs](https://img.shields.io/badge/docs-online-blue?style=flat-square)](https://binance.github.io/binance-connector-dotnet/api/Binance.Cms.WebSocketStreams.html)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This is a client library for the Binance CMS API. Binance announcements in English.

It provides a typed WebSocket Streams client:

- [WebSocket Streams](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/WebSocketStreams/CmsWebSocketStreams.cs)

## Table of Contents

- [Supported Features](#supported-features)
- [Installation](#installation)
- [Documentation](#documentation)
- [WebSocket Streams](#websocket-streams)
- [Logging](#logging)
- [Testing](#testing)
- [Migration Guide](#migration-guide)
- [Contributing](#contributing)
- [Licence](#licence)

## Supported Features

- WebSocket Endpoints: Real-time data streaming.
- Inclusion of test cases and examples for quick onboarding.

## Installation

To use this library, ensure your environment targets **.NET 8** or later (net8.0 and net10.0 are supported; trimming and Native AOT work). Supported platforms: `win-x64`, `win-x86`, `win-arm64`, `linux-x64`, `linux-arm64`, `linux-arm`, `linux-musl-x64`, `linux-musl-arm64`, `osx-x64` and `osx-arm64`.

Then install the library using `dotnet`:

```bash
dotnet add package Binance.Cms
```

The platform library (`libbinance_c`) ships inside the package. On a platform it does not support, the first client you create throws a `BinanceLibraryException`. The examples in this repository target **net10.0** and need the .NET 10 SDK; the library itself runs on net8.0 and later.

## Documentation

For detailed information, refer to the [Binance API Documentation](https://developers.binance.com/en/docs/products/announcements/cms-log).

### WebSocket Streams

WebSocket Streams provide real-time data feeds. Use the [`CmsWebSocketStreams`](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/WebSocketStreams/CmsWebSocketStreams.cs) client: its `ConnectAsync` opens a connection and returns it once it is open, a `CmsWebSocketStreamsConnection` with one method per stream. `ConnectAsync(streams)` subscribes to streams by name on open, and `ConnectAsync(poolSize: n)` opens a pool of `n`. Dispose the connection when done.

```csharp
using Binance.Common;
using Binance.Cms.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
var client = CmsWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.ComAnnouncementEn();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(CmsWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```

`Events` of a subscription is a `ChannelReader<T>`. It completes when the subscription ends (the client is disconnected or disposed, or the subscription is disposed) and faults with a `BinanceException` when the server rejects the SUBSCRIBE, so `await foreach` throws it; a connection the client re-establishes does not end it. `subscription.Completion` and `IsActive` report the same. `subscription.OnMessage(callback)` delivers the events to callbacks instead (every callback gets every event, in order), and `subscription.RunAsync(handler, ct)` runs one handler over the reader.

A message that does not decode as the event type is skipped, not fatal: it is logged as a warning and counted in `subscription.DecodeFailureCount`; the stream goes on.

More examples are available in the [`examples/Binance.Cms.Examples`](https://github.com/binance/binance-connector-dotnet/tree/master/examples/Binance.Cms.Examples) folder.

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

See the [Reconnect Delay example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/docs/websocket-streams/reconnect-delay.md) for a complete program.

##### Compression

Enable or disable compression for WebSocket Streams messages.

See the [Compression example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/docs/websocket-streams/compression.md) for a complete program.

##### Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

See the [Connection Mode example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/docs/websocket-streams/connection-mode.md) for a complete program.

##### Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

See the [Custom CA Certificates and Certificate Pinning example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/docs/websocket-streams/certificate-pinning.md) for a complete program.

##### Key Pair Based Authentication

The streams of this product are signed. You can sign the connections with an `RSA` or `Ed25519` key instead of `ApiSecret`, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`).

See the [Key Pair Based Authentication example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Cms/docs/websocket-streams/key-pair-authentication.md) for a complete program.

#### Unsubscribing from Streams

You can unsubscribe from a stream with `Unsubscribe()` (or by disposing its subscription). This is useful for managing active subscriptions without closing the connection.

```csharp
using Binance.Common;
using Binance.Cms.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
var client = CmsWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

var subscription = connection.ComAnnouncementEn();

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
var client = CmsWebSocketStreams.Production();
await using var connection = await client.ConnectAsync();
using var subscription = connection.Subscribe("name-of-the-stream");
await subscription.WaitSubscribedAsync();
Console.WriteLine(connection.IsSubscribed("name-of-the-stream"));
await foreach (var e in subscription.Events.ReadAllAsync())
    Console.WriteLine(e);
```

If you need another endpoint, set `Url` of the configuration: `new CmsWebSocketStreams(new WebSocketStreamsConfig { Url = "wss://..." })`. The default is `CmsWebSocketStreams.ProductionUrl`.

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
dotnet test tests/Binance.Cms.Tests
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
