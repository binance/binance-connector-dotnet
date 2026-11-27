//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Common;

/// <summary>
/// The endpoints of the Binance environments, named <c>&lt;Product&gt;&lt;Module&gt;&lt;Environment&gt;Url</c> (for example <c>SpotRestApiProdUrl</c>).
/// The product clients take their <c>Production</c>, <c>Testnet</c> and <c>Demo</c> endpoints from here.
/// </summary>
public static class BinanceUrls
{
    /// <summary>The production REST API endpoint of Algo.</summary>
    public static readonly string AlgoRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Alpha.</summary>
    public static readonly string AlphaRestApiProdUrl = "https://www.binance.com";

    /// <summary>The production WebSocket Streams endpoint of Alpha.</summary>
    public static readonly string AlphaWebSocketStreamsProdUrl = "wss://nbstream.binance.com/w3w/wsa";

    /// <summary>The production REST API endpoint of C2C.</summary>
    public static readonly string C2CRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production WebSocket Streams endpoint of CMS.</summary>
    public static readonly string CmsWebSocketStreamsProdUrl = "wss://api.binance.com/sapi/wss";

    /// <summary>The production REST API endpoint of Convert.</summary>
    public static readonly string ConvertRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Copy Trading.</summary>
    public static readonly string CopyTradingRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Crypto Loan.</summary>
    public static readonly string CryptoLoanRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesRestApiProdUrl = "https://dapi.binance.com";

    /// <summary>The testnet REST API endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesRestApiTestnetUrl = "https://testnet.binancefuture.com";

    /// <summary>The demo REST API endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesRestApiDemoUrl = "https://demo-dapi.binance.com";

    /// <summary>The production WebSocket API endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesWebSocketApiProdUrl = "wss://ws-dapi.binance.com/ws-dapi/v1";

    /// <summary>The testnet WebSocket API endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesWebSocketApiTestnetUrl = "wss://testnet.binancefuture.com/ws-dapi/v1";

    /// <summary>The production WebSocket Streams endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesWebSocketStreamsProdUrl = "wss://dstream.binance.com";

    /// <summary>The testnet WebSocket Streams endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesWebSocketStreamsTestnetUrl = "wss://dstream.binancefuture.com";

    /// <summary>The demo WebSocket Streams endpoint of Derivatives Trading Coin Futures.</summary>
    public static readonly string DerivativesTradingCoinFuturesWebSocketStreamsDemoUrl = "wss://demo-dstream.binance.com";

    /// <summary>The production REST API endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesRestApiProdUrl = "https://fapi.binance.com";

    /// <summary>The testnet REST API endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesRestApiTestnetUrl = "https://testnet.binancefuture.com";

    /// <summary>The demo REST API endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesRestApiDemoUrl = "https://demo-fapi.binance.com";

    /// <summary>The production WebSocket API endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesWebSocketApiProdUrl = "wss://ws-fapi.binance.com/ws-fapi/v1";

    /// <summary>The testnet WebSocket API endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesWebSocketApiTestnetUrl = "wss://testnet.binancefuture.com/ws-fapi/v1";

    /// <summary>The production WebSocket Streams endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesWebSocketStreamsProdUrl = "wss://fstream.binance.com";

    /// <summary>The testnet WebSocket Streams endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesWebSocketStreamsTestnetUrl = "wss://fstream.binancefuture.com";

    /// <summary>The demo WebSocket Streams endpoint of Derivatives Trading USDS Futures.</summary>
    public static readonly string DerivativesTradingUsdsFuturesWebSocketStreamsDemoUrl = "wss://demo-fstream.binance.com";

    /// <summary>The production REST API endpoint of Derivatives Trading Options.</summary>
    public static readonly string DerivativesTradingOptionsRestApiProdUrl = "https://eapi.binance.com";

    /// <summary>The testnet REST API endpoint of Derivatives Trading Options.</summary>
    public static readonly string DerivativesTradingOptionsRestApiTestnetUrl = "https://testnet.binancefuture.com";

    /// <summary>The production WebSocket Streams endpoint of Derivatives Trading Options.</summary>
    public static readonly string DerivativesTradingOptionsWebSocketStreamsProdUrl = "wss://fstream.binance.com";

    /// <summary>The testnet WebSocket Streams endpoint of Derivatives Trading Options.</summary>
    public static readonly string DerivativesTradingOptionsWebSocketStreamsTestnetUrl = "wss://fstream.binancefuture.com";

    /// <summary>The production REST API endpoint of Derivatives Trading Portfolio Margin.</summary>
    public static readonly string DerivativesTradingPortfolioMarginRestApiProdUrl = "https://papi.binance.com";

    /// <summary>The testnet REST API endpoint of Derivatives Trading Portfolio Margin.</summary>
    public static readonly string DerivativesTradingPortfolioMarginRestApiTestnetUrl = "https://testnet.binancefuture.com";

