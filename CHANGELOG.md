# Changelog

## 4.0.0 - 2023-06-28

### Added
- Added User-Agent

## 4.0.0-rc1 - 2023-04-27

### Added
- Added WebSocket API support.
- Added new Models `SelfTradePreventionMode` and `TickerType`.

### Updated
- Updated `MarketDataWebSocket.cs` and `UserDataWebSocket.cs` path to be under `WebSocketStream`.
- Updated `Interval` Model with `ONE_SECOND`.
- Updated dependencies versions:
  - `Microsoft.Extensions.Logging` to `6.0.0`.
  - `Microsoft.Extensions.Logging.Console` to `6.0.0`.
  - `Microsoft.Extensions.Logging.Abstractions` to `6.0.0`.
  - `Microsoft.NET.Test.Sdk` to `17.5.0`.

## 3.0.0 - 2023-03-29

### Removed
- End of compatibility verification for .NET `3.1.x` and `5.0.x` due to these versions reaching their end of life.

### Updated
- Replaced `BouncyCastle` cryptographic package to `BouncyCastle.Cryptography`.
- Updated Examples and Tests project file to `net6.0`.

## 2.0.0 - 2022-11-22

### Added
- Add RSA Key signature

## 1.8.0 - 2022-10-11

### Added
- New endpoint for Portfolio Margin:
  - `GET /sapi/v1/portfolio/pmLoan` to query Portfolio Margin Bankruptcy Loan Record.
  - `POST /sapi/v1/portfolio/repay` to repay Portfolio Margin Bankruptcy Loan.
  - `GET /sapi/v1/portfolio/collateralRate` to get Portfolio Margin Collateral Rate.

### Changed
- Changed endpoints for Trade:
  - `POST /api/v3/order/test` New optional fields `strategyId` and `strategyType`.
  - `POST /api/v3/order` New optional fields `strategyId` and `strategyType`.
  - `POST /api/v3/order/cancelReplace` New optional fields `strategyId` and `strategyType`.
  - `POST /api/v3/order/oco` New optional fields `limitStrategyId`, `limitStrategyType`, `stopStrategyId` and `stopStrategyType`.
- Fixing null value appended in the stream
- Update WebSocket example code

## 1.7.0 - 2022-07-19

### Added
- New endpoint for Margin:
  - `POST /sapi/v3/asset/getUserAsset` to get user assets.

- New endpoint for Wallet:
  - `GET /sapi/v1/margin/dribblet` to query the historical information of user's margin account small-value asset conversion BNB.

### Changed
- Update endpoint for Convert:
  - `GET /sapi/v1/fiat/orders`: Weight changes from IP(3000) to IP(100)

## 1.6.0 - 2022-07-04

### Added
- New endpoint for Market:
  - `GET /api/v3/ticker` for rolling window price change statistics based on windowSize provided.

- New endpoint for Account Trade:
  - `POST /api/v3/order/cancelReplace` to cancel an existing order and place a new order on the same symbol.
  
### Changed
- Update endpoint for Fiat:
  - `GET /sapi/v1/fiat/orders`: Weight changes from IP(1) to UID(90000)

- Update endpoint for Pay:
  - `GET /sapi/v1/pay/transactions`: Param names changed: startTimestamp -> startTime; endTimestamp -> endTime.

### Fixed
- Included `Examples/CSharp` and `Examples/FSharp` build process in CI pipeline.

- Explicitly set optional parameters in examples.

## 1.5.0 - 2022-05-27
### Added
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

### Changed
- Update endpoint for Binance Code:
  - `POST /sapi/v1/giftcard/redeemCode`: new optional parameter externalUid. Each external unique ID represents a unique user on the partner platform. The function helps you to identify the redemption behavior of different users.

- Update endpoints for Market:
  - `GET /api/v3/ticker/24hr`, `GET /api/v3/ticker/price` and `GET /api/v3/ticker/bookTicker` new optional parameter symbols.

### Fixed
- Added missing `Market` examples.
- Updated endpoint documentation and examples to latest version.
- Added missing `Mining` endpoint parameters.

## 1.4.0 - 2022-04-20
### Added
- New endpoint for Sub-Account
  - `GET /sapi/v1/managed-subaccount/accountSnapshot` to support investor master account query asset snapshot of managed sub-account.
- New transfer types `MARGIN`, `ISOLATED_MARGIN` and parameter `symbol` for `POST /sapi/v1/sub-account/universalTransfer` to support transfer to sub-account cross margin account and isolated margin account.

### Changed
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

### Fixed
- Fixed query parameters for `POST /api/v3/order/test`.

## 1.3.1 - 2022-03-08
### Fixed
- Query parameter is no longer subject to culture.
- Trade examples have more appropriate arguments

## 1.3.0 - 2022-03-02
### Added
- New endpoints for Wallet
  - `POST /sapi/v1/asset/dust-btc` to get assets that can be converted into BNB.

## 1.2.0 - 2022-02-16
### Added
- New endpoints for Binance Code, named as Gift Card to avoid technical confusion.
  - `POST /sapi/v1/giftcard/createCode` to create a Binance Code.
  - `POST /sapi/v1/giftcard/redeemCode` to redeem a Binance Code.
  - `GET /sapi/v1/giftcard/verify` to verify a Binance Code.

## 1.1.0 - 2022-01-19
### Added
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

### Updated
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

### Added
- Github CI format & unit tests actions
- Unit tests for enum models

### Fixed
- Enum query string serialisation
