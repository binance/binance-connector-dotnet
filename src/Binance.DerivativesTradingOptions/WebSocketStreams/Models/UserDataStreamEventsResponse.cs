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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

[JsonConverter(typeof(OneOfConverter<UserDataStreamEventsResponse>))]
public sealed class UserDataStreamEventsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingOptionsWebSocketStreamsJson.Default;

    private static readonly Type[] AlternativeList = [typeof(AccountUpdate), typeof(BalancePositionUpdate), typeof(GreekUpdate), typeof(ListenKeyExpired), typeof(OrderTradeUpdate), typeof(RiskLevelChange)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag e selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("e", out var tag)
        ? tag.GetString() switch
        {
            "ACCOUNT_UPDATE" => As<AccountUpdate>(),
            "BALANCE_POSITION_UPDATE" => As<BalancePositionUpdate>(),
            "GREEK_UPDATE" => As<GreekUpdate>(),
            "ORDER_TRADE_UPDATE" => As<OrderTradeUpdate>(),
            "RISK_LEVEL_CHANGE" => As<RiskLevelChange>(),
            "listenKeyExpired" => As<ListenKeyExpired>(),
            _ => null,
        }
        : null;
}
