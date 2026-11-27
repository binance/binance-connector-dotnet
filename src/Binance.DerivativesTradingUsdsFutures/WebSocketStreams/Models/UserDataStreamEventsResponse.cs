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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

[JsonConverter(typeof(OneOfConverter<UserDataStreamEventsResponse>))]
public sealed class UserDataStreamEventsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingUsdsFuturesWebSocketStreamsJson.Default;

    private static readonly Type[] AlternativeList = [typeof(AccountConfigUpdate), typeof(AccountUpdate), typeof(AlgoUpdate), typeof(ConditionalOrderTriggerReject), typeof(GridUpdate), typeof(ListenKeyExpired), typeof(MarginCall), typeof(OrderTradeUpdate), typeof(StrategyUpdate), typeof(TradeLite)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag e selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("e", out var tag)
        ? tag.GetString() switch
        {
            "ACCOUNT_CONFIG_UPDATE" => As<AccountConfigUpdate>(),
            "ACCOUNT_UPDATE" => As<AccountUpdate>(),
            "ALGO_UPDATE" => As<AlgoUpdate>(),
            "CONDITIONAL_ORDER_TRIGGER_REJECT" => As<ConditionalOrderTriggerReject>(),
            "GRID_UPDATE" => As<GridUpdate>(),
            "MARGIN_CALL" => As<MarginCall>(),
            "ORDER_TRADE_UPDATE" => As<OrderTradeUpdate>(),
            "STRATEGY_UPDATE" => As<StrategyUpdate>(),
            "TRADE_LITE" => As<TradeLite>(),
            "listenKeyExpired" => As<ListenKeyExpired>(),
            _ => null,
        }
        : null;
}
