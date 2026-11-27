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

namespace Binance.MarginTrading.WebSocketStreams;

[JsonConverter(typeof(OneOfConverter<TradeDataStreamEventsResponse>))]
public sealed class TradeDataStreamEventsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => MarginTradingWebSocketStreamsJson.Default;

    private static readonly Type[] AlternativeList = [typeof(MarginLevelStatusChange), typeof(UserLiabilityChange), typeof(BalanceUpdate), typeof(ExecutionReport), typeof(ListStatus), typeof(ListenKeyExpired), typeof(OutboundAccountPosition)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag e selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("e", out var tag)
        ? tag.GetString() switch
        {
            "MARGIN_LEVEL_STATUS_CHANGE" => As<MarginLevelStatusChange>(),
            "USER_LIABILITY_CHANGE" => As<UserLiabilityChange>(),
            "balanceUpdate" => As<BalanceUpdate>(),
            "executionReport" => As<ExecutionReport>(),
            "listStatus" => As<ListStatus>(),
            "listenKeyExpired" => As<ListenKeyExpired>(),
            "outboundAccountPosition" => As<OutboundAccountPosition>(),
            _ => null,
        }
        : null;
}
