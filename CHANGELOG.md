# Changelog

## 5.0.0 - 2026-11-27

A new major version, replacing the single 4.x `Binance.Spot` package with one package per Binance product, with typed REST API,
WebSocket API and WebSocket Streams clients. Signing, retries and reconnects are built in. See [MIGRATION.md](./MIGRATION.md).

### Added (13)

- One package per product (`Binance.Spot`, `Binance.Wallet`, `Binance.DerivativesTradingUsdsFutures`, ...), each with typed
  REST API, WebSocket API and WebSocket Streams clients, tests, and a runnable example for every endpoint.
- `Binance.Common`: configuration (proxies, retries, timeouts, compression, keep-alive, custom headers, HMAC / RSA / Ed25519
  keys, time unit, reconnect settings), a typed exception hierarchy (`BinanceException` and subclasses), rate limit counters
  (`RestApiRateLimit`, `WebSocketApiRateLimit`), connection lifecycle events, `ILogger` integration and extensible enums.
- `Binance.Common.DependencyInjection`: `AddBinanceRestApi`, `AddBinanceWebSocketApi` and `AddBinanceWebSocketStreams`.
- Factories for every environment of a product (`Production`, `Testnet`, `Demo` where it exists) and `FromConfig`.
- WebSocket API and WebSocket Streams clients hold the configuration, and `ConnectAsync()` returns an open connection with the
  methods, as in the other Binance connectors. `WebSocketMode.Single` (default) or `WebSocketMode.Pool(n)`, in the configuration
  or given to `ConnectAsync`, spreads requests or streams over a pool of connections.
- Responses decode their body or result with `Data()`, on first use.
- Subscriptions deliver their events to a `ChannelReader<T>` (`Events`) or to `OnMessage` callbacks; connections deliver their
  lifecycle events to `Events` or `OnEvent` callbacks, and every message with `EnableMessages()` or `OnMessage`.
  `WaitSubscribedAsync()` completes once the server has acknowledged a subscription; `Unsubscribe()` ends it.
- Errors carry what came with them: `Body`, `Headers` and `RateLimits` of a REST error, and `WebSocketRateLimits` and `ErrorData`
  (the `error.data` of the answer) of a WebSocket API error. HTTP 409 is a `BinanceConflictException`.
- `TimeOffset` and `TimestampProvider` on every configuration, for the `timestamp` of signed requests.
- TLS options: `CaFile`, `CaPem` and `CaOnly` for private CAs, `ServerCertificateValidator` for certificate pinning, and client
  certificates (`ClientCertificatePem` / `ClientCertificateFile` with `ClientKeyPem` / `ClientKeyFile` and `ClientKeyPassphrase`)
  for mutual TLS.
- Proxies: HTTP, HTTPS, `socks5` and `socks5h`.
- For what has no generated method yet: `SendRequestAsync` / `SendSignedRequestAsync` (REST), `SendMessageAsync` /
  `SendSignedMessageAsync` (WebSocket API), `Subscribe(stream)` and `Subscribe` / `Unsubscribe` of stream names (WebSocket
  Streams), plus `IsSubscribed` and `ConnectAsync(streams)`.
- Platform libraries for `win-x64`, `win-x86`, `win-arm64`, `linux-x64`, `linux-arm64`, `linux-arm`, `linux-musl-x64`,
  `linux-musl-arm64`, `osx-x64` and `osx-arm64`; the packages target net8.0 and net10.0, and trimming and Native AOT are supported.

### Changed (7)

- Clients are created per product from a configuration (`SpotRestApi.Production(config)`, `.Testnet(config)`, ...), instead of
  one class per group of endpoints (`Market`, `SpotAccountTrade`, ...) built with a base URL and keys.
- Requests are typed `<Operation>Request` classes instead of positional arguments, and responses are typed models
  (`RestApiResponse<T>` with `Data()`, `Status`, `RateLimits` and `Headers`) instead of the response body as a string. Amounts that
  the API documents as numbers are `decimal`, 64-bit ids are `long`.
