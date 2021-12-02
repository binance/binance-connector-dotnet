namespace Binance.Common
{
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Binance humble object for <see cref="System.Net.WebSockets.ClientWebSocket" />.
    /// </summary>
    public class BinanceWebSocketHandler : IBinanceWebSocketHandler
    {
        private ClientWebSocket webSocket;

        public BinanceWebSocketHandler(ClientWebSocket clientWebSocket)
        {
            this.webSocket = clientWebSocket;
        }

        public WebSocketState State
        {
            get
            {
                return this.webSocket.State;
            }
        }

        public async Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
        {
            await this.webSocket.ConnectAsync(uri, cancellationToken);
        }

        public async Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            await this.webSocket.CloseOutputAsync(closeStatus, statusDescription, cancellationToken);
        }

        public async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            await this.webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
        }

        public async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            return await this.webSocket.ReceiveAsync(buffer, cancellationToken);
        }

        public async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            await this.webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
        }

        public void Dispose()
        {
            this.webSocket.Dispose();
        }
    }
}