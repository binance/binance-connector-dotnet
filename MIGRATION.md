# **Migration Guide: Transition from the Legacy HttpClient .NET Connector**

With the move towards product-specific connectors, version 5.0 replaces the single `Binance.Spot` 4.x package, which implemented signing, HTTP and WebSocket handling in C#, with one package per Binance product. Signing, retries and reconnects are built in. This guide explains how to migrate from the 4.x connector to the new modular connectors. The 4.x code remains on the `legacy` branch.

## Overview of Changes

| Feature | Legacy 4.x Connector | New 5.0 Connectors |
| --- | --- | --- |
| Packages | `Binance.Spot` for everything in Spot and SAPI (its shared code bundled in the package) | `Binance.<Product>` (`Binance.Spot`, `Binance.Wallet`, `Binance.DerivativesTradingUsdsFutures`, ...), each depending on the new `Binance.Common` package |
| Target | netstandard2.0 | net8.0 and net10.0 (trimming and Native AOT supported) |
| REST | one class per group (`Market`, `SpotAccountTrade`, ...) built with a base URL and keys | `SpotRestApi.Production(config)`; one `<Operation>Async` method per endpoint |
| Parameters | positional arguments (`NewOrder(symbol, side, type, ...)`) | `<Operation>Request` objects with `required` members |
| Results | the response body as a `string` | `RestApiResponse<T>`: typed `Data()`, `Status`, `RateLimits`, `Headers` |
| Numbers | `decimal` arguments | amounts the API documents as numbers are `decimal`; amounts the API sends as strings stay `string` |
| Enums | C# enums (`Models.Side.BUY`) | extensible string-backed structs (`NewOrderSide.Buy`), which also carry values the SDK does not know |
| Signing | `BinanceHmac`, `BinanceRsa` passed to each class | `ApiSecret`, or `PrivateKeyPem` / `PrivateKeyFile` + `PrivateKeyPassphrase` (RSA or Ed25519) in the config |
| WebSocket streams | `MarketDataWebSocket(stream)` + `OnMessageReceived` callback | `SpotWebSocketStreams` client, whose `ConnectAsync()` returns a connection with one method per stream; typed events on a `ChannelReader<T>` or `OnMessage` callbacks |
| WebSocket API | `WebSocketApi` with `General`, `Market`, `AccountTrade`, `UserDataStream` | `SpotWebSocketApi` client, whose `ConnectAsync()` returns a connection with one method per request, `WebSocketApiResponse<T>` |
| Errors | `BinanceClientException` (HTTP 4xx), `BinanceServerException` (HTTP 5xx) | `BinanceException` and subclasses: `BinanceBadRequestException`, `BinanceTooManyRequestsException`, ... for HTTP 4xx, `BinanceServerException` for 5xx; `BinanceClientException` now means an unexpected status or a response that does not decode |
| Retries, reconnects | none, or by hand | built in (`Retries`, `Backoff`, `ReconnectDelay`, ...) |
| Logging | `Microsoft.Extensions.Logging` per class | `BinanceLogging.Configure(loggerFactory)` (process-wide) |

## Migration Steps

### Step 1: Replace the Packages

```bash
dotnet add package Binance.Spot   # 5.x replaces 4.x: a different library under the same id
```

Add the package of every other product you used: `Binance.Wallet`, `Binance.SubAccount`, `Binance.MarginTrading`,
`Binance.Mining`, `Binance.Convert`, ... The old classes map to products like this:

| 4.x class | 5.0 |
| --- | --- |
| `Market`, `SpotAccountTrade` | `Binance.Spot` |
| `UserDataStreams` | Spot: the user data stream of the WebSocket API (`UserDataStreamSubscribeAsync` of `SpotWebSocketApi`), which needs no listen key. Margin and isolated margin: the listen keys of `Binance.MarginTrading` (`StartUserDataStreamAsync`, ...) with its `RiskData` / `TradeData` streams |
| `MarginAccountTrade` | `Binance.MarginTrading` |
| `Wallet` | `Binance.Wallet` |
| `SubAccount` | `Binance.SubAccount` |
| `Savings` | `Binance.SimpleEarn` (Simple Earn replaced the Savings endpoints; the operations are not one-to-one) |
| `Mining`, `Convert`, `C2C`, `Fiat`, `GiftCard`, `Pay`, `Rebate` | the package of the same name (`Binance.Mining`, ...) |
| `CryptoLoans` | `Binance.CryptoLoan` |
| `PortfolioMargin` | `Binance.DerivativesTradingPortfolioMarginPro` |
| `Futures` | the transfer (`/sapi/v1/futures/transfer`): `UserUniversalTransferAsync` of `Binance.Wallet`. The cross-collateral loan endpoints (`/sapi/v1` and `/sapi/v2/futures/loan/*`) are not in the current Binance API and have no 5.0 equivalent |
| `BLVT`, `NFT` | no 5.0 package |

