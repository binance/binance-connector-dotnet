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

public sealed class SubscribeLockedProductResponse
{
    [JsonPropertyName("purchaseId")]
    public long? PurchaseId { get; set; }

    [JsonPropertyName("positionId")]
    public string? PositionId { get; set; }

    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}
