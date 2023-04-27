namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class CurrentOpenOcoOrders_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<CurrentOpenOcoOrders_Example>();

            string apiSecret = "apiSecret";
            var websocket = new WebSocketApi("wss://testnet.binance.vision/ws-api/v3", "apiKey", new BinanceHmac(apiSecret));

            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.AccountTrade.CurrentOpenOcoOrdersAsync();

            await Task.Delay(3000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}