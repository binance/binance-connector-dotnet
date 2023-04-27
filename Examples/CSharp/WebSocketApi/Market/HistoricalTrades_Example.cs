namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class HistoricalTrades_Example
    {
        public static async Task Main(string[] args)
        {
            // Create logger
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<HistoricalTrades_Example>();

            // Create WebSocket API
            var websocket = new WebSocketApi(apiKey: "apiKey");

            // Receive WebSocket API Response
            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.Market.HistoricalTradesAsync(symbol: "BNBUSDT", limit: 10, fromId: 1, requestId: 123, cancellationToken: CancellationToken.None);

            // wait for 5s before disconnected
            await Task.Delay(5000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}