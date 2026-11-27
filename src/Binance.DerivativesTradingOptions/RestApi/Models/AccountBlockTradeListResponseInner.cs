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

public sealed class AccountBlockTradeListResponseInner
{
    /// <summary>parent Order Id</summary>
    [JsonPropertyName("parentOrderId")]
    public string? ParentOrderId { get; set; }

    /// <summary>cross Type</summary>
    [JsonPropertyName("crossType")]
    public string? CrossType { get; set; }

    /// <summary>legs</summary>
    [JsonPropertyName("legs")]
    public List<AccountBlockTradeListResponseInnerLegsInner>? Legs { get; set; }

    /// <summary>block Trade Settlement Key</summary>
    [JsonPropertyName("blockTradeSettlementKey")]
    public string? BlockTradeSettlementKey { get; set; }
}
