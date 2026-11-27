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

public sealed class DustTransferResponse
{
    [JsonPropertyName("totalServiceCharge")]
    public string? TotalServiceCharge { get; set; }

    [JsonPropertyName("totalTransfered")]
    public string? TotalTransfered { get; set; }

    [JsonPropertyName("transferResult")]
    public List<DustTransferResponseTransferResultInner>? TransferResult { get; set; }
}
