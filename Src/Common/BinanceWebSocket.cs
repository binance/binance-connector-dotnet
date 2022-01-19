namespace Binance.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Binance web socket wrapper.
    /// </summary>
    public class BinanceWebSocket : IDisposable
    {
        private IBinanceWebSocketHandler handler;
        private List<Func<string, Task>> onMessageReceivedFunctions;
        private List<CancellationTokenRegistration> onMessageReceivedCancellationTokenRegistrations;
        private CancellationTokenSource loopCancellationTokenSource;
        private Uri url;
        private int receiveBufferSize;

        public BinanceWebSocket(IBinanceWebSocketHandler handler, string url, int receiveBufferSize = 8192)
        {
            this.handler = handler;
            this.url = new Uri(url);
            this.receiveBufferSize = receiveBufferSize;
            this.onMessageReceivedFunctions = new List<Func<string, Task>>();
            this.onMessageReceivedCancellationTokenRegistrations = new List<CancellationTokenRegistration>();
        }

        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            if (this.handler.State != WebSocketState.Open)
            {
                this.loopCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                await this.handler.ConnectAsync(this.url, cancellationToken);
                await Task.Factory.StartNew(() => this.ReceiveLoop(this.loopCancellationTokenSource.Token, this.receiveBufferSize), this.loopCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        public async Task DisconnectAsync(CancellationToken cancellationToken)
        {
            if (this.loopCancellationTokenSource != null)
            {
                this.loopCancellationTokenSource.Cancel();
            }

            if (this.handler.State == WebSocketState.Open)
            {
                await this.handler.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
                await this.handler.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
            }
        }

        public void OnMessageReceived(Func<string, Task> onMessageReceived, CancellationToken cancellationToken)
        {
            this.onMessageReceivedFunctions.Add(onMessageReceived);

            if (cancellationToken != CancellationToken.None)
            {
                var reg = cancellationToken.Register(() =>
                    this.onMessageReceivedFunctions.Remove(onMessageReceived));

                this.onMessageReceivedCancellationTokenRegistrations.Add(reg);
            }
        }

        public async Task SendAsync(string message, CancellationToken cancellationToken)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(message);

            await this.handler.SendAsync(new ArraySegment<byte>(byteArray), WebSocketMessageType.Text, true, cancellationToken);
        }

        public void Dispose()
        {
            this.DisconnectAsync(CancellationToken.None).Wait();

            this.handler.Dispose();

            this.onMessageReceivedCancellationTokenRegistrations.ForEach(ct => ct.Dispose());

            this.loopCancellationTokenSource.Dispose();
        }

        private async Task ReceiveLoop(CancellationToken cancellationToken, int receiveBufferSize = 8192)
        {
            WebSocketReceiveResult receiveResult = null;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var buffer = new ArraySegment<byte>(new byte[receiveBufferSize]);
                    receiveResult = await this.handler.ReceiveAsync(buffer, cancellationToken);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    string content = Encoding.UTF8.GetString(buffer.ToArray());
                    this.onMessageReceivedFunctions.ForEach(omrf => omrf(content));
                }
            }
            catch (TaskCanceledException)
            {
                await this.DisconnectAsync(CancellationToken.None);
            }
        }
    }
}