namespace Binance.Spot
{
    using System.Net.WebSockets;
    using Binance.Common;

    public class WebSocketApi : BinanceWebSocketApi
    {
        private const string DEFAULT_WEBSOCKET_API_BASE_URL = "wss://ws-api.binance.com:443/ws-api/v3";
        private WebSocketApiGeneral general;
        private WebSocketApiMarket market;
        private WebSocketApiAccountTrade accountTrade;
        private WebSocketApiUserDataStream userDataStream;

        public WebSocketApi(string baseUrl = DEFAULT_WEBSOCKET_API_BASE_URL, string apiKey = null, IBinanceSignatureService signatureService = null)
        : base(new BinanceWebSocketHandler(new ClientWebSocket()), baseUrl, apiKey, signatureService: signatureService)
        {
            this.general = new WebSocketApiGeneral(this);
            this.market = new WebSocketApiMarket(this);
            this.accountTrade = new WebSocketApiAccountTrade(this);
            this.userDataStream = new WebSocketApiUserDataStream(this);
        }

        public WebSocketApiGeneral General
        {
            get
            {
                return this.general;
            }
        }

        public WebSocketApiMarket Market
        {
            get
            {
                return this.market;
            }
        }

        public WebSocketApiAccountTrade AccountTrade
        {
            get
            {
                return this.accountTrade;
            }
        }

        public WebSocketApiUserDataStream UserDataStream
        {
            get
            {
                return this.userDataStream;
            }
        }
    }
}
