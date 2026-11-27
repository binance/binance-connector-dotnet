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

namespace Binance.MarginTrading.RestApi;

public sealed class GetSmallLiabilityExchangeHistoryResponseRowsInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>amount.</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>target Asset.</summary>
    [JsonPropertyName("targetAsset")]
    public string? TargetAsset { get; set; }

    /// <summary>target Amount.</summary>
    [JsonPropertyName("targetAmount")]
    public string? TargetAmount { get; set; }

    /// <summary>biz Type.</summary>
    [JsonPropertyName("bizType")]
    public string? BizType { get; set; }

    /// <summary>timestamp.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
