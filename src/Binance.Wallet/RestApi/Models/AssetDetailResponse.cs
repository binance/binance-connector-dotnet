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

public sealed class AssetDetailResponse
{
    [JsonPropertyName("CTR")]
    public AssetDetailResponseCTR? CTR { get; set; }

    [JsonPropertyName("SKY")]
    public AssetDetailResponseSKY? SKY { get; set; }
}
