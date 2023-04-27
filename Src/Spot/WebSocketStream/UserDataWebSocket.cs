namespace Binance.Spot
{
    using System.Net.WebSockets;
    using Binance.Common;

    public class UserDataWebSocket : BinanceWebSocket
    {
        private const string DEFAULT_USER_DATA_WEBSOCKET_BASE_URL = "wss://stream.binance.com:9443";

        public UserDataWebSocket(string listenKey, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(new BinanceWebSocketHandler(new ClientWebSocket()), baseUrl + "/ws/" + listenKey)
        {
        }

        public UserDataWebSocket(string listenKey, IBinanceWebSocketHandler handler, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(handler, baseUrl + "/ws/" + listenKey)
        {
        }

        public UserDataWebSocket(string[] listenKeys, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(new BinanceWebSocketHandler(new ClientWebSocket()), baseUrl + "/stream?streams=" + string.Join("/", listenKeys))
        {
        }

        public UserDataWebSocket(string[] listenKeys, IBinanceWebSocketHandler handler, string baseUrl = DEFAULT_USER_DATA_WEBSOCKET_BASE_URL)
        : base(handler, baseUrl + "/stream?streams=" + string.Join("/", listenKeys))
        {
        }
    }
}