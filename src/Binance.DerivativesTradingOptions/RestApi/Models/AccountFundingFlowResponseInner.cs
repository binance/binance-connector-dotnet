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

public sealed class AccountFundingFlowResponseInner
{
    /// <summary>id</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>Asset type</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Amount (positive numbers represent inflow, negative numbers represent outflow)</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Option symbol the record relates to. Returned only for contract-related types (e.g. CONTRACT, FEE,
    /// EXERCISE_PNL, EXERCISE_FEE); omitted for other types such as TRANSFER. Older records may not include
    /// this field.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>type (fees)</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("createDate")]
    public long? CreateDate { get; set; }
}
