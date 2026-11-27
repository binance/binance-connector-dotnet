# Binance .NET Connector

[![Build Status](https://img.shields.io/github/actions/workflow/status/binance/binance-connector-dotnet/ci.yaml)](https://github.com/binance/binance-connector-dotnet/actions)
[![Open Issues](https://img.shields.io/github/issues/binance/binance-connector-dotnet)](https://github.com/binance/binance-connector-dotnet/issues)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-blue)
[![Docs](https://img.shields.io/badge/docs-online-blue?style=flat-square)](https://binance.github.io/binance-connector-dotnet/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Official collection of .NET connectors for Binance APIs.

Every connector offers typed REST API, WebSocket API and WebSocket Streams clients, built on the shared
[`Binance.Common`](./src/Binance.Common/README.md) library (configuration, signing, errors, logging and connection management).

## Migration Guide

If you're upgrading from the previous 4.x connector, refer to our [Migration Guide](./MIGRATION.md) for detailed steps on transitioning to the new modular structure. The legacy connector will still be available for a limited time. You can find the code for the old connector in the `legacy` branch.

## Prerequisites

Before using the connectors, ensure you have:

- **.NET 8 or later** (the packages target net8.0 and net10.0); to build this repository, the **.NET SDK 10** (see [`global.json`](https://github.com/binance/binance-connector-dotnet/blob/master/global.json))
- **Examples:** the projects under [`examples/`](https://github.com/binance/binance-connector-dotnet/tree/master/examples) target net10.0, so running them needs the .NET 10 SDK; the packages themselves run on net8.0 and later
- **Supported platforms:** `win-x64`, `win-x86`, `win-arm64`, `linux-x64`, `linux-arm64`, `linux-arm`, `linux-musl-x64`, `linux-musl-arm64`, `osx-x64` and `osx-arm64` (see [`src/Binance.Common/README.md`](./src/Binance.Common/README.md#supported-platforms))

Install or update .NET from [dot.net](https://dotnet.microsoft.com/download) and check it with:

```bash
dotnet --version
```

## Available Connectors

Each connector is a NuGet package and a project under [`src/`](https://github.com/binance/binance-connector-dotnet/tree/master/src) (`src/Binance.<Product>/`). Install only the ones you need:

- [`algo`](./src/Binance.Algo/README.md) - Algo Trading connector (`Binance.Algo`)
- [`alpha`](./src/Binance.Alpha/README.md) - Alpha connector (`Binance.Alpha`)
- [`c2c`](./src/Binance.C2C/README.md) - C2C connector (`Binance.C2C`)
- [`cms`](./src/Binance.Cms/README.md) - CMS (Binance announcements) connector, WebSocket Streams only (`Binance.Cms`)
- [`convert`](./src/Binance.Convert/README.md) - Convert connector (`Binance.Convert`)
- [`copy_trading`](./src/Binance.CopyTrading/README.md) - Copy Trading connector (`Binance.CopyTrading`)
- [`crypto_loan`](./src/Binance.CryptoLoan/README.md) - Crypto Loan connector (`Binance.CryptoLoan`)
- [`derivatives_trading_coin_futures`](./src/Binance.DerivativesTradingCoinFutures/README.md) - Derivatives Trading (COIN-M Futures) connector (`Binance.DerivativesTradingCoinFutures`)
- [`derivatives_trading_options`](./src/Binance.DerivativesTradingOptions/README.md) - Derivatives Trading (Options) connector (`Binance.DerivativesTradingOptions`)
- [`derivatives_trading_portfolio_margin`](./src/Binance.DerivativesTradingPortfolioMargin/README.md) - Derivatives Trading (Portfolio Margin) connector (`Binance.DerivativesTradingPortfolioMargin`)
- [`derivatives_trading_portfolio_margin_pro`](./src/Binance.DerivativesTradingPortfolioMarginPro/README.md) - Derivatives Trading (Portfolio Margin Pro) connector (`Binance.DerivativesTradingPortfolioMarginPro`)
- [`derivatives_trading_usds_futures`](./src/Binance.DerivativesTradingUsdsFutures/README.md) - Derivatives Trading (USDS-M Futures) connector (`Binance.DerivativesTradingUsdsFutures`)
- [`dual_investment`](./src/Binance.DualInvestment/README.md) - Dual Investment connector (`Binance.DualInvestment`)
- [`fiat`](./src/Binance.Fiat/README.md) - Fiat connector (`Binance.Fiat`)
- [`gift_card`](./src/Binance.GiftCard/README.md) - Gift Card connector (`Binance.GiftCard`)
- [`margin_trading`](./src/Binance.MarginTrading/README.md) - Margin Trading connector (`Binance.MarginTrading`)
- [`mining`](./src/Binance.Mining/README.md) - Mining connector (`Binance.Mining`)
- [`pay`](./src/Binance.Pay/README.md) - Pay connector (`Binance.Pay`)
- [`rebate`](./src/Binance.Rebate/README.md) - Rebate connector (`Binance.Rebate`)
- [`simple_earn`](./src/Binance.SimpleEarn/README.md) - Simple Earn connector (`Binance.SimpleEarn`)
- [`spot`](./src/Binance.Spot/README.md) - Spot Trading connector (`Binance.Spot`)
- [`staking`](./src/Binance.Staking/README.md) - Staking connector (`Binance.Staking`)
- [`stock_options`](./src/Binance.StockOptions/README.md) - Stock Options connector (`Binance.StockOptions`)
- [`stocks`](./src/Binance.Stocks/README.md) - Stocks connector (`Binance.Stocks`)
- [`sub_account`](./src/Binance.SubAccount/README.md) - Sub Account connector (`Binance.SubAccount`)
- [`vip_loan`](./src/Binance.VipLoan/README.md) - VIP Loan connector (`Binance.VipLoan`)
- [`w3w_prediction`](./src/Binance.W3WPrediction/README.md) - W3W Prediction connector (`Binance.W3WPrediction`)
- [`wallet`](./src/Binance.Wallet/README.md) - Wallet connector (`Binance.Wallet`)

The `cms` and `w3w_prediction` WebSocket Streams are signed: set `ApiKey` and `ApiSecret` (or `PrivateKeyPem` /
`PrivateKeyFile`) in the `WebSocketStreamsConfig`.

## Documentation

- **API reference:** [binance.github.io/binance-connector-dotnet](https://binance.github.io/binance-connector-dotnet/)
- **Common library:** [`src/Binance.Common/README.md`](./src/Binance.Common/README.md): configuration, error handling, logging and the supported platforms.
- **Examples:** [`examples/Binance.<Product>.Examples/`](https://github.com/binance/binance-connector-dotnet/tree/master/examples) has one runnable example for every endpoint, named after the operation (`examples/Binance.Spot.Examples/RestApi/Market/Klines.cs`). Run one with `dotnet run --project examples/Binance.Spot.Examples -- RestApi/Market/Klines`; without an argument the project lists them.
- **Tests:** [`tests/Binance.<Product>.Tests/`](./tests/README.md) has a test for every operation, WebSocket API request and stream, run against a loopback server with the example response documented for the API.
- **Official Binance API docs:** [Binance API Documentation](https://developers.binance.com)

## Installation

Each connector is published as a separate NuGet package. For example:

```bash
dotnet add package Binance.Spot
```

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

using var rest = SpotRestApi.Production(new RestApiConfig
{
    ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
});
var time = await rest.TimeAsync();
Console.WriteLine(time.Data()!.ServerTime);
```

The platform library (`libbinance_c`) ships inside the packages; on a platform it does not support, the first client you create throws a `BinanceLibraryException`.

A signed order on the Spot testnet (create testnet keys at [testnet.binance.vision](https://testnet.binance.vision)); the credentials come from the `API_KEY` and `API_SECRET` environment variables:

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

using var client = SpotRestApi.Testnet(new RestApiConfig
{
    ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
});

try
{
    var response = await client.NewOrderAsync(new()
    {
        Symbol = "BTCUSDT",
        Side = NewOrderSide.Buy,
        Type = NewOrderType.Market,
        Quantity = 0.001m,
    });
    Console.WriteLine($"Order {response.Data()!.OrderId} placed");
}
catch (BinanceException e)
{
    Console.Error.WriteLine($"{e.Kind} {e.Code}: {e.Message}");
}
```

To sign with a private key instead of an HMAC secret, set `PrivateKeyFile = "/path/to/ed25519-private-key.pem"` (or `PrivateKeyPem`) in place of `ApiSecret`.

```csharp
using Binance.Spot.WebSocketStreams;

var client = SpotWebSocketStreams.Production();
await using var connection = await client.ConnectAsync();
using var trades = connection.AggTrade(new() { Symbol = "btcusdt" });
await foreach (var trade in trades.Events.ReadAllAsync())
    Console.WriteLine($"{trade.S} {trade.P}");
```

As in the other Binance connectors, the WebSocket clients hold the configuration, and `ConnectAsync()` returns an open connection
with the methods.

Each module (`RestApi`, `WebSocketApi`, `WebSocketStreams`) has factories for its environments: `Production`, `Testnet`
and, where available, `Demo`. The README of every connector, in [`src/Binance.<Product>/`](https://github.com/binance/binance-connector-dotnet/tree/master/src), has more, including the
configuration options (timeouts, retries, proxies, custom CAs and certificate pinning), error handling and logging.

### Dependency injection

The optional `Binance.Common.DependencyInjection` package registers any client:

```csharp
services.AddBinanceRestApi<SpotRestApi>(SpotRestApi.Production, o => o.ApiKey = Environment.GetEnvironmentVariable("API_KEY"));
```

### Logging

`BinanceLogging.Configure(loggerFactory)` sends the log, which is process-wide, to `ILogger`.

### Versioning

Releases follow [Semantic Versioning](https://semver.org). Version `5.0.0` replaces the HttpClient based 4.x connector, see
[MIGRATION.md](./MIGRATION.md). All packages share one version, set in [`Directory.Build.props`](https://github.com/binance/binance-connector-dotnet/blob/master/Directory.Build.props).

### Building from source

```bash
dotnet build Binance.slnx -c Release
dotnet format whitespace Binance.slnx --verify-no-changes
dotnet test Binance.slnx --filter "Category!=Native"        # tests that do not load the platform library
dotnet test Binance.slnx                                    # everything (needs the platform library for your system, see below)
```

Tests marked `[Trait("Category", "Native")]` load the platform library, which comes from
[binance-connector-cpp](https://github.com/binance/binance-connector-cpp): the packages ship the release named in
[`src/Binance.Common/native-version.txt`](https://github.com/binance/binance-connector-dotnet/blob/master/src/Binance.Common/native-version.txt). `make native-download` fetches that
release's library for your system (with curl and unzip; `NATIVE_RID=<rid>` picks another), and `make test` then uses it:

```bash
make native-download && make test
```

To change the C interface, build the library from a clone of binance-connector-cpp next to this repository (or
`NATIVE_SRC=<path>`) with `make native`. It needs CMake 3.24+, Ninja, a C++20 compiler and
[vcpkg](https://github.com/microsoft/vcpkg) with `VCPKG_ROOT` set:

```bash
brew install cmake ninja                               # macOS (with the Xcode command line tools)
sudo apt install build-essential cmake ninja-build     # Debian / Ubuntu
git clone https://github.com/microsoft/vcpkg.git ~/vcpkg && ~/vcpkg/bootstrap-vcpkg.sh && export VCPKG_ROOT=~/vcpkg
git clone https://github.com/binance/binance-connector-cpp.git ../binance-connector-cpp
make native && make test
```

`make help` lists the other targets.

To pack, put the libraries into
`src/Binance.Common/runtimes/<rid>/native/` (they are not committed; see [`src/Binance.Common/README.md`](./src/Binance.Common/README.md#supported-platforms) for the override), and run `dotnet pack`.

#### The project list

`Binance.slnx` (the solution file) lists the projects of `src/*`, `examples/*` and `tests/*`. After adding a
product, run

```bash
scripts/update-slnx.sh
```

It writes the file from the projects on disk, one solution folder for each of `src`, `examples` and `tests`: running it
twice changes nothing, and a deleted project drops out.

## Contributing

We encourage you to:

1. Open a GitHub issue to discuss your ideas or report bugs
2. Allow maintainers to implement the necessary changes

The connector projects (`src/Binance.<Product>/`, `examples/Binance.<Product>.Examples/` and `tests/Binance.<Product>.Tests/`) are maintained from the Binance API definitions, so a change to them is made there; manual edits to those folders would be overwritten. `src/Binance.Common/`, `src/Binance.Common.DependencyInjection/` and `tests/Binance.Common.Tests/` (with the test support shared by the product tests) are maintained by hand and take pull requests as usual.

## Disclaimer

This SDK is provided by Binance on an "as is" and "as available" basis for use at your own risk. Binance makes no representations or warranties of any kind, whether express or implied, as to the operation of the SDK, its accuracy, reliability, completeness, or fitness for any particular purpose.

To the fullest extent permitted by law, Binance shall not be liable for any losses, damages, or expenses of any kind arising from or in connection with your use of, or inability to use, this SDK, including but not limited to any financial losses resulting from errors, bugs, interruptions, or inaccuracies in the SDK.

Your use of this SDK to access the Binance Platform is subject to the Binance API Key Terms and the Binance Terms of Use, which shall prevail in the event of any conflict with this disclaimer. You are solely responsible for any orders or transactions executed through the Binance Platform using this SDK.

This SDK is not intended to constitute investment advice or a recommendation to buy, sell, or hold any digital asset. You should independently evaluate and verify all information before acting.

- [Binance Terms of Use](https://www.binance.com/en/terms)
- [Binance API Key Terms](https://www.binance.com/en/about-legal/terms-binance-api)

## License

This project is licensed under the MIT License - see the [LICENCE](https://github.com/binance/binance-connector-dotnet/blob/master/LICENCE) file for details.
