namespace Binance.Spot.Tests
{
    using System;
    using System.Threading;
    using Binance.Common;
    using Moq;
    using Xunit;

    public class UserDataWebSocket_Tests
    {
        #region ConnectAsync
        [Fact]
        public async void ConnectAsync_Url_Formation_Single_Listen_Key()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            var listenKey = "iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6";
            var websocket = new UserDataWebSocket(listenKey, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(mock => mock.ConnectAsync(It.Is<Uri>(uri => uri.AbsolutePath == "/ws/iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6"), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async void ConnectAsync_Url_Formation_Multiple_Listen_Keys()
        {
            var mockHandler = new Mock<IBinanceWebSocketHandler>();

            var listenKeys = new string[] { "iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6", "iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q7" };
            var websocket = new UserDataWebSocket(listenKeys, mockHandler.Object);
            await websocket.ConnectAsync(CancellationToken.None);

            mockHandler.Verify(mock => mock.ConnectAsync(It.Is<Uri>(uri => uri.AbsolutePath == "/stream" && uri.Query == "?streams=iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q6/iCi0Xma5WU1AjEUUWCVeqgMkelySNpjYs1HPrqKxJCJGeLkUTbD4K8Hl04q7"), It.IsAny<CancellationToken>()), Times.Once());
        }
        #endregion
    }
}