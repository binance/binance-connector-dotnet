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

public sealed class WithdrawTravelRuleResponse
{
    /// <summary>The travel rule record Id</summary>
    [JsonPropertyName("trId")]
    public long? TrId { get; set; }

    /// <summary>Whether the withdraw request is accepted</summary>
    [JsonPropertyName("accepted")]
    public bool? Accepted { get; set; }

    /// <summary>The detailed infomation of the withdrawal result.</summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }
}
