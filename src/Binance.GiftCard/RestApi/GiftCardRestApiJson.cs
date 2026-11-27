//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.GiftCard.RestApi;

/// <summary>The System.Text.Json context of the GiftCard RestApi models: <c>JsonSerializer.Serialize(value, GiftCardRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(CreateADualTokenGiftCardResponse), TypeInfoPropertyName = "CreateADualTokenGiftCardResponse")]
[JsonSerializable(typeof(CreateASingleTokenGiftCardResponse), TypeInfoPropertyName = "CreateASingleTokenGiftCardResponse")]
[JsonSerializable(typeof(FetchRsaPublicKeyResponse), TypeInfoPropertyName = "FetchRsaPublicKeyResponse")]
[JsonSerializable(typeof(FetchTokenLimitResponse), TypeInfoPropertyName = "FetchTokenLimitResponse")]
[JsonSerializable(typeof(RedeemABinanceGiftCardResponse), TypeInfoPropertyName = "RedeemABinanceGiftCardResponse")]
[JsonSerializable(typeof(VerifyBinanceGiftCardByGiftCardNumberResponse), TypeInfoPropertyName = "VerifyBinanceGiftCardByGiftCardNumberResponse")]
public sealed partial class GiftCardRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the GiftCard RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
