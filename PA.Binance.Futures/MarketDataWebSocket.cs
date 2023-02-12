namespace Binance.Futures
{
    using System.Net.WebSockets;
    using Binance.Common;

    public class FMarketDataWebSocket : BinanceWebSocket
    {
        private const string DEFAULT_USER_DATA_WEBSOCKET_BASE_URL = "wss://fstream.binance.com";

        public FMarketDataWebSocket(string stream, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(new BinanceWebSocketHandler(new ClientWebSocket()), baseUrl + "/ws/" + stream)
        {
        }

        public FMarketDataWebSocket(string stream, IBinanceWebSocketHandler handler, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(handler, baseUrl + "/ws/" + stream)
        {
        }

        public FMarketDataWebSocket(string[] streams, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(new BinanceWebSocketHandler(new ClientWebSocket()), baseUrl + "/stream?streams=" + string.Join("/", streams))
        {
        }

        public FMarketDataWebSocket(string[] streams, IBinanceWebSocketHandler handler, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(handler, baseUrl + "/stream?streams=" + string.Join("/", streams))
        {
        }
    }
}