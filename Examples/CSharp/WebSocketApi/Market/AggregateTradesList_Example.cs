namespace Binance.Spot.WebSocketApiExamples
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Spot;

    public class AggregateTradesList_Example
    {
        public static async Task Main(string[] args)
        {
            // Create WebSocket API
            var websocket = new WebSocketApi();

            // Receive WebSocket API Response
            websocket.OnMessageReceived(
                async (data) =>
            {
                Console.WriteLine(data);
                await Task.CompletedTask;
            }, CancellationToken.None);

            await websocket.ConnectAsync(CancellationToken.None);

            await websocket.Market.AggregateTradesListAsync(symbol: "BNBUSDT", limit: 10, cancellationToken: CancellationToken.None);

            // wait for 5s before disconnected
            await Task.Delay(5000);
            Console.WriteLine("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync(CancellationToken.None);
        }
    }
}