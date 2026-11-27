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

namespace Binance.W3WPrediction.RestApi;

public sealed class ApplyMmWithdrawResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("walletId")]
    public string? WalletId { get; set; }

    [JsonPropertyName("walletAddress")]
    public string? WalletAddress { get; set; }

    [JsonPropertyName("transferId")]
    public string? TransferId { get; set; }
}
