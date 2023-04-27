namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class ExchangeInfo_Example
    {
        public static async Task Main(string[] args)
        {
            // Create logger
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<ExchangeInfo_Example>();

            // Create WebSocket API
            var websocket = new WebSocketApi();

            // Receive WebSocket API Response
            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.General.ExchangeInfoAsync();
            Task.Delay(1000).Wait();
            await websocket.General.ExchangeInfoAsync(symbol: "BNBBTC", cancellationToken: CancellationToken.None);
            Task.Delay(1000).Wait();
            string[] symbols = { "BNBBTC", "BTCUSDT" };
            await websocket.General.ExchangeInfoAsync(symbols: symbols, requestId: 123);
            Task.Delay(1000).Wait();
            string[] permissions = { "LEVERAGED" };
            await websocket.General.ExchangeInfoAsync(permissions: permissions, requestId: 123);

            // Wait for 5s before disconnected
            await Task.Delay(5000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}