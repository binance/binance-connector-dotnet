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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class ExtendBlockTradeOrderResponse
{
    /// <summary>block Trade Settlement Key</summary>
    [JsonPropertyName("blockTradeSettlementKey")]
    public string? BlockTradeSettlementKey { get; set; }

    /// <summary>expire Time</summary>
    [JsonPropertyName("expireTime")]
    public long? ExpireTime { get; set; }

    /// <summary>liquidity</summary>
    [JsonPropertyName("liquidity")]
    public string? Liquidity { get; set; }

    /// <summary>status</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>create Time</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>legs</summary>
    [JsonPropertyName("legs")]
    public List<ExtendBlockTradeOrderResponseLegsInner>? Legs { get; set; }
}
