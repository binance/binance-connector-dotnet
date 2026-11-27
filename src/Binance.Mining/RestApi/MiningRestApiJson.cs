//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Mining.RestApi;

/// <summary>The System.Text.Json context of the Mining RestApi models: <c>JsonSerializer.Serialize(value, MiningRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountListResponse), TypeInfoPropertyName = "AccountListResponse")]
[JsonSerializable(typeof(AcquiringAlgorithmResponse), TypeInfoPropertyName = "AcquiringAlgorithmResponse")]
[JsonSerializable(typeof(AcquiringCoinnameResponse), TypeInfoPropertyName = "AcquiringCoinnameResponse")]
[JsonSerializable(typeof(CancelHashrateResaleConfigurationResponse), TypeInfoPropertyName = "CancelHashrateResaleConfigurationResponse")]
[JsonSerializable(typeof(EarningsListResponse), TypeInfoPropertyName = "EarningsListResponse")]
[JsonSerializable(typeof(ExtraBonusListResponse), TypeInfoPropertyName = "ExtraBonusListResponse")]
[JsonSerializable(typeof(HashrateResaleDetailResponse), TypeInfoPropertyName = "HashrateResaleDetailResponse")]
[JsonSerializable(typeof(HashrateResaleListResponse), TypeInfoPropertyName = "HashrateResaleListResponse")]
[JsonSerializable(typeof(HashrateResaleRequestResponse), TypeInfoPropertyName = "HashrateResaleRequestResponse")]
[JsonSerializable(typeof(MiningAccountEarningResponse), TypeInfoPropertyName = "MiningAccountEarningResponse")]
[JsonSerializable(typeof(RequestForDetailMinerListResponse), TypeInfoPropertyName = "RequestForDetailMinerListResponse")]
[JsonSerializable(typeof(RequestForMinerListResponse), TypeInfoPropertyName = "RequestForMinerListResponse")]
[JsonSerializable(typeof(StatisticListResponse), TypeInfoPropertyName = "StatisticListResponse")]
public sealed partial class MiningRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Mining RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
