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

namespace Binance.Spot.WebSocketStreams;

[JsonConverter(typeof(OneOfConverter<UserDataStreamEventsResponse>))]
public sealed class UserDataStreamEventsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => SpotWebSocketStreamsJson.Default;

    private static readonly Type[] AlternativeList = [typeof(BalanceUpdate), typeof(EventStreamTerminated), typeof(ExecutionReport), typeof(ExternalLockUpdate), typeof(ListStatus), typeof(OutboundAccountPosition)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag e selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("e", out var tag)
        ? tag.GetString() switch
        {
            "balanceUpdate" => As<BalanceUpdate>(),
            "eventStreamTerminated" => As<EventStreamTerminated>(),
            "executionReport" => As<ExecutionReport>(),
            "externalLockUpdate" => As<ExternalLockUpdate>(),
            "listStatus" => As<ListStatus>(),
            "outboundAccountPosition" => As<OutboundAccountPosition>(),
            _ => null,
        }
        : null;
}
