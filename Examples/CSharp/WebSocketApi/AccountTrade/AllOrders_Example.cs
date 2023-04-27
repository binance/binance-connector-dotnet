namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class AllOrders_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<AllOrders_Example>();

            string apiSecret = "apiSecret";
            var websocket = new WebSocketApi("wss://testnet.binance.vision/ws-api/v3", "apiKey", new BinanceHmac(apiSecret));

            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.AccountTrade.AllOrdersAsync("BNBUSDT", 1);
            await websocket.AccountTrade.AllOrdersAsync(symbol: "BNBUSDT", startTime: 0, recvWindow: 6000, requestId: 123);

            await Task.Delay(3000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}