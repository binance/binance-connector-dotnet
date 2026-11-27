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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

/// <summary>Order amendment details.</summary>
public sealed class GetOrderModifyHistoryResponseInnerAmendment
{
    [JsonPropertyName("price")]
    public GetOrderModifyHistoryResponseInnerAmendmentPrice? Price { get; set; }

    [JsonPropertyName("origQty")]
    public GetOrderModifyHistoryResponseInnerAmendmentOrigQty? OrigQty { get; set; }

    /// <summary>Total number of trades in the 24h window.</summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }

    /// <summary>user-defined modification identifier, only returned if provided in the request</summary>
    [JsonPropertyName("modifyId")]
    public long? ModifyId { get; set; }
}
