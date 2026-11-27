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

namespace Binance.Staking.RestApi;

public sealed class GetBoostRewardsHistoryResponseRowsInner
{
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Display if the type is "DISTRIBUTE"</summary>
    [JsonPropertyName("bnsolHolding")]
    public string? BnsolHolding { get; set; }

    /// <summary>Display if the type is "CLAIM"</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
