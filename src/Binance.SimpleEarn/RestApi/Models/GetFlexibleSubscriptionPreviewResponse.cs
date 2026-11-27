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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetFlexibleSubscriptionPreviewResponse
{
    [JsonPropertyName("totalAmount")]
    public string? TotalAmount { get; set; }

    [JsonPropertyName("rewardAsset")]
    public string? RewardAsset { get; set; }

    [JsonPropertyName("airDropAsset")]
    public string? AirDropAsset { get; set; }

    [JsonPropertyName("estDailyBonusRewards")]
    public string? EstDailyBonusRewards { get; set; }

    [JsonPropertyName("estDailyRealTimeRewards")]
    public string? EstDailyRealTimeRewards { get; set; }

    [JsonPropertyName("estDailyAirdropRewards")]
    public string? EstDailyAirdropRewards { get; set; }
}
