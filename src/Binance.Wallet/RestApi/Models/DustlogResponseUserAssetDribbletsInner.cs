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

public sealed class DustlogResponseUserAssetDribbletsInner
{
    [JsonPropertyName("operateTime")]
    public long? OperateTime { get; set; }

    /// <summary>Total transfered BNB amount for this exchange.</summary>
    [JsonPropertyName("totalTransferedAmount")]
    public string? TotalTransferedAmount { get; set; }

    /// <summary>Total service charge amount for this exchange.</summary>
    [JsonPropertyName("totalServiceChargeAmount")]
    public string? TotalServiceChargeAmount { get; set; }

    [JsonPropertyName("transId")]
    public long? TransId { get; set; }

    [JsonPropertyName("userAssetDribbletDetails")]
    public List<DustlogResponseUserAssetDribbletsInnerUserAssetDribbletDetailsInner>? UserAssetDribbletDetails { get; set; }
}
