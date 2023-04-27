namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class CancelAndReplaceOrder_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<CancelAndReplaceOrder_Example>();

            string apiSecret = "apiSecret";
            var websocket = new WebSocketApi("wss://testnet.binance.vision/ws-api/v3", "apiKey", new BinanceHmac(apiSecret));

            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.AccountTrade.CancelAndReplaceOrderAsync("BNBUSDT", Side.SELL, OrderType.LIMIT, "STOP_ON_FAILURE", cancelOrderId: 12, timeInForce: TimeInForce.GTC, quantity: 10.1m, price: 295.92m);
            await Task.Delay(3000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}