//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.Stocks.WebSocketStreams;

public sealed class OrderReportStreamRequest
{
    /// <summary>User data listen key obtained from the Listen Key endpoint.</summary>
    public required string ListenKey { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed partial class StocksWebSocketStreamsConnection
{

    /// <summary>Order Report Stream</summary>
    /// <remarks>
    /// Real-time push of the authenticated user's order state transitions — both open-state updates
    /// (ORDER_UPDATE) and terminal-state notifications (ORDER_TERMINAL). Prerequisite: obtain a listenKey
    /// via the Listen Key endpoint first.
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<OrderReportStreamResponse> OrderReportStream(OrderReportStreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("<listenKey>@orderReport", ("listenKey", request.ListenKey), ("id", request.Id)), StocksWebSocketStreamsJson.Default.OrderReportStreamResponse, null, id: request.Id);
    }
}
