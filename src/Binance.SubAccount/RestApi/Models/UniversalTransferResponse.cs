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

namespace Binance.SubAccount.RestApi;

public sealed class UniversalTransferResponse
{
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    [JsonPropertyName("clientTranId")]
    public string? ClientTranId { get; set; }
}
