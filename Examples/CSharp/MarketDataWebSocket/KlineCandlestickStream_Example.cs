namespace Binance.Spot.MarketDataWebSocketExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class KlineCandlestickStream_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<KlineCandlestickStream_Example>();

            var websocket = new MarketDataWebSocket("btcusdt@kline_5m");

            var onlyOneMessage = new TaskCompletionSource<string>();

            websocket.OnMessageReceived(
                async (data) =>
            {
                onlyOneMessage.SetResult(data);
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            string message = await onlyOneMessage.Task;

            logger.LogInformation(message);

            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}