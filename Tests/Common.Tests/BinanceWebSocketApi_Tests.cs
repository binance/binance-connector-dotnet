namespace Binance.Common.Tests
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Moq;
    using Xunit;

    public class BinanceWebSocketApi_Tests
    {
        #region SendAsync
        [Fact]
        public async void SendAsync_Cancel_Stops_Send()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var mockHandler = new Mock<IBinanceWebSocketHandler>();
            var signatureProvider = new BinanceHmac("apiSecret");
            var binanceWebSocket = new BinanceWebSocketApi(mockHandler.Object, "wss://test.com", "apiKey", signatureProvider, 8192);

            await binanceWebSocket.ConnectAsync(cancellationToken: CancellationToken.None);

            // Accepts null, empty string, string and int as request Id.
            await Task.WhenAll(
                binanceWebSocket.SendAsync(string.Empty, null, cancellationToken: cancellationTokenSource.Token),
                binanceWebSocket.SendAsync(string.Empty, new Dictionary<string, object> { { "symbol", "BNBBTC" } }, cancellationToken: cancellationTokenSource.Token),
                binanceWebSocket.SendAsync(string.Empty, new Dictionary<string, object> { { "requestId", "requestId123" } }, cancellationToken: cancellationTokenSource.Token),
                binanceWebSocket.SendAsync(string.Empty, new Dictionary<string, object> { { "requestId", 123 } }, cancellationToken: cancellationTokenSource.Token),
                binanceWebSocket.SendAsync(string.Empty, new Dictionary<string, object> { { "requestId", null } }, cancellationToken: cancellationTokenSource.Token),
                Task.Run(() => cancellationTokenSource.Cancel()));
        }
        #endregion
    }
}