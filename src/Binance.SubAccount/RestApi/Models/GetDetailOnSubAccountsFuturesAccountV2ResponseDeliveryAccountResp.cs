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

namespace Binance.SubAccount.RestApi;

public sealed class GetDetailOnSubAccountsFuturesAccountV2ResponseDeliveryAccountResp
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("assets")]
    public List<GetDetailOnSubAccountsFuturesAccountV2ResponseDeliveryAccountRespAssetsInner>? Assets { get; set; }

    [JsonPropertyName("canDeposit")]
    public bool? CanDeposit { get; set; }

    [JsonPropertyName("canTrade")]
    public bool? CanTrade { get; set; }

    [JsonPropertyName("canWithdraw")]
    public bool? CanWithdraw { get; set; }

    [JsonPropertyName("feeTier")]
    public long? FeeTier { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
