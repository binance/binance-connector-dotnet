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

    public class SymbolBookTickerStream_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<SymbolBookTickerStream_Example>();

            string[] streams = { "btcusdt@bookTicker", "bnbusdt@bookTicker" };
            var websocket = new MarketDataWebSocket(streams);

            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            // wait for 5s before disconnnected
            await Task.Delay(5000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}