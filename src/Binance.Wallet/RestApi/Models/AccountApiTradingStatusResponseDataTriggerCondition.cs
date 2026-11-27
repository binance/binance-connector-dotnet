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

public sealed class AccountApiTradingStatusResponseDataTriggerCondition
{
    /// <summary>Number of GTC orders</summary>
    [JsonPropertyName("GCR")]
    public long? GCR { get; set; }

    /// <summary>Number of FOK/IOC orders</summary>
    [JsonPropertyName("IFER")]
    public long? IFER { get; set; }

    /// <summary>Number of orders</summary>
    [JsonPropertyName("UFR")]
    public long? UFR { get; set; }
}