Check the README of the product package for the exact operations.

### Step 2: Build a Client

4.x:

```csharp
var market = new Market(baseUrl: "https://api.binance.com", apiKey: "key", apiSecret: "secret");
```

5.0:

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

using var rest = SpotRestApi.Production(new RestApiConfig { ApiKey = "key", ApiSecret = "secret" });
// SpotRestApi.Testnet(...), SpotRestApi.Demo(...), or new SpotRestApi(new RestApiConfig { BasePath = "..." })
```

The client is `IDisposable` and thread-safe: create one and reuse it. The `HttpClient` constructor overloads are gone, use the
`Proxy`, `CustomHeaders`, `Timeout` and `Retries` options. A `BinanceRsa` key becomes `PrivateKeyPem`/`PrivateKeyFile`
(with `PrivateKeyPassphrase` when encrypted) instead of `ApiSecret`.

### Step 3: Update the Calls

| 4.x (`Market`, `SpotAccountTrade`) | 5.0 (`SpotRestApi`) |
| --- | --- |
| `TestConnectivity()` | `PingAsync()` |
| `CheckServerTime()` | `TimeAsync()` |
| `ExchangeInformation(...)` | `ExchangeInfoAsync(new ExchangeInfoRequest { ... })` |
| `OrderBook(symbol, limit)` | `DepthAsync(new DepthRequest { Symbol = ..., Limit = ... })` |
| `RecentTradesList` | `GetTradesAsync` |
| `OldTradeLookup` | `HistoricalTradesAsync` |
| `CompressedAggregateTradesList` | `AggTradesAsync` |
| `KlineCandlestickData` | `KlinesAsync` |
| `CurrentAveragePrice` | `AvgPriceAsync` |
| `TwentyFourHrTickerPriceChangeStatistics` | `Ticker24hrAsync` |
| `SymbolPriceTicker` | `TickerPriceAsync` |
| `SymbolOrderBookTicker` | `TickerBookTickerAsync` |
| `RollingWindowPriceChangeStatistics` | `TickerAsync` |
| `TestNewOrder` / `NewOrder` | `OrderTestAsync` / `NewOrderAsync` |
| `CancelOrder` / `CancelAllOpenOrdersOnASymbol` | `DeleteOrderAsync` / `DeleteOpenOrdersAsync` |
| `QueryOrder` / `CurrentOpenOrders` / `AllOrders` | `GetOrderAsync` / `GetOpenOrdersAsync` / `AllOrdersAsync` |
| `NewOco` / `CancelOco` / `QueryOco` / `QueryAllOco` / `QueryOpenOco` | `OrderListOcoAsync` / `DeleteOrderListAsync` / `GetOrderListAsync` / `AllOrderListAsync` / `OpenOrderListAsync` |
| `AccountInformation` / `AccountTradeList` | `GetAccountAsync` / `MyTradesAsync` |
| `QueryCurrentOrderCountUsage` | `RateLimitOrderAsync` |
| `CancelAnExistingOrderAndSendANewOrder` | `OrderCancelReplaceAsync` |

4.x:

```csharp
string json = await account.NewOrder("BTCUSDT", Side.BUY, OrderType.LIMIT, timeInForce: TimeInForce.GTC, quantity: 0.01m, price: 30000m);
```

5.0:

```csharp
using var rest = SpotRestApi.Production(new RestApiConfig { ApiKey = "key", ApiSecret = "secret" });
var order = await rest.NewOrderAsync(new()
{
    Symbol = "BTCUSDT", Side = NewOrderSide.Buy, Type = NewOrderType.Limit,
    TimeInForce = NewOrderTimeInForce.Gtc, Quantity = 0.01m, Price = 30000m,
});
Console.WriteLine(order.Data()!.OrderId);
```

There is no `requestId`; the connector creates the ids. A `CancellationToken` cancels the request in flight.

### Step 4: Streams

4.x:

```csharp
var websocket = new MarketDataWebSocket("btcusdt@aggTrade");
websocket.OnMessageReceived(data => { Console.WriteLine(data); return Task.CompletedTask; }, CancellationToken.None);
await websocket.ConnectAsync(CancellationToken.None);
```

5.0:

```csharp
using Binance.Spot.WebSocketStreams;

