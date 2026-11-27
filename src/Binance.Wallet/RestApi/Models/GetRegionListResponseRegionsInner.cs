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

namespace Binance.Wallet.RestApi;

public sealed class GetRegionListResponseRegionsInner
{
    /// <summary>Region/city display name (use this value in questionnaire answers).</summary>
    [JsonPropertyName("regionName")]
    public string? RegionName { get; set; }

    /// <summary>supported, limited, or blocked.</summary>
    [JsonPropertyName("blockType")]
    public string? BlockType { get; set; }

    /// <summary>Whether deposit is allowed for this region.</summary>
    [JsonPropertyName("depositAllowed")]
    public bool? DepositAllowed { get; set; }

    /// <summary>Whether withdrawal is allowed for this region.</summary>
    [JsonPropertyName("withdrawalAllowed")]
    public bool? WithdrawalAllowed { get; set; }
}
