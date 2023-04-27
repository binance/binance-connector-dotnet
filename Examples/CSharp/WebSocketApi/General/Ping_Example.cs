namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class Ping_Example
    {
        public static async Task Main(string[] args)
        {
            // Create logger
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Ping_Example>();

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

            await websocket.General.PingAsync();
            await Task.Delay(1000);
            await websocket.General.PingAsync(requestId: 123, CancellationToken.None);
            await Task.Delay(1000);
            await websocket.General.PingAsync(requestId: null, CancellationToken.None);
            await Task.Delay(1000);
            await websocket.General.PingAsync(requestId: string.Empty, CancellationToken.None);
            await Task.Delay(1000);
            await websocket.General.PingAsync(requestId: "request123", CancellationToken.None);

            // wait for 5s before disconnected
            await Task.Delay(2000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}