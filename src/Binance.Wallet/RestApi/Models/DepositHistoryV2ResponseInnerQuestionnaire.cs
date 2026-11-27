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

public sealed class DepositHistoryV2ResponseInnerQuestionnaire
{
    [JsonPropertyName("vaspName")]
    public string? VaspName { get; set; }

    [JsonPropertyName("depositOriginator")]
    public long? DepositOriginator { get; set; }
}
