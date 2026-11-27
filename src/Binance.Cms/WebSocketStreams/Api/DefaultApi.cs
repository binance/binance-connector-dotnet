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

namespace Binance.Cms.WebSocketStreams;

public sealed partial class CmsWebSocketStreamsConnection
{

    /// <summary>
    /// Receive push notifications hen Binance publishes announcements in English (language code: en).
    /// </summary>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<ComAnnouncementEnResponse> ComAnnouncementEn()
    {
        return _client.Subscribe(StreamName.Build("/com_announcement_en"), CmsWebSocketStreamsJson.Default.ComAnnouncementEnResponse, null);
    }
}
