//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.W3WPrediction.WebSocketStreams;

/// <summary>The System.Text.Json context of the W3WPrediction WebSocketStreams models: <c>JsonSerializer.Serialize(value, W3WPredictionWebSocketStreamsJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(BatchClaimPartiallySucceededResponse), TypeInfoPropertyName = "BatchClaimPartiallySucceededResponse")]
[JsonSerializable(typeof(FundTransferFailedResponse), TypeInfoPropertyName = "FundTransferFailedResponse")]
[JsonSerializable(typeof(FundTransferSucceededResponse), TypeInfoPropertyName = "FundTransferSucceededResponse")]
[JsonSerializable(typeof(LimitOrderFullyFilledResponse), TypeInfoPropertyName = "LimitOrderFullyFilledResponse")]
[JsonSerializable(typeof(LimitOrderPartiallyFilledResponse), TypeInfoPropertyName = "LimitOrderPartiallyFilledResponse")]
[JsonSerializable(typeof(LimitOrderSubmissionFailedResponse), TypeInfoPropertyName = "LimitOrderSubmissionFailedResponse")]
[JsonSerializable(typeof(LimitOrderSubmittedSuccessfullyResponse), TypeInfoPropertyName = "LimitOrderSubmittedSuccessfullyResponse")]
[JsonSerializable(typeof(MarketBuyOrderFailedResponse), TypeInfoPropertyName = "MarketBuyOrderFailedResponse")]
[JsonSerializable(typeof(MarketBuyOrderFullyFilledResponse), TypeInfoPropertyName = "MarketBuyOrderFullyFilledResponse")]
[JsonSerializable(typeof(MarketResolutionNotificationResponse), TypeInfoPropertyName = "MarketResolutionNotificationResponse")]
[JsonSerializable(typeof(MarketSellOrderFailedExpiredResponse), TypeInfoPropertyName = "MarketSellOrderFailedExpiredResponse")]
[JsonSerializable(typeof(MarketSellOrderFullyFilledResponse), TypeInfoPropertyName = "MarketSellOrderFullyFilledResponse")]
[JsonSerializable(typeof(PredictionOrderBookByMarketIdResponse), TypeInfoPropertyName = "PredictionOrderBookByMarketIdResponse")]
[JsonSerializable(typeof(RewardClaimFailedResponse), TypeInfoPropertyName = "RewardClaimFailedResponse")]
[JsonSerializable(typeof(RewardClaimSucceededResponse), TypeInfoPropertyName = "RewardClaimSucceededResponse")]
public sealed partial class W3WPredictionWebSocketStreamsJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the W3WPrediction WebSocketStreams (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