- Enums are string-backed structs that also carry values the SDK does not know, instead of C# enums.
- WebSocket Streams have one method per stream, and their events are read from a `ChannelReader<T>` or `OnMessage` callbacks instead of
  an `OnMessageReceived` callback. Connections reconnect and renew on their own.
- Errors are one exception hierarchy, `BinanceException`, with a subclass per cause (`BinanceBadRequestException`,
  `BinanceTooManyRequestsException`, `BinanceWebSocketNotConnectedException`, ...). `BinanceServerException` is an HTTP 5xx
  answer; `BinanceClientException`, an HTTP 4xx answer in 4.x, is now an unexpected status or a response that does not decode.
- Asynchronous calls take a `CancellationToken`; durations are `TimeSpan` values; logging is configured once with
  `BinanceLogging.Configure(loggerFactory)`.
- The packages target net8.0 and net10.0 instead of netstandard2.0, support trimming and Native AOT, and ship the platform library
  for `win-x64`, `win-x86`, `win-arm64`, `linux-x64`, `linux-arm64`, `linux-arm`, `linux-musl-x64`, `linux-musl-arm64`, `osx-x64`
  and `osx-arm64`. .NET Framework and Unity applications should stay on 4.x.

### Removed (1)

- The 4.x connector (`Binance.Spot` 4.1.0 with `Market`, `SpotAccountTrade`, ..., its bundled common code and the F# examples).
  It remains on the `legacy` branch.

## 4.1.0 - 2024-06-18

### Added (1)

- New endpoints for Margin:
  - `POST /sapi/v1/margin/borrow-repay`: Margin account borrow/repay
  - `GET /sapi/v1/margin/borrow-repay`: Query borrow/repay records in Margin account

### Changed (2)

- Updated dependencies versions:
  - `Microsoft.Extensions.Logging` to `8.0.0`
  - `Microsoft.Extensions.Logging.Console` to `8.0.0`
  - `Microsoft.Extensions.Logging.Abstractions` to `8.0.1`
  - `BouncyCastle.Cryptograph` to `2.3.1`
- Margin:
  - `GET /sapi/v1/margin/transfer`: add parameter `isolatedSymbol`
  - `GET /sapi/v1/margin/allAssets`: add parameter `asset`
  - `GET /sapi/v1/margin/allPairs`: add parameter `symbol`
  - `GET /sapi/v1/margin/isolated/allPairs`: add parameter `symbol`

### Removed (3)

- Bswap
  - `GET /sapi/v1/bswap/pools`
  - `GET /sapi/v1/bswap/liquidity`
  - `POST /sapi/v1/bswap/liquidityAdd`
  - `POST /sapi/v1/bswap/liquidityRemove`
  - `GET /sapi/v1/bswap/liquidityOps`
  - `GET /sapi/v1/bswap/quote`
  - `POST /sapi/v1/bswap/swap`
  - `GET /sapi/v1/bswap/swap`
  - `GET /sapi/v1/bswap/poolConfigure`
  - `GET /sapi/v1/bswap/addLiquidityPreview`
  - `GET /sapi/v1/bswap/removeLiquidityPreview`
  - `GET /sapi/v1/bswap/unclaimedRewards`
  - `POST /sapi/v1/bswap/claimRewards`
  - `GET /sapi/v1/bswap/claimedHistory`

- Margin
  - `GET /sapi/v1/margin/isolated/pair`
  - `POST /sapi/v1/margin/isolated/transfer`
  - `GET /sapi/v1/margin/isolated/transfer`
  - `GET /sapi/v1/margin/asset`
  - `POST /sapi/v1/margin/loan`
  - `GET /sapi/v1/margin/dribblet`
  - `GET /sapi/v1/margin/loan`
  - `GET /sapi/v1/margin/pair`
  - `POST /sapi/v1/margin/repay`
  - `GET /sapi/v1/margin/repay`
  - `POST /sapi/v1/margin/transfer`

- Staking
  - `GET /sapi/v1/staking/productList`
  - `POST /sapi/v1/staking/purchase`
  - `POST /sapi/v1/staking/redeem`
  - `GET /sapi/v1/staking/position`
  - `GET /sapi/v1/staking/stakingRecord`
  - `POST /sapi/v1/staking/setAutoStaking`
  - `GET /sapi/v1/staking/personalLeftQuota`

## 4.0.1 - 2023-10-04

### Changed (1)

- Fix parameter type issue in method `AggregateTradesListAsync`, `KlinesAsync` and `UiKlinesAsync`

## 4.0.0 - 2023-06-28

### Added (1)

- Added User-Agent

## 4.0.0-rc1 - 2023-04-27

### Added (2)

- Added WebSocket API support.
- Added new Models `SelfTradePreventionMode` and `TickerType`.

### Changed (3)

- Updated `MarketDataWebSocket.cs` and `UserDataWebSocket.cs` path to be under `WebSocketStream`.
- Updated `Interval` Model with `ONE_SECOND`.
- Updated dependencies versions:
  - `Microsoft.Extensions.Logging` to `6.0.0`.
  - `Microsoft.Extensions.Logging.Console` to `6.0.0`.
  - `Microsoft.Extensions.Logging.Abstractions` to `6.0.0`.
  - `Microsoft.NET.Test.Sdk` to `17.5.0`.

## 3.0.0 - 2023-03-29

### Removed (1)

- End of compatibility verification for .NET `3.1.x` and `5.0.x` due to these versions reaching their end of life.

### Changed (2)

- Replaced `BouncyCastle` cryptographic package to `BouncyCastle.Cryptography`.
- Updated Examples and Tests project file to `net6.0`.

## 2.0.0 - 2022-11-22

### Added (1)

- Add RSA Key signature

## 1.8.0 - 2022-10-11

### Added (1)

- New endpoint for Portfolio Margin:
  - `GET /sapi/v1/portfolio/pmLoan` to query Portfolio Margin Bankruptcy Loan Record.
  - `POST /sapi/v1/portfolio/repay` to repay Portfolio Margin Bankruptcy Loan.
  - `GET /sapi/v1/portfolio/collateralRate` to get Portfolio Margin Collateral Rate.

### Changed (3)

- Changed endpoints for Trade:
  - `POST /api/v3/order/test` New optional fields `strategyId` and `strategyType`.
  - `POST /api/v3/order` New optional fields `strategyId` and `strategyType`.
  - `POST /api/v3/order/cancelReplace` New optional fields `strategyId` and `strategyType`.
  - `POST /api/v3/order/oco` New optional fields `limitStrategyId`, `limitStrategyType`, `stopStrategyId` and `stopStrategyType`.
- Fixing null value appended in the stream
- Update WebSocket example code

## 1.7.0 - 2022-07-19

### Added (2)

- New endpoint for Margin:
  - `POST /sapi/v3/asset/getUserAsset` to get user assets.

- New endpoint for Wallet:
  - `GET /sapi/v1/margin/dribblet` to query the historical information of user's margin account small-value asset conversion BNB.

### Changed (1)

- Update endpoint for Convert:
  - `GET /sapi/v1/fiat/orders`: Weight changes from IP(3000) to IP(100)

## 1.6.0 - 2022-07-04

### Added (2)

- New endpoint for Market:
  - `GET /api/v3/ticker` for rolling window price change statistics based on windowSize provided.

- New endpoint for Account Trade:
  - `POST /api/v3/order/cancelReplace` to cancel an existing order and place a new order on the same symbol.

### Changed (2)

- Update endpoint for Fiat:
  - `GET /sapi/v1/fiat/orders`: Weight changes from IP(1) to UID(90000)

- Update endpoint for Pay:
  - `GET /sapi/v1/pay/transactions`: Param names changed: startTimestamp -> startTime; endTimestamp -> endTime.

### Fixed (2)

- Included `Examples/CSharp` and `Examples/FSharp` build process in CI pipeline.

- Explicitly set optional parameters in examples.

## 1.5.0 - 2022-05-27

### Added (6)

- New endpoint for Binance Code:
  - `GET /sapi/v1/giftcard/cryptography/rsa-public-key` to fetch RSA public key.

- New endpoints for Staking:
  - `GET /sapi/v1/staking/productList` to get Staking product list
  - `POST /sapi/v1/staking/purchase` to stake product
  -   - `POST /sapi/v1/staking/redeem` to redeem product
  - `GET /sapi/v1/staking/position` to get Staking product holding position
  - `GET /sapi/v1/staking/stakingRecord` to inquiry Staking history records
  - `POST /sapi/v1/staking/setAutoStaking` to set Auto Staking function
  - `GET /sapi/v1/staking/personalLeftQuota` to inquiry Staking left quota

- New endpoint for Portfolio Margin:
  - `GET /sapi/v1/portfolio/account` to support query portfolio margin account info

- New endpoint for BSwap:
  - `GET /sapi/v1/bswap/removeLiquidityPreview` to get remove liquidity preview

### Changed (2)

- Update endpoint for Binance Code:
  - `POST /sapi/v1/giftcard/redeemCode`: new optional parameter externalUid. Each external unique ID represents a unique user on the partner platform. The function helps you to identify the redemption behavior of different users.

- Update endpoints for Market:
  - `GET /api/v3/ticker/24hr`, `GET /api/v3/ticker/price` and `GET /api/v3/ticker/bookTicker` new optional parameter symbols.

### Fixed (3)

- Added missing `Market` examples.
- Updated endpoint documentation and examples to latest version.
- Added missing `Mining` endpoint parameters.

## 1.4.0 - 2022-04-20

### Added (2)

- New endpoint for Sub-Account
  - `GET /sapi/v1/managed-subaccount/accountSnapshot` to support investor master account query asset snapshot of managed sub-account.
- New transfer types `MARGIN`, `ISOLATED_MARGIN` and parameter `symbol` for `POST /sapi/v1/sub-account/universalTransfer` to support transfer to sub-account cross margin account and isolated margin account.

### Changed (4)

- Changed endpoints for Spot Trading
  - `POST /api/v3/order` - New optional field trailingDelta.
  - `POST /api/v3/order/test` - New optional field trailingDelta.
  - `POST /api/v3/order/oco` - New optional field trailingDelta.
- Changed endpoints for Sub-Account
- `GET /sapi/v1/sub-account/universalTransfer`
  - The query time period must be less then 30 days; If startTime and endTime not sent, return records of the last 30 days by default.
- `GET api/v3/depth`
  - The limit value can be outside of the previous values (i.e. 5, 10, 20, 50, 100, 500, 1000,5000) and will return the correct limit. (i.e. if limit=3 then the response will be the top 3 bids and asks)
  - The limit still cannot exceed 5000. If the limit provided is greater than 5000, then the response will be truncated to 5000.

### Fixed (1)

- Fixed query parameters for `POST /api/v3/order/test`.

## 1.3.1 - 2022-03-08

### Fixed (2)

- Query parameter is no longer subject to culture.
- Trade examples have more appropriate arguments

## 1.3.0 - 2022-03-02

### Added (1)

- New endpoints for Wallet
  - `POST /sapi/v1/asset/dust-btc` to get assets that can be converted into BNB.

## 1.2.0 - 2022-02-16

### Added (1)

- New endpoints for Binance Code, named as Gift Card to avoid technical confusion.
  - `POST /sapi/v1/giftcard/createCode` to create a Binance Code.
  - `POST /sapi/v1/giftcard/redeemCode` to redeem a Binance Code.
  - `GET /sapi/v1/giftcard/verify` to verify a Binance Code.

## 1.1.0 - 2022-01-19

### Added (12)

- New endpoints for BSwap
  - GET /sapi/v1/bswap/poolConfigure to get pool configure
  - GET /sapi/v1/bswap/addLiquidityPreview to get add liquidity preview
  - GET /sapi/v1/margin/isolated/accountLimit to get remove liquidity preview
  - GET /sapi/v1/bswap/unclaimedRewards to get unclaimed rewards record.
  - POST /sapi/v1/bswap/claimRewards to claim swap rewards or liquidity rewards.
  - GET /sapi/v1/bswap/claimedHistory to get history of claimed rewards.

- New endpoints for Trade:
  - GET api/v3/rateLimit/order added

- New endpoint for Crypto Loans
  - GET /sapi/v1/loan/income

- New endpoint for Pay
  - GET /sapi/v1/pay/transactions to support user query Pay trade history

- New endpoint for Convert
  - GET /sapi/v1/convert/tradeFlow to support user query convert trade history records

- New endpoint for Rebate
  - GET /sapi/v1/rebate/taxQuery to support user query spot rebate history records

- New endpoint for Margin
  - GET /sapi/v1/margin/crossMarginData to get cross margin fee data collection
  - GET /sapi/v1/margin/isolatedMarginData to get isolated margin fee data collection
  - GET /sapi/v1/margin/isolatedMarginTier to get isolated margin tier data collection

- New endpoints for NFT
  - GET /sapi/v1/nft/history/transactions to get NFT transaction history
  - GET /sapi/v1/nft/history/deposit to get NFT deposit history
  - GET /sapi/v1/nft/history/withdraw to get NFT withdraw history
  - GET /sapi/v1/nft/user/getAsset to get NFT asset

- New endpoint for Mining
  - GET /sapi/v1/mining/payment/uid to get Mining account earning.

- New endpoints for Sub-Account
  - POST /sapi/v1/sub-account/subAccountApi/ipRestriction to support master account enable and disable IP restriction for a sub-account API Key
  - POST /sapi/v1/sub-account/subAccountApi/ipRestriction/ipList to support master account add IP list for a sub-account API Key
  - GET /sapi/v1/account/apiRestrictions/ipRestriction to support master account query IP restriction for a sub-account API Key
  - DELETE /sapi/v1/account/apiRestrictions/ipRestriction/ipList to support master account delete IP list for a sub-account API Key

- Issue templates
  - Added templates for bug report and documentation changes

- Actions
  - Added release action
  - Added multi-framework distributable build tests

### Changed (6)

- Updated endpoints for Sub-Account
  - New parameter clientTranId added in POST /sapi/v1/sub-account/universalTransfer and GET /sapi/v1/sub-account/universalTransfer to support custom transfer id

- Updated endpoint for Wallet and Futures
  - GET /sapi/v1/asset/transfer
  - GET /sapi/v1/futures/transfer
  - GET /sapi/v1/accountSnapshot
  - The query time range of both endpoints are shortened to support data query within the last 6 months only, where startTime does not support selecting a timestamp beyond 6 months.
If you do not specify startTime and endTime, the data of the last 7 days will be returned by default.

- Updated endpoints for Wallet
  - New parameter walletType added in POST /sapi/v1/capital/withdraw/apply

- Updated endpoints for Margin
  - Removed out limit from GET /sapi/v1/margin/interestRateHistory
  - As the Mining account is merged into Funding account, transfer types MAIN_MINING, MINING_MAIN, MINING_UMFUTURE, MARGIN_MINING, and MINING_MARGIN will be discontinued in Universal Transfer endpoint POST /sapi/v1/asset/transfer on January 05, 2022 08:00 AM UTC

- Resolved lint warnings

- Improved Http Exceptions

## 1.0.1 - 2022-01-10

### Added (2)

- Github CI format & unit tests actions
- Unit tests for enum models

### Fixed (1)

- Enum query string serialisation
