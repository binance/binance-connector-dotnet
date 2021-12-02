namespace Binance.Spot.Tests
{
    using System;
    using System.Threading;
    using Binance.Common;
    using Moq;
    using Xunit;

    public class MarketDataWebSocket_Tests
    {
        #region ConnectAsync
        [Fact]
        public async void ConnectAsync_Url_Formation_Single_Stream_Key()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            var listenKey = "BTCUSDT@trade";
            var websocket = new MarketDataWebSocket(listenKey, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(mock => mock.ConnectAsync(It.Is<Uri>(uri => uri.AbsolutePath == "/ws/BTCUSDT@trade"), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async void ConnectAsync_Url_Formation_Multiple_Stream_Keys()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            var listenKeys = new string[] { "BTCUSDT@trade", "BNBUSDT@kline_1m" };
            var websocket = new MarketDataWebSocket(listenKeys, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(mock => mock.ConnectAsync(It.Is<Uri>(uri => uri.AbsolutePath == "/stream" && uri.Query == "?streams=BTCUSDT@trade/BNBUSDT@kline_1m"), It.IsAny<CancellationToken>()), Times.Once());
        }
        #endregion
    }
}