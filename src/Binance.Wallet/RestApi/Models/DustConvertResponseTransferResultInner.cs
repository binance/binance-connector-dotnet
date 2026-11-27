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

public sealed class DustConvertResponseTransferResultInner
{
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    [JsonPropertyName("fromAsset")]
    public string? FromAsset { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("transferedAmount")]
    public string? TransferedAmount { get; set; }

    [JsonPropertyName("serviceChargeAmount")]
    public string? ServiceChargeAmount { get; set; }

    [JsonPropertyName("operateTime")]
    public long? OperateTime { get; set; }
}
