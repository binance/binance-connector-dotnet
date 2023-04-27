namespace Binance.Spot.WebSocketApiExamples
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class AccountInfo_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<AccountInfo_Example>();

            string privateKey = File.ReadAllText("/Users/john/ssl/Private_key.pem");
            var websocket = new WebSocketApi(baseUrl: "wss://testnet.binance.vision/ws-api/v3", apiKey: "apiKey", signatureService: new BinanceRsa(privateKey));

            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.AccountTrade.AccountInfoAsync();
            await websocket.AccountTrade.AccountInfoAsync(recvWindow: 6000, requestId: 123);
            await websocket.AccountTrade.AccountInfoAsync(recvWindow: 6000, cancellationToken: CancellationToken.None);

            await Task.Delay(3000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}