//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

/// <summary>The System.Text.Json context of the DerivativesTradingPortfolioMargin WebSocketStreams models: <c>JsonSerializer.Serialize(value, DerivativesTradingPortfolioMarginWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountConfigUpdate), TypeInfoPropertyName = "AccountConfigUpdate")]
[JsonSerializable(typeof(AccountUpdate), TypeInfoPropertyName = "AccountUpdate")]
[JsonSerializable(typeof(AlgoOrderUpdate), TypeInfoPropertyName = "AlgoOrderUpdate")]
[JsonSerializable(typeof(BalanceUpdate), TypeInfoPropertyName = "BalanceUpdate")]
[JsonSerializable(typeof(ConditionalOrderTradeUpdate), TypeInfoPropertyName = "ConditionalOrderTradeUpdate")]
[JsonSerializable(typeof(ExecutionReport), TypeInfoPropertyName = "ExecutionReport")]
[JsonSerializable(typeof(LiabilityChange), TypeInfoPropertyName = "LiabilityChange")]
[JsonSerializable(typeof(ListenKeyExpired), TypeInfoPropertyName = "ListenKeyExpired")]
[JsonSerializable(typeof(OpenOrderLoss), TypeInfoPropertyName = "OpenOrderLoss")]
[JsonSerializable(typeof(OrderTradeUpdate), TypeInfoPropertyName = "OrderTradeUpdate")]
[JsonSerializable(typeof(OutboundAccountPosition), TypeInfoPropertyName = "OutboundAccountPosition")]
[JsonSerializable(typeof(RiskLevelChange), TypeInfoPropertyName = "RiskLevelChange")]
[JsonSerializable(typeof(UserDataStreamEventsResponse), TypeInfoPropertyName = "UserDataStreamEventsResponse")]
public sealed partial class DerivativesTradingPortfolioMarginWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingPortfolioMargin WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
