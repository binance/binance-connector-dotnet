# Binance .NET Dual Investment Connector

[![Open Issues](https://img.shields.io/github/issues/binance/binance-connector-dotnet)](https://github.com/binance/binance-connector-dotnet/issues)
[![NuGet version](https://img.shields.io/nuget/v/Binance.DualInvestment)](https://www.nuget.org/packages/Binance.DualInvestment)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Binance.DualInvestment)](https://www.nuget.org/packages/Binance.DualInvestment)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-blue)
[![Docs](https://img.shields.io/badge/docs-online-blue?style=flat-square)](https://binance.github.io/binance-connector-dotnet/api/Binance.DualInvestment.RestApi.html)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This is a client library for the Binance Dual Investment API. Query products, request quotes, and subscribe to Advanced Earn Dual Investment strategies.

It provides a typed REST API client:

- [REST API](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/RestApi/DualInvestmentRestApi.cs)

## Table of Contents

- [Supported Features](#supported-features)
- [Installation](#installation)
- [Documentation](#documentation)
- [REST APIs](#rest-apis)
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
dotnet add package Binance.DualInvestment
```

The platform library (`libbinance_c`) ships inside the package. On a platform it does not support, the first client you create throws a `BinanceLibraryException`. The examples in this repository target **net10.0** and need the .NET 10 SDK; the library itself runs on net8.0 and later.

## Documentation

For detailed information, refer to the [Binance API Documentation](https://developers.binance.com/en/docs/products/dual-investment/Introduction).

### REST APIs

All REST API endpoints are available through the [`DualInvestmentRestApi`](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/RestApi/DualInvestmentRestApi.cs) class. Some endpoints require authentication with your Binance API credentials.

```csharp
using Binance.Common;
using Binance.DualInvestment.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
};
using var client = DualInvestmentRestApi.Production(config);

var response = await client.GetDualInvestmentProductListAsync(new()
{
    OptionType = GetDualInvestmentProductListOptionType.Call,
    ExercisedCoin = "USDT",
    InvestCoin = "BNB",
});

Console.WriteLine(DualInvestmentRestApiJson.ToJson(response.Data()));
```

Every endpoint is a method named after it (`<Operation>Async`) that takes an `<Operation>Request` when it has parameters. The response (`RestApiResponse<T>`) has `Data()`, which decodes the body, `Status`, `RateLimits` and `Headers`. Every client has a factory for each of its environments (`Production`, and `Testnet` / `Demo` where they exist) and `FromConfig(config)` for the endpoint of the configuration.

More examples can be found in the [`examples/Binance.DualInvestment.Examples`](https://github.com/binance/binance-connector-dotnet/tree/master/examples/Binance.DualInvestment.Examples) folder.

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

See the [Timeout example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/timeout.md) for a complete program.

##### Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

See the [Proxy example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/proxy.md) for a complete program.

##### Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

See the [Custom CA Certificates and Certificate Pinning example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/certificate-pinning.md) for a complete program.

##### Client Certificates and Timestamps

A client certificate (mutual TLS) is set with the certificate and its private key, as PEM text or files. `TimestampProvider` returns the time for the `timestamp` of signed requests instead of the host clock (or set `TimeOffset`, a fixed offset added to it).

See the [Client Certificates and Timestamps example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/client-certificates-and-timestamps.md) for a complete program.

##### Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

See the [Keep-Alive example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/keep-alive.md) for a complete program.

##### Compression

Enable or disable response compression (enabled by default).

See the [Compression example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/compression.md) for a complete program.

##### Retries

Configure the number of attempts and the delay between them (`Backoff`, a `TimeSpan`). `GET` and `DELETE` requests are retried after a network error or an HTTP 500, 502, 503 or 504. Every retry of a signed request is signed again.

See the [Retries example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/retries.md) for a complete program.

##### Custom Headers

Add headers to every request.

See the [Custom Headers example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/custom-headers.md) for a complete program.

##### Key Pair Based Authentication

The REST API supports key pair-based authentication for secure communication. You can use `RSA` or `Ed25519` keys for signing requests, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`). Without a private key, `ApiSecret` signs with HMAC-SHA256.

See the [Key Pair Based Authentication example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/key-pair-authentication.md) for a complete program.

`config.ToString()` never prints the key, the secret, the private key or the passphrase.

##### Rate Limits

Every response carries the rate limit counters Binance reports, and the response headers.

```csharp
using var client = DualInvestmentRestApi.Production();
var response = await client.GetDualInvestmentProductListAsync(new()
{
    OptionType = GetDualInvestmentProductListOptionType.Call,
    ExercisedCoin = "USDT",
    InvestCoin = "BNB",
});
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
using var client = DualInvestmentRestApi.Production(config);
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

See the [Error Handling example](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.DualInvestment/docs/rest-api/error-handling.md) for a complete program.

`BinanceException` carries `Kind`, `HttpStatus`, `Code` (the Binance error code), `RetryAfter` (REST 418 and 429), `RetryAt` (WebSocket API), `TransportCode`, `TransportCategory` and `RequestSent`, for a REST error the response that caused it (`Body`, `Headers` and `RateLimits`), and for a WebSocket API error its `WebSocketRateLimits` and `ErrorData` (the `error.data` of the answer). Cancelling a `CancellationToken` cancels the request in flight and throws `OperationCanceledException`.

If you need another endpoint, create the client from a configuration: `new DualInvestmentRestApi(new RestApiConfig { BasePath = "https://..." })`. The default is `DualInvestmentRestApi.ProductionUrl`.

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
dotnet test tests/Binance.DualInvestment.Tests
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
