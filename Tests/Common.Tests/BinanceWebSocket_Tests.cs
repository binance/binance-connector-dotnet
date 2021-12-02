namespace Binance.Common.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Xunit;

    public class BinanceWebSocket_Tests
    {
        #region ConnectAsync
        [Fact]
        public async void ConnectAsync_Cancel_Stops_Connect()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com", 8192);

            await Task.WhenAll(
                binanceWebSocket.ConnectAsync(cancellationToken: cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }
        #endregion

        #region SendAsync
        [Fact]
        public async void SendAsync_Cancel_Stops_Send()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com", 8192);

            await binanceWebSocket.ConnectAsync(cancellationToken: CancellationToken.None);

            await Task.WhenAll(
                binanceWebSocket.SendAsync(string.Empty, cancellationToken: cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }
        #endregion

        #region OnMessageReceived
        [Fact]
        public async void OnMessageReceived_Subscribes_Action()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com", 8192);

            await binanceWebSocket.ConnectAsync(cancellationToken: CancellationToken.None);

            binanceWebSocket.OnMessageReceived(
                message =>
                {
                    Assert.Equal("message", message);

                    return Task.CompletedTask;
                },
                cancellationToken: CancellationToken.None);
        }

        [Fact]
        public async void OnMessageReceived_Cancel_Drops_Receiver()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com", 8192);

            await binanceWebSocket.ConnectAsync(cancellationToken: CancellationToken.None);

            binanceWebSocket.OnMessageReceived(
                message =>
                {
                    return Task.Delay(2);
                },
                cancellationToken: cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();
        }
        #endregion

        #region DisconnectAsync
        [Fact]
        public async void DisconnectAsync_Cancel_Stops_Disconnect()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var binanceWebSocket = new BinanceWebSocket(mockHandler.Object, "wss://test.com", 8192);

            await binanceWebSocket.ConnectAsync(cancellationToken: CancellationToken.None);

            await Task.WhenAll(
                binanceWebSocket.DisconnectAsync(cancellationToken: cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }
        #endregion
    }
}