var client = SpotWebSocketStreams.Production();
await using var connection = await client.ConnectAsync();
using var trades = connection.AggTrade(new() { Symbol = "btcusdt" });
await foreach (var trade in trades.Events.ReadAllAsync())
    Console.WriteLine($"{trade.S} {trade.P}");   // typed
// or, as callbacks: using var callback = trades.OnMessage(trade => Console.WriteLine(trade.P));
```

The connection reconnects and resubscribes by itself; `connection.Events` (or `connection.OnEvent(...)`) reports the lifecycle
(open, close, error). Events are buffered without limit unless `EventBufferCapacity` is set. `trades.WaitSubscribedAsync()`
completes once the server has acknowledged the subscription. A subscription's reader completes when the connection is
disconnected or disposed, and faults with a `BinanceException` when the server rejects the SUBSCRIBE (`await foreach` throws it);
`trades.Completion` and `trades.IsActive` report the same. A reconnect does not end it. `connection.PingServer()` sends a ping frame.

### Step 5: WebSocket API

4.x: `new WebSocketApi(url, apiKey, signatureService)`, `websocket.AccountTrade.NewOrderAsync(...)`, responses through
`OnMessageReceived`.

5.0: every call returns its own response:

```csharp
var config = new WebSocketApiConfig { ApiKey = "key", PrivateKeyFile = "ed25519.pem" };
var client = SpotWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();
var time = await connection.TimeAsync();
var logon = await connection.SessionLogonAsync();      // Ed25519 key; relogon after a reconnect is automatic
using var user = await connection.UserDataStreamSubscribeAsync();
await foreach (var e in user.Events.ReadAllAsync()) { /* typed user data events */ }
```

### Step 6: Errors

```csharp
using var rest = SpotRestApi.Production();
try { await rest.TimeAsync(); }
catch (BinanceTooManyRequestsException e) { await Task.Delay(e.RetryAfter ?? TimeSpan.FromSeconds(1)); }
catch (BinanceApiException e) { Console.WriteLine($"{e.HttpStatus} {e.Code} {e.Message}"); }
catch (BinanceNetworkException e) when (!e.RequestSent) { /* the request never left: safe to send again */ }
```

`BinanceException` carries `Kind`, `HttpStatus`, `Code` (the Binance error code), `RetryAfter`, `RetryAt`, `TransportCode`,
`TransportCategory`, `RequestSent` and, for WebSocket failures, `WebSocketKind`; each WebSocket cause has its own exception type (`BinanceWebSocketResponseException`, `BinanceWebSocketNotConnectedException`, ...).

### Step 7: Dependency Injection and Logging

`Binance.Common.DependencyInjection` replaces constructing the classes with an `HttpClient` by hand:
`services.AddBinanceRestApi<SpotRestApi>(SpotRestApi.Production, o => o.ApiKey = key)`.
`BinanceLogging.Configure(loggerFactory)` routes the log to `ILogger`.

### Step 8: Check for API Differences

Some function names or response structures may have changed. Check the README of the product package in
[`src/Binance.<Product>/`](https://github.com/binance/binance-connector-dotnet/tree/master/src) and the [API reference](https://binance.github.io/binance-connector-dotnet/) for the details.

## Backward Compatibility

- If a 5.0 package is not yet available for your use case (`BLVT`, `NFT`), continue using the 4.x connector until the corresponding package is released. The 4.x code is on the `legacy` branch.
- 5.0 needs .NET 8 or later. Applications on .NET Framework, .NET Standard 2.0 libraries and Unity, which 4.x supported through netstandard2.0, should stay on 4.x.
- Future updates and new product support will only be added to the new connectors.

---

## FAQs

### What if my project used the 4.x connector for multiple products?

Add the package of each product you use (`Binance.Spot`, `Binance.Wallet`, `Binance.SubAccount`, ...). The table in [Step 1](#step-1-replace-the-packages) maps the 4.x classes to the new packages.

### Will the new connectors introduce breaking changes?

We aim to maintain stability for existing features. Releases follow [Semantic Versioning](https://semver.org); any breaking changes will be documented in the [changelog](./CHANGELOG.md) and communicated prior to release.

### Where can I find more examples?

Every endpoint has a runnable example in [`examples/Binance.<Product>.Examples/`](https://github.com/binance/binance-connector-dotnet/tree/master/examples), and the README of each package has usage examples for the REST API, WebSocket API and WebSocket Streams.

---

For further assistance, open an issue in the repository or refer to the official [Binance API Documentation](https://developers.binance.com).