    /// <summary>The production WebSocket Streams endpoint of Derivatives Trading Portfolio Margin.</summary>
    public static readonly string DerivativesTradingPortfolioMarginWebSocketStreamsProdUrl = "wss://fstream.binance.com/pm";

    /// <summary>The testnet WebSocket Streams endpoint of Derivatives Trading Portfolio Margin.</summary>
    public static readonly string DerivativesTradingPortfolioMarginWebSocketStreamsTestnetUrl = "wss://fstream.binancefuture.com/pm";

    /// <summary>The production REST API endpoint of Derivatives Trading Portfolio Margin Pro.</summary>
    public static readonly string DerivativesTradingPortfolioMarginProRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production WebSocket Streams endpoint of Derivatives Trading Portfolio Margin Pro.</summary>
    public static readonly string DerivativesTradingPortfolioMarginProWebSocketStreamsProdUrl = "wss://fstream.binance.com/pm-classic";

    /// <summary>The production REST API endpoint of Dual Investment.</summary>
    public static readonly string DualInvestmentRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Fiat.</summary>
    public static readonly string FiatRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Gift Card.</summary>
    public static readonly string GiftCardRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Margin Trading.</summary>
    public static readonly string MarginTradingRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production WebSocket Streams endpoint of Margin Trading.</summary>
    public static readonly string MarginTradingWebSocketStreamsProdUrl = "wss://stream.binance.com:9443";

    /// <summary>The production WebSocket Streams endpoint of Margin Trading Risk.</summary>
    public static readonly string MarginTradingRiskWebSocketStreamsProdUrl = "wss://margin-stream.binance.com";

    /// <summary>The production REST API endpoint of Mining.</summary>
    public static readonly string MiningRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Pay.</summary>
    public static readonly string PayRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Rebate.</summary>
    public static readonly string RebateRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Simple Earn.</summary>
    public static readonly string SimpleEarnRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Spot.</summary>
    public static readonly string SpotRestApiProdUrl = "https://api.binance.com";

    /// <summary>The testnet REST API endpoint of Spot.</summary>
    public static readonly string SpotRestApiTestnetUrl = "https://testnet.binance.vision";

    /// <summary>The demo REST API endpoint of Spot.</summary>
    public static readonly string SpotRestApiDemoUrl = "https://demo-api.binance.com";

    /// <summary>The production WebSocket API endpoint of Spot.</summary>
    public static readonly string SpotWebSocketApiProdUrl = "wss://ws-api.binance.com:443/ws-api/v3";

    /// <summary>The testnet WebSocket API endpoint of Spot.</summary>
    public static readonly string SpotWebSocketApiTestnetUrl = "wss://ws-api.testnet.binance.vision/ws-api/v3";

    /// <summary>The demo WebSocket API endpoint of Spot.</summary>
    public static readonly string SpotWebSocketApiDemoUrl = "wss://demo-ws-api.binance.com/ws-api/v3";

    /// <summary>The production WebSocket Streams endpoint of Spot.</summary>
    public static readonly string SpotWebSocketStreamsProdUrl = "wss://stream.binance.com:9443";

    /// <summary>The testnet WebSocket Streams endpoint of Spot.</summary>
    public static readonly string SpotWebSocketStreamsTestnetUrl = "wss://stream.testnet.binance.vision";

    /// <summary>The demo WebSocket Streams endpoint of Spot.</summary>
    public static readonly string SpotWebSocketStreamsDemoUrl = "wss://demo-stream.binance.com:9443";

    /// <summary>The market data REST API endpoint of Spot.</summary>
    public static readonly string SpotRestApiMarketUrl = "https://data-api.binance.vision";

    /// <summary>The market data WebSocket Streams endpoint of Spot.</summary>
    public static readonly string SpotWebSocketStreamsMarketUrl = "wss://data-stream.binance.vision";

    /// <summary>The production REST API endpoint of Staking.</summary>
    public static readonly string StakingRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of Stock Options.</summary>
    public static readonly string StockOptionsRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production WebSocket Streams endpoint of Stock Options.</summary>
    public static readonly string StockOptionsWebSocketStreamsProdUrl = "wss://nbstream.binance.com/equity";

    /// <summary>The production REST API endpoint of Stocks.</summary>
    public static readonly string StocksRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production WebSocket Streams endpoint of Stocks.</summary>
    public static readonly string StocksWebSocketStreamsProdUrl = "wss://nbstream.binance.com/equity";

    /// <summary>The production REST API endpoint of Sub Account.</summary>
    public static readonly string SubAccountRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of VIP Loan.</summary>
    public static readonly string VipLoanRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production REST API endpoint of W3W Prediction.</summary>
    public static readonly string W3WPredictionRestApiProdUrl = "https://api.binance.com";

    /// <summary>The production WebSocket Streams endpoint of W3W Prediction.</summary>
    public static readonly string W3WPredictionWebSocketStreamsProdUrl = "wss://api.binance.com/sapi/wss";

    /// <summary>The production REST API endpoint of Wallet.</summary>
    public static readonly string WalletRestApiProdUrl = "https://api.binance.com";
}
