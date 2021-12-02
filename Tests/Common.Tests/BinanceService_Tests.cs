namespace Binance.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class BinanceService_Tests
    {
        #region SendPublicAsync
        [Fact]
        public async void SendPublicAsync_HttpMethod_Post()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Post), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Post);
        }

        [Fact]
        public async void SendPublicAsync_HttpMethod_Put()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Put), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Put);
        }

        [Fact]
        public async void SendPublicAsync_HttpMethod_Delete()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Delete), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Delete);
        }

        [Fact]
        public async void SendPublicAsync_HttpMethod_Get()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Get), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Get);
        }

        [Fact]
        public async void SendPublicAsync_QueryParameter_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("hello=world")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(
                string.Empty,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "hello", "world" },
                });
        }

        [Fact]
        public async void SendPublicAsync_Empty_QueryParameter_Not_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => !rm.RequestUri.Query.Contains("hello=")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            await binanceService.SendPublicAsync<string>(
                string.Empty,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "hello", null },
                });
        }

        [Fact]
        public async void SendPublicAsync_Server_Formatted_Unauthorized_Error_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("{\"code\":1234,\"msg\":\"Message\"}"),
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com");

            var exception = await Assert.ThrowsAsync<BinanceClientException>(async () =>
            {
                await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Get);
            });

            Assert.Equal(1234, exception.Code);
            Assert.Equal("Message", exception.Message);
        }

        [Fact]
        public async void SendPublicAsync_Request_And_Response_Are_Logged()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var mockLogger = new Mock<ILogger>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });

            var binanceService = new MockBinanceService(new HttpClient(new BinanceLoggingHandler(mockLogger.Object, mockMessageHandler.Object)), baseUrl: "https://www.binance.com", apiKey: string.Empty, apiSecret: "apiSecret");

            await binanceService.SendPublicAsync<string>(string.Empty, HttpMethod.Get);

            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.AtLeast(2));
        }
        #endregion

        #region SendSignedAsync
        [Fact]
        public async void SendSignedAsync_HttpMethod_Post()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Post), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Post);
        }

        [Fact]
        public async void SendSignedAsync_HttpMethod_Put()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Put), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Put);
        }

        [Fact]
        public async void SendSignedAsync_HttpMethod_Delete()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Delete), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Delete);
        }

        [Fact]
        public async void SendSignedAsync_HttpMethod_Get()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.Method == HttpMethod.Get), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
        }

        [Fact]
        public async void SendSignedAsync_QueryParameter_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("hello=world")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "hello", "world" },
                });
        }

        [Fact]
        public async void SendSignedAsync_Empty_QueryParameter_Not_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => !rm.RequestUri.Query.Contains("hello=")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "hello", null },
                });
        }

        [Fact]
        public async void SendSignedAsync_Signature_In_Query_String_Is_Valid()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("signature=c8db56825ae71d6d79447849e617115f4a920fa2acdcab2b053c4b2838bd6b71")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A", apiSecret: "NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "symbol", "LTCBTC" },
                    { "side", "BUY" },
                    { "type", "LIMIT" },
                    { "timeInForce", "GTC" },
                    { "quantity", 1 },
                    { "price", 0.1 },
                    { "recvWindow", 5000 },
                    { "timestamp", 1499827319559 },
                });
        }

        [Fact]
        public async void SendSignedAsync_Timestamp_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("timestamp=1499827319559")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "timestamp", 1499827319559 },
                });
        }

        [Fact]
        public async void SendSignedAsync_RecvWindow_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.Query.Contains("recvWindow=1000")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(
                string.Empty,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", 1000 },
                });
        }

        [Fact]
        public async void SendSignedAsync_RecvWindow_Default_Not_In_Query_String()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => !rm.RequestUri.Query.Contains("recvWindow=")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: "apiKey", apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
        }

        [Fact]
        public async void SendSignedAsync_Server_Unformatted_Internal_Error_Throws_BinanceServerException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("hello"),
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: null, apiSecret: "apiSecret");

            var exception = await Assert.ThrowsAsync<BinanceServerException>(async () =>
            {
                await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
            });

            Assert.Equal("hello", exception.Message);
        }

        [Fact]
        public async void SendSignedAsync_Server_Formatted_Internal_Error_Throws_BinanceServerException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("{\"code\":1234,\"msg\":\"Message\"}"),
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: null, apiSecret: "apiSecret");

            var exception = await Assert.ThrowsAsync<BinanceServerException>(async () =>
            {
                await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
            });

            Assert.Equal("{\"code\":1234,\"msg\":\"Message\"}", exception.Message);
        }

        [Fact]
        public async void SendSignedAsync_Server_Unformatted_Unauthorized_Error_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("hello"),
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: null, apiSecret: "apiSecret");

            var exception = await Assert.ThrowsAsync<BinanceClientException>(async () =>
            {
                await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
            });

            Assert.Equal(-1, exception.Code);
            Assert.Equal("hello", exception.Message);
        }

        [Fact]
        public async void SendSignedAsync_Server_Formatted_Unauthorized_Error_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("{\"code\":1234,\"msg\":\"Message\"}"),
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: null, apiSecret: "apiSecret");

            var exception = await Assert.ThrowsAsync<BinanceClientException>(async () =>
            {
                await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
            });

            Assert.Equal(1234, exception.Code);
            Assert.Equal("Message", exception.Message);
        }

        [Fact]
        public async void SendSignedAsync_Missing_ApiKey_Throws_BinanceClientException()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(rm => !rm.Headers.Contains("X-MBX-APIKEY")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("{\"code\":-2014,\"msg\":\"API-key format invalid.\"}"),
                });
            var binanceService = new MockBinanceService(new HttpClient(mockMessageHandler.Object), baseUrl: "https://www.binance.com", apiKey: null, apiSecret: "apiSecret");

            var exception = await Assert.ThrowsAsync<BinanceClientException>(async () =>
            {
                await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);
            });
        }

        [Fact]
        public async void SendSignedAsync_Request_And_Response_Are_Logged()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var mockLogger = new Mock<ILogger>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });

            var binanceService = new MockBinanceService(new HttpClient(new BinanceLoggingHandler(mockLogger.Object, mockMessageHandler.Object)), baseUrl: "https://www.binance.com", apiKey: string.Empty, apiSecret: "apiSecret");

            await binanceService.SendSignedAsync<string>(string.Empty, HttpMethod.Get);

            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.AtLeast(2));
        }
        #endregion
    }
}