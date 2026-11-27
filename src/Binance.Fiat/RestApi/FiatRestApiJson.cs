//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Fiat.RestApi;

/// <summary>The System.Text.Json context of the Fiat RestApi models: <c>JsonSerializer.Serialize(value, FiatRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(DepositResponse), TypeInfoPropertyName = "DepositResponse")]
[JsonSerializable(typeof(FiatWithdrawRequestAccountInfo), TypeInfoPropertyName = "FiatWithdrawRequestAccountInfo")]
[JsonSerializable(typeof(FiatWithdrawResponse), TypeInfoPropertyName = "FiatWithdrawResponse")]
[JsonSerializable(typeof(GetFiatDepositWithdrawHistoryResponse), TypeInfoPropertyName = "GetFiatDepositWithdrawHistoryResponse")]
[JsonSerializable(typeof(GetFiatPaymentsHistoryResponse), TypeInfoPropertyName = "GetFiatPaymentsHistoryResponse")]
[JsonSerializable(typeof(GetOrderDetailResponse), TypeInfoPropertyName = "GetOrderDetailResponse")]
public sealed partial class FiatRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Fiat RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
