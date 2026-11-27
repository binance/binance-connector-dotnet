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

namespace Binance.StockOptions.WebSocketStreams;

public sealed class OrderReportV2StreamRequest
{
    /// <summary>User data listen key obtained from the Listen Key endpoint.</summary>
    public required string ListenKey { get; init; }

    /// <summary>Unique WebSocket request ID.</summary>
    public string? Id { get; init; }
}

public sealed partial class StockOptionsWebSocketStreamsConnection
{

    /// <summary>Order Report V2 Stream</summary>
    /// <remarks>
    /// <para>
    /// Real-time push of the user's order updates. Option orders are pushed on orderReportV2, not on
    /// orderReport.
    /// </para>
    /// <para>
    /// orderReportV2 carries both US stock and US stock option orders; tell them apart with the ac field.
    /// To process option orders only, subscribe to orderReportV2 and handle events where ac = us_option.
    /// </para>
    /// <para>
    /// A push is sent once when an open order changes (x = ORDER_UPDATE) and once when it reaches a
    /// terminal state (x = ORDER_TERMINAL). Pushes are best-effort: a failed push is not retried, events
    /// while the listenKey is invalid are not replayed, and an order never pushed in an open state (e.g.
    /// rejected immediately) may not get a terminal push. After reconnecting, call Current Open Option
    /// Orders for a full snapshot first. Fill-level details are not pushed; use Option Order Detail or
    /// Option Trade History.
    /// </para>
    /// <para>
    /// For expiration-day auto-liquidation orders by the broker (o = market), p, b, q, tc, u, ct, sp and ed
    /// may be null; get contract details from Option Exchange Info by os.
    /// </para>
    /// <para>Prerequisite: obtain a listenKey via the Listen Key endpoint first.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<OrderReportV2StreamResponse> OrderReportV2Stream(OrderReportV2StreamRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/<listenKey>@orderReportV2", ("listenKey", request.ListenKey), ("id", request.Id)), StockOptionsWebSocketStreamsJson.Default.OrderReportV2StreamResponse, null, id: request.Id);
    }
}